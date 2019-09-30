using Autothon.Core.Enums;
using Autothon.Core.Exceptions;
using Autothon.Core.Models;
using Newtonsoft.Json;
using BaseRestSharp = RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Autothon.Core.Communication
{
	/// <summary>
	/// Further info is found on https://github.com/restsharp/RestSharp/
	/// </summary>
	public class HttpManager
	{
		public Task<BaseRestSharp.RestResponse> InvokeCall(HttpServiceRequest httpRequest, bool throwException = true,
												   bool isElasticLog = false, bool invokeAsync = false)
		{
			ServicePointManager.DefaultConnectionLimit = 200;
			// Base URL
			BaseRestSharp.RestClient client = new BaseRestSharp.RestClient(httpRequest.Url);
			BaseRestSharp.IRestResponse response = null;
			Stopwatch watch = new Stopwatch();


			// Method to be triggered
			BaseRestSharp.RestRequest request = new BaseRestSharp.RestRequest(httpRequest.Action, (BaseRestSharp.Method)httpRequest.MethodType) { Timeout = httpRequest.Timeout };

			if (httpRequest.CookieJar != null)
			{
				foreach (Cookie cookie in httpRequest.CookieJar)
				{
					request.AddCookie(cookie.Name, cookie.Value);
				}
			}

			if (httpRequest.Body != null)
			{
				request.RequestFormat = BaseRestSharp.DataFormat.Json;
				request.AddJsonBody(httpRequest.Body);

			}

			if (httpRequest.Headers != null)
			{
				foreach (KeyValuePair<string, string> header in httpRequest.Headers.ToList())
				{

					request.AddHeader(header.Key, header.Value);

				}
			}


			if (httpRequest.QueryStringParameters != null)
			{
				foreach (KeyValuePair<string, string> param in httpRequest.QueryStringParameters.ToList())
				{
					request.AddQueryParameter(param.Key, param.Value);
				}
			}

			watch.Start();

			BaseRestSharp.RestResponse customRestResponse = null;
			TaskCompletionSource<BaseRestSharp.RestResponse> taskCompletionSource = new TaskCompletionSource<BaseRestSharp.RestResponse>();


			response = client.Execute(request);
			watch.Stop();

			taskCompletionSource.SetResult(customRestResponse);

			ResponseVerifications(response, throwException, httpRequest.Url, httpRequest.MethodType);


			return taskCompletionSource.Task;
		}

		private void ResponseVerifications(BaseRestSharp.IRestResponse response, bool throwException, string url, Enums.Method methodType)
		{
			// end of index logic
			if (throwException)
			{
				if (response.ErrorException != null)
				{
					throw response.ErrorException;
				}
			}

			if (!IsRequestStatusCodeSuccess(response.StatusCode))
			{
				switch (response.StatusCode)
				{
					case HttpStatusCode.NotFound:
						throw new WebApiException($"{url} has thrown status code : {response.StatusCode}. Please check that you have spelled the url correctly");
					case HttpStatusCode.InternalServerError:
						throw new WebApiException($"{url} has thrown status code : {response.StatusCode}.{response.ErrorMessage} Content :{response.Content}");
					case HttpStatusCode.MethodNotAllowed:
						throw new WebApiException($"{url} has thrown status code : {response.StatusCode}. {methodType} verb is not supported. Change the method type to a supported one");
					default:
						throw new WebApiException($"{url} has thrown status code : {response.StatusCode} {response.ErrorMessage} {response.Content}");
				}
			}
		}

		private bool IsRequestStatusCodeSuccess(HttpStatusCode statusCode)
		{
			return ((int)statusCode >= 200) && ((int)statusCode < 300);
		}

	}
}
