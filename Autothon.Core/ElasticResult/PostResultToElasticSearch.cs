using System;
using System.Configuration;

namespace Autothon.Core.ElasticResult
{
    public class PostResultToElasticSearch
    {
        Uri uri = new Uri(ConfigurationManager.AppSettings.Get("ElasticURL"));

    }
}
