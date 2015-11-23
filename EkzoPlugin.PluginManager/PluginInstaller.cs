using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace EkzoPlugin.PluginManager
{
    public static class PluginInstaller
    {
        private static FileInfo[] _plugins = null;
        private static string _pluginsDirectory = "";

        public static void InstallPlugins(FileInfo[] plugins)
        {
            _plugins = plugins;
            string pluginsDir = System.Configuration.ConfigurationSettings.AppSettings["pluginsDirectory"] == null ? "~/plugins" : System.Configuration.ConfigurationSettings.AppSettings["pluginsDirectory"];
            if (!pluginsDir.StartsWith("~/")) pluginsDir = "~/" + pluginsDir;
            pluginsDir = pluginsDir.Replace("//", "/");

            string pluginsPath = HostingEnvironment.MapPath(pluginsDir);
            pluginsPath = Path.Combine(pluginsPath, "repository");
            if (pluginsPath == null)
                throw new DirectoryNotFoundException("plugins");
            _pluginsDirectory = pluginsPath;

            var installationResult = Install();
            foreach (var item in installationResult)
                Console.WriteLine(string.Format("{0} {1} {2}",item.Status,item.Message,item.Error==null?"":item.Error.Message));
        }

        private static PluginExtractionResult[] Install()
        {
            IList<PluginExtractionResult> result = new List<PluginExtractionResult>();
            foreach(var file in _plugins)
            {
                result.Add(UnzipPlugin(file));
            }
            return result.ToArray();
        }

        private static PluginExtractionResult UnzipPlugin(FileInfo plugin)
        {
            if (plugin.Extension != ".zip") throw new Exception(string.Format("The {0} extention is not recognized as valid plugin repository item extention. Default extention is .zip",plugin.Extension));
            try {
                ICSharpCode.SharpZipLib.Zip.FastZip zip = new ICSharpCode.SharpZipLib.Zip.FastZip();
                zip.ExtractZip(plugin.FullName, Path.Combine(_pluginsDirectory, plugin.Name), string.Empty);
                return new PluginExtractionResult(ExtractionResult.OK, string.Format("Plugin {0} successfully ",plugin.Name));
            }
            catch (Exception ex)
            {
                return new PluginExtractionResult(ExtractionResult.Error, string.Format("Error while extract {0} plugin from archive",plugin.Name), ex);
            }
        }
    }
}
