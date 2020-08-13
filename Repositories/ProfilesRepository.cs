using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using honey_harvest.Models;

namespace honey_harvest.Repositories
{
  public class ProfilesRepository
  {
    private IDbConnection _db;
    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Profile> Get()
    {
      string sql = "SELECT * FROM profiles";
      return _db.Query<Profile>(sql);
    }

    internal Profile GetById(int id)
    {
      string sql = @"
      SELECT * FROM profiles WHERE id = @id;";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile newProfile)
    {
      string sql = @"
      INSERT INTO profiles
      (userId, name, picture, score, autoUpgrades, clickUpgrades)
      VALUES
      (@UserId, @Name, @Picture, @Score, @AutoUpgrades, @ClickUpgrades);
      SELECT LAST_INSERT_ID()";
      newProfile.Id = _db.ExecuteScalar<int>(sql, newProfile);
      return newProfile;
    }

    internal Profile Edit(Profile original)
    {
      string sql = @"
      UPDATE profiles
      SET
        name = @Name,
        userId = @UserId,
        picture = @Picture, 
        score = @Score,
        autoUpgrades = @AutoUpgrades,
        clickUpgrades = @ClickUpgrades
        WHERE id = @Id and userId = @UserId";
      return _db.QueryFirstOrDefault<Profile>(sql, original);
    }

    internal bool Delete(int id, string userId)
    {
      string sql = @"
      DELETE FROM profiles WHERE id = @id AND userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}