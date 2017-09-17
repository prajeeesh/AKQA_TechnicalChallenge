using Autofac;
using PersonInfo.Services.Interface;
namespace PersonInfo.Services.Autofac
{
    class RegisterTypes
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<SettingsService>().As<ISettingsService>().InstancePerLifetimeScope();
            builder.RegisterType<ProcessPersonInfoService>().As<IProcessPersonInfoService>().InstancePerLifetimeScope();
        }
    }
}
