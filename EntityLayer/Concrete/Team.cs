using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Team
    {
        [Key]
        public int PersonID { get; set; }


        public int PersonName { get; set; }

        public int PersonDuty { get; set; }

        public int ImageUrl { get; set; }

        public int FacebookUrl { get; set; }

        public int InstagramUrl { get; set; }

        public int WebsiteUrl { get; set; }

        public int TwitterUrl { get; set; }


    }
}
