using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Layout Layout { get; set; }

        // nav properties
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
        public ICollection<HotelRoom> HotelRooms { get; set; }

    }
    public enum Layout
    {
        Studio,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom
    }
}
