using System.Reflection;
using Autofac;
using Main.Server.Core.Repositories;
using Main.Server.Core.Services;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;
using Main.Server.DataAccess;
using Main.Server.DataAccess.Repositories;
using Main.Server.DataAccess.UnitOfWorks;
using Main.Server.Service.Mappings;
using Main.Server.Service.Services;
using Main.Server.Service.Services.AllServices;
using Module = Autofac.Module;

namespace generic_framework.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Generic repository kaydı
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            // Generic service kaydı
            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>))
                .InstancePerLifetimeScope();

            // UnitOfWorks kaydı
            builder.RegisterType<UnitOfWorks>().As<IUnitOfWorks>();

            // Repository ve Service'leri assembly taraması ile kaydet
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
