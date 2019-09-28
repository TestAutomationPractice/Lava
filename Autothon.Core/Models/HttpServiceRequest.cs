using Autothon.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Models
{
	public class HttpServiceRequest
	{
		public string Action { get; set; }
		public object Body { get; set; }
		public Dictionary<string, string> QueryStringParameters { get; set; }
		public Dictionary<string, string> Headers { get; set; }
		public CookieCollection CookieJar { get; set; }
		public Method MethodType { get; set; }
		public int Timeout { get; set; }
		public ContentType ContentType { get; set; }
		public string Url { get; set; }

		public HttpServiceRequest(string action, object body, Dictionary<string, string> queryStringParameters = null, Dictionary<string, string> headers = null, CookieCollection cookieJar = null, Method methodType = Method.POST, int timeout = 100000, ContentType contentType = ContentType.Json)
		{
			Action = action;
			Body = body;
			QueryStringParameters = queryStringParameters;
			Headers = headers ?? new Dictionary<string, string>();
			CookieJar = cookieJar ?? new CookieCollection();
			MethodType = methodType;
			Timeout = timeout;
			ContentType = contentType;
		}

		public HttpServiceRequest(string url, string action, object body, Dictionary<string, string> queryStringParameters = null,
								  Dictionary<string, string> headers = null, CookieCollection cookieJar = null,
								  Method methodType = Method.POST, int timeout = 100000,
								  ContentType contentType = ContentType.Json) 
		{
			Action = action;
			Body = body;
			QueryStringParameters = queryStringParameters;
			Headers = headers ?? new Dictionary<string, string>();
			CookieJar = cookieJar ?? new CookieCollection();
			MethodType = methodType;
			Timeout = timeout;
			ContentType = contentType;
			Url = url;
		}
public override string ToString()
		{
			return $"{nameof(Action)}: {Action}, " +
					$"{nameof(Body)}: {Body}, " +
					$"{nameof(QueryStringParameters)}: {QueryStringParameters}, " +
					$"{nameof(Headers)}: {Headers}, " +
					$"{nameof(CookieJar)}: {CookieJar}, " +
					$"{nameof(MethodType)}: {MethodType}, " +
					$"{nameof(Timeout)}: {Timeout}, " +
					$"{nameof(ContentType)}: {ContentType}";
		}
	}
}
