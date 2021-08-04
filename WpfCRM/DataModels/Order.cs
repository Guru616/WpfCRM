using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCRM.DataModels
{
    class Order
    {
        [Key] public int id { get; set; }
        public int Id_product { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
