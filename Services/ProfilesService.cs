using System;
using System.Collections.Generic;
using honey_harvest.Models;
using honey_harvest.Repositories;

namespace honey_harvest.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    public ProfilesService(ProfilesRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Profile> Get()
    {
      return _repo.Get();
    }

    public Profile Get(int id, string userId)
    {
      Profile foundProfile = Get(id);
      if (foundProfile == null)
      {
        throw new Exception("Invalid Id");
      }
      if (foundProfile.UserId == userId)
      {
        return foundProfile;
      }
      throw new Exception("you broke it");
    }

    public Profile Get(int id)
    {
      Profile foundProfile = _repo.GetById(id);
      if (foundProfile == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundProfile;
    }

    public Profile Create(Profile newProfile)
    {
      return _repo.Create(newProfile);
    }

    public Profile Edit(Profile profileToUpdate)
    {
      Profile original = Get(profileToUpdate.Id);
      if (profileToUpdate.UserId == original.UserId)
      {
        original.AutoUpgrades = profileToUpdate.AutoUpgrades > 0 ? profileToUpdate.AutoUpgrades : original.AutoUpgrades;
        original.ClickUpgrades = profileToUpdate.ClickUpgrades > 0 ? profileToUpdate.ClickUpgrades : original.ClickUpgrades;
        original.UserId = profileToUpdate.UserId.Length > 0 ? profileToUpdate.UserId : original.UserId;
        original.Name = profileToUpdate.Name.Length > 0 ? profileToUpdate.Name : original.Name;
        // original.Picture = profileToUpdate.Picture.Length > 0 ? profileToUpdate.Picture : original.Picture;
        original.Score = profileToUpdate.Score > 0 ? profileToUpdate.Score : original.Score;
        return _repo.Edit(original);
      }
      throw new Exception("This is not your Profile");
    }

    public string Delete(int id, string userId)
    {
      Profile foundProfile = Get(id);
      if (foundProfile.UserId != userId)
      {
        throw new Exception("This is not your Profile!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted";
      }
      throw new Exception("you broke it...");
    }
  }
}