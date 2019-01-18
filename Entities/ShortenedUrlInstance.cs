using System;

namespace ginx.me.Entities
{
    public class ShortenedUrlInstance
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public string Salt { get; set; }
        
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}