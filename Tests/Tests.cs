using NUnit.Framework;
using System.IO;
using sqlite3_analyzer_toObject;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var fileContent = File.ReadAllText("./Output.txt");
            var ret = new sqlite3_analyzer_Object(fileContent);

            Assert.AreEqual(ret.DataBase.SizeBytes, 3231744);            

            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "LOGS").Percentaje, 45.5);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "SQLITEANALYZEREXECS").Percentaje,23.2);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "WORDS").Percentaje,22.1);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "USERPROFILEDATAS").Percentaje,3.4);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "USERWORDREQUESTS").Percentaje,3.3);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "PRICES").Percentaje,0.89);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "FILESIZEMBS").Percentaje,0.63);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "USERS").Percentaje,0.38);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "__EFMIGRATIONSHISTORY").Percentaje,0.25);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "LOGTYPES").Percentaje,0.13);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x=>x.Name== "SQLITE_SCHEMA").Percentaje,0.13);
            Assert.AreEqual(ret.Tables.FirstOrDefault(x => x.Name == "SQLITE_SEQUENCE").Percentaje, 0.13);


        }
    }
}