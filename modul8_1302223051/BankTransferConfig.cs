using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace modul8_1302223051
{
    public class Config
    {
        public string lang { get; set; }

        public class Transfer
        {
            [JsonPropertyName("threshold")]
            public int threshold { get; set; }
            [JsonPropertyName("low_fee")]
            public int low_fee { get; set; }
            [JsonPropertyName("high_fee")]
            public int high_fee { get; set; }
        }

        public Transfer transfer { get; set; }

        public string[] methods { get; set; }

        public class Confirmation
        {
            [JsonPropertyName("en")]
            public string en { get; set; }
            [JsonPropertyName("id")]
            public string id { get; set; }
        }
        public Confirmation confirmation { get; set; }
    }
    public class BankTransferConfig
    {
        public Config config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                setDefault();
            }
            catch
            {
                setDefault();
                writeConfig();
            }
        }
        public static Config Read()
        {
            string json = File.ReadAllText("bank_transfer_config.json");
            return JsonSerializer.Deserialize<Config>(json);
        }

        private void writeConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        public void setDefault()
        {
            config = new Config
            {
                lang = "en",
                transfer = new Config.Transfer
                {
                    threshold = 25000000,
                    low_fee = 6500,
                    high_fee = 15000
                },
                methods = new string[] { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                confirmation = new Config.Confirmation
                {
                    en = "yes",
                    id = "ya"
                }

            };
        }





    }
}
