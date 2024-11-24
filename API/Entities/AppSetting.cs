namespace API.Entities;

public class AppSetting
{
    public int Id { get; set; }
    public required string AppName { get; set; }
    public required string Key { get; set; }
    public required string Value { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
