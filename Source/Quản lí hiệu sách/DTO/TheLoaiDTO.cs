using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TheLoaiDTO
    {
        private string _maTL;

        public string MaTL
        {
            get { return _maTL; }
            set { _maTL = value; }
        }
        private string _tenTL;

        public string TenTL
        {
            get { return _tenTL; }
            set { _tenTL = value; }
        }
    }
}
