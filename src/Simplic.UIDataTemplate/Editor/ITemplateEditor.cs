using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Interface that must be implemented to enable template editing
    /// </summary>
    public interface ITemplateEditor
    {
        /// <summary>
        /// Edit a given ui template
        /// </summary>
        /// <param name="path">Path to the template</param>
        /// <param name="loader">Loader instance</param>
        /// <param name="presenter">Content presenter instance</param>
        void Edit(string path, ITemplateLoader loader, UIContentPresenter presenter);
    }
}
