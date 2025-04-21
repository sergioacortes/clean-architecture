namespace CleanArchitecture.Domain.Companies;

public partial class Company
{
    
    public static Company Create(string tradeName)
    {
        
        if (string.IsNullOrWhiteSpace(tradeName))
        {
            throw new ArgumentNullException(nameof(tradeName));
        }

        return new Company(tradeName);
        
    }
    
}