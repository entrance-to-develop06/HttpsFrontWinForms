using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Mime;
using System.Net;
using System.Text;

namespace HttpsFrontWinForms.Http
{
    public class HttpPort
    {
        private static HttpClient? httpClient;
        private HttpSetting settings = new HttpSetting();
        private bool Fauthentication = true; // 認証済みOK/NG
        private string CONTENT_TYPE = @"application/json";

        public async Task<HttpResponseMessage> HttpRequest(HttpMethod method, string uriStr, string content)
        {
            var uri = new Uri(uriStr);
            var response = new HttpResponseMessage();
            //string resStr = "";

            response = await httpClient!.SendAsync(RequestSetting(method, uri, content));

            

            return response;
        }

        private HttpRequestMessage RequestSetting(HttpMethod method, Uri uri, string content)
        {

            ServicePointManager.SecurityProtocol = settings.SslProtocolVer;
            var request = new HttpRequestMessage();
            request.Method = method;
            request.RequestUri = uri;
            request.Version = settings.HttpVer;
            request.Content = new StringContent(content, Encoding.UTF8, CONTENT_TYPE);
            if (Fauthentication) //プログラムを変更したので常にtrueにしなければならないかも。このフラグは必要ないかも
            {
                string BasicStr = Authentication.BasicRequestHeader();
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", BasicStr);
            }

            return request;
        }
    }
}