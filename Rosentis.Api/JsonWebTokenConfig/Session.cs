using System.Collections.Generic;

namespace Rosentis.Api.JsonWebTokenConfig
{
    public static class Session
    {
        
        public static string Token { get; set; }
        public static string Username { get; set; }
        public static string DisplayName { get; set; }
        public static string Group { get; set; }
        public static string  Project { get; set; }
        public static string  Domain { get; set; }
        public static string UserId { get; set; }
        public static string Ip { get; set; }
        public static IList<string> Roles { get; set; }
        public static IList<string> Permissions { get; set; }
        public static int ProjectId { get; set; }
    }
}