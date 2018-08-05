using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatCustomDisign.Models.Template
{
    public class UserChat
    {
        public string Id { get; set; }

        public string ChatName  { get; set; }

        public Person Chatter { get; set; }

        public DateTime LastMessageTime { get; set; }

        public ICollection<ChatMessage> Messages { get; set; }

        public ChatMessage LastMessage { get; set; }

        public int UnreadedMessages { get; set; }
    }
}
