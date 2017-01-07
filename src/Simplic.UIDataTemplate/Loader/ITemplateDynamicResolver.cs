using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Resolver interface that must be implemented into all resolvers
    /// </summary>
    public interface ITemplateDynamicResolver
    {
        /// <summary>
        /// Gets a list of available dynamic templates for the given dataTemplateName
        /// </summary>
        /// <param name="ns">Namespace of the root control</param>
        /// <param name="dateTemplateName">Name of the template</param>
        /// <returns>List of templates or null</returns>
        IList<UITemplate> ResolveDynamicTemplates(string ns, string dateTemplateName);
    }
}
