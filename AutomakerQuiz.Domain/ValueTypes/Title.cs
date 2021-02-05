using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AutomakerQuiz.Domain.ValueTypes
{
    public struct Title
    {
        private readonly string _value;
        public readonly Contract contract;

        private Title(string value)
        {
            _value = value;
            contract = new Contract();
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator Title(string value) =>
            new Title(value);

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Inform a valid title.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(Title), message);
            return false;
        }
    }
}
