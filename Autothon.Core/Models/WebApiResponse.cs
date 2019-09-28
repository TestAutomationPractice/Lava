using Autothon.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Models
{
	public class WebApiResponse
	{

		public object Data { get; set; }
		public bool Success { get; set; }
		public List<ErrorCodeResponse> Errors { get; set; }

		public override string ToString()
		{
			if (Success)
			{
				return $"Success: {Success} Data: {Data}";
			}
			else
			{
				StringBuilder sb = new StringBuilder();

				if (Errors != null)
				{
					Errors.ForEach(error => sb.Append(error.ToString()));
				}

				return string.Format("Success: {0} Data: {1}", Success, sb);
			}
		}

		public void Validate(object payload)
		{
			if (!Success || Errors?.Count > 0)
			{
				throw new WebApiException(this, payload);
			}
		}
	}
}

