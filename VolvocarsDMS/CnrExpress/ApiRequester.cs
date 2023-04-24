using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using VolvocarsDMS.Common;
using System;
using System.Net.Http.Json;
using System.IO;
using DevExpress.DataAccess.Native.Web;
using RestSharp;

namespace VolvocarsDMS
{
    internal class ApiRequester
    {


        public static bool Get(string Caption, string UriRoute, JObject Parameter, out DataTable? dt)
        {
            #region Variable
            string ParameterContent = string.Empty;

            HttpClient? httpClient;
            HttpResponseMessage? httpResponseMessage;
            string? ResponseMessage;

            JObject? ResponseData;
            string? statusCode;
            string? resultCode;
            string? result;
            string? results;

            #endregion

            #region Init
            dt = null;


            SetLog("Url", Sessions.ApiServer + UriRoute);
            #endregion

            #region Parameter
            if (Parameter != null)
            {
                if (Parameter.Count > 0)
                {
                    foreach (var item in Parameter)
                    {
                        ParameterContent += "&" + item.Key + "=" + item.Value;
                    }

                    ParameterContent = string.Concat("?", ParameterContent.AsSpan(1));
                }
            }

            SetLog("Request", ParameterContent);
            #endregion

            #region Request
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Api-Key", "afaaf7250386f5eddad6ae34e4a55e95a65beb");
            SetLog("Header", "Api-Key: afaaf7250386f5eddad6ae34e4a55e95a65beb");

            if (Sessions.Token != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Sessions.Token);

                SetLog("Header", "Token: Bearer " + Sessions.Token);
            }

            httpClient.Timeout = TimeSpan.FromMinutes(30);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpResponseMessage = httpClient.GetAsync(Sessions.ApiServer + UriRoute + ParameterContent).Result;
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, httpResponseMessage.StatusCode.ToString());
                return false;
            }
            #endregion

            #region Response
            ResponseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (ResponseMessage == null || ResponseMessage == "")
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, "응답 메세지가 없습니다.");
                return false;
            }
            SetLog("Response", ResponseMessage);

            ResponseData = JObject.Parse(ResponseMessage);
            if (ResponseData == null)
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, "응답 메세지를 JSON 형식으로 변환하지 못하였습니다.");
                return false;
            }

            statusCode = ResponseData["statusCode"]?.ToString();
            resultCode = ResponseData["resultCode"]?.ToString();
            result = ResponseData["result"]?.ToString();

            if (statusCode != "200")
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, statusCode + ", " + resultCode);
                return false;
            }
            #endregion

            #region Data
            if (result != null && result != "")
            {
                if (Sessions.Token != null)
                {
                    JObject? Datas = JObject.Parse(result);
                    results = Datas["data"]?.ToString().Trim();

                    if (results != null)
                    {
                        dt = JsonConvert.DeserializeObject<System.Data.DataTable>(results);
                    }
                }
                else
                {
                    result = "[" + result + "]";

                    dt = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                }

                if (dt == null)
                {
                    MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, "응답 메세지를 DATATABLE 형식으로 변환하지 못하였습니다.");
                    return false;
                }
            }
            #endregion

            #region Return

            return true;

            #endregion
        }

        public static bool Post(string Caption, string UriRoute, JObject Parameter, out DataTable? dt, out DataSet? ds)
        {
            #region Variable
            StringContent? ParameterContent;

            HttpClient? httpClient;
            HttpResponseMessage? httpResponseMessage;
            string? ResponseMessage;

            JObject? ResponseData;
            string? statusCode;
            string? resultCode;
            string? result;
            string? results;

            #endregion

            #region Init
            dt = null;
            ds = null;

            SetLog("Url", Sessions.ApiServer + UriRoute);
            #endregion

            #region Parameter
            ParameterContent = new StringContent(Parameter.ToString(), Encoding.UTF8, "application/json");

            SetLog("Request", Parameter.ToString());
            #endregion

            #region Request
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Api-Key", "afaaf7250386f5eddad6ae34e4a55e95a65beb");
            SetLog("Header", "Api-Key: afaaf7250386f5eddad6ae34e4a55e95a65beb");

            if (Sessions.Token != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Sessions.Token);

                SetLog("Header", "Token: Bearer " + Sessions.Token);
            }

            httpClient.Timeout = TimeSpan.FromMinutes(30);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpResponseMessage = httpClient.PostAsync(Sessions.ApiServer + UriRoute, ParameterContent).Result;
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, httpResponseMessage.StatusCode.ToString());
                return false;
            }
            #endregion

            #region Response
            ResponseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
            if (ResponseMessage == null || ResponseMessage == "")
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, "응답 메세지가 없습니다.");
                return false;
            }
            SetLog("Response", ResponseMessage);

            ResponseData = JObject.Parse(ResponseMessage);
            if (ResponseData == null)
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, "응답 메세지를 JSON 형식으로 변환하지 못하였습니다.");
                return false;
            }

            statusCode = ResponseData["statusCode"]?.ToString();
            resultCode = ResponseData["resultCode"]?.ToString();
            result = ResponseData["result"]?.ToString();

            if (statusCode != "200")
            {
                MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, statusCode + ", " + resultCode);
                return false;
            }
            #endregion

            #region Data
            if (result!= null && result != "")
            {
                if (Sessions.Token != null)
                {
                    JObject? Datas = JObject.Parse(result);
                    results = Datas["data"]?.ToString().Trim();

                    if (results != null)
                    {
                        dt = JsonConvert.DeserializeObject<System.Data.DataTable>(results);
                    }


                    string data_master = Datas["data_master"]?.ToString().Trim();
                    if (data_master != null)
                    {
                        //ds = JsonConvert.DeserializeObject<System.Data.DataSet>(data_master);
                    }
                }
                else
                {
                    result = "[" + result + "]";

                    dt = JsonConvert.DeserializeObject<System.Data.DataTable>(result);
                }

                if (dt == null)
                {
                    MessageboxHelper.Error(MethodBase.GetCurrentMethod()?.DeclaringType?.Name, MethodBase.GetCurrentMethod()?.Name, Caption, "응답 메세지를 DATATABLE 형식으로 변환하지 못하였습니다.");
                    return false;
                }
            }
            #endregion

            #region Return

            return true;

            #endregion
        }

        private static void SetLog(string Factor, string Value)
        {
            if (Sessions.IsApiLog != null && (bool)Sessions.IsApiLog && Sessions.MainForm != null)
            {
                if (Factor == "Url")
                {
                    Sessions.MainForm.SetLogApiUrl(Value);
                }
                else if (Factor == "Header")
                {
                    Sessions.MainForm.SetLogApiHeader(Value);
                }
                else if (Factor == "Request")
                {
                    Sessions.MainForm.SetLogApiRequest(Value);
                }
                else if (Factor == "Response")
                {
                    Sessions.MainForm.SetLogApiResponse(Value);
                }
            }
        }
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }

    public class ReturnValue
    {
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public DataTable? Data { get; set; }

        public ReturnValue()
        {
            ReturnCode = 0;
            ReturnMessage = string.Empty;
            Data = null;
        }
    }
}
