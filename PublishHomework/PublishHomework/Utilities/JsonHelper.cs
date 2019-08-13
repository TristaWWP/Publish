using Newtonsoft.Json;

namespace PublishHomework.Utilities
{
    public class ResponseJson
    {
        public string retCode { get; set; }
        public string retMessage { get; set; }
    }
    public static class JsonHelper
    {
        public static string ConvertJson(string strJson)
        {
            ResponseJson tmp = JsonConvert.DeserializeObject<ResponseJson>(strJson);
            return tmp.retMessage;
        }
    }
}
