using System;
using FFMpegCore.Enums;
namespace MediaEncoding.Rabbit.Messages
{
	public class MessageVideo: MessageBase
	{
		public string PathFile { get; set; }
		public VideoSize Size { get; set; }
	}
}

