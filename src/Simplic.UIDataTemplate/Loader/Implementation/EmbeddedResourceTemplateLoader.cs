using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Embedded resource template loader, which loads templates from a list of assemblies
    /// </summary>
    public class EmbeddedResourceTemplateLoader : ITemplateLoader
    {
        private IList<Assembly> assemblies;

        /// <summary>
        /// Initialize resource loader
        /// </summary>
        /// <param name="assemblies">List of assemblies</param>
        public EmbeddedResourceTemplateLoader(IList<Assembly> assemblies)
        {
            this.assemblies = assemblies;
        }

        /// <summary>
        /// Search a template in the list of assemblies and returns its code
        /// </summary>
        /// <param name="templateName">DateTemplate name</param>
        /// <param name="path">Absolute path to the template</param>
        /// <returns>Code of the template if found, else null</returns>
        public LoaderResult GetTemplate(string templateName, string path)
        {
            if (assemblies == null)
                return null;

            foreach (var asm in assemblies)
            {
                if (asm.GetManifestResourceNames().Any(item => item.ToLower() == path))
                {
                    using (Stream stm = asm.GetManifestResourceStream(path))
                    {
                        if (stm != null)
                        {
                            return new LoaderResult()
                            {
                                Code = new StreamReader(stm).ReadToEnd(),
                                Path = path
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// !Saving to embedded resources is not allowed
        /// </summary>
        /// <param name="templateName">DateTemplate name</param>
        /// <param name="path">-</param>
        /// <param name="code">-</param>
        public void SaveTemplate(string templateName, string path, string code)
        {

        }

        /// <summary>
        /// Gets whether the loaded code is readonly (true)
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the truely loaded path
        /// </summary>
        public string Path
        {
            get;
            set;
        }
    }
}
