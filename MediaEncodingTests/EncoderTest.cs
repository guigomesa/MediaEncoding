using System;
using MediaEncoding.Encoder;

namespace MediaEncodingTests
{
    [TestFixture]
    public class EncoderTest : MediaTestBase
    {
        public static string BasicPath = AppContext.BaseDirectory;

        [SetUp]
        public void Setup()
        {
            EncoderConfig.Config(EncoderConfig.BinaryFolder(), TEMP_FOLDER);
            Directory.CreateDirectory($"{BasicPath}/{EncoderTest.VIDEO_TEST_OUTPUT_FOLDER}");
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete($"{BasicPath}/{EncoderTest.VIDEO_TEST_OUTPUT_FOLDER}");
        }

        [TestCase(FFMpegCore.Enums.VideoSize.Ed)]
        [TestCase(FFMpegCore.Enums.VideoSize.Hd)]
        [TestCase(FFMpegCore.Enums.VideoSize.FullHd)]
        [TestCase(FFMpegCore.Enums.VideoSize.Ld)]
        [TestCase(FFMpegCore.Enums.VideoSize.Original)]
        public async Task Test_Encode_(FFMpegCore.Enums.VideoSize videoSize)
        {
            System.Console.WriteLine($"Test encode for => {videoSize.ToString()}");

            var basicPath = AppContext.BaseDirectory;
            var encoder = new EncoderVideo($"{basicPath}/{EncoderTest.EXAMPLE_VIDEO_FOLDER}/NO_ICE_MAN.mp4")
            {
                 VideoSize = FFMpegCore.Enums.VideoSize.Hd
            };

            var outputFile = $"{BasicPath}/{EncoderTest.VIDEO_TEST_OUTPUT_FOLDER}/NO_ICE_MAN_TESTE.mp4";
            await encoder.Execute(outputFile);

            Assert.IsTrue(File.Exists(outputFile), "NO_ICE_MAN_TESTE exist");

            File.Delete(outputFile);
        }
    }
}

