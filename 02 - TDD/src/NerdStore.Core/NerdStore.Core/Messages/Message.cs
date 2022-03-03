using MediatR;
using System;

namespace NerdStore.Core.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AgregateId { get; set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }

    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; private set; }

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
