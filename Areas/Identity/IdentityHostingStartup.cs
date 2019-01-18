using System;
using ginx.me.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ginx.me.Areas.Identity.IdentityHostingStartup))]
namespace ginx.me.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<IdentityDataContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("IdentityDataContextConnection")));

                services.AddDbContext<IdentityDataContext>(options => options.UseInMemoryDatabase());


                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<IdentityDataContext>();
            });
        }
    }
}