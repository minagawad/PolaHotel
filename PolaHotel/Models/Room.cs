using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PolaHotel.Models
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Remote(action: "CheckRoomNumber", controller: "Room", ErrorMessage = "Room Already Exist")]
        public int Room_Number { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
        [Required]
        [Display(Name = "Entert Room Price ?")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "You should select room's availability?")]
        public bool isavailble { get; set; }

        [Required(ErrorMessage = "enter number of Beeds")]
        [Range(1, 4, ErrorMessage = "Number Of Beds Must Be Less Than 5 Beds")]
        public int NumberOfBeeds { get; set; }


        [Required(ErrorMessage = "Enter Room Category")]
        [ForeignKey("Room_Category")]
        public int Room_Categ_ID { get; set; }
        [ForeignKey("Room_Categ_ID")]
        public virtual Room_Category Room_Category { get; set; }
        public virtual ICollection<RoomService> RoomServices { get; set; }



    }
}