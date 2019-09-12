using CustomersApi.Services.Models;

namespace CustomersApi.Services.Domain
{
    public static class CustomersExtensions
    {
        public static CustomerDto ToMapper(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Age = customer.Age,
                Email = customer.Email,
                Name = customer.Name,
                Surname = customer.Surname,
                Gender = customer.Gender
            };
        }
    }
}
