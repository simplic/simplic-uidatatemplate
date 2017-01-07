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
        /// <param name="path">Path to the template</param>
        /// <returns>Null if the template was not found, else the template code</returns>
        string GetTemplate(string path);

        /// <summary>
        /// Save ui template
        /// </summary>
        /// <param name="path">Path to the template</param>
        /// <param name="code">Template code</param>
        void SaveTemplate(string path, string code);
    }
}
