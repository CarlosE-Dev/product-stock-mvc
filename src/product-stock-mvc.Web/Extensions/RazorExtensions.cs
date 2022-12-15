using Microsoft.AspNetCore.Mvc.Razor;

namespace product_stock_mvc.Web.Extensions
{
    public static class RazorExtensions
    {
        public static string FormatDocNumber(this RazorPage page, int personType, string docNumber)
        {
            return personType == 1 ?
                Convert.ToUInt64(docNumber)
                    .ToString(@"000\.000\.000\-00") :
                Convert.ToUInt64(docNumber)
                    .ToString(@"00\.000\.000\/000\-00");
        }
    }
}
