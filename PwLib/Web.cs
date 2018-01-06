using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PwLib
{
    public class Web
    {
        public static String UA = "User-Agent:Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Downloader/12590 MailRuGameCenter/1259 Safari/537.36";
        public static CookieContainer CC = new CookieContainer();
        Boolean AllowAutoRedirect = true;
        private HttpWebRequest request;
        public String response;
        public String[] blocks;

        public Web(String URL)
        {
            request = (HttpWebRequest)WebRequest.Create(URL);
            response = "";
        }

        public Web Get()
        {
            try
            {
                request.Method = "GET";
                request.UserAgent = UA;
                request.AllowAutoRedirect = AllowAutoRedirect;
                request.CookieContainer = CC;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder output = new StringBuilder();
                output.Append(reader.ReadToEnd());
                this.response = output.ToString();
                foreach (Cookie c in response.Cookies)
                    CC.Add(c);
                return this;
            }
            catch { return this; }
        }

        public Web Post(Dictionary<String,String> post_array)
        {
            try
            {
                request.Method = "POST";
                request.AllowAutoRedirect = AllowAutoRedirect;
                request.CookieContainer = CC;
                List<String> kva = new List<String>();
                foreach (String k in post_array.Keys)
                    kva.Add(k + "=" + post_array[k]);
                byte[] PD = Encoding.ASCII.GetBytes(String.Join("&", kva.ToArray()));
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = UA;
                request.ContentLength = PD.Length;
                request.GetRequestStream().Write(PD, 0, PD.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder output = new StringBuilder();
                output.Append(reader.ReadToEnd());
                this.response = output.ToString();
                foreach (Cookie c in response.Cookies)
                    CC.Add(c);
                return this;
            }
            catch { return this; }
        }

        public Web Post(String post_string)
        {
            try
            {
                request.Method = "POST";
                byte[] PD = Encoding.ASCII.GetBytes(post_string);
                request.ContentType = "application/x-www-form-urlencoded";
                request.UserAgent = UA;
                request.ContentLength = PD.Length;
                request.GetRequestStream().Write(PD, 0, PD.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                StringBuilder output = new StringBuilder();
                output.Append(reader.ReadToEnd());
                this.response = output.ToString();
                return this;
            }
            catch { return this; }
        }

        public String[] Parse(String pattern, String exclude = "", int PG = 1)
        {
            List<String> L = new List<String>();
            if (exclude.Length > 0)
                response = Regex.Replace(response, exclude, "");
            foreach (Match match in new Regex(pattern).Matches(response))
                L.Add(match.Groups[PG].Value);
            return L.ToArray();
        }

        public void SplitOnBlocks(String SplitPattern)
        {
            blocks = Regex.Split(response, SplitPattern);
        }

        public String[] ParseBlocks(String pattern, String exclude = "", int PG = 1)
        {
            List<String> L = new List<String>();
            foreach(String b in blocks)
            {
                if (exclude.Length > 0 && b.Contains(exclude))
                    continue;
                foreach (Match match in new Regex(pattern).Matches(b))
                    L.Add(match.Groups[PG].Value);
            }
            return L.ToArray();
        }

        /**
         *  0   - SELL Aray
         *  1   - BUY  Array
         *  2,0 - Best Sell
         *  2,0 - Best Buy
         * */
        public static int[][] GetInfoFromPwCats(String server, int item, String CharName)
        {
            List<int> SM = new List<int>();
            List<int> BM = new List<int>();
            Web w = new Web("https://pwcats.info/" + server + "/" + item).Get();
            w.SplitOnBlocks("</tr>");
            foreach (String rr in w.ParseBlocks("<td class=\"sell[^\"]*\">([0-9 ]+)</td>", CharName))
                try { SM.Add(Convert.ToInt32(rr.Replace(" ", "").Trim())); }
                catch(Exception e) { Logging.Log("ERROR: " + e.ToString());  continue; }
            foreach (String rr in w.ParseBlocks("<td class=\"buy[^\"]*\">([0-9 ]+)</td>", CharName))
                try { BM.Add(Convert.ToInt32(rr.Replace(" ", "").Trim())); }
                catch (Exception e) { Logging.Log("ERROR: " + e.ToString()); continue; }
            int[][] RA = new int[3][];
            try
            {
                RA[0] = SM.ToArray();
                RA[1] = BM.ToArray();
                RA[2] = new int[] { SM.Count > 1 ? SM.Min() : (SM.Count > 0 ? SM.First<int>() : -1), BM.Count > 1 ? BM.Max() : (BM.Count > 0 ? BM.First<int>() : -1) };
                return RA;
            }
            catch { return RA; }
        }
    }
}
