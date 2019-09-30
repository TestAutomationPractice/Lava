namespace Autothon.Core.Enums
{
    public enum TestTypeEnum
    {
        All,
        Web,
        Mobile,
        API
    }
    public enum Browser
    {
        Chrome,
        FireFox,
        InternetExplorer,
        Remote
    }

	public enum Method
	{
		GET = 0,
		POST = 1,
		PUT = 2,
		DELETE = 3,
		HEAD = 4,
		OPTIONS = 5,
		PATCH = 6,
		MERGE = 7,
		COPY = 8
	}

	public enum ContentType
	{
		Json,
		TextXml,
		CustomXml,
		CustomApplicationXml,
		Form
	}
}
