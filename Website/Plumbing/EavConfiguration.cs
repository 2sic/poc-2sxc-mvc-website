using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ToSic;
using ToSic.Eav;
using ToSic.Eav.Apps.ImportExport;
using ToSic.Eav.Caching;
using ToSic.Eav.Configuration;
using ToSic.Eav.Run.Basic;
using ToSic.Eav.LookUp;
using ToSic.Eav.Persistence.Interfaces;
using ToSic.Eav.Run;
using ToSic.SexyContent.Interfaces;
using ToSic.Sxc.Adam;
using ToSic.Sxc.Apps.ImportExport;
using ToSic.Sxc.Conversion;
using ToSic.Sxc.Interfaces;
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

        internal static void ConfigureIoC()
        {
            ToSic.Eav.Factory.ActivateNetCoreDi(sc =>
            {
                sc.AddTransient<ToSic.Eav.Conversion.EntitiesToDictionary, DataToDictionary>();
                sc.AddTransient<IValueConverter, BasicValueConverter>();
                sc.AddTransient<IUser, BasicUser>();

                //sc.AddTransient<XmlExporter, DnnXmlExporter>();
                //sc.AddTransient<IImportExportEnvironment, DnnImportExportEnvironment>();

                sc.AddTransient<IRuntime, BasicRuntime>();
                //sc.AddTransient<IAppEnvironment, DnnEnvironment>();
                sc.AddTransient<IEnvironment, MvcEnvironment>();

                // The file-importer - temporarily itself
                sc.AddTransient<XmlImportWithFiles, XmlImportFull>();

                sc.AddTransient<IClientDependencyOptimizer, BasicClientDependencyOptimizer>();
                //sc.AddTransient<IRuntimeFactory, DnnEnvironmentFactory>();
                //sc.AddTransient<IEnvironmentFactory, DnnEnvironmentFactory>();
                //sc.AddTransient<IWebFactoryTemp, DnnEnvironmentFactory>();
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
