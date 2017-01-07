using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    public class FileSystemTemplateLoader : ITemplateLoader
    {
        private string baseDirectory;

        public FileSystemTemplateLoader(string baseDirectory)
        {
            this.baseDirectory = baseDirectory;
        }

        public string GetTemplate(string path)
        {
            var fullPath = Path.Combine(baseDirectory, path);

            if (File.Exists(fullPath))
            {
                return File.ReadAllText(fullPath);
            }

            return null;
        }

        public void SaveTemplate(string path, string code)
        {
            var fullPath = Path.Combine(baseDirectory, path);

            File.WriteAllText(fullPath, code);
        }
    }
}
