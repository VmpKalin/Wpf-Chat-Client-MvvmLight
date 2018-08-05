using System;

namespace ChatCustomDisign.Models.Template
{
    public class ChatMessage
    {
        public string Id { get; set; }

        public string ChatId { get; set; }

        public string Content { get; set; }

        public UserChat Chat { get; set; }

        public DateTime MessageTime { get; set; }
    }
}