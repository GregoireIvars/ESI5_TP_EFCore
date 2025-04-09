
using System;
using WebAPI.Models;
namespace WebAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Events = new Repository<Event>(_context);
            Sessions = new Repository<Session>(_context);
            Speakers = new Repository<Speaker>(_context);
            Participants = new Repository<Participant>(_context);
            Ratings = new Repository<Rating>(_context);
            Categories = new Repository<Category>(_context);
            Locations = new Repository<Location>(_context);
            Rooms = new Repository<Room>(_context);
        }

        public IRepository<Event> Events { get; private set; }
        public IRepository<Session> Sessions { get; private set; }
        public IRepository<Speaker> Speakers { get; private set; }
        public IRepository<Participant> Participants { get; private set; }
        public IRepository<Rating> Ratings { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<Location> Locations { get; private set; }
        public IRepository<Room> Rooms { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}