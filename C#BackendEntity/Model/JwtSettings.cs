namespace C_BackendEntity.Model
{
    public class JwtSettings
    {
            public string Key { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public int AccessTokenLifetimeMinutes { get; set; }
            public int RefreshTokenLifetimeDays { get; set; }
        
    }
}
