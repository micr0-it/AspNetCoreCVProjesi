using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        [Key]
        public int PortfolioID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string DateStart { get; set; }
        public string DateFinish { get; set; }
        public string Cost { get; set; }
        public string ImgUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string BigImgUrl { get; set; }

    }
}
