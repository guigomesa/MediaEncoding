using System;
namespace MediaEncoding.Rabbit.Messages
{
	public abstract class MessageBase
	{
		public Guid Id { get; set; }

		public MessageBase()
		{
			
		}
	}
}

