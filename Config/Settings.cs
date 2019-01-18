using System;

namespace ginx.me.Config
{
    public class Settings
    {
        public static Settings Current;
        
        public string ApiBaseUrl { get; set; }
        public string ShortenUrlMethod { get; set; }

        public string ShorterUrlFullUrl { get
            {
                return ApiBaseUrl + ShortenUrlMethod;
            }
        }

        public Settings()
        {
            Current = this;
        }
    }
}
