using System.IO;
using ToSic.Eav.Documentation;
using ToSic.Eav.Run;
using ToSic.Sxc.Mvc.TestStuff;

namespace ToSic.Sxc.Mvc.Run
{
    /// <summary>
    /// This is a Mvc implementation of a Tenant-object. 
    /// </summary>
    [InternalApi_DoNotUse_MayChangeWithoutNotice("this is just fyi")]
    public class MvcTenant : Tenant<MvcPortalSettings>
    {
        /// <inheritdoc />
        public override string DefaultLanguage => UnwrappedContents.DefaultLanguage;

        /// <inheritdoc />
        public override int Id => UnwrappedContents.Id;

        /// <inheritdoc />
        public override string Name => UnwrappedContents.Name;

        [PrivateApi]
        public override string SxcPath => Path.Combine(UnwrappedContents.HomePath, Settings.AppsRootFolder);

        [PrivateApi]
        public override bool RefactorUserIsAdmin => false;

        /// <inheritdoc />
        public override string ContentPath => UnwrappedContents.HomePath;

        public MvcTenant(MvcPortalSettings settings) : base(settings ?? new MvcPortalSettings()) { }
    }
}
