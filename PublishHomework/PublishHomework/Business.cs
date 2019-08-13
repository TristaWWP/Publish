using Cvte.EasiNote;
using Cvte.Net.WebServices;
using PublishHomework.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PublishHomework
{
    //public static class Business
    //{
    //    public static async Task<PublishHomeworkResponse> PublishHomeworkAsync(PublishInfo info)
    //    {
    //        // PublishHomeworkRequest request = new PublishHomeworkRequest(info);
    //        // WebService service = new WebService();

    //        //var response = await service.PostAsync<PublishHomeworkResponse>(request);
    //        //return response;

    //        using (HttpClient client = new HttpClient(new HttpClientHandler() { UseCookies = false }))
    //        {
    //            string boundary = "--------------------------298450531353667036191391";
    //            MultipartFormDataContent content = new MultipartFormDataContent(boundary);
    //            content.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

    //            var response = await client.PostAsync(info.ServerAddress, content);
    //            return response;
    //        }
            
    //    }
    //}
}
