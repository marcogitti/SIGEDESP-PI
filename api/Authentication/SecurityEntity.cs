namespace api.Authentication
{
    public class SecurityEntity
    {
        public string Issuer { get; } = "Server API";
        public string Audience { get; } = "WebSite";
        public string Key { get; } = "SIGEDESP_BarramentUser_API_Autentication";
    }
}
