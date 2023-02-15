using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class PLatform
    {
        [Required]
        public string Id { get; set; } = $"platform:{Guid.NewGuid().ToString()}";

        [Required]
        public string Name {get; set;} = String.Empty;
   
    }
}