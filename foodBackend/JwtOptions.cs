﻿namespace foodBackend
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public TimeSpan LifeTime { get; set; }
    }
}