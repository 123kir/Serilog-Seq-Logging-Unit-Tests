using AirPort_PRO_NuGet_Logger.AirPortManager;
using DataGridAirPort.Storage.Memory;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using Serilog.Extensions.Logging;
using System.Windows.Forms;

namespace AirPort_PRO_NuGet_Logger
{
    /// <summary>
    /// Главный класс приложения, содержащий точку входа
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Seq("http://localhost:5341", apiKey: "1ul5GVPRG6zSKanMtrWa")
                .CreateLogger();

            var logger = new SerilogLoggerFactory(serilogLogger).CreateLogger("DataGrid");

            // спрошлой версии
            //var factory = LoggerFactory.Create(builder => builder.AddDebug());
            //var logger = factory.CreateLogger(nameof(DataGrid));

            var storage = new MemoryAirPlaneStorage();
            var manager = new PlaneManager_cs(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}
