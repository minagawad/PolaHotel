using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolaHotel.Models
{
    public class Room_Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage ="You Must Enter Category Name")]
        [Display(Name ="Enter Category Nane")]
        public string Category_Name { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }



    }
}