using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OrdersApp.Domain.Core
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<Order> Orders { get; set; }

        public void Update(string name, string surname, int age, string email, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Gender = gender;
            LastUpdate = DateTime.Now;
        }
    }
}
