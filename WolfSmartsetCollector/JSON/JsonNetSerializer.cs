using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace WolfSmartsetCollector.JSON
{
    public class JsonNetSerializer : IRestSerializer
    {
        public Func<Type, JsonSerializerSettings> SerializerSettingsFactory { get; private set; }
        public JsonNetSerializer(Func<Type, JsonSerializerSettings> serializerFactory)
        {
            SerializerSettingsFactory = serializerFactory;
        }
        public string Serialize(object obj) =>
            JsonConvert.SerializeObject(obj);

        public string Serialize(RestSharp.Parameter bodyParameter) =>
            JsonConvert.SerializeObject(bodyParameter.Value);

        public T Deserialize<T>(IRestResponse response) =>
            JsonConvert.DeserializeObject<T>(response.Content, SerializerSettingsFactory?.Invoke(typeof(T)));

        public string[] SupportedContentTypes { get; } =
        {
                "application/json", "text/json", "text/x-json", "text/javascript", "*+json"
            };

        public string ContentType { get; set; } = "application/json";

        public DataFormat DataFormat { get; } = DataFormat.Json;
    }

}
