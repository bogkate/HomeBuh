using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuhDb
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryId { get; set; }

        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
    }
}
