using System.Threading.Tasks;
using ginx.me.Entities;
using ginx.me.ViewModels;
using ginx.me.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using ginx.me.Requests;

namespace ginx.me.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class UrlShortenerController : ControllerBase
    {
        private const string baseUrl = "https://ginx.me/";

        private readonly IHashGenerator hashGenerator;
        private readonly GinxMeDbContext dbContext;

        public UrlShortenerController(IHashGenerator hashGenerator,
                                      GinxMeDbContext dbContext
        )
        {
            this.dbContext = dbContext;
            this.hashGenerator = hashGenerator;
        }

        [HttpPost()]
        [Route("api/sh")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]        
        public ActionResult<ShortenedUrl> Shorten(ShortenRequest request)
        {
            Uri parsedUri;
            bool isValid = Uri.TryCreate(request.OriginalUrl, UriKind.Absolute, out parsedUri) 
                    && (parsedUri.Scheme == Uri.UriSchemeHttp || parsedUri.Scheme == Uri.UriSchemeHttps);

            if (!isValid) {
                return BadRequest();
            }
            // else if is ginx.me/xxxxxxx already -> return the same
            else
            {
                UniqueIdWithSalt uniqueIdWithSalt = null;
                ShortenedUrlInstance collision = null;
                do {
                    uniqueIdWithSalt = hashGenerator.GetNext();
                    collision = dbContext.ShortenedUrlInstances.Where(sh => sh.UniqueId == uniqueIdWithSalt.UniqueId).FirstOrDefault();
                }
                while(collision != null); 

                var shortenedUrl = baseUrl +  uniqueIdWithSalt.UniqueId;

                ShortenedUrlInstance shortenedUrlInstance = new ShortenedUrlInstance {
                    UniqueId = uniqueIdWithSalt.UniqueId,
                    Salt = uniqueIdWithSalt.Salt,
                    OriginalUrl = request.OriginalUrl,
                    ShortenedUrl = shortenedUrl
                };

                dbContext.ShortenedUrlInstances.Add(shortenedUrlInstance);
                dbContext.SaveChanges();

                var result = new ShortenedUrl {
                    Original = request.OriginalUrl,
                    Shortened = shortenedUrl
                };

                return result;
            }
        }
    }
}