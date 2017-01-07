using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Factory for creating a type of <see cref="ITemplateInvoker" />
    /// </summary>
    public interface ITemplateInvokerFactory
    {
        /// <summary>
        /// Create a new instance of an <see cref="ITemplateInvoker"/>
        /// </summary>
        /// <returns>New instance of <see cref="ITemplateInvoker"/></returns>
        ITemplateInvoker Create();
    }
}
