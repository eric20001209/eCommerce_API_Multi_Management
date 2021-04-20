using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Host.Models
{
    public class ApplicationHost

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HostId { get; set; }
        public string TradingName { get; set; }
        public string ConnectionString { get; set; }
        public string ApiRoot { get; set; }
    }
}
