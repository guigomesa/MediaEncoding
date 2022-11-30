using System;
using MediaEncoding.Encoder;

namespace MediaEncodingTests
{
    [TestFixture]
    public class EncoderTest : MediaTestBase
    {
        [SetUp]
        public void Setup()
        {
            EncoderConfig.Config(EncoderConfig.BinaryFolder(), TEMP_FOLDER);
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public async Task Test_Encoder_Video()
        {
            var basicPath = AppContext.BaseDirectory;
            var encoder = new EncoderVideo($"{basicPath}/{EncoderTest.EXAMPLE_VIDEO_FOLDER}/NO_ICE_MAN.mp4");

            var outputFile = $"{basicPath}/{EncoderTest.EXAMPLE_VIDEO_FOLDER}/NO_ICE_MAN_TESTE.mp4";
            await encoder.Execute(outputFile);

            Assert.IsTrue(File.Exists(outputFile),"NO_ICE_MAN_TESTE exist");

            File.Delete(outputFile);
        }
    }
}

