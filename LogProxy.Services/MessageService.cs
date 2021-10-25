using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LogProxy.Models;
using LogProxy.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LogProxy.Services
{
    public class MessageService : IMessageService
    {
        private readonly IConfiguration _configuration;

        private string _key { get; set; }
        private string _auth { get; set; }

        public MessageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration.GetSection("RequestData").GetSection("ApiKey").Value;
            _auth = _configuration.GetSection("RequestData").GetSection("AuthType").Value;
        }

        public async Task<RecordList> MessageTransfer(IList<Message> messages)
        {
            try
            {
                if (messages == null)
                {
                    return null;
                }

                var uri = this._configuration.GetSection("RequestData").GetSection("PostUri").Value;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_auth, _key);
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                    var outer = PrepareData(messages);
                    
                    var json = JsonConvert.SerializeObject(outer);

                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(uri, data);
                    var contents = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<RecordList>(contents);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
        }

        

        public async Task<RecordList> GetMessages()
        {
            try
            {
                var uri = this._configuration.GetSection("RequestData").GetSection("GetUri").Value;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_auth, _key);
                    HttpResponseMessage response = await client.GetAsync(uri);
                    var contents = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<RecordList>(contents);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
            
        }

        private InData PrepareData(IList<Message> messages)
        {
            var records = new InData();
            foreach (var messagesItem in messages)
            {
                var rec = new InRecord
                {
                    fields = ConvertMessage(messagesItem)
                };
                records.records.Add(rec);
            }

            return records;
        }

        private OuterMessage ConvertMessage(IMessage message)
        {
            if (message == null)
            {
                return null;
            }

            return new OuterMessage
            {
                id = "1",
                Summary = message.Title,
                Message = message.Text,
                receivedAt = DateTimeOffset.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ssZ")
            };
        }

    }
}
