using Simplic.UIDataTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sample.UIDataTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            UITemplateManager.LoaderFactories.Add(new FSInvokerFactory());
            UITemplateManager.InvokerFactories.Add(new SampleInvokerFactory());
            UITemplateManager.EditorFactory = new EditorFactory();
            UITemplateManager.DynamicResolverFactory = new DynamicResolverFactory();

            InitializeComponent();

            this.DataContext = new SampleViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sampleContentTemplate.RefreshDataTemplate();
        }
    }

    public class DynamicResolverFactory : ITemplateDynamicResolverFactory
    {
        public ITemplateDynamicResolver Create()
        {
            return new SampleResolver();
        }
    }

    public class SampleResolver : ITemplateDynamicResolver
    {
        public IList<UITemplate> ResolveDynamicTemplates(string ns, string dateTemplateName)
        {
            return null;
        }
    }

    public class EditorFactory : ITemplateEditorFactory
    {
        public ITemplateEditor Create()
        {
            return new SampleEditor();
        }
    }

    public class FSInvokerFactory : ITemplateLoaderFactory
    {
        public ITemplateLoader Create()
        {
            return new FileSystemTemplateLoader("C:\\Users\\beggers.SPIEGELBURG\\Sources\\simplic-uidatatemplate\\src\\Sample");
        }
    }

    public class SampleInvokerFactory : ITemplateInvokerFactory
    {
        public ITemplateInvoker Create()
        {
            return new SampleInvoker();
        }
    }

    public class SampleInvoker : ITemplateInvoker
    {
        public void Load(DependencyObject content)
        {
            if (content is Label)
            {
                ((Label)content).Background = new SolidColorBrush(Colors.Red);
            }
        }

        public void Unload(DependencyObject content)
        {

        }
    }
}
