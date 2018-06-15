using System;
using System.Net;
using Newtonsoft.Json;

namespace LineBotLibrary
{
    public class LineLiff
    {
        //2018-05-10
        //authkey: authkey
        //size: full, tall, compact
        //url: Any HTTPS URL
        //Use: line://app/{liffId}
        
        public string AddLiffId(string authkey, string size, string url)
        {
            string apiurl = "https://api.line.me/liff/v1/apps";
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", "Bearer " + authkey);
                wc.Headers.Set("Content-Type", "application/json");

                View lv = new View();
                lv.type = size; //full, tall, compact
                lv.url = url;

                View2 lv2 = new View2();
                lv2.view = lv;

                string json = JsonConvert.SerializeObject(lv2);

                wc.Encoding = System.Text.Encoding.UTF8;
                string state = wc.UploadString(apiurl, json);
                LiffViewReceive m = JsonConvert.DeserializeObject<LiffViewReceive>(state);

                return m.liffId;
            }

        }

        public string UpdateLiff(string liffid, string authkey, string size, string url)
        {
            string apiurl = string.Format("https://api.line.me/liff/v1/apps/{0}/view", liffid);
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", "Bearer " + authkey);
                wc.Headers.Set("Content-Type", "application/json");

                View lv = new View();
                lv.type = size;
                lv.url = url;

                string json = JsonConvert.SerializeObject(lv);

                wc.Encoding = System.Text.Encoding.UTF8;
                string state = wc.UploadString(apiurl,"PUT", json);

                return state;
            }
        }

        public string GetLiff(string authkey)
        {
            string apiurl = "https://api.line.me/liff/v1/apps";
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", "Bearer " + authkey);
                wc.Encoding = System.Text.Encoding.UTF8;
                string state = wc.DownloadString(apiurl);
                GetAllLiff m = JsonConvert.DeserializeObject<GetAllLiff>(state);
              
                return state;
            }

        }

        public string DelLiff(string liffid, string authkey)
        {
            string apiurl = string.Format("https://api.line.me/liff/v1/apps/{0}",liffid );
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", "Bearer " + authkey);
                wc.Encoding = System.Text.Encoding.UTF8;
                string state = wc.UploadString(apiurl, "DELETE", "");
                return state;
            }
           
        }
    }
}
