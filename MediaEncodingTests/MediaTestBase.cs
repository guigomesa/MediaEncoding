using System;
using System.Runtime.InteropServices;

namespace MediaEncodingTests
{
    public class MediaTestBase
    {
        protected const string EXAMPLE_VIDEO_FOLDER = "/VideosExample";
        protected const string VIDEO_TEST_OUTPUT_FOLDER = "/VideosTestOutput";
        protected const string TEMP_FOLDER = "./tmp";

        [SetUp]
        public void BaseSetup()
        {

        }

        [TearDown]
        public void BaseTearDownSetup()
        {

        }
    }
}

