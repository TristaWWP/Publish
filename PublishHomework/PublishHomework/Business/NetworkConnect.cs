using PublishHomework.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PublishHomework.Utilities;

namespace PublishHomework.Business
{
    public class NetworkConnect
    {
        public async Task<string> PublishHomeworkAsync(PublishInfo info, string fromId, string timestamp)
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false }))
            {
                MultipartFormDataContent content = new MultipartFormDataContent();

                content.Add(new StringContent(info.Categ.SchoolId), "schoolsId");

                content.Add(new StringContent(fromId), "fromId");

                content.Add(new StringContent(timestamp), "timeStamp");

                content.Add(new StringContent(info.Categ.ClassId), "classesId");

                content.Add(new StringContent(((int)info.Categ.Subject).ToString()), "course");
                string sign = Md5Helper.GetMD5Sign(info.Categ.SchoolId, info.Categ.ClassId, fromId, timestamp);
                content.Add(new StringContent(sign), "sign");
                try
                {
                    foreach (var t in info.Pictures)
                    {
                        string imagePath = t.Replace(@"file:///", string.Empty);
                        var fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        var fileContent = new StreamContent(fileStream);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                        var fileName = Path.GetFileName(imagePath);
                        content.Add(fileContent, "homework[]", fileName);
                    }
                    var response = await client.PostAsync(info.ServerAddress, content).ConfigureAwait(false);
                    var temp = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonHelper.ConvertJson(temp);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return string.Empty;
                }
            }
        }
    }
}
