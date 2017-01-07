using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Factory for creating a type of <see cref="ITemplateLoader"/>
    /// </summary>
    public interface ITemplateLoaderFactory
    {
        /// <summary>
        /// Create a new instance of an <see cref="ITemplateLoader"/>
        /// </summary>
        /// <returns>New instance of <see cref="ITemplateLoader"/></returns>
        ITemplateLoader Create();
    }
}
