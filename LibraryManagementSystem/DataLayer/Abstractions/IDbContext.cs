namespace LibraryManagementSystem.DataLayer.Abstractions
{
    public interface IDbContext
    {
        IRepository<EntityType>? GetRepository<EntityType>() where EntityType : IEntity;
    }
}
