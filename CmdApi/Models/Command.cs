using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.Models
{
    public class Command
    { 
        [Key]
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Platform { get; set; }
        public string Commandline { get; set; }
    }
}
