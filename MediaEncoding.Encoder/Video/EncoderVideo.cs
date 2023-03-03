using System;
using FFMpegCore;
using FFMpegCore.Enums;

namespace MediaEncoding.Encoder.Video
{
    public class EncoderVideo : Encoder, IVideoEncoder
    {
        public double? ConstantRateFactor { get; set; }
        public Codec? VideoCodec { get; set; }
        public VideoSize? VideoSize { get; set; }
        public double? VariableBitrate { get; set; }

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

        protected void GenerateDefaultMediaFileToEncode()
        {
            if (!this.ConstantRateFactor.HasValue)
                this.ConstantRateFactor = OriginalMediaInfo.PrimaryVideoStream.AvgFrameRate;

            if (VideoCodec == null)
                this.VideoCodec = FFMpeg.GetCodec(OriginalMediaInfo.PrimaryVideoStream.CodecName);

            if (this.VideoSize == null)
                this.VideoSize = FFMpegCore.Enums.VideoSize.Original;

            if (!this.VariableBitrate.HasValue)
                this.VariableBitrate = OriginalMediaInfo.PrimaryVideoStream.BitRate;
            if (this.VariableBitrate.Value > 5)
                this.VariableBitrate = 5;
        }

        public  override async Task Execute(string outputFile)
        {
            this.OutputFile = outputFile;
            await GenerateMediaInfo();

            GenerateDefaultMediaFileToEncode();

            await FFMpegArguments.FromFileInput(OriginalFile)
                .OutputToFile(OutputFile,false,
                options => options.WithVideoCodec(this.VideoCodec)
                .WithConstantRateFactor((int) this.ConstantRateFactor)
                .WithVariableBitrate((int) this.VariableBitrate)
                .WithVideoFilters(filterOption => filterOption.Scale(this.VideoSize.Value))
                .WithFastStart())
                .ProcessAsynchronously();

            await GenerateOutputMediaInfo();
        }
    }
}

