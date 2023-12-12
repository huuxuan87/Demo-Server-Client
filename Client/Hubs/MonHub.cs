using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Hubs
{
    public static class MonHub
    {
        public static HubConnection Build(string apiUrlHub)
        {
            var monHub = new HubConnectionBuilder()
                .WithUrl(apiUrlHub + "/monHub")
                .Build();
            return monHub;
        }

        public static Task SendNguoiChoiKetNoiAsync(this HubConnection monHub, string DienThoai)
        {
            var task = monHub.InvokeAsync("NguoiChoiKetNoi", DienThoai);
            return task;
        }

        public static Task SendNguoiChoiBoKetNoiAsync(this HubConnection monHub)
        {
            var task = monHub.InvokeAsync("NguoiChoiBoKetNoi");
            return task;
        }

        public static Task<MonHubUserConnectModel> SendNguoiChoiDatSoAsync(this HubConnection monHub, string DienThoai)
        {
            var task = monHub.InvokeAsync<MonHubUserConnectModel>("NguoiChoiDatSo", DienThoai);
            return task;
        }

        public static void OnNguoiChoiDatSo(this HubConnection monHub, Action<MonHubUserConnectModel> action)
        {
            monHub.Remove("NguoiChoiDatSo");
            monHub.On<MonHubUserConnectModel>("NguoiChoiDatSo", (client) =>
            {
                if (action != null) 
                {
                    action(client);
                }
            });
        }
    }
}
