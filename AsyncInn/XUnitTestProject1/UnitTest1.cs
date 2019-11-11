using AsyncInn.Data;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        #region Getter Setter Tests
        [Fact]
        public void TestHotelsGetSet()
        {
            Hotel hotel = new Hotel();
            hotel.ID = 1;
            hotel.Name = "Hoopty";
            hotel.StreetAddress = "Boopty";
            hotel.City = "Woopty";
            hotel.State = "Poopty";
            hotel.Phone = "4";

            Assert.Equal(1, hotel.ID);
            Assert.Equal("Hoopty", hotel.Name);
            Assert.Equal("Boopty", hotel.StreetAddress);
            Assert.Equal("Woopty", hotel.City);
            Assert.Equal("Poopty", hotel.State);
            Assert.Equal("4", hotel.Phone);
        }
        [Fact]
        public void TestRoomGetSet()
        {
            Room room = new Room();
            room.ID = 2;
            room.Layout = Layout.Studio;
            room.Name = "Scoopty";

            Assert.Equal(2, room.ID);
            Assert.Equal(Layout.Studio, room.Layout);
            Assert.Equal("Scoopty", room.Name);
        }
        [Fact]
        public void TestAmenitiesGetSet()
        {
            Amenities amenities = new Amenities();
            amenities.ID = 3;
            amenities.Name = "Fwoopty";

            Assert.Equal(3, amenities.ID);
            Assert.Equal("Fwoopty", amenities.Name);
        }
        [Fact]
        public void TestRoomAmenitiesGetSet()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 4;
            roomAmenities.RoomID = 5;

            Assert.Equal(4, roomAmenities.AmenitiesID);
            Assert.Equal(5, roomAmenities.RoomID);
        }
        [Fact]
        public void TestHotelRoomsGetSet()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 6;
            hotelRoom.RoomID = 7;
            hotelRoom.RoomNumber = 8;
            hotelRoom.PetFriendly = true;
            hotelRoom.Rate = 9;

            Assert.Equal(6, hotelRoom.HotelID);
            Assert.Equal(7, hotelRoom.RoomID);
            Assert.Equal(8, hotelRoom.RoomNumber);
            Assert.True(hotelRoom.PetFriendly);
            Assert.Equal(9, hotelRoom.Rate);
        }
        #endregion

        #region Database Tests
        [Fact]
        public async Task SaveRoomInDBAsync()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("SaveRoomInDB")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = new Room();
                room.ID = 2;
                room.Layout = Layout.Studio;
                room.Name = "Scoopty";

                context.Add(room);
                await context.SaveChangesAsync();

                Room result = await context.Rooms.FirstOrDefaultAsync(x => x.ID == room.ID);

                Assert.Equal("Scoopty", result.Name);
            }
        }
        [Fact]
        public async Task SaveHotelInDBAsync()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("SaveRoomInDB")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Hoopty";
                hotel.StreetAddress = "Boopty";
                hotel.City = "Woopty";
                hotel.State = "Poopty";
                hotel.Phone = "4";

                context.Add(hotel);
                await context.SaveChangesAsync();

                Hotel result = await context.Hotels.FirstOrDefaultAsync(x => x.ID == hotel.ID);

                Assert.Equal("Hoopty", result.Name);
            }
        }
        [Fact]
        public async Task SaveAmenityInDBAsync()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("SaveRoomInDB")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenities = new Amenities();
                amenities.ID = 3;
                amenities.Name = "Fwoopty";

                context.Add(amenities);
                await context.SaveChangesAsync();

                Amenities result = await context.Amenities.FirstOrDefaultAsync(x => x.ID == amenities.ID);

                Assert.Equal("Fwoopty", result.Name);
            }
        }
        [Fact]
        public async Task SaveHotelRoomInDBAsync()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("SaveRoomInDB")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                HotelRoom hotelRoom = new HotelRoom();
                hotelRoom.HotelID = 6;
                hotelRoom.RoomID = 7;
                hotelRoom.RoomNumber = 8;
                hotelRoom.PetFriendly = true;
                hotelRoom.Rate = 9;

                context.Add(hotelRoom);
                await context.SaveChangesAsync();

                HotelRoom result = await context.HotelRooms.FirstOrDefaultAsync(x => x.RoomID == hotelRoom.RoomID);

                Assert.Equal(9, result.Rate);
            }
        }
        [Fact]
        public async Task SaveRoomAmenityInDBAsync()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("SaveRoomInDB")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                RoomAmenities roomAmenities = new RoomAmenities();
                roomAmenities.AmenitiesID = 4;
                roomAmenities.RoomID = 5;

                context.Add(roomAmenities);
                await context.SaveChangesAsync();

                RoomAmenities result = await context.RoomAmenities.FirstOrDefaultAsync(x => x.RoomID == roomAmenities.RoomID);

                Assert.Equal(5, result.RoomID);
            }
        }
        #endregion
    }
}
