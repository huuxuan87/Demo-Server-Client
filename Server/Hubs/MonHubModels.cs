using System.Threading;

namespace Server.Hubs
{
    public class MonHubStore
    {
        private readonly List<MonHubUserConnectModel> _lstUserConnect;
        private readonly object _lockObject;

        public MonHubStore()
        {
            _lstUserConnect = new List<MonHubUserConnectModel>();
            _lockObject = new object();
        }

        public List<MonHubUserConnectModel> GetListUserConnect(string? ConnectionId = null, string? DienThoai = null, bool? IsMonitor = null)
        {
            var query = _lstUserConnect.AsQueryable();
            if (!string.IsNullOrEmpty(ConnectionId)) query = query.Where(m => m.ConnectionId == ConnectionId);
            if (!string.IsNullOrEmpty(DienThoai)) query = query.Where(m => m.DienThoai == DienThoai);
            if (IsMonitor.HasValue) query = query.Where(m => (m.IsMonitor ?? false) == IsMonitor);
            return query.ToList();
        }

        public MonHubUserConnectModel AddOrUpdateUserConnect(string? ConnectionId, string? DienThoai = null, bool? IsMonitor = null)
        {
            lock (_lockObject)
            {
                var item = _lstUserConnect.FirstOrDefault(m => m.ConnectionId == ConnectionId);
                if (item == null)
                {
                    item = new MonHubUserConnectModel()
                    {
                        ConnectionId = ConnectionId,
                        DienThoai = DienThoai,
                        IsMonitor = IsMonitor,
                        NgayTao = DateTime.Now
                    };
                    _lstUserConnect.Add(item);
                }
                else
                {
                    item.DienThoai = DienThoai;
                    item.IsMonitor = IsMonitor;
                }
                return item;
            }
        }

        public int RemoveUserConnect(string? ConnectionId, string? DienThoai = null, bool? IsMonitor = null)
        {
            lock (_lockObject)
            {
                var lst = GetListUserConnect(ConnectionId, DienThoai, IsMonitor);
                foreach (var item in lst)
                {
                    _lstUserConnect.Remove(item);
                }
                return lst.Count;
            }
        }
    }

    public class MonHubUserConnectModel
    {
        public string? ConnectionId { get; set; }
        public string? DienThoai { get; set; }
        public bool? IsMonitor { get; set; }
        public DateTime? NgayTao { get; set; }
    }
}
