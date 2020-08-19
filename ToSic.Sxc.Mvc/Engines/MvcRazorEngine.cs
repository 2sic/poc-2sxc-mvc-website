//using System;
//using System.Configuration;
//using System.Globalization;
//using System.IO;
//using System.Runtime.CompilerServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Razor.Compilation;
//using ToSic.Eav.Documentation;
//using ToSic.Sxc.Engines;
//using ToSic.Sxc.Mvc.Code;

//namespace ToSic.Sxc.Mvc.Engines
//{
//    /// <summary>
//    /// The razor engine, which compiles / runs engine templates
//    /// </summary>
//    [InternalApi_DoNotUse_MayChangeWithoutNotice("this is just fyi")]
//    [EngineDefinition(Name = "Razor")]

//    public partial class MvcRazorEngine : EngineBase
//    {
//        [PrivateApi]
//        protected RazorComponentBase Webpage { get; set; }

//        /// <inheritdoc />
//        [PrivateApi]
//        protected override void Init()
//        {
//            try
//            {
//                InitWebpage();
//            }
//            // Catch web.config Error on DNNs upgraded to 7
//            catch (ConfigurationErrorsException exc)
//            {
//                var e = new Exception("Configuration Error: Please follow this checklist to solve the problem: http://swisschecklist.com/en/i4k4hhqo/2Sexy-Content-Solve-configuration-error-after-upgrading-to-DotNetNuke-7", exc);
//                throw e;
//            }
//        }

//        [PrivateApi]
//        protected HttpContext HttpContext => null; // todo!

//        [PrivateApi]
//        public void Render(TextWriter writer)
//        {
//            Log.Add("will render into TextWriter");
//            try
//            {
//                writer.WriteLine("TODO - must execute page");
//                //Webpage.ExecutePageHierarchy(new WebPageContext(HttpContext, Webpage, null), writer, Webpage);
//            }
//            catch (Exception maybeIEntityCast)
//            {
//                Sxc.Code.ErrorHelp.AddHelpIfKnownError(maybeIEntityCast);
//                throw;
//            }
//        }

//        /// <inheritdoc/>
//        protected override string RenderTemplate()
//        {
//            Log.Add("will render razor template");
//            var writer = new StringWriter();
//            Render(writer);
//            return writer.ToString();
//        }

//        private object CreateWebPageInstance()
//        {
//            try
//            {
//                var compiledType = GetType(); // TODO!!!  // BuildManager.GetCompiledType(TemplatePath);
//                object objectValue = null;
//                if (compiledType != null)
//                    objectValue = RuntimeHelpers.GetObjectValue(Activator.CreateInstance(compiledType));
//                return objectValue;
//            }
//            catch (Exception ex)
//            {
//                Sxc.Code.ErrorHelp.AddHelpIfKnownError(ex);
//                throw;
//            }
//        }

//        private void InitWebpage()
//        {
//            if (string.IsNullOrEmpty(TemplatePath)) return;

//            // WIP https://github.com/dotnet/aspnetcore/blob/master/src/Mvc/Mvc.Razor.RuntimeCompilation/src/RuntimeViewCompiler.cs#L397-L404
//            //var compiler = Eav.Factory.Resolve<Microsoft.AspNetCore.Mvc.Razor.Compilation>();

//            //var result = compiler.CompileAsync(TemplatePath);

//            object objectValue = null; //RuntimeHelpers.GetObjectValue(result.Result.Type);
            

//            //var objectValue = RuntimeHelpers.GetObjectValue(CreateWebPageInstance());
//            // ReSharper disable once JoinNullCheckWithUsage
//            if (objectValue == null)
//                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The webpage found at '{0}' was not created.", TemplatePath));

//            Webpage = objectValue as RazorComponentBase;

//            if (Webpage == null)
//                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "The webpage at '{0}' must derive from RazorComponentBase.", TemplatePath));

//            //Webpage.Context = HttpContext;
//            Webpage.VirtualPath = TemplatePath;
//            Webpage.Purpose = Purpose;

//            InitHelpers(Webpage, 10);
//        }

//        private void InitHelpers(RazorComponentBase webPage, int compatibility)
//        {
//            // probably not needed: webPage.Html = new Razor.HtmlHelper();
//            webPage.DynCode = new MvcDynamicCode().Init(BlockBuilder, compatibility, Log);

//            #region New in 10.25 - ensure jquery is not included by default

//            if (compatibility == 10) CompatibilityAutoLoadJQueryAndRVT = false;

//            #endregion

//        }


//    }
//}