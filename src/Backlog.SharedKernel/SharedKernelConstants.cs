using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Backlog.SharedKernel;
public static class SharedKernelConstants
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

    public static class StoryStatus
    {
        public const string Backlog = nameof(Backlog);
        public const string Assigned = nameof(Assigned);
        public const string InProgress = nameof(InProgress);
        public const string Done = nameof(Done);

        public static List<string> All => new()
        {
            Backlog,
            Assigned,
            InProgress,
            Done
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
