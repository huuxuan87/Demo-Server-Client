using Client.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Helpers
{
    public static class ApiRequestHelper
    {
        public static ApiRequestResult<T> Get<T>(string apiUrl, string resource, object data = null)
        {
            var rs = new ApiRequestResult<T>();
            using (var client = new RestClient(apiUrl))
            {
                var request = new RestRequest(resource, Method.Get);

                if (data != null)
                {
                    request.AddJsonBody(JsonConvert.SerializeObject(data));
                }

                var response = client.Execute(request);
                rs.Response = response;

                if (response.IsSuccessful)
                {
                    var obj = JsonConvert.DeserializeObject<T>(response.Content);
                    rs.Result = obj;
                }
                else
                {
                    rs.Errors = GetErrorResponse(response);
                }
            }
            return rs;
        }

        public static ApiRequestResult<T> Post<T>(string apiUrl, string resource, object data = null)
        {
            var rs = new ApiRequestResult<T>();
            using (var client = new RestClient(apiUrl))
            {
                var request = new RestRequest(resource, Method.Post);

                if (data != null)
                {
                    request.AddJsonBody(JsonConvert.SerializeObject(data));
                }

                var response = client.Execute(request);
                rs.Response = response;

                if (response.IsSuccessful)
                {
                    var obj = JsonConvert.DeserializeObject<T>(response.Content);
                    rs.Result = obj;
                }
                else
                {
                    rs.Errors = GetErrorResponse(response);
                }
            }
            return rs;
        }

        public static ApiRequestResult<T> Put<T>(string apiUrl, string resource, object data = null)
        {
            var rs = new ApiRequestResult<T>();
            using (var client = new RestClient(apiUrl))
            {
                var request = new RestRequest(resource, Method.Put);

                if (data != null)
                {
                    request.AddJsonBody(JsonConvert.SerializeObject(data));
                }

                var response = client.Execute(request);
                rs.Response = response;

                if (response.IsSuccessful)
                {
                    var obj = JsonConvert.DeserializeObject<T>(response.Content);
                    rs.Result = obj;
                }
                else
                {
                    rs.Errors = GetErrorResponse(response);
                }
            }
            return rs;
        }

        public static ApiRequestResult Put(string apiUrl, string resource, object data = null)
        {
            var rs = new ApiRequestResult();
            using (var client = new RestClient(apiUrl))
            {
                var request = new RestRequest(resource, Method.Put);

                if (data != null)
                {
                    request.AddJsonBody(JsonConvert.SerializeObject(data));
                }

                var response = client.Execute(request);
                rs.Response = response;

                if (response.IsSuccessful)
                {
                }
                else
                {
                    rs.Errors = GetErrorResponse(response);
                }
            }
            return rs;
        }

        private static List<string> GetErrorResponse(RestResponse response)
        {
            var lstError = new List<string>();
            var isGetErrorFinish = false;
            if (!string.IsNullOrEmpty(response.Content))
            {
                try
                {
                    var rsError = JsonConvert.DeserializeObject<ApiRequestResult>(response.Content);
                    if (rsError != null && rsError.Errors != null && rsError.Errors.Count > 0)
                    {
                        lstError.AddRange(rsError.Errors);
                        isGetErrorFinish = true;
                    }
                }
                catch (Exception)
                {
                }
            }
            if (!isGetErrorFinish)
            {
                if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    lstError.Add(response.ErrorMessage);
                }
                if (response.ErrorException != null && !string.IsNullOrEmpty(response.ErrorException.Message))
                {
                    lstError.Add(response.ErrorException.Message);
                }
            }
            return lstError;
        }
    }

    #region Model
    
    public class ApiRequestResult<T>
    {
        public RestResponse Response { get; set; }
        public T Result { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public bool IsOk => (Response != null && 200 <= (int)Response.StatusCode && (int)Response.StatusCode < 300);
        public string ErrorMessage
        {
            get
            {
                var rs = "";
                if (Errors != null && Errors.Count > 0)
                {
                    rs += string.Join(", ", Errors);
                }
                return rs;
            }
        }
    }

    public class ApiRequestResult : ApiRequestResult<object>
    {
    }

    #endregion
}
