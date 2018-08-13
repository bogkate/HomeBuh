using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuhDb
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }
    }
}
