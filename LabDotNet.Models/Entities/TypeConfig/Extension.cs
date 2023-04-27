using Microsoft.EntityFrameworkCore;

namespace LabDotNet.Models.Entities.TypeConfig
{
    public static class Extension
    {
        public static void ConfigureAllTypeConfig(this ModelBuilder modelBuilder) => modelBuilder.ApplyConfiguration(new UserTypeConfig());
    }
}