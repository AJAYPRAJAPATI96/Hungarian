using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hungarian.Models

{[Table("Contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }
        [Required]
        public string CName { get; set; }
        [Required]
        public string CEmail { get; set; }
        [Required]
        [RegularExpression(@"^([0-9]{10})$")]
        public long CContact { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
