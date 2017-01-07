using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simplic.UIDataTemplate
{
    public class EmbeddedResourceTemplateLoader : ITemplateLoader
    {
        private IList<Assembly> assemblies;

        public EmbeddedResourceTemplateLoader(IList<Assembly> assemblies)
        {
            this.assemblies = assemblies;
        }

        public string GetTemplate(string path)
        {
            return null;   
        }

        public void SaveTemplate(string path, string code)
        {
            throw new NotImplementedException();
        }
    }
}
