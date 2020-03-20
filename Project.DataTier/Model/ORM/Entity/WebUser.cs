using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataTier.Model.ORM.Entity
{
    public class WebUser:Base
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string ImagePath { get; set; }
    }
}
