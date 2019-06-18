using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EnFramework
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        public DateTime StartDate { get; set; }
        private DateTime endDate;
        public DateTime EndDate => endDate;

        public void SetEndDate(DateTime value)
         {
            if (value > StartDate)
            {
                endDate = value;
            }
            else
            {
                Console.WriteLine("Error!StartDate is bigger than EndDate");
                    
                    }
        }
        public User User { get; set; }
        public Room Room { get; set; }

    }
}
