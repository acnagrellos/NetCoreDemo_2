using System;

namespace OrdersApp.Domain.Core
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime LastUpdate { get; private set; }
        // public ICollection<Order> Orders { get; set; }

        public Customer(string name, string surname, int age, string email, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Gender = gender;
            LastUpdate = DateTime.UtcNow;
        }

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
