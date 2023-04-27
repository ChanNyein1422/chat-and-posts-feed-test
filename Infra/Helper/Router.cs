namespace Infra.Helper
{
    public struct baseUrls
    {
        public const string doctorapproute = "https://localhost:7200/";
    }

    public struct Request
    {
        public const string chatappapi = "ChatTest";
    }

    public static class Router
    {
        public static string route(this string Route, string project)
        {
            string? route = null;
            switch (project)
            {
                case Request.chatappapi:
                    route = $"{baseUrls.doctorapproute}{Route}";
                    break;
                default:
                    throw new ArgumentException("Invalid Route");
            }
            return route;
        }
    }

}
