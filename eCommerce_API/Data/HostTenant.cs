using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce_API_RST_Multi.Data
{
    public class HostTenant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Tenant Id")]
        public int Id { get; set; }
        public string TradingName { get; set; }
        public string DbConnectionString { get; set; }
    }
}
