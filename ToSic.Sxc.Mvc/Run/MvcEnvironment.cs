using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting.Internal;
using ToSic.Eav.Apps;
using ToSic.Eav.Logging;
using ToSic.Eav.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.Run
{
    public class MvcEnvironment : HasLog, IAppEnvironment
    {
        public IZoneMapper ZoneMapper { get; } = new MvcZoneMapper();

        public IUser User { get; } = new MvcUser();

        public IPagePublishing PagePublishing => Eav.Factory.Resolve<IPagePublishing>().Init(Log);


        public string MapAppPath(string virtualPath)
        {
            throw new NotImplementedException();

            // return HostingEnvironment.MapPath(virtualPath);
        }


        public MvcEnvironment() : base("DNN.Enviro") { }

        //public MvcEnvironment(ILog parentLog = null) : base("DNN.Enviro", parentLog, "()")
        //{
        //    PagePublishing = Eav.Factory.Resolve<IEnvironmentFactory>().PagePublisher(Log);
        //}

        public string DefaultLanguage => new MvcPortalSettings().DefaultLanguage;
        public IAppEnvironment Init(ILog parent)
        {
            Log.LinkTo(parent);
            return this;
        }
    }
}
