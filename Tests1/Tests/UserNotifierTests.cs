using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Tests1.DependencyInjectionTask;
using Tests1.Preconditions;

namespace Tests1.Tests
{
    internal class UserNotifierTests
    {
        private readonly NotificationPreconditions p = new NotificationPreconditions();

        [Test]
//Задача 1. Внедрить зависимость через конструктор вместо new
//Есть такой код:

//public class EmailSender
//{
//public void Send(string to, string text)
//{
//// Логика отправки письма
//Console.WriteLine($"Sending mail to {to}: {text}");
//}
//}

//public class UserNotifier
//{
//public void Notify(int userId)
//{
//var sender = new EmailSender();
//sender.Send("user@mail.com", $"Hello, user {userId}!");
//}
//}

//Проблема: UserNotifier сам создаёт EmailSender через new.  
//Нужно сделать так, чтобы:
//- UserNotifier не создавал EmailSender сам,  
//- EmailSender внедрялся через Dependency Injection

        public void Test001NotifyDoesNotCreateEmailSenderItself()
        {
            var notifier = p.Provider.GetService<UserNotifier>();
            notifier.Should().NotBeNull();
            notifier.Notify(1);
        }
    }
}
