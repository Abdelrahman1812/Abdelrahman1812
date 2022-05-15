using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentitServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


           services.AddAuthentication("OAuth").AddJwtBearer("OAuth", config => {


               // to pass access token throgh the query string

               Func<MessageReceivedContext, Task> OnMsgRecived = context => {
                   if (context.Request.Query.ContainsKey("accesstoken"))
                   {
                       context.Token = context.Request.Query["accesstoken"];
                   }
                   return Task.CompletedTask; 
               };

               config.Events= new JwtBearerEvents() { OnMessageReceived = OnMsgRecived };

               config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
               {
                  // IssuerSigningKey = 

               };
               
               });
            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(configure => { configure.MapDefaultControllerRoute(); });


        }
    }
}
