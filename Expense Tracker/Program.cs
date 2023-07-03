using Expense_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;

namespace Expense_Tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //dependency injection
            builder.Services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnectionString")));
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt9QHFqVkBrVE5FaV1CX2BZeFl0Qmlad04BCV5EYF5SRHFfQF1lSnxWcURqX3k=;Mgo+DSMBPh8sVXJ2S0d+X1dPfkBDQmFJfFBmQ2lbeFRzfEU3HVdTRHRcQlpjS35VdUdmXn1fcnI=;ORg4AjUWIQA/Gnt2V1hhQlJCfVddXHxLflF1VWVTfVl6d11WESFaRnZdQV1kSXxTcEZhXHhcd3ZT;MjUzNDE0MEAzMjMyMmUzMDJlMzBpSkNCR09JV0M0WEltaFNCeTI1YVhIaEhkYUFKdjBoYUdPcUFhQlNiZE5nPQ==;MjUzNDE0MUAzMjMyMmUzMDJlMzBMSWJwUkFVRXJ3YysvanVBek05UTFpQTdYbmN2cXR4ekxwU1BkMEQzWEJBPQ==;NRAiBiAaIQQuGjN/V0R+XU9HcFRKQmJWfFN0RnNfdVx3flZOcC0sT3RfQF5jTn5RdkNgW3pZdHVcRQ==;MjUzNDE0M0AzMjMyMmUzMDJlMzBrQTNpUXpWMytvS2dGSm41R04yVC9iclVRTHNjbWdkWXBkS0drMjBKVzhNPQ==;MjUzNDE0NEAzMjMyMmUzMDJlMzBqMVF1TzVrcWhZMmNPOVJEWERmS29sdHBWK0t0YjBGdTlrL0toN1ZJazM0PQ==;Mgo+DSMBMAY9C3t2V1hhQlJCfVddXHxLflF1VWVTfVl6d11WESFaRnZdQV1kSXxTcEZhXHhbcnJX;MjUzNDE0NkAzMjMyMmUzMDJlMzBOanBzcGNPU1dxak5DaVpaZzhkbEtyMlQwUTE1ZWZQbTZYRlVrTzdlb2RZPQ==;MjUzNDE0N0AzMjMyMmUzMDJlMzBSSkhuU3RhaDl6S1FXRTBKdlVkbFdqNDZicjdQUlVjUFdMMmYybzI0Ky9JPQ==;MjUzNDE0OEAzMjMyMmUzMDJlMzBrQTNpUXpWMytvS2dGSm41R04yVC9iclVRTHNjbWdkWXBkS0drMjBKVzhNPQ==");

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}