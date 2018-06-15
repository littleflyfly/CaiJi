using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace CaiJi.Utils
{
    public class Requester
    {
        public class Get
        {
            public static string ResponseToString(string Url, out string Host)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                    Host = request.RequestUri.Scheme + "://" + request.RequestUri.Host;
                    request.Method = "GET";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    var html = reader.ReadToEnd();
                    reader.Close();
                    return html;
                }
                catch
                {
                    Host = "";
                    return null;
                }
            }
        }
    }
}