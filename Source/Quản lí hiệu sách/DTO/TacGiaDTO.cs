using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TacGiaDTO
    {
        private string _maTG;

        public string MaTG
        {
            get { return _maTG; }
            set { _maTG = value; }
        }
        private string _tenTG;

        public string TenTG
        {
            get { return _tenTG; }
            set { _tenTG = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
    }
}
