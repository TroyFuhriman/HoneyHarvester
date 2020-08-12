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

    internal Profile Get(int id, string email)
    {
      Profile foundProfile = Get(id);
      if (foundProfile == null)
      {
        throw new Exception("Invalid Id");
      }
      if (foundProfile.Email == email)
      {
        return foundProfile;
      }
      throw new Exception("you broke it");
    }

    private Profile Get(int id)
    {
      Profile foundProfile = _repo.GetById(id);
      if (foundProfile == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundProfile;
    }

    internal Profile Create(Profile newProfile)
    {
      return _repo.Create(newProfile);
    }

    internal Profile Edit(Profile profileToUpdate)
    {
      Profile original = Get(profileToUpdate.Id);
      if (profileToUpdate.Email == original.Email)
      {
        original.AutoUpgrades = profileToUpdate.AutoUpgrades > 0 ? profileToUpdate.AutoUpgrades : original.AutoUpgrades;
        original.ClickUpgrades = profileToUpdate.ClickUpgrades > 0 ? profileToUpdate.ClickUpgrades : original.ClickUpgrades;
        original.Email = profileToUpdate.Email.Length > 0 ? profileToUpdate.Email : original.Email;
        original.Name = profileToUpdate.Name.Length > 0 ? profileToUpdate.Name : original.Name;
        original.Picture = profileToUpdate.Picture.Length > 0 ? profileToUpdate.Picture : original.Picture;
        original.Score = profileToUpdate.Score > 0 ? profileToUpdate.Score : original.Score;
        return _repo.Edit(original);
      }
      throw new Exception("This is not your Profile");
    }

    internal string Delete(int id, string email)
    {
      Profile foundProfile = Get(id);
      if (foundProfile.Email != email)
      {
        throw new Exception("This is not your Profile!");
      }
      if (_repo.Delete(id, email))
      {
        return "Successfully Deleted";
      }
      throw new Exception("you broke it...");
    }
  }
}