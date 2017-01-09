using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Result of the GetTemplate method of an <see cref="ITemplateLoader"/>
    /// </summary>
    public class LoaderResult
    {
        /// <summary>
        /// Gets or sets the loaded path
        /// </summary>
        public string Path
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the template code
        /// </summary>
        public string Code
        {
            get;
            set;
        }
    }
}
