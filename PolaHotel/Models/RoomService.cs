using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolaHotel.Models
{
    public class RoomService
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        [Key, Column(Order = 2)]
        [ForeignKey("Services")]
        public int ServiceID { get; set; }
        [Required]
        public bool IsAvailble { get; set; }

        public virtual Room Room { get; set; }
        public virtual Services Services { get; set; }
    }
}