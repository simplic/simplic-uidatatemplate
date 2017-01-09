using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Template loader implementation that loads templates fromt he filesystem
    /// </summary>
    public class FileSystemTemplateLoader : ITemplateLoader
    {
        private string baseDirectory;

        /// <summary>
        /// Initialize filesystem template loader
        /// </summary>
        /// <param name="baseDirectory"></param>
        public FileSystemTemplateLoader(string baseDirectory)
        {
            this.baseDirectory = baseDirectory;
        }

        /// <summary>
        /// Try to load a template from the filesystem
        /// </summary>
        /// <param name="templateName">DateTemplate name</param>
        /// <param name="path">Relative path to the file</param>
        /// <returns>The code of the template if found, else null</returns>
        public LoaderResult GetTemplate(string templateName, string path)
        {
            var fullPath = System.IO.Path.Combine(baseDirectory, path);

            if (File.Exists(fullPath))
            {
                return new LoaderResult()
                {
                    Path = fullPath,
                    Code = File.ReadAllText(fullPath)
                };
            }

            return null;
        }

        /// <summary>
        /// Save template code in a file on the filesystem
        /// </summary>
        /// <param name="templateName">DateTemplate name</param>
        /// <param name="path">Full path to the template</param>
        /// <param name="code">Code which should be saved</param>
        public void SaveTemplate(string templateName, string path, string code)
        {
            var fullPath = Path.Combine(baseDirectory, path);

            File.WriteAllText(fullPath, code);
        }

        /// <summary>
        /// Gets whether the loaded code is readonly (true)
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
    }
}
