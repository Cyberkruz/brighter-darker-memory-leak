using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterDarkerMemory.Web.Domain
{
    public class TestItem
    {
        [Key]
        public Guid SampleItemId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }
    }
}
