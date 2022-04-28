using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class Punishment
    {
        [Key]
        public int CezaId { get; set; }
        public string DocumentTipi { get; set; }
        public string CompanyName { get; set; }
        public string CezaTeam { get; set; }
        public string Description { get; set; }
        public string DocumentName { get; set; }
        public string CezaPhoto { get; set; }
        public decimal CezaAmont { get; set; }
        public bool Status { get; set; }
        public DateTime CezaDate { get; set; }
        //public int CompanyId { get; set; }
        //public Company Company { get; set; }

        //public int? VehicleId { get; set; }
      
    }
}
