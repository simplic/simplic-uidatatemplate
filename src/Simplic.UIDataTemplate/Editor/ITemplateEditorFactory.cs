using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Factory for creating a type of <see cref="ITemplateEditor" />
    /// </summary>
    public interface ITemplateEditorFactory
    {
        /// <summary>
        /// Create a new instance of an <see cref="ITemplateEditor"/>
        /// </summary>
        /// <returns>New instance of <see cref="ITemplateEditor"/></returns>
        ITemplateEditor Create();
    }
}
