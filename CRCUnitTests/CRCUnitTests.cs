using CRCSumLab3Kashkin;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CRCUnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCRC_FromExample_Success()
        {
            IList<bool> message = new List<bool>() { 
                true, 
                true, 
                false, 
                true,
                false,
                true,
                true,
                false,
                true,
                true
            };//сообщение 1101011011
            int[] polynome = new int[] {0, 1, 4};
            IEnumerable<bool> expectedCRC = new bool[] {
                true,
                true,
                true,
                false
            };//CRC 1110

            Message generatedMessage = new Message(polynome, message);
            CRCProcessor crcProcessor = new CRCProcessor(generatedMessage);            
            IList<bool> CRC = crcProcessor.GetCRC();

            Assert.AreEqual(expectedCRC, CRC);
        }

        [Test]
        public void GetCRC_RandomSequence_Success()
        {
            Message generatedMessage = new Message();
            CRCProcessor crcProcessor = new CRCProcessor(generatedMessage);
            IList<bool> CRC = crcProcessor.GetCRC();

            IList<bool> CheckedCRC = crcProcessor.CheckCRC(CRC);
            var expectedCRC = new bool[CheckedCRC.Count()];

            Assert.AreEqual(expectedCRC, CheckedCRC);
        }
    }
}