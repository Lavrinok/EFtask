using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EnFramework
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        public string  Name { get; set; }

        public int FoundationYear { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

    }
}
