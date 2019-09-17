namespace OrdersApp.Domain.Models
{
    public class ConfigurationSettings
    {
        public ListSettings ListSettings { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ListSettings
    {
        public int ItemsPerPage { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
