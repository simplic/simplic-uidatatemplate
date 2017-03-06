using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simplic.UIDataTemplate.Cache
{
    /// <summary>
    /// Contains the UIDataTemplate cache
    /// </summary>
    public static class TemplateCache
    {
        private static IDictionary<string, ResourceDictionary> resources = new Dictionary<string, ResourceDictionary>();

        /// <summary>
        /// Clear the cache
        /// </summary>
        public static void Clear()
        {
            resources = new Dictionary<string, ResourceDictionary>();
        }

        /// <summary>
        /// Add a <see cref="ResourceDictionary"/> to the cache
        /// </summary>
        /// <param name="templateName">Template name</param>
        /// <param name="path">Path</param>
        /// <param name="resourceDictionary"><see cref="ResourceDictionary"/> instance</param>
        public static void Add(string templateName, string path, ResourceDictionary resourceDictionary)
        {
            if (resourceDictionary != null)
            {
                resources[$"{templateName}_{path}"] = resourceDictionary;
            }
        }

        /// <summary>
        /// Get a <see cref="ResourceDictionary"/> from cache by its template name and path
        /// </summary>
        /// <param name="templateName">Template name</param>
        /// <param name="path">Patj</param>
        /// <returns><see cref="ResourceDictionary"/> if exists, else null</returns>
        public static ResourceDictionary Get(string templateName, string path)
        {
            if (resources.ContainsKey($"{templateName}_{path}"))
            {
                return resources[$"{templateName}_{path}"];
            }

            return null;
        }

        /// <summary>
        /// Remove <see cref="ResourceDictionary"/> from cache
        /// </summary>
        /// <param name="templateName">Template name</param>
        /// <param name="path">Path</param>
        public static void Remove(string templateName, string path)
        {
            if (resources.ContainsKey($"{templateName}_{path}"))
            {
                resources.Remove($"{templateName}_{path}");
            }
        }
    }
}
