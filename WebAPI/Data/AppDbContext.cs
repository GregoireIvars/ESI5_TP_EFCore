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
            // ----- EventParticipant (Many-to-Many) -----
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

            // ----- SessionSpeaker (Many-to-Many) -----
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

            // ----- Event -----
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
                .HasConversion<string>(); // Enregistre l'enum en string

            // ----- Participant -----
            modelBuilder.Entity<Participant>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Participant>()
                .HasIndex(p => p.Email)
                .IsUnique();

            // ----- Session -----
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

            // ----- Room -----
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Location)
                .WithMany(l => l.Rooms)
                .HasForeignKey(r => r.LocationId);

            // ----- Rating -----
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

            // ----- Category -----
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}