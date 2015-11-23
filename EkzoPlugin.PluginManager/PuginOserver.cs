using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace EkzoPlugin.PluginManager
{
    public class PluginOserver
    {
        private string _pluginsStorePath = "";
        public FileInfo[] avaliblePlugins = null;

        public PluginOserver()
        {
            string pluginsDir = System.Configuration.ConfigurationSettings.AppSettings["pluginsDirectory"] == null ? "~/plugins" : System.Configuration.ConfigurationSettings.AppSettings["pluginsDirectory"];
            if (!pluginsDir.StartsWith("~/")) pluginsDir = "~/" + pluginsDir;
            pluginsDir = pluginsDir.Replace("//", "/");

            string pluginsPath = HostingEnvironment.MapPath(pluginsDir);
            pluginsPath = Path.Combine(pluginsPath, "repository");
            if (pluginsPath == null)
                throw new DirectoryNotFoundException("plugins");
            this._pluginsStorePath = pluginsPath;

            ScanPluginRepository();
        }

        private void ScanPluginRepository()
        {
            this.avaliblePlugins = new DirectoryInfo(this._pluginsStorePath).GetFiles("*.zip", SearchOption.AllDirectories);
        }
    }
}
