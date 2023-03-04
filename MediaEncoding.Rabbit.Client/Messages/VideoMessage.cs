using System;
using FFMpegCore.Enums;
namespace MediaEncoding.Rabbit.Messages
{
	public class VideoMessage: MessageBase
	{
        public VideoMessage()
        {
        }

        public String UrlFile { get; set; }
		public VideoSize Size { get; set; }
		public string Extension { get; set; }
		
	}
}

