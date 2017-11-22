using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace JsonNetAbstractClass
{
    [TestFixture]
    public class CollectionFixture
    {
        [Test]
        public void GetObjectData_JsonSerialization_ValidString()
        {
            const string expectedJson =
                "{" +
                    "\"Children\":" +
                    "{" +
                        "\"$type\":\"JsonNetAbstractClass.BaseClass[], DesktopJsonNetAbstractClass\"," +
                        "\"$values\":[" +
                            "{" +
                                "\"$type\":\"JsonNetAbstractClass.Termination, DesktopJsonNetAbstractClass\"," +
                                "\"Value\":10" +
                            "}," +
                            "{" +
                                "\"$type\":\"JsonNetAbstractClass.Termination, DesktopJsonNetAbstractClass\"," +
                                "\"Value\":20" +
                            "}" +
                        "]" +
                    "}" +
                "}";

            var stringWriter = new StringWriter();
            var collection = new Collection();
            collection.Add(new Termination(10));
            collection.Add(new Termination(20));

            var traceWriter = new MemoryTraceWriter();
            var serializer = JsonSerializer.CreateDefault();
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.TraceWriter = traceWriter;

            try
            {
                serializer.Serialize(stringWriter, collection);
            }
            catch (Exception ex)
            {
                traceWriter.Trace(TraceLevel.Error, "Error trying to serialize object", ex);
                Assert.Fail(traceWriter.ToString());
            }

            Assert.That(stringWriter.ToString(), Is.EqualTo(expectedJson));
        }
    }
}
