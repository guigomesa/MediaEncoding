using System;
using FFMpegCore;
using FFMpegCore.Enums;

namespace MediaEncoding.Encoder
{
    public class EncoderVideo : Encoder, IMediaEncoder
    {
        public EncoderVideo(string originalFile) : base(originalFile)
        {
        }

        public async Task GenerateMediaInfo()
        {
            OriginalMediaInfo = await FFProbe.AnalyseAsync(OriginalFile);
        }

        protected async Task GenerateOutputMediaInfo()
        {
            OutputMediaInfo = await FFProbe.AnalyseAsync(OutputFile);
        }

        public  override async Task Execute(string outputFile)
        {
            this.OutputFile = outputFile;
            await GenerateMediaInfo();

            await FFMpegArguments.FromFileInput(OriginalFile)
                .OutputToFile(OutputFile,false,
                options => options.WithVideoCodec(VideoCodec.LibX264)
                .WithConstantRateFactor(21)
                .WithVariableBitrate(4)
                .WithVideoFilters(filterOption => filterOption.Scale(VideoSize.FullHd))
                .WithFastStart())
                .ProcessAsynchronously();

            await GenerateOutputMediaInfo();
        }
    }
}

