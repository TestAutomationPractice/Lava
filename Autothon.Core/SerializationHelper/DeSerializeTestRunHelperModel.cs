using System.Collections.Generic;
using System.Xml.Serialization;

namespace Autothon.Core.SerializationHelper
{
    public class DeSerializeTestRunHelperModel
    {
        [XmlRoot(ElementName = "filter")]
        public class Filter
        {
            [XmlElement(ElementName = "cat")]
            public string Cat { get; set; }
        }

        [XmlRoot(ElementName = "property")]
        public class Property
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }

        [XmlRoot(ElementName = "properties")]
        public class Properties
        {
            [XmlElement(ElementName = "property")]
            public List<Property> Property { get; set; }
        }

        [XmlRoot(ElementName = "test-case")]
        public class TestCase
        {
            [XmlElement(ElementName = "properties")]
            public Properties Properties { get; set; }
            [XmlAttribute(AttributeName = "duration")]
            public string Duration { get; set; }
            [XmlAttribute(AttributeName = "end-time")]
            public string Endtime { get; set; }
            [XmlAttribute(AttributeName = "start-time")]
            public string Starttime { get; set; }
            [XmlAttribute(AttributeName = "asserts")]
            public string Asserts { get; set; }
            [XmlAttribute(AttributeName = "result")]
            public string Result { get; set; }
            [XmlAttribute(AttributeName = "fullname")]
            public string Fullname { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "runstate")]
            public string Runstate { get; set; }
            [XmlAttribute(AttributeName = "classname")]
            public string Classname { get; set; }
            [XmlAttribute(AttributeName = "seed")]
            public string Seed { get; set; }
            [XmlAttribute(AttributeName = "methodname")]
            public string Methodname { get; set; }
        }

        [XmlRoot(ElementName = "test-suite")]
        public class TestSuite
        {
            [XmlElement(ElementName = "properties")]
            public Properties Properties { get; set; }
            [XmlElement(ElementName = "test-case")]
            public List<TestCase> Testcase { get; set; }
            [XmlAttribute(AttributeName = "duration")]
            public string Duration { get; set; }
            [XmlAttribute(AttributeName = "end-time")]
            public string Endtime { get; set; }
            [XmlAttribute(AttributeName = "start-time")]
            public string Starttime { get; set; }
            [XmlAttribute(AttributeName = "asserts")]
            public string Asserts { get; set; }
            [XmlAttribute(AttributeName = "skipped")]
            public string Skipped { get; set; }
            [XmlAttribute(AttributeName = "inconclusive")]
            public string Inconclusive { get; set; }
            [XmlAttribute(AttributeName = "failed")]
            public string Failed { get; set; }
            [XmlAttribute(AttributeName = "passed")]
            public string Passed { get; set; }
            [XmlAttribute(AttributeName = "total")]
            public string Total { get; set; }
            [XmlAttribute(AttributeName = "result")]
            public string Result { get; set; }
            [XmlAttribute(AttributeName = "testcasecount")]
            public string Testcasecount { get; set; }
            [XmlAttribute(AttributeName = "fullname")]
            public string Fullname { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
            [XmlAttribute(AttributeName = "warnings")]
            public string Warnings { get; set; }
            [XmlAttribute(AttributeName = "runstate")]
            public string Runstate { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
            [XmlAttribute(AttributeName = "classname")]
            public string Classname { get; set; }
        }

        [XmlRoot(ElementName = "test-run")]
        public class TestRun
        {
            [XmlElement(ElementName = "filter")]
            public Filter Filter { get; set; }
            [XmlElement(ElementName = "test-suite")]
            public TestSuite Testsuite { get; set; }
            [XmlAttribute(AttributeName = "duration")]
            public string Duration { get; set; }
            [XmlAttribute(AttributeName = "end-time")]
            public string Endtime { get; set; }
            [XmlAttribute(AttributeName = "start-time")]
            public string Starttime { get; set; }
            [XmlAttribute(AttributeName = "clr-version")]
            public string Clrversion { get; set; }
            [XmlAttribute(AttributeName = "engine-version")]
            public string Engineversion { get; set; }
            [XmlAttribute(AttributeName = "asserts")]
            public string Asserts { get; set; }
            [XmlAttribute(AttributeName = "skipped")]
            public string Skipped { get; set; }
            [XmlAttribute(AttributeName = "inconclusive")]
            public string Inconclusive { get; set; }
            [XmlAttribute(AttributeName = "failed")]
            public string Failed { get; set; }
            [XmlAttribute(AttributeName = "passed")]
            public string Passed { get; set; }
            [XmlAttribute(AttributeName = "total")]
            public string Total { get; set; }
            [XmlAttribute(AttributeName = "result")]
            public string Result { get; set; }
            [XmlAttribute(AttributeName = "testcasecount")]
            public string Testcasecount { get; set; }
            [XmlAttribute(AttributeName = "fullname")]
            public string Fullname { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "id")]
            public string Id { get; set; }
        }

    }
}
