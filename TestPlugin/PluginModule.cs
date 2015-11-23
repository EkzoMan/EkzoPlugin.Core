using EkzoPlugin.Infrastructure;
using System;

namespace TestPlugin
{
    public class PluginModule : IModule
    {
        public string EntryControllerName
        {
            get
            {
                return "Plugin";
            }
        }

        public string Name
        {
            get
            {
                return "TestPlugin";
            }
        }

        public string Title
        {
            get
            {
                return this.Name;
            }
        }

        public Version Version
        {
            get
            {
                return new Version(0, 1, 0);
            }
        }

        public void Install()
        {
            throw new NotImplementedException();
        }

        public void Uninstall()
        {
            throw new NotImplementedException();
        }
    }
}