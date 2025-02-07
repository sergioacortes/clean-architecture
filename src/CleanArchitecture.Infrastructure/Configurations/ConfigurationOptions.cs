namespace CleanArchitecture.Orders.Infrastructure.Configurations;

public class ConfigurationOptions
{

    public const string SectionName = "ConfigurationOptions";
    
    public string AccountingEndpoing { get; set; }
    
    public int Seconds { get; set; }
    
}