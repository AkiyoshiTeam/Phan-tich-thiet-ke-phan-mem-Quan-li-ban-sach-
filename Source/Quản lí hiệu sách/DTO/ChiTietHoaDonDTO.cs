using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        private string _soHD;

        public string SoHD
        {
            get { return _soHD; }
            set { _soHD = value; }
        }
        private string _maSach;

        public string MaSach
        {
            get { return _maSach; }
            set { _maSach = value; }
        }
        private int _soLuongBan;

        public int SoLuongBan
        {
            get { return _soLuongBan; }
            set { _soLuongBan = value; }
        }
        private long _giaBan;

        public long GiaBan
        {
            get { return _giaBan; }
            set { _giaBan = value; }
        }
        private long _thanhTien;

        public long ThanhTien
        {
            get { return _thanhTien; }
            set { _thanhTien = value; }
        }
    }
}
