using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public string ContentMahalle { get; set; }
        public int ContentAdaNo { get; set; }
        public int ContentParselNo { get; set; }
        public string ContentSonuc { get; set; }
        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }

        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }

    }
}
