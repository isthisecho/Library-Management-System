
using Library.API.Entities;
using LibraryManagementSystem.Abstractions;
using System.Linq.Expressions;

namespace LibraryManagementSystem.DataLayer.Abstractions
{


    public interface IRepository<EntityType> where EntityType : BaseEntity
    {
        Task    <IEnumerable<EntityType>>   GetAll                                              ();
        Task    <EntityType?>               Get             (Guid id                             );
        Task    <EntityType?>               Get             (EntityType? entity                  );

        Task    <EntityType?>               Create          (EntityType? entity                  );
        Task    <IEnumerable<EntityType>>   Where(Expression<Func<EntityType, bool>> predicate   );
        Task    <IEnumerable<EntityType>?>  CreateMany      (IEnumerable<EntityType> entities    );
        Task    <EntityType?>               Update          (Guid id, EntityType? entity         );
        Task                                Delete          (Guid id                             );
        Task                                DeleteMany      (IEnumerable<EntityType> entities    );


    }
}
