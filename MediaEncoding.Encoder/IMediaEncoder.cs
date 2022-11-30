using System;
using FFMpegCore;

namespace MediaEncoding.Encoder
{
    public interface IMediaEncoder
    {
        public IMediaAnalysis OriginalMediaInfo { get; }
        public IMediaAnalysis OutputMediaInfo { get; }
        public string OriginalFile { get; set; }
        public string OutputFile { get; }

        public Task Execute(string outputFile);
    }
}

