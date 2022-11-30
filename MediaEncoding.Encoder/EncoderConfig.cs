using System;
using System.Runtime.InteropServices;
using FFMpegCore;

namespace MediaEncoding.Encoder
{
    public static class EncoderConfig
    {
        public static void Config(string binaryFolder = "./bin", string temporaryfolder = "/tmp")
        {
            GlobalFFOptions.Configure(new FFOptions()
            {
                BinaryFolder = binaryFolder,
                TemporaryFilesFolder = temporaryfolder
            });
        }


        public static string BinaryFolder()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "/usr/bin";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "/usr/local/bin";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "C:\\ProgramData\\chocolatey\\lib\\ffmpeg\\tools\\ffmpeg\\bin";

            return String.Empty;
        }
    }
}

