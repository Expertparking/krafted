﻿using Krafted.Test.Result;
using Xunit;

namespace Krafted.UnitTest.Krafted
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class NotificationTest
    {
        [Fact]
        public void NewNotification_NotificationShouldBeCreated()
        {
            var notification = new Notification("The property", "The message");

            Assert.Equal("The property", notification.Property);
            Assert.Equal("The message", notification.Message);
        }
    }
}