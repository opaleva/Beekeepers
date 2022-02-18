namespace Conference.Contracts.DTO;

public class CreateOrUpdateBeekeeperDto
{
    public string Name { get; set; } 
    public string City { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Expected { get; set; }
}