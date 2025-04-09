
using System;
using WebAPI.Models;
namespace WebAPI.Data
{
    public interface IUnitOfWork
    {
        IRepository<Event> Events { get; }
        IRepository<Session> Sessions { get; }
        IRepository<Speaker> Speakers { get; }
        IRepository<Participant> Participants { get; }
        IRepository<Rating> Ratings { get; }
        IRepository<Category> Categories { get; }
        IRepository<Location> Locations { get; }
        IRepository<Room> Rooms { get; }

        int Complete();
    }
}
