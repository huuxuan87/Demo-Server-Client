using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config
{
    public class ConfigAppSetting : IConfigAppSetting
    {
        public string ApiUrl => ConfigurationManager.AppSettings["apiUrl"];
        public string ApiUrlHub => ConfigurationManager.AppSettings["apiUrlHub"];
    }
}
