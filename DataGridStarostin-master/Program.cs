﻿using System;
using System.Windows.Forms;
using DataGridStarostin.Standart.ApplicantManager;
using DataGridStarostin.Standart.Storage.Memory;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace DataGridStarostin
{
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

            var logger = new SerilogLoggerFactory(serilogLogger).CreateLogger("datagrid");

            var storage = new MemoryApplicantStorage();
            var manager = new ApplicantManager(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}