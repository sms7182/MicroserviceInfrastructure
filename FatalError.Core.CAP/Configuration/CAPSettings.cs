using System;
using System.Collections.Generic;
using System.Text;

namespace FatalError.Core.CAP.Configuration
{
    public class CAPSettings
    {
        public string CAPDBName { get; set; }
        public string CAPDBHost { get; set; }
        public string RabbitMQHost { get; set; }
        public string RabbitUser { get; set; }
        public string RabbitPass { get; set; }
    }
}
