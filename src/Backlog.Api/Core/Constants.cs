using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace Backlog.Api.Core
{
    public static class Constants
    {
        public static class ClaimTypes
        {
            public const string UserId = nameof(UserId);
            public const string Username = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
            public const string Privilege = nameof(Privilege);
        }

        public static class Aggregates
        {
            public const string User = nameof(User);

            public static List<string> All => new()
            {
                User
            };

            public static List<string> Authenticated => new()
            {

            };

        }


        public static class ContentName
        {
            public static List<string> All => new() { };
        }

        public static class ContentTypes
        {
            public static List<string> All => new() {  };
        }

        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy(),

            },
            Formatting = Formatting.Indented
        };
    }
}
