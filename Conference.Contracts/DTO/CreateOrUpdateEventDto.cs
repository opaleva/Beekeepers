namespace Conference.Contracts.DTO;

public class CreateOrUpdateEventDto
{
    public string Title { get; set; }
    public string Time { get; set; }
    public string SpeakerName { get; set; }
    public string SpeakerLocation { get; set; }
}