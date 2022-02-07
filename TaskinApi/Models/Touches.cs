using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TaskinApi
{
    public class Touches
    {
       
        public int Id { get; set; }
        [MaxLength]
        public byte[] pic { get; set; }

        public string description { get; set; }

        public int ListTypeId { get; set; }

    }
}
