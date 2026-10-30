using System.Linq;
using System.Web;

namespace ResumeProject.Helpers
{
    public static class ClientIp
    {
        public static string Get(HttpRequestBase request)
        {
            string forwarded = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrWhiteSpace(forwarded))
            {
                // Azure'un ön sunucusu gerçek IP'yi listenin sonuna ekler
                string ip = forwarded.Split(',').Last().Trim();

                // "1.2.3.4:5678" biçimindeki IPv4 adreslerinden portu at
                int colon = ip.LastIndexOf(':');
                if (colon > -1 && ip.IndexOf(':') == colon)
                    ip = ip.Substring(0, colon);

                if (!string.IsNullOrEmpty(ip))
                    return ip;
            }

            // Yerelde (F5) başlık yoktur
            return request.UserHostAddress;
        }
    }
}