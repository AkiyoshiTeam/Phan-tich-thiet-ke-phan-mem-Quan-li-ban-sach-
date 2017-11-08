using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaXuatBanDTO
    {
        private string _maNXB;

        public string MaNXB
        {
            get { return _maNXB; }
            set { _maNXB = value; }
        }
        private string _tenNXB;

        public string TenNXB
        {
            get { return _tenNXB; }
            set { _tenNXB = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _dienThoai;

        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }
    }
}
