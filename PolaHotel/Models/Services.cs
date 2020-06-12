using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PolaHotel.Models
{
    public class Services
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="you should Enter Service Name")]
        [Display(Name="Service Name")]
        public string Name { get; set; }

       

        public virtual ICollection<RoomService> RoomServices { get; set; }
       
        


    }
}