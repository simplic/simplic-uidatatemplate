using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Custom content presenter, which implements <see cref="UIDataTemplateSelector"/>
    /// </summary>
    public class UIContentPresenter : ContentControl, IDisposable
    {
        #region DependencyProperties
        /// <summary>
        /// Contains a list of available templates
        /// </summary>
        public static readonly DependencyProperty TemplatesProperty =
            DependencyProperty.Register("TemplatesProperty", typeof(IList), typeof(UIContentPresenter), new PropertyMetadata(new List<UITemplate>()));

        /// <summary>
        /// Contains whether a selected template is required or not
        /// </summary>
        public static readonly DependencyProperty IsSelectedTemplateRequiredProperty =
            DependencyProperty.Register("IsSelectedTemplateRequired", typeof(bool), typeof(UIContentPresenter), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for SelectedTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTemplateProperty =
            DependencyProperty.Register("SelectedTemplate", typeof(UITemplate), typeof(UIContentPresenter), new PropertyMetadata(null));
        
        /// <summary>
        /// DataTemplate name (in the template)
        /// </summary>
        public static readonly DependencyProperty DataTemplateNameProperty =
            DependencyProperty.Register("DataTemplateName", typeof(string), typeof(UIContentPresenter), new PropertyMetadata(""));

        /// <summary>
        /// Contains whether the control is in edit mode or not
        /// </summary>
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(UIContentPresenter), new PropertyMetadata(false, IsInEditorChanged));
        #endregion

        #region Static Event Handler
        /// <summary>
        /// Is in edit mode changed event
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void IsInEditorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uicp = d as UIContentPresenter;

            if (uicp != null)
            {
                if ((bool)e.NewValue == true)
                    uicp.editButton.Visibility = Visibility.Visible;
                else
                    uicp.editButton.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region Fields
        private NotifiableContentPresenter presenter;
        private Button editButton;
        private IList<ITemplateLoader> loaders;
        private IList<ITemplateInvoker> invokers;
        private UIDataTemplateSelector selector;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialize content presenter
        /// </summary>
        public UIContentPresenter()
        {
            loaders = UITemplateManager.LoaderFactories.Select(item => item.Create()).ToList();
            invokers = UITemplateManager.InvokerFactories.Select(item => item.Create()).ToList();

            selector = new UIDataTemplateSelector(loaders, invokers);

            // Assign data template selector
            presenter = new NotifiableContentPresenter()
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                ContentTemplateSelector = selector
            };

            presenter.ContentChanged += PresenterContentChanged;

            // Create grid container and edit button
            var grid = new Grid();
            editButton = new Button()
            {
                Width = 26,
                Height = 26,
                Margin = new Thickness(5),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                Padding = new Thickness(0),
                Visibility = Visibility.Collapsed,
                Background = new SolidColorBrush(Colors.Transparent),
                BorderBrush = new SolidColorBrush(Colors.Transparent),
                ToolTip = Properties.Resource.EditButtonToolTip
            };

            // Edit button image#
            var image = new Image() { Width = 24, Height = 24 };
            var bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("pack://application:,,/Simplic.UIDataTemplate;component/Resources/Images/Edit_grey_24x.png");
            bitmapImage.EndInit();

            image.Source = bitmapImage;
            editButton.Content = image;

            editButton.Click += OnEditClick;

            grid.Children.Add(presenter);
            grid.Children.Add(editButton);
            
            // Set the grid as the content of the current control
            this.Content = grid;
        }
        #endregion

        /// <summary>
        /// Didpose the content presenter and clean all resources
        /// </summary>
        public void Dispose()
        {
            presenter.ContentChanged -= PresenterContentChanged;
        }
        
        /// <summary>
        /// Refresh the content-presenter template
        /// </summary>
        public void RefreshDataTemplate()
        {
            presenter.ContentTemplate = presenter.ContentTemplateSelector.SelectTemplate(DataContext, presenter);
        }

        #region Private Methods
        /// <summary>
        /// Will be called if the template should be edited
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEditClick(object sender, RoutedEventArgs e)
        {
            if (UITemplateManager.EditorFactory == null)
            {
                MessageBox.Show(Properties.Resource.NoEditorFactoryText, Properties.Resource.NoEditorFactoryTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var editor = UITemplateManager.EditorFactory.Create();
            editor.Edit(SelectedTemplate.TemplatePath, selector.Loader, this);
        }

        /// <summary>
        /// Will be called if the presenter content has changed
        /// </summary>
        /// <param name="sender">Presneter</param>
        /// <param name="e">Routed event arguments</param>
        private void PresenterContentChanged(object sender, ContentChangedEventArgs e)
        {
            // Handle loading case
            if (e.VisualAdded != null)
            {
                foreach (var invoker in invokers)
                {
                    invoker.Load(e.VisualAdded);
                }
            }

            // Handle unload case
            if (e.VisualRemoved != null)
            {
                foreach (var invoker in invokers)
                {
                    invoker.Unload(e.VisualRemoved);
                }
            }
        }
        #endregion

        #region Public Member
        /// <summary>
        /// Gets the currently selected template
        /// </summary>
        public UITemplate SelectedTemplate
        {
            get { return (UITemplate)GetValue(SelectedTemplateProperty); }
            internal set { SetValue(SelectedTemplateProperty, value); }
        }

        /// <summary>
        /// Gets or sets a list of available templates
        /// </summary>
        public IList Templates
        {
            get { return (IList)GetValue(TemplatesProperty); }
            set { SetValue(TemplatesProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether a selected template is required or not
        /// </summary>
        public bool IsSelectedTemplateRequired
        {
            get { return (bool)GetValue(IsSelectedTemplateRequiredProperty); }
            set { SetValue(IsSelectedTemplateRequiredProperty, value); }
        }

        /// <summary>
        /// Gets or sets the datatemplate name which should be resolved in the resource dictionary
        /// </summary>
        public string DataTemplateName
        {
            get { return (string)GetValue(DataTemplateNameProperty); }
            set { SetValue(DataTemplateNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether the current presenter is in edit mode or not
        /// </summary>
        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }
        #endregion
    }
}
