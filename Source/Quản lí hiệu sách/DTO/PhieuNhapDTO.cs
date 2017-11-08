using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapDTO
    {
        private string _soPN;

        public string SoPN
        {
            get { return _soPN; }
            set { _soPN = value; }
        }
        private DateTime _ngayNhap;

        public DateTime NgayNhap
        {
            get { return _ngayNhap; }
            set { _ngayNhap = value; }
        }
        private string _maNXB;

        public string MaNXB
        {
            get { return _maNXB; }
            set { _maNXB = value; }
        }
        private byte[] _hinhAnh;

        public byte[] HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }
    }
}
