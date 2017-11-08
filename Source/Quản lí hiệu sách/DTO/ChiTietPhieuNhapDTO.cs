using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuNhapDTO
    {
        private string _soPN;

        public string SoPN
        {
            get { return _soPN; }
            set { _soPN = value; }
        }
        private string _maSach;

        public string MaSach
        {
            get { return _maSach; }
            set { _maSach = value; }
        }
        private int _soLuongNhap;

        public int SoLuongNhap
        {
            get { return _soLuongNhap; }
            set { _soLuongNhap = value; }
        }
        private long _giaNhap;

        public long GiaNhap
        {
            get { return _giaNhap; }
            set { _giaNhap = value; }
        }
    }
}
