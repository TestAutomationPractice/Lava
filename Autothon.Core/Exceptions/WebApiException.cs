using Autothon.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Exceptions
{
	
		public class WebApiException : Exception
		{
			private string ErrorMessage { get; set; } = string.Empty;

			public WebApiException()
			{
			}

			public WebApiResponse ApiResponse { get; }
			public List<ErrorCodeResponse> Errors { get; set; }

			public WebApiException(string message) : base(message)
			{
			}

			public WebApiException(string message, Exception innerException) : base(message, innerException)
			{
			}

			protected WebApiException(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}

			public WebApiException(WebApiResponse response, object request) : base()
			{
				ApiResponse = response;
				ErrorMessage = ApiResponse.ToString();

				if (request != null)
				{
					ErrorMessage += $"\nPayLoad: {JsonConvert.SerializeObject(request)}";
				}
			}

			public WebApiException(List<ErrorCodeResponse> errors, object request) : base()
			{
				if (errors != null && errors.Count > 0)
				{
					errors.ForEach(x => ErrorMessage += x.ToString());
					Errors = errors;
				}
				if (request != null)
				{
					ErrorMessage += $"\nPayLoad: {JsonConvert.SerializeObject(request)}";
				}

			}

			public override string Message
			{
				get
				{
					return base.Message + ErrorMessage;
				}
			}
		
	}
}
