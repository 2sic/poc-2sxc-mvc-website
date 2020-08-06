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
using ToSic.Eav.Implementations.Runtime;
using ToSic.Eav.LookUp;
using ToSic.Eav.Persistence.Interfaces;
using ToSic.Eav.Run;
using ToSic.SexyContent.Interfaces;
using ToSic.Sxc.Adam;
using ToSic.Sxc.Apps.ImportExport;
using ToSic.Sxc.Conversion;
using ToSic.Sxc.Interfaces;

namespace Website.Plumbing
{
    public class EavConfiguration
    {
        internal void ConfigureConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("EavSqlServer"); //.ConnectionString;
            ToSic.Eav.Repository.Efc.Implementations.Configuration.SetConnectionString(connectionString);
            ToSic.Eav.Repository.Efc.Implementations.Configuration.SetFeaturesHelpLink("https://2sxc.org/help?tag=features", "https://2sxc.org/r/f/");
        }

        internal static void ConfigureIoC(/*string appsCacheOverride*/)
        {
            ToSic.Eav.Factory.ActivateNetCoreDi(sc =>
            {
                sc.AddTransient<ToSic.Eav.Conversion.EntitiesToDictionary, DataToDictionary>();
                //sc.AddTransient<IValueConverter, DnnValueConverter>();
                //sc.AddTransient<IUser, DnnUser>();

                //sc.AddTransient<XmlExporter, DnnXmlExporter>();
                //sc.AddTransient<IImportExportEnvironment, DnnImportExportEnvironment>();

                sc.AddTransient<IRuntime, NeutralRuntime>();
                //sc.AddTransient<IAppEnvironment, DnnEnvironment>();
                sc.AddTransient<IEnvironment, MvcEnvironment>();

                // The file-importer - temporarily itself
                sc.AddTransient<XmlImportWithFiles, XmlImportFull>();

                //sc.AddTransient<IClientDependencyOptimizer, DnnClientDependencyOptimizer>();
                //sc.AddTransient<IRuntimeFactory, DnnEnvironmentFactory>();
                //sc.AddTransient<IEnvironmentFactory, DnnEnvironmentFactory>();
                //sc.AddTransient<IWebFactoryTemp, DnnEnvironmentFactory>();
                //sc.AddTransient<IRenderingHelpers, DnnRenderingHelpers>();
                //sc.AddTransient<IMapAppToInstance, DnnMapAppToInstance>();
                //sc.AddTransient<IEnvironmentInstaller, InstallationController>();
                //sc.AddTransient<IEnvironmentFileSystem, DnnFileSystem>();
                //sc.AddTransient<IGetEngine, GetDnnEngine>();
                //sc.AddTransient<IFingerprintProvider, DnnFingerprint>();

                //if (appsCacheOverride != null)
                //{
                //    try
                //    {
                //        var appsCacheType = Type.GetType(appsCacheOverride);
                //        sc.TryAddSingleton(typeof(IAppsCache), appsCacheType);
                //    }
                //    catch {  /* ignore */ }
                //}

                new DependencyInjection().ConfigureNetCoreContainer(sc);
            });
        }
    }
}
