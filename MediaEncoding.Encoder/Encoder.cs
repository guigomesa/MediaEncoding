using System;
using FFMpegCore;

namespace MediaEncoding.Encoder
{
    public abstract class Encoder : IMediaEncoder
    {
        public Encoder(string originalFile)
        {
            OriginalFile = originalFile;
        }
        public IMediaAnalysis OriginalMediaInfo { get; protected set; }
        public IMediaAnalysis OutputMediaInfo { get; protected set; }
        public string OriginalFile { get; set; }
        public string OutputFile { get; protected set; }

        public abstract Task Execute(string outputFile);
       
    }
}

