using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Manager template dependencies
    /// </summary>
    public static class UITemplateManager
    {
        private static IList<ITemplateInvokerFactory> invokerFactories = new List<ITemplateInvokerFactory>();
        private static IList<ITemplateLoaderFactory> loaderFactories = new List<ITemplateLoaderFactory>();
        private static ITemplateEditorFactory editorFactory;
        /// <summary>
        /// Gets an instance of all available invoker factories
        /// </summary>
        public static IList<ITemplateInvokerFactory> InvokerFactories
        {
            get
            {
                return invokerFactories;
            }
        }

        /// <summary>
        /// Gets a list of all available loader factories
        /// </summary>
        public static IList<ITemplateLoaderFactory> LoaderFactories
        {
            get
            {
                return loaderFactories;
            }
        }

        /// <summary>
        /// Gets or sets the editor factory
        /// </summary>
        public static ITemplateEditorFactory EditorFactory
        {
            get
            {
                return editorFactory;
            }

            set
            {
                editorFactory = value;
            }
        }
    }
}
