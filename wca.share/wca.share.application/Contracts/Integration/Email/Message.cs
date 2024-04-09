﻿using MimeKit;

namespace wca.share.application.Contracts.Integration.Email
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(d => new MailboxAddress("", d)));
            Subject = subject;
            Content = content;
        }
    }
}
