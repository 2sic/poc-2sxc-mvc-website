using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToSic.Eav;
using ToSic.Eav.Apps.ImportExport;
using ToSic.Eav.Run.Basic;
using ToSic.Eav.Run;
using ToSic.SexyContent.Interfaces;
using ToSic.Sxc.Apps.ImportExport;
using ToSic.Sxc.Conversion;
using ToSic.Sxc.Mvc.Run;
using ToSic.Sxc.Web;
using ToSic.Sxc.Web.Basic;

namespace Website.Plumbing
{
    public class EavConfiguration
    {
        internal void ConfigureConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SiteSqlServer");
            ToSic.Eav.Repository.Efc.Implementations.Configuration.SetConnectionString(connectionString);
            ToSic.Eav.Repository.Efc.Implementations.Configuration.SetFeaturesHelpLink("https://2sxc.org/help?tag=features", "https://2sxc.org/r/f/");
        }

        internal static void ConfigureIoC(IServiceCollection services)
        {
            Factory.BetaUseExistingServiceCollection(services);
            Factory.ActivateNetCoreDi(sc =>
            {
                sc.AddTransient<ToSic.Eav.Conversion.EntitiesToDictionary, DataToDictionary>();
                sc.AddTransient<IValueConverter, BasicValueConverter>();
                sc.AddTransient<IUser, BasicUser>();

                //sc.AddTransient<XmlExporter, DnnXmlExporter>();
                //sc.AddTransient<IImportExportEnvironment, DnnImportExportEnvironment>();

                sc.AddTransient<IRuntime, BasicRuntime>();
                sc.AddTransient<IAppEnvironment, ToSic.Sxc.Mvc.Run.MvcEnvironment>();
                sc.AddTransient<IEnvironment, MvcEnvironment>();

                // new for .net standard
                sc.AddTransient<ITenant, MvcTenant>();
                //sc.AddTransient<IAppFileSystemLoader, DnnAppFileSystemLoader>();
                //sc.AddTransient<IAppRepositoryLoader, DnnAppFileSystemLoader>();
                sc.AddTransient<IHttp, HttpAbstraction>();


                // The file-importer - temporarily itself
                sc.AddTransient<XmlImportWithFiles, XmlImportFull>();

                sc.AddTransient<IClientDependencyOptimizer, BasicClientDependencyOptimizer>();
                sc.AddTransient<IEnvironmentFactory, MvcEnvironmentFactory>();
                sc.AddTransient<IWebFactoryTemp, MvcEnvironmentFactory>();
                //sc.AddTransient<IRenderingHelpers, DnnRenderingHelpers>();
                //sc.AddTransient<IMapAppToInstance, DnnMapAppToInstance>();
                //sc.AddTransient<IEnvironmentInstaller, InstallationController>();
                //sc.AddTransient<IEnvironmentFileSystem, DnnFileSystem>();
                //sc.AddTransient<IGetEngine, GetDnnEngine>();
                sc.AddTransient<IFingerprint, BasicFingerprint>();

                new DependencyInjection().ConfigureNetCoreContainer(sc);
            });
        }
    }
}
