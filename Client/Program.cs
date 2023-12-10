using Autofac;
using AutoMapper;
using Client.Helpers;
using Client.Models;
using Client.Views;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize Autofac container
            var builder = new ContainerBuilder();

            #region Register types

            builder.RegisterType<NguoiChoiModel>().AsSelf();
            builder.RegisterType<StartForm>().SingleInstance();
            builder.RegisterType<DangKyForm>().SingleInstance();
            builder.RegisterType<DangNhapForm>().SingleInstance();
            builder.RegisterType<MainForm>().SingleInstance();
            builder.RegisterInstance((new MapperConfiguration(cf => cf.AddProfile<CustomerProfile>())).CreateMapper());
            builder.RegisterType<NguoiChoiService>().As<INguoiChoiService>();
            builder.RegisterType<DatSoService>().As<IDatSoService>();

            #endregion

            // Build the container
            var container = builder.Build();

            // Resolve the main form from the container
            var startForm = container.Resolve<StartForm>();

            Application.Run(startForm);
        }
    }

    internal class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<ApiRequestResult<DatSoModel>, ApiRequestResult>()
                .ForMember(dest => dest.Result, opt => opt.Ignore());
        }
    }
}
