#nullable enable
using System;

namespace ChatApplicatie.Model
{
    public class ChatMessageRequest
    {
        public string? Author { get; set; }

        public string? Message { get; set; }

        public string? Channel { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
