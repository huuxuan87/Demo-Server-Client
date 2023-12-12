$(document).ready(function () {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/monHub")
        .configureLogging(signalR.LogLevel.Information)
        //.withAutomaticReconnect()
        .build();

    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
            await startInit();
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    };

    async function startInit() {
        try {
            await connection.invoke("MonitorKetNoi");
            await connection.invoke("DanhSachNguoiChoi");
        } catch (err) {
            console.error(err);
        }
        $('.my-loading').addClass('d-none');
    }

    connection.onreconnected(async (connectionId) => {
        await startInit();
    });

    connection.onclose(async (error) => {
        $('.my-loading').removeClass('d-none');
        await start();
    });

    connection.onreconnecting(async (error) => {
        $('.my-loading').removeClass('d-none');
    });

    connection.on("DanhSachNguoiChoi", (lstAppConnect) => {
        console.log('onDanhSachNguoiChoi', lstAppConnect);

        let countAppDangChay = $('#countAppDangChay');
        let countNguoiDangChoi = $('#countNguoiDangChoi');
        let lstNguoiChoi = lstAppConnect.filter(m => (m.dienThoai != null && m.dienThoai != ''));
        let objGroupNguoiChoi = Object.groupBy(lstNguoiChoi, ({ dienThoai }) => dienThoai);

        countAppDangChay.html(lstAppConnect.length);
        countNguoiDangChoi.html(Object.keys(objGroupNguoiChoi).length);
    });

    // Start the connection.
    start();
});