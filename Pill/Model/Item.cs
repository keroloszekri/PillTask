using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pill.Model
{
    class Item
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public string Total { get; set; }
        public int Discount { get; set; }
        public double Net { get; set; }

        public int PillID { get; set; }
        [ForeignKey("PillID")]
        public virtual Fat  Pill { get; set; }

    }
}
