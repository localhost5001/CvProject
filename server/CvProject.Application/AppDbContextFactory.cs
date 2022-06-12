using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CvProject.Application;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args) 
    {
        Console.WriteLine(AppConfiguration.DefaultDbConnection);
        Console.WriteLine(Directory.GetCurrentDirectory());

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        return new AppDbContext(optionsBuilder.Options);
    }
}
