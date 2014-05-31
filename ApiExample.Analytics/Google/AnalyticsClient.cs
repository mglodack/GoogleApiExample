using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiExample.Analytics.Google
{
    public class AnalyticsClient
    {
        private static string _urlBase = "http://www.google-analytics.com/collect";

        private HttpWebRequest Create()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_urlBase);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            String encodedPayloadString = BuildParameterString();
            Byte[] payLoadBytes = Encoding.UTF8.GetBytes(encodedPayloadString);
            request.ContentLength = payLoadBytes.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(payLoadBytes, 0, payLoadBytes.Length);
            }
            return request;
        }
        private static void Send(HttpWebRequest request)
        {
            try
            {
                using (WebResponse response = request.GetResponse()) { }
            }
                catch(WebException) { }
        }

        public void Report()
        {
            Send(Create());
        }
        public string BuildParameterString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("v=1&");
            sb.Append("tid=UA-51515444-1&");
            sb.Append("cid=" + System.Guid.NewGuid().ToString() + "&"); //Figure out how to save this client Id per application, should generate a new one on startup
            sb.Append("an=ApiExample&");
            sb.Append("av=0.1&");
            sb.Append("t=event&");
            sb.Append("ec=Application&");
            sb.Append("ea=Startup&");
            sb.Append("el=Application Started");
            return sb.ToString();
        }
    }
}
