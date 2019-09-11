using OrdersApp.Domain.Core;

namespace OrdersApp.Domain.Models
{
    public static class ClientsExtensions
    {
        public static ClientDto ToMapper(this Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Age = client.Age,
                Email = client.Email,
                Name = client.Name,
                Surname = client.Surname,
                Gender = client.Gender
            };
        }
    }
}
