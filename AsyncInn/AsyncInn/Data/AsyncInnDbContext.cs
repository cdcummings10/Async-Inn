using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(hotelRoom =>
            new { hotelRoom.HotelID, hotelRoom.RoomNumber });

            modelBuilder.Entity<RoomAmenities>().HasKey(roomAmenities =>
            new { roomAmenities.AmenitiesID, roomAmenities.RoomID });
            // Data Seeding
            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel
                    {
                        ID = 1,
                        Name = "Nier Waterfront",
                        StreetAddress = "2BA2 Replicant Rd, Seattle, WA",
                        City = "Seattle",
                        State = "Washington",
                        Phone = "(206)994-1524"
                    },
                    new Hotel
                    {
                        ID = 2,
                        Name = "Hotel of Light",
                        StreetAddress = "8000 Ascian Rd, Bellevue, WA",
                        City = "Bellevue",
                        State = "Washington",
                        Phone = "(206)485-6491"
                    },
                    new Hotel
                    {
                        ID = 3,
                        Name = "Mythra Respite Inn",
                        StreetAddress = "6565 Rex Rd, Bellingham, WA",
                        City = "Seattle",
                        State = "Washington",
                        Phone = "(425)641-3001"
                    },
                    new Hotel
                    {
                        ID = 4,
                        Name = "Divinity's Rest",
                        StreetAddress = "301 Larian Ln, Seattle, WA",
                        City = "Seattle",
                        State = "Washington",
                        Phone = "(206)569-9515"
                    },
                    new Hotel
                    {
                        ID = 5,
                        Name = "Lion's Pride Inn",
                        StreetAddress = "2004 Northshire Blvd, Portland, OR",
                        City = "Portland",
                        State = "Oregon",
                        Phone = "(503)132-1323"
                    });

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Yonah Yawn",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 2,
                    Name = "Eorzean Escape",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "Nya Nap",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 4,
                    Name = "The Red Prince",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Moon Glade",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Good Sleep In Here",
                    Layout = Layout.OneBedroom
                });

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Air Conditioning"
                }, new Amenities
                {
                    ID = 2,
                    Name = "Coffee Maker"
                }, new Amenities
                {
                    ID = 3,
                    Name = "California King Bed"
                }, new Amenities
                {
                    ID = 4,
                    Name = "Full Kitchen"
                }, new Amenities
                {
                    ID = 5,
                    Name = "Game System"
                });
        }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
