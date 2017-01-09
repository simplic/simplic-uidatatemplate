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
using System.Windows.Shapes;

namespace Sample.UIDataTemplate
{
    /// <summary>
    /// Interaction logic for SampleEditor.xaml
    /// </summary>
    public partial class SampleEditor : Window, ITemplateEditor
    {
        private string path;
        private ITemplateLoader loader;
        private UIContentPresenter presenter;
        private LoaderResult result;

        public SampleEditor()
        {
            InitializeComponent();
        }

        public void Edit(string path, ITemplateLoader loader, UIContentPresenter presenter)
        {
            this.path = path;
            this.loader = loader;
            this.presenter = presenter;

            result = loader.GetTemplate(presenter.DataTemplateName, path);

            if (result != null)
            {
                codeTextBox.Text = result.Code;
            }

            this.Show();
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            loader.SaveTemplate(presenter.DataTemplateName, result.Path, codeTextBox.Text);
            presenter.RefreshDataTemplate();
        }
    }
}
