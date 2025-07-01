using JobTracking.DataAccess;
using JobTracking.DataAccess.Persistance;

namespace JobTracking.Application.Contracts.Base
{
    /// <summary>
    /// Provides application-wide access to the database context.
    /// Used for service-level dependency injection.
    /// </summary>
    public class DependencyProvider
    {
        public DependencyProvider(AppDbContext dbContext)
        {
            Db = dbContext;
        }

        public AppDbContext Db { get; set; }
    }
}