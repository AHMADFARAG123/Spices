using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spices.Models
{
    public class OrderDetail    //  lecture9   00:13:00
    { 

        [Key]
        public int id { get; set; }
        [Required]
        public int orderiD { get; set; }
        [ForeignKey("orderiD")]
        public virtual OrderHeader OrderHeadEr { get; set; }

        public int MenuIteMid { get; set; }
        [ForeignKey("MenuIteMid")]
        public virtual MenItem MenItEm { get; set; }

        public int cOunt  { get; set; }

        public string Name { get; set; }// اسم المينو ايتم

        public string Description { get; set; } //وصف المنيو ايتم
        public double Price { get; set; }
    }
}
