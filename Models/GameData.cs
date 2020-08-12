namespace honey_harvest.Models
{
  public class GameData
  {
    public int Score { get; set; }
    public int ClickUpgrades { get; set; }
    public int AutoUpgrades { get; set; }
    public class ProfileGameData : GameData
    {
      public int ProfileGameDataId { get; set; }
    }
  }
}