using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkzoPlugin.PluginManager
{
    public class PluginExtractionResult
    {
        public ExtractionResult Status { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }

        public PluginExtractionResult() { }
        public PluginExtractionResult(ExtractionResult status,string message)
        {
            init(status, message,null);
        }

        public PluginExtractionResult(ExtractionResult status,string message,Exception error)
        {
            init(status, message, error);
        }

        private void init(ExtractionResult status, string message, Exception error)
        {
            this.Status = status;
            this.Message = message;
            this.Error = error;
        }
    }

    public enum ExtractionResult
    {
        OK = 1,
        Error = 2
    }
}
