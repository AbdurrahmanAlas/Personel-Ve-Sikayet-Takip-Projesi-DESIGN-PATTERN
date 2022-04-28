using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IPetrolRuhsatService
    {
        List<PetrolRuhsat> GetList();
        List<PetrolRuhsat> GetListByWriter(int id);
        void PetrolRuhsatAdd(PetrolRuhsat heading);

        PetrolRuhsat GetByID(int id);
        void PetrolRuhsatDelete(PetrolRuhsat heading);
        void PetrolRuhsatUpdate(PetrolRuhsat heading);
    }
}
