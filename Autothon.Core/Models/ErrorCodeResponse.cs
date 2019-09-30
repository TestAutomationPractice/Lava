using System;

namespace Autothon.Core.Models
{
	public class ErrorCodeResponse
	{
		public int ErrorCodeID { get; set; }
		public string Error { get; set; }
		public string Message { get; set; }

		public override string ToString()
		{
			return string.Format("ID : {0} , Error : {1} , Message: {2} " + Environment.NewLine, ErrorCodeID, Error, Message);
		}
	}
}