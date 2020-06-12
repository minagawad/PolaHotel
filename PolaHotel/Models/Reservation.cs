using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PolaHotel.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        public DateTime ChickIn { get; set; }

        public DateTime choutOut { get; set; }




        public DateTime ReserveDate
        {
            get
            {
                return this.ReserveDate;
            }
            private

              set { this.ReserveDate = value; }
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Period { get { return this.Period; } set { this.Period = this.choutOut.Day - this.ChickIn.Day; } }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("room")]
        public int RoomNumber { get; set; }

        [ForeignKey("RoomNumber")]
        public virtual Room room { get; set; }
    }
}