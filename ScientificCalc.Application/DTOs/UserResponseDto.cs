using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificCalcApi.Application.DTOs
{
    public class UserResponseDto
    {
        public UserResponseDto(int id, string name, string email, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get;}
        public string Name { get;}

        public string Email { get;}

        public DateTime CreatedAt { get;}

        public DateTime UpdatedAt { get;}
    }
}
