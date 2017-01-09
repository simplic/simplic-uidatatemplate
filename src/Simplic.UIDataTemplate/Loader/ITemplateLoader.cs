using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Interface that must be implemented into all template loader
    /// </summary>
    public interface ITemplateLoader
    {
        /// <summary>
        /// Returns the xaml template code
        /// </summary>
        /// <param name="templateName">Name of the DataTemplate</param>
        /// <param name="path">Path to the template</param>
        /// <returns>Null if the template was not found, else the template code</returns>
        LoaderResult GetTemplate(string templateName, string path);

        /// <summary>
        /// Save ui template
        /// </summary>
        /// <param name="templateName">Name of the DataTemplate</param>
        /// <param name="path">Path to the template</param>
        /// <param name="code">Template code</param>
        void SaveTemplate(string templateName, string path, string code);

        /// <summary>
        /// Gets whether the loaded code is readonly
        /// </summary>
        bool IsReadOnly
        {
            get;
        }
    }
}
