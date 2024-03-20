using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepository(AppDbContext dbContext) : IPlatformRepository
{
    public async Task<List<Platform>> GetAllPlatforms() 
        => await dbContext.Set<Platform>().ToListAsync();
    
    public async Task<Platform?> GetPlatformById(int id)
        => await dbContext.Set<Platform>().FirstOrDefaultAsync(p => p.Id == id);
    
    public async Task CreatePlatform(Platform platform)
        => await dbContext.Set<Platform>().AddAsync(platform);
    
    public async Task<bool> SaveChanges()
        => await dbContext.SaveChangesAsync() >= 0;
}