using Carter;

namespace API.Extensions;

public static class MiddlewareExtension
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Url Shortener API V1");
            });
        }
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapCarter();

        app.UseExceptionHandler();
    }
}