using System;
using System.Collections.Generic;

namespace ToSic.Sxc.Mvc
{
    public class TestConstants
    {
        // Global, valid for all
        public const int TenantId = 2;
        public const string DefaultLanguage = "en";

        // Blog App
        public const int BlogApp = 78;
        public const int BlogPage = 680;
        public const int BlogInstanceId = 3002;
        public static Guid BlogGuid = new Guid("9cbcee9d-49d5-4fe0-8e74-1e20f74a5916");

        // Content App on home
        public const int ContentPage = 56;
        public const int ContentInstance = 6935;
        public const int ContentApp = 2;
        public static Guid ContentGuid = new Guid("f8ae3d07-5805-4650-a46d-a047e113ab53");


        public static Dictionary<int, Guid> InstanceContentBlockDb = new Dictionary<int, Guid>
        {
            {BlogInstanceId, BlogGuid },
            {ContentInstance, ContentGuid }
        };

    }
}


//ID: 10522
//RepoID: 10522
//GUID: cf7e16ed-6289-4733-b4b9-55fa008049ad