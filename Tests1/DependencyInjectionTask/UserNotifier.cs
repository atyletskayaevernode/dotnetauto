using System;
using System.Collections.Generic;
using System.Text;

namespace Tests1.DependencyInjectionTask
{
    public class UserNotifier
    {
        private readonly EmailSender sender;
        public UserNotifier(EmailSender sender)
        {
            this.sender = sender;
        }

        public void Notify(int userId)
        {
            sender.Send("user@mail.com", $"Hello, user {userId}!");
        }
    }
}
