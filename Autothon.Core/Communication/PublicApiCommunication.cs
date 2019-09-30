using Autothon.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autothon.Core.Communication
{
	class PublicApiCommunication
	{
		public T SendRequestAndDeserializeData<T>(HttpServiceRequest request)
		{
			WebApiResponse response = SendRequest(request);

			Type castType = typeof(T);

			if (castType.IsPrimitive || castType == typeof(String) || castType == typeof(string))
			{
				return (T)Convert.ChangeType(response.Data.ToString(), typeof(T));
			}
			else
			{
				return JsonConvert.DeserializeObject<T>(response.Data?.ToString());
			}
		}

		private WebApiResponse SendRequest(HttpServiceRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
