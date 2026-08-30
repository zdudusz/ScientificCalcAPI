using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcAPI.Core.Models.InputModels
{
    public class UserInputModel(string name, string email, string passwordHash, DateTime createdAt)
    {

        public string Name { get;} = name;

        public string Email { get;} = email!;

        public string PasswordHash { get; } = passwordHash!;

        public DateTime CreatedAt { get; } = createdAt;

    }
}

