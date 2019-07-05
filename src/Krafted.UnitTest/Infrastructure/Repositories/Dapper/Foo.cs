﻿using System;
using Flunt.Validations;
using SharedKernel.Domain;

namespace Krafted.UnitTest.Infrastructure.Repositories.Dapper
{
    public class Foo : Entity
    {
        public Foo(string name, in DateTime startDate, in DateTime endDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Validate();
        }

        protected Foo()
        {
        }

        public string Name { get; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public bool Canceled { get; private set; }

        public void ChangeSchedule(in DateTime startDate, in DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Validate();
        }

        public void Cancel()
        {
            if (!Canceled)
                Canceled = true;
        }

        private void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Name, 5, nameof(Name), "O nome deve ter pelo menos 5 caracteres.")
                .HasMaxLen(Name, 50, nameof(Name), "O nome deve ter no máximo 50 caracteres.")
                .IsGreaterThan(StartDate, new DateTime(1980, 1, 1), nameof(StartDate), "Data de inicio inválida")
                .IsGreaterThan(EndDate, new DateTime(1980, 1, 1), nameof(EndDate), "Data de encerramento inválida")
                .IsGreaterThan(EndDate, StartDate, nameof(EndDate), "A data de inicio não pode ser maior do que a data de encerramento."));
        }
    }
}