using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Dynamic data template selector using <see cref="ITemplateLoader"/> and <see cref="ITemplateInvoker"/>
    /// </summary>
    internal class UIDataTemplateSelector : DataTemplateSelector
    {
        private IList<ITemplateLoader> loaders;
        private IList<ITemplateInvoker> invokers;
        private ITemplateLoader loader;

        /// <summary>
        /// initialize new DataTemplate-Selector
        /// </summary>
        /// <param name="loaders">List of available loader</param>
        /// <param name="invokers">List of available invoker</param>
        public UIDataTemplateSelector(IList<ITemplateLoader> loaders, IList<ITemplateInvoker> invokers)
        {
            this.invokers = invokers;
            this.loaders = loaders;
        }
        
        /// <summary>
        /// Search for the content presenter container that belongs to a <see cref="ContentPresenter"/>
        /// </summary>
        /// <param name="child">Child to start searching from</param>
        /// <returns>Presenter if found</returns>
        private UIContentPresenter SearchCustomContentPresenter(DependencyObject child)
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) { return null; }

            //check if the parent matches the type we're looking for
            UIContentPresenter parent = parentObject as UIContentPresenter;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return SearchCustomContentPresenter(parentObject);
            }
        }

        /// <summary>
        /// Select a datatemplate
        /// </summary>
        /// <param name="item">Viewmodel instance</param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
           var presenter = SearchCustomContentPresenter(container);

            if (presenter != null)
            {
                // Contains all possible UITemplates
                UITemplate template = null;

                if (presenter.Templates == null)
                    throw new Exception($"Templates list can not be null. UIContentPresenter: {presenter.Name ?? "<No name set>"}");

                // Copy template list
                var templates = presenter.Templates.OfType<UITemplate>().ToList();

                // Add dynamic templates
                if (UITemplateManager.DynamicResolverFactory != null)
                {
                    var resolver = UITemplateManager.DynamicResolverFactory.Create();

                    // Add all dynamically resolved templates
                    templates.AddRange(resolver.ResolveDynamicTemplates(presenter.GetType().Namespace, presenter.DataTemplateName));
                }

                // Find all templates that are selectable
                if (presenter.Templates != null)
                {
                    foreach (var _template in presenter.Templates.OfType<UITemplate>())
                    {
                        // Select a template if it has no selector and there is no template set yet
                        // or select a template if there is already a selected template but that has not selector
                        if ((_template.Selector == null && template == null) || (template != null && template.Selector == null))
                            template = _template;
                        else if (_template.Selector != null && _template.Selector.SelectTemplate(_template, presenter.DataContext))
                            template = _template;
                    }
                }

                if (presenter.IsSelectedTemplateRequired && template == null)
                {
                    throw new Exception($"A template is required for the given UIContentPresenter, but there is no selectable uitemplate {presenter.Name ?? "<No name set>"}");
                }

                if (template != null)
                {
                    foreach (var loader in loaders)
                    {
                        var code = loader.GetTemplate(template.TemplatePath);
                        if (!string.IsNullOrWhiteSpace(code))
                        {
                            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(code)))
                            {
                                ResourceDictionary resourceDict = (ResourceDictionary)System.Windows.Markup.XamlReader.Load(stream);

                                if (resourceDict != null)
                                {
                                    if (resourceDict.Contains(presenter.DataTemplateName))
                                    {
                                        this.loader = loader;
                                        presenter.SelectedTemplate = template;
                                        return (DataTemplate)resourceDict[presenter.DataTemplateName];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return new DataTemplate();
        }

        /// <summary>
        /// Gets the active template loader
        /// </summary>
        public ITemplateLoader Loader
        {
            get
            {
                return loader;
            }
        }
    }
}