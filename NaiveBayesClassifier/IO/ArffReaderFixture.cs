using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NaiveBayesClassifier.IO
{
    [TestFixture]
    public class ArffReaderFixture
    {
        public ArffReaderFixture()
        {
        }

        [Test]
        public void BlaBlaWorls()
        {
            var arffReader = new ArffReader();
            var result = arffReader.Read(@"Data\MultiClass_Testing_SVM_100.0.arff");
            Assert.AreEqual(7,result.SamplesCount);
        }


        [Test]
        public void TestReadTuple()
        {

            var arffReader = new ArffReader();
            String line =
                "0:2 2:3 3:1 4:3 5:4 8:4 11:10 12:2 13:2 14:14 15:9 16:2 17:14 18:1 19:1 20:8 21:2 22:1 23:1 25:3 26:4 27:1 28:8 31:1 33:4 34:2 35:3 36:2 37:1 38:5 39:2 40:2 41:2 42:1 43:1 44:1 45:1 46:3 47:1 48:1 49:2 50:1 51:5 52:1 53:1 54:1 55:1 56:3 57:4 58:4 59:1 60:1 61:1 # c22 c31  ";
            var result = arffReader.ReadTuple(line);
            Assert.IsTrue(result.HasTopic(new Topic("c22")));
            Assert.IsTrue(result.HasTopic(new Topic("c31")));
            Assert.AreEqual(2, result.Topics.Length);
        }

        [Test]
        public void testReadAttribute()
        {
            String   chestie = "0:1";
            var result = new ArffReader().ReadAttributeOccurrence(chestie);
            Assert.AreEqual(1,result.Count);
            Assert.AreEqual(new Attribute("0"), result.Attribute);
        }
    }
}
