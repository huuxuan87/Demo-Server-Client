using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Hubs
{
    public class MonHubUserConnectModel
    {
        public string ConnectionId { get; set; }
        public string DienThoai { get; set; }
        public bool? IsMonitor { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
