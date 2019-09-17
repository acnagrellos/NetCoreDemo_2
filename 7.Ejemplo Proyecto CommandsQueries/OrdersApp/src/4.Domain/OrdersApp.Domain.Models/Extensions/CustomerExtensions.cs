using OrdersApp.Domain.Core;

namespace OrdersApp.Domain.Models.Extensions
{
    public static class CustomerExtensions
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

        public static void UpdateClient(this CustomerDto customerDto, Customer customer)
        {
            customer.Update(
                customerDto.Name,
                customerDto.Surname,
                customerDto.Age,
                customerDto.Email,
                customerDto.Gender);
        }
    }
}
