namespace honey_harvest.Models
{
  public class Profile
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserId { get; set; }
    public string Picture { get; set; }
    public int Score { get; set; }
    public int ClickUpgrades { get; set; }
    public int AutoUpgrades { get; set; }
  }
}