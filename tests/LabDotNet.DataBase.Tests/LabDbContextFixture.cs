using Microsoft.EntityFrameworkCore;

namespace LabDotNet.DataBase.Tests
{
    public class LabDbContextFixture : IDisposable
    {

        public LabDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<LabDbContext>().UseInMemoryDatabase("LabDbCommandsTestDb").Options;
            Context = new LabDbContext(options);
            Context.Database.EnsureCreated();
        }

        public LabDbContext Context { get; private set; }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}