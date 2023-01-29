using HttpsFrontWinForms.Http;
using System;
using System.Net.Http.Headers;
using System.Net;
using System.Text;

namespace HttpsFrontWinForms.Model.AppService
{
    public class ShohinAppService
    {
        private HttpPort httpPort = new HttpPort();

        private static HttpClient? httpClient;
        private HttpSetting settings = new HttpSetting();
        private bool Fauthentication = true; // 認証済みOK/NG
        private string CONTENT_TYPE = @"application/json";
        private HttpStatusCode lastStatusCode;
        private HttpResponseHeaders? lastHeaders;
        private string lastBody = "";

        public ShohinAppService(HttpClient client)
        {
            httpClient = client;
        }

        public async Task<HttpResponseMessage> HttpGet(string uriStr)
        {
            var res = await httpPort.HttpRequest(HttpMethod.Get, uriStr, @"dummy text");
            //JsonData = await httpClient!.GetStringAsync(uri);
            await SetLastStatus(res);

            return res;
        }

        public async Task HttpPost(string uriStr, string content)
        {
            var res = await httpPort.HttpRequest(HttpMethod.Post, uriStr, content);
            await SetLastStatus(res);
        }

        public async Task HttpPut(string uriStr, string content)
        {
            var res = await httpPort.HttpRequest(HttpMethod.Put, uriStr, content);
            await SetLastStatus(res);
        }

        public async Task HttpDelete(string uriStr, string content)
        {
            var res = await httpPort.HttpRequest(HttpMethod.Delete, uriStr, content);
            await SetLastStatus(res);
        }

        private async Task SetLastStatus(HttpResponseMessage response)
        {
            lastStatusCode = response.StatusCode;
            lastHeaders = response.Headers;
            lastBody = await response.Content.ReadAsStringAsync();
        }

        public string CreateJsonStr(string code, string name, string remarks)
        {
            var builder = new StringBuilder();
            
            builder.Append("{ \"shohinCode\":");
            builder.Append(code);
            builder.Append(", \"shohinName\": \"");
            builder.Append(name);
            builder.Append("\", \"note\": \"");
            builder.Append(remarks);
            builder.Append("\" }");

            return builder.ToString();
        }

        /*private async Task<HttpResponseMessage> HttpRequest(HttpMethod method, string uriStr, string content)
        {
            var uri = new Uri(uriStr);
            var response = new HttpResponseMessage();
            //string resStr = "";

            response = await httpClient!.SendAsync(RequestSetting(method, uri, content));

            lastStatusCode = response.StatusCode;
            lastHeaders = response.Headers;
            lastBody = await response.Content.ReadAsStringAsync();

            //if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.NoContent)
            //{
            //    resStr = await response.Content.ReadAsStringAsync();
            //    richTextBox1.AppendText(response.Headers.ToString());
            //}
            //else
            //{
            //    switch (response.StatusCode)
            //    {
            //        case HttpStatusCode.Unauthorized: // 認証が必要
            //            richTextBox1.AppendText(response.Headers.ToString());
            //            new FormAuth().ShowDialog();
            //            Fauthentication = true;
            //            response = await httpClient.SendAsync(RequestSetting(method, uri, content));
            //            if (response.StatusCode == HttpStatusCode.Unauthorized)
            //            {
            //                Authentication.UserID = "";
            //                Authentication.Password = "";
            //                Fauthentication = false;
            //                MessageBox.Show(response.Headers.ToString(), "認証に失敗しました。");
            //            }
            //            else
            //            {
            //                resStr = await response.Content.ReadAsStringAsync();
            //                richTextBox1.AppendText(response.Headers.ToString());
            //            }
            //            break;
            //        case HttpStatusCode.BadRequest:
            //            resStr = await response.Content.ReadAsStringAsync();
            //            richTextBox1.AppendText(response.Headers.ToString());
            //            break;
            //        default: //その他のエラー
            //            MessageBox.Show(response.Headers.ToString(), response.StatusCode.ToString());
            //            break;
            //    }
            //}
            //textBoxReqBody.Text = resStr;

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
        }*/

        public HttpStatusCode LastStatusCode
        {
            get => lastStatusCode;
        }
        public HttpResponseHeaders LastHeaders
        {
            get => lastHeaders!;
        }
        public string LastBody
        {
            get => lastBody;
        }
    }
}