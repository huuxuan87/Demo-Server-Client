using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Config
{
    public interface IConfigAppSetting
    {
        string ApiUrl { get; }
    }
}
