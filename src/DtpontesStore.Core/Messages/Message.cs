using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtpontesStore.Core.Messages
{
    public abstract class Message 
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get;  set; }

        public Guid AggregateId { get; protected  set; }
    }
}
