using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<SessionSpeaker> SessionSpeakers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventParticipant>()
                .HasKey(ep => new { ep.EventId, ep.ParticipantId });

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Event)
                .WithMany(e => e.EventParticipants)
                .HasForeignKey(ep => ep.EventId);

            modelBuilder.Entity<EventParticipant>()
                .HasOne(ep => ep.Participant)
                .WithMany(p => p.EventParticipants)
                .HasForeignKey(ep => ep.ParticipantId);

    
            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });

            modelBuilder.Entity<SessionSpeaker>()
                .HasOne(ss => ss.Session)
                .WithMany(s => s.SessionSpeakers)
                .HasForeignKey(ss => ss.SessionId);

            modelBuilder.Entity<SessionSpeaker>()
                .HasOne(ss => ss.Speaker)
                .WithMany(s => s.SessionSpeakers)
                .HasForeignKey(ss => ss.SpeakerId);

        
            modelBuilder.Entity<Event>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Location)
                .WithMany(l => l.Events)
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Event>()
                .Property(e => e.Status)
                .HasConversion<string>();

       
            modelBuilder.Entity<Participant>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Participant>()
                .HasIndex(p => p.Email)
                .IsUnique();

            modelBuilder.Entity<Session>()
                .Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Event)
                .WithMany(e => e.Sessions)
                .HasForeignKey(s => s.EventId);

            modelBuilder.Entity<Session>()
                .HasOne(s => s.Room)
                .WithMany(r => r.Sessions)
                .HasForeignKey(s => s.RoomId);

        
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Location)
                .WithMany(l => l.Rooms)
                .HasForeignKey(r => r.LocationId);

           
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Session)
                .WithMany(s => s.Ratings)
                .HasForeignKey(r => r.SessionId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Participant)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ParticipantId);

            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.SessionId, r.ParticipantId })
                .IsUnique();

           
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

        
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Conférence" },
                new Category { Id = 2, Name = "Atelier" }
            );

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Campus Lyon", Address = "10 rue des Capucins, Lyon", City = "Lyon", Country = "France", Capacity = 500 },
                new Location { Id = 2, Name = "Campus Paris", Address = "5 avenue République, Paris", City = "Paris", Country = "France", Capacity = 300 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Salle A", Capacity = 100, LocationId = 1 },
                new Room { Id = 2, Name = "Salle B", Capacity = 50, LocationId = 1 },
                new Room { Id = 3, Name = "Salle C", Capacity = 75, LocationId = 2 }
            );

            modelBuilder.Entity<Participant>().HasData(
                new Participant { Id = 1, FirstName = "Alice", LastName = "Martin", Email = "alice@example.com", Company = "TechCorp", JobTitle = "Développeuse" },
                new Participant { Id = 2, FirstName = "Bob", LastName = "Dupont", Email = "bob@example.com", Company = "InnoTech", JobTitle = "Ingénieur" }
            );

            modelBuilder.Entity<Speaker>().HasData(
                new Speaker { Id = 1, FirstName = "Jean", LastName = "Durand", Email = "Jean.Du@gmail.com", Bio = "Expert en IA", Company = "AI Solutions" },
                new Speaker { Id = 2, FirstName = "Marie", LastName = "Leroy", Email = "Marie38@outlook.fr", Bio = "Spécialiste DevOps", Company = "DevOps Inc." }
            );

            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Journée Tech 2025",
                    StartDate = new DateTime(2025, 6, 15),
                    EndDate = new DateTime(2025, 6, 15),
                    Status = Models.EventStatus.Upcoming,
                    LocationId = 1,
                    CategoryId = 1
                },
                new Event
                {
                    Id = 2,
                    Title = "Atelier DevOps",
                    StartDate = new DateTime(2025, 4, 20),
                    EndDate = new DateTime(2025, 4, 20),
                    Status = Models.EventStatus.Upcoming,
                    LocationId = 2,
                    CategoryId = 2
                }
            );

            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    Title = "Introduction à l'IA",
                    Description = "An introductory session on Artificial Intelligence.",
                    StartDate = new DateTime(2025, 6, 15, 10, 0, 0),
                    EndDate = new DateTime(2025, 6, 15, 11, 0, 0),
                    EventId = 1,
                    RoomId = 1
                },
                new Session
                {
                    Id = 2,
                    Title = "CI/CD pour les nuls",
                    Description = "A beginner's guide to Continuous Integration and Continuous Deployment.",
                    StartDate = new DateTime(2025, 4, 20, 14, 0, 0),
                    EndDate = new DateTime(2025, 4, 20, 15, 0, 0),
                    EventId = 2,
                    RoomId = 3
                }
            );

            modelBuilder.Entity<SessionSpeaker>().HasData(
                new SessionSpeaker { SessionId = 1, SpeakerId = 1, Role = "Keynote Speaker" },
                new SessionSpeaker { SessionId = 2, SpeakerId = 2, Role = "Workshop Leader" }
            );

            modelBuilder.Entity<EventParticipant>().HasData(
                new EventParticipant { EventId = 1, ParticipantId = 1 },
                new EventParticipant { EventId = 1, ParticipantId = 2 },
                new EventParticipant { EventId = 2, ParticipantId = 1 }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, SessionId = 1, ParticipantId = 1, Score = 4, Comments = "Great session!" },
                new Rating { Id = 2, SessionId = 2, ParticipantId = 1, Score = 5, Comments = "Excellent workshop!" },
                new Rating { Id = 3, SessionId = 2, ParticipantId = 2, Score = 3, Comments = "No comments provided." }
            );
        }

    }
}