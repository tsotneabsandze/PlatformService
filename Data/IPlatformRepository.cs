using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepository
{
    Task<bool> SaveChanges();

    Task<List<Platform>> GetAllPlatforms();

    Task<Platform?> GetPlatformById(int id);

    Task CreatePlatform(Platform platform);
}