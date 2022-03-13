using System;

namespace FatalError.Core.Contracts
{
    public class Event
    {
        public Event()
        {
            TrackId = Guid.NewGuid();
        }
        public Guid TrackId { get; set; }
    }
}
