using Autothon.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Models
{
	public class HttpRequest : HttpServiceRequest
	{
		public string Url { get; set; }

		public HttpRequest(string url, string action, object body, Dictionary<string, string> queryStringParameters = null,
								  Dictionary<string, string> headers = null, CookieCollection cookieJar = null,
								  Method methodType = Method.POST, int timeout = 100000,
								  ContentType contentType = ContentType.Json) : base(action, body, queryStringParameters, headers, cookieJar, methodType, timeout, contentType)
		{
			Url = url;
		}

		public HttpRequest(string url, HttpServiceRequest request) : this(url, request.Action, request.Body, request.QueryStringParameters, request.Headers, request.CookieJar, request.MethodType, request.Timeout, request.ContentType)
		{

		}

		public override string ToString()
		{
			return $"{nameof(Url)}: {Url}, " + base.ToString();
		}
	}
}
