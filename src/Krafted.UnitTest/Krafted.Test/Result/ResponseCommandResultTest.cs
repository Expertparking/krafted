﻿using Krafted.Test.Result;
using Xunit;

namespace Krafted.UnitTest.Krafted.Test.Result
{
    [Trait(nameof(UnitTest), nameof(Krafted))]
    public class ResponseCommandResultTest
    {
        [Fact]
        public void NewNotification_ResponseCommandResultCreated()
        {
            var commandResult = new ResponseCommandResult(success: true, message: "The message");
            Assert.True(commandResult.Success);
            Assert.Equal("The message", commandResult.Message);

            commandResult = new ResponseCommandResult(id: "1802159c-ead3-4509-a4f0-55b93329b090", success: true, message: "The message");
            Assert.True(commandResult.Success);
            Assert.Equal("The message", commandResult.Message);
            Assert.Equal("1802159c-ead3-4509-a4f0-55b93329b090", commandResult.Id.ToString());
        }
    }
}