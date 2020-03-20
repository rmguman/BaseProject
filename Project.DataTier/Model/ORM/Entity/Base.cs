using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataTier.Model.ORM.Entity
{
    public class Base
    {
        public int ID { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime AddDate { get; set; }
    }
}
