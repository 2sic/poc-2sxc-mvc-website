using System;
using System.Collections.Generic;

namespace ToSic.Sxc.Mvc
{
    public class TestConstants
    {
        // Global, valid for all
        public const int TenantId = 2;
        public const string DefaultLanguage = "en";
        public const int PrimaryApp = ContentApp;

        // Blog App
        public const int BlogT = 2;
        public const int BlogA = 78;
        public const int BlogP = 680;
        public const int BlogI = 3002;
        public static Guid BlogB = new Guid("9cbcee9d-49d5-4fe0-8e74-1e20f74a5916");

        // Content App on home
        public const int ContentPage = 56;
        public const int ContentInstance = 6935;
        public const int ContentApp = 2;
        public static Guid ContentGuid = new Guid("f8ae3d07-5805-4650-a46d-a047e113ab53");

        // Token app here: http://2sexycontent.2dm.2sic/features/Tokens

        public const int TokenAppId = 1262;
        public const string TokenAppGuid = "b255e493-63b8-4c9a-b36a-a6487730f78f";
        public const int TokenZoneId = 128;
        public const int TokenPage = 4062;
        public const int TokenInstance = 9170;
        public static Guid TokenGuid = new Guid("584b7398-8517-4bdf-b05d-71d64b935f4f");

    }
}

