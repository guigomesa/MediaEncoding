using System;
using MediaEncoding.Rabbit.Messages;
using ServiceStack.Messaging;
using ServiceStack.RabbitMq;
using MediaEncoding.Encoder.Video;
using System.Net;

namespace MediaEncoding.Rabbit.Client
{
	public class MediaEncodingRabbit : IMediaEncodingRabbit
    {
		private readonly IMessageService RabbitMqServer;

        public MediaEncodingRabbit(IMessageService rabbitMqServer)
		{
			this.RabbitMqServer = rabbitMqServer;

		}

		protected async Task<string> DownloadFile(string url, string extensionFile)
		{
			var pathTempFile = $"temp-video/{Guid.NewGuid}.{extensionFile}";

            var client = new HttpClient();
            var s = await client.GetStreamAsync("https://via.placeholder.com/150");
            var fs = new FileStream(pathTempFile, FileMode.OpenOrCreate);
			await s.CopyToAsync(fs);

			return pathTempFile;
        }

		public async Task<string> EncodeVideo(VideoMessage videoMessage)
		{
			var tempFile = this.DownloadFile(videoMessage.UrlFile, "mp4");

			var videoEncoder = new EncoderVideo(videoMessage.UrlFile);

			var tempOutput = $"temp-video/{videoMessage.Id}-encoded.{videoMessage.Extension}";
			await videoEncoder.Execute(tempOutput);

			return tempOutput;
		}

	}
}

