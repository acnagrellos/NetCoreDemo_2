namespace OrdersApp.Domain.Models
{
    public class ConfigurationSettings
    {
        public ListSettings ListSettings { get; set; }
    }

    public class ListSettings
    {
        public int ItemsPerPage { get; set; }
    }
}
