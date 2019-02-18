﻿using System;
using Krafted.Framework.SharedKernel.Application.Commands;

namespace Krafted.IntegrationTest.FooBar.Application
{
    public class DeleteFooCommand : ICommand
    {
        public DeleteFooCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}