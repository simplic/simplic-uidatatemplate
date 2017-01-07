using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Template invoker which will be called when templates are laoded and unloaded
    /// </summary>
    public interface ITemplateInvoker
    {
        /// <summary>
        /// Template is laoded
        /// </summary>
        /// <param name="content">Freshly loaded content</param>
        void Load(DependencyObject content);

        /// <summary>
        /// Template is unloaded
        /// </summary>
        /// <param name="content">Unloaded content</param>
        void Unload(DependencyObject content);
    }
}
