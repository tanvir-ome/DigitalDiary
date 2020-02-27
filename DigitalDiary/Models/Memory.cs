//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalDiary.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Memory
    {
        public int MemoryId { get; set; }

        [DisplayName("Experience")]
        public string Experience { get; set; }

        [DisplayName("Thoughts")]
        public string Thoughts { get; set; }

        [DisplayName("Feelings")]
        public string Feelings { get; set; }

        [DisplayName("Comments")]
        public string Comments { get; set; }

        [DisplayName("Memory Date")]
        public string MemoryDate { get; set; }

        [DisplayName("Images")]
        public string ImagePath { get; set; }

        [DisplayName("Last Modified")]
        public string LastModificationDate { get; set; }

        [DisplayName("Importance")]
        public int ImportanceId { get; set; }
        public int UserId { get; set; }
    
        public virtual Importance Importance { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual User User { get; set; }

        [NotMapped]
        public IEnumerable<Importance> ImportanceClassifierCollection { get; set; }
    }
}