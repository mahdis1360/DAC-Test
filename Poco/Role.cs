using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Poco
{
    [Table("Role")]
   public class Role
    {
        [Key]
        public short role{ get; set; }
        public byte NameOfRole { get; set; }
        public virtual User User { get; set; }

    }
}
