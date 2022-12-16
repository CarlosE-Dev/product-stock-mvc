using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace product_stock_mvc.Web.Configurations
{
    public static class GlobalizationConfiguration
    {
        public static IApplicationBuilder ConfigureGlobalization(this IApplicationBuilder app)
        {
            var defaultCulture = new CultureInfo("en-US");
            var localizationOpt = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOpt);

            return app;
        }
    }
}
