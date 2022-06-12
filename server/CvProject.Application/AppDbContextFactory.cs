using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CvProject.Application;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args) 
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
        return new AppDbContext(optionsBuilder.Options);
    }
}
