using System.Windows;

namespace Simplic.UIDataTemplate
{
    public class UITemplate : DependencyObject
    {
        /// <summary>
        /// TemplatePath property
        /// </summary>
        public static readonly DependencyProperty TemplatePathProperty =
            DependencyProperty.Register("TemplatePath", typeof(string), typeof(UITemplate), new PropertyMetadata(""));

        /// <summary>
        /// Contains an optional selector instance
        /// </summary>
        public static readonly DependencyProperty SelectorProperty =
            DependencyProperty.Register("Selector", typeof(ISelector), typeof(UITemplate), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets template path
        /// </summary>
        public string TemplatePath
        {
            get { return (string)GetValue(TemplatePathProperty); }
            set { SetValue(TemplatePathProperty, value); }
        }

        /// <summary>
        /// Gets or sets a selector instance
        /// </summary>
        public ISelector Selector
        {
            get { return (ISelector)GetValue(SelectorProperty); }
            set { SetValue(SelectorProperty, value); }
        }
    }
}
