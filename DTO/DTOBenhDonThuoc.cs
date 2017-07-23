using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class DTOBenhDonThuoc
    {
        int MaBDT;
        DTOBenhNhan BenhNhan;
        string KetLuan;
        List<DTOCT_BenhDonThuoc> CT_BenhDonThuoc;

        DTOBenhDonThuoc()
        {
            CT_BenhDonThuoc = new List<DTOCT_BenhDonThuoc>();
        }
    }
}
