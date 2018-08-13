using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBuhDb
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PaymentId { get; set; }

        public virtual Product Product { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
    }
}
