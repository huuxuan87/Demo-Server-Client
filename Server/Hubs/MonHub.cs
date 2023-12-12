using Microsoft.AspNetCore.SignalR;
using Server.Extensions;

namespace Server.Hubs
{
    public class MonHub : Hub
    {
        #region Init

        private readonly MonHubStore _monHubStore;

        public MonHub(MonHubStore monHubStore)
        {
            _monHubStore = monHubStore;
        }

        #endregion

        #region Function

        private async Task SendDanhSachNguoiChoi(List<MonHubUserConnectModel> lstSend)
        {
            if (lstSend != null && lstSend.Count > 0)
            {
                var lstNguoiChoi = _monHubStore.GetListUserConnect(null, null, false);
                foreach (var user in lstSend)
                {
                    await Clients.Client(user.ConnectionId.ToStringEx()).SendAsync("DanhSachNguoiChoi", lstNguoiChoi);
                }
            }
        }

        private async Task SendDanhSachNguoiChoiDenMonitor()
        {
            var lstMonitor = _monHubStore.GetListUserConnect(null, null, true);
            await SendDanhSachNguoiChoi(lstMonitor);
        }

        #endregion

        #region Hub

        public async Task NguoiChoiKetNoi(string DienThoai)
        {
            _monHubStore.AddOrUpdateUserConnect(Context.ConnectionId, DienThoai, false);
            await SendDanhSachNguoiChoiDenMonitor();
        }

        public async Task NguoiChoiBoKetNoi()
        {
            _monHubStore.AddOrUpdateUserConnect(Context.ConnectionId, null, false);
            await SendDanhSachNguoiChoiDenMonitor();
        }

        public async Task NguoiChoiDatSo(string DienThoai)
        {
            var lstByDienThoai = _monHubStore.GetListUserConnect(null, DienThoai, false);
            foreach (var client in lstByDienThoai.Where(m => m.ConnectionId != Context.ConnectionId))
            {
                await Clients.Client(client.ConnectionId.ToStringEx()).SendAsync("NguoiChoiDatSo", client);
            }
        }

        public async Task DanhSachNguoiChoi()
        {
            var lstSend = _monHubStore.GetListUserConnect(Context.ConnectionId, null, null);
            await SendDanhSachNguoiChoi(lstSend);
        }

        public void MonitorKetNoi()
        {
            _monHubStore.AddOrUpdateUserConnect(Context.ConnectionId, null, true);
        }

        #endregion

        #region Event

        public override async Task OnConnectedAsync()
        {
            _monHubStore.AddOrUpdateUserConnect(Context.ConnectionId);
            await SendDanhSachNguoiChoiDenMonitor();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _monHubStore.RemoveUserConnect(Context.ConnectionId);
            await SendDanhSachNguoiChoiDenMonitor();
            await base.OnDisconnectedAsync(exception);
        }

        #endregion
    }
}
