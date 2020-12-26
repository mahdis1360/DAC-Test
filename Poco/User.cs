using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poco
    
{
    [Table("User")]
    public class User : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Family { get; set; }

        [Required]
        public string  UserName { get; set; }

        [Required]
        public string Email{ get; set; }

        [Required]
        public string Password { get; set; }
      

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? Birthdate { get; set; }

        public virtual  MemberShipTypes MemberShipTypes { get; set; }
       
    }
}
