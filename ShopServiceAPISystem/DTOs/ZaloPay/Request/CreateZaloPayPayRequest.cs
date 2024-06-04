using DTOs.ZaloPay.Response;
using ShopServiceAPISystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.ZaloPay.Request
{
    public class CreateZaloPayPayRequest
    {
        public CreateZaloPayPayRequest(int appId, string appUser, string appTransId, long appTime, long amount, string description, string embedData, string bankCode, string mac)
        {
            AppId = appId;
            AppUser = appUser;
            AppTransId = appTransId;
            AppTime = appTime;
            Amount = amount;
            Description = description;
            EmbedData = embedData;
            BankCode = bankCode;
            Mac = mac;
        }

            public int AppId { get; set; }
            public string AppUser { get; set; } = string.Empty;
            public string AppTransId { get; set; } = string.Empty;
            public long AppTime { get; set; }
            public long Amount { get; set;}
            public string Item { get; set; }
            public string Description { get; set; } = string.Empty;
            public string EmbedData { get; set; } = string.Empty;
            public string BankCode { get; set; } = string.Empty;
            public string Mac { get; set; } = string.Empty;
        
        public void MakeSignature(string key)
        {   
            var data= AppId + "|" + AppTransId + "|" + AppUser + "|" + Amount + "|" + AppTime + "|" + EmbedData + "|" + Item;
            this.Mac = HashHelper.HmacSHA256(data, key);
        }

        public Dictionary<string,string> GetContent()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string,string>();

            keyValuePairs.Add("appid", AppId.ToString());
            keyValuePairs.Add("appuser", AppUser);
            keyValuePairs.Add("apptransid", AppTransId);
            keyValuePairs.Add("apptime", AppTime.ToString());
            keyValuePairs.Add("amount", Amount.ToString());
            keyValuePairs.Add("item", Item);
            keyValuePairs.Add("description", Description);
            keyValuePairs.Add("bankcode", "zalopayapp");
            keyValuePairs.Add("mac", Mac);

            return keyValuePairs;
        }

        //public (bool, string) GetLink(string paymentUrl)
        //{
        //    using var client = new HttpClient();
        //    var content = new FormUrlEncodedContent(GetContent());
        //    var response = client.PostAsync(paymentUrl, content).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseContent = response.Content.ReadAsStringAsync().Result;
        //        var responseData = JsonConvert.DeserializeObject<CreateZaloPayPayResponse>(responseContent);
        //        if (responseData.resultCode == 1)
        //        {
        //            return (true, responseData.payUrl);
        //        }
        //        else
        //        {
        //            return(false, responseData.message);
        //        }
        //    }
        //}
    }
}
