using System;
using System.Collections.Generic;
using System.Text;

namespace ToSic.Sxc.Mvc
{
    public class TestConstants
    {
        public const int TenantId = 2;
        public const int AppId = 78;
        public const int PageId = 680;
        public const int InstanceId = 6935;

        public const string DefaultLanguage = "en";


        public static Dictionary<int, Guid> InstanceContentBlockDb = new Dictionary<int, Guid>
        {
            {InstanceId, new Guid("9cbcee9d-49d5-4fe0-8e74-1e20f74a5916") },
        };
    }
}


//ID: 10522
//RepoID: 10522
//GUID: cf7e16ed-6289-4733-b4b9-55fa008049ad