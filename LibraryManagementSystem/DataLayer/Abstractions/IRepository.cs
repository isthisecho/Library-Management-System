using LibraryManagementSystem.Abstractions;

namespace LibraryManagementSystem.DataLayer.Abstractions
{


    public interface IRepository<EntityType> where EntityType : IEntity
    {
        Task    <IEnumerable<EntityType>>   GetAll                                              ();
        Task    <EntityType?>               Get             (string id                           );
        Task    <EntityType?>               Create          (EntityType? item                    );
        Task    <IEnumerable<EntityType>?>  CreateMany      (IEnumerable<EntityType> items       );
        Task    <EntityType?>               Update          (string id, EntityType? item         );
        Task                                Delete          (string id                           );
        Task                                DeleteMany      (IEnumerable<EntityType> items       );


    }
}
