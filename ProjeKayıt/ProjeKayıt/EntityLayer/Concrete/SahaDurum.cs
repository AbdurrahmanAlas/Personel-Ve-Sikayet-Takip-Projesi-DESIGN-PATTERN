using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
 public class SahaDurum
    {

        [Key]
        public int SahaId { get; set; }
        [StringLength(50)]
        public string SahaName { get; set; }
        public string SahaAdres { get; set; }
        public string SahaAda { get; set; }
        public string SahaParsel { get; set; }
        public string SahaTelefon { get; set; }
        public DateTime SahaDate { get; set; }
        public bool SahaStatus { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }

    }
}
