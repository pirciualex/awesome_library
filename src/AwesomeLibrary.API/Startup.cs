namespace AwesomeLibrary.API
{
    public class Startup
    {
        // Dependency injection container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // Application middleware
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(enpoints =>
            {
                enpoints.MapControllers();
            });
        }
    }
}
