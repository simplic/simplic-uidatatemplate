using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Interface which must be implemented into all custom and default selector,
    /// to make a UITemplate dependeding on any property
    /// </summary>
    public interface ISelector
    {
        /// <summary>
        /// Returns true if a template is selectable
        /// </summary>
        /// <param name="template">Template instance which should be proofed</param>
        /// <param name="viewModel">Current viewmodel instance</param>
        /// <returns>True if the template is selectable</returns>
        bool SelectTemplate(UITemplate template, object viewModel);
    }
}
