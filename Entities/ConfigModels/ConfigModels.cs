namespace TaskApi.Entities.ConfigModels
{
    public class JwtConfiguration
    {
        public string Section { get; set; } = "JwtSettings";
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Secret { get; set; }
        public int? Expires { get; set; }
    }
}
