using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISahaService
    {
        List<SahaDurum> GetList();
        List<SahaDurum> GetListByWriter(int id);
        void SahaAdd(SahaDurum heading);

        SahaDurum GetByID(int id);
        void SahaDelete(SahaDurum heading);
        void SahaUpdate(SahaDurum heading);
    }
}
