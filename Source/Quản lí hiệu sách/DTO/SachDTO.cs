using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SachDTO
    {
        private string _maSach;

        public string MaSach
        {
            get { return _maSach; }
            set { _maSach = value; }
        }
        private string _tenSach;

        public string TenSach
        {
            get { return _tenSach; }
            set { _tenSach = value; }
        }
        private string _maTL;

        public string MaTL
        {
            get { return _maTL; }
            set { _maTL = value; }
        }
        private string _maNXB;

        public string MaNXB
        {
            get { return _maNXB; }
            set { _maNXB = value; }
        }
        private string _maTG;

        public string MaTG
        {
            get { return _maTG; }
            set { _maTG = value; }
        }
        private int _soLuongTon;

        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set { _soLuongTon = value; }
        }
        private long _giaBan;

        public long GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }
        }
    }
}
