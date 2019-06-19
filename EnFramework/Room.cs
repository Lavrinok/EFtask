using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EnFramework
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public Hotel Hotel { get; set; }
        public int Number { get; set; }
        public Comforts Comfort { get; set; }
        public Capabilities Capability { get; set; }
        public decimal Price { get; set; }
        public enum Comforts
        {
            FirstLevel = 1,
            SecondLevel = 2,
            ThirdLevel = 3
        }
        public enum Capabilities
        {
            Single = 1,
            Double = 2,
            Triple = 3,
            Quadruple = 4

        }

    }
}
