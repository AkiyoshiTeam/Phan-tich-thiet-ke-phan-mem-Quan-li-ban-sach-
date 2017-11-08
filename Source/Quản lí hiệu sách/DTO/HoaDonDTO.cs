using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        private string _soHD;

        public string SoHD
        {
            get { return _soHD; }
            set { _soHD = value; }
        }
        private DateTime _ngayBan;

        public DateTime NgayBan
        {
            get { return _ngayBan; }
            set { _ngayBan = value; }
        }
        private long _tongTien;

        public long TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        private byte[] _hinhAnh;

        public byte[] HinhAnh
        {
            get { return _hinhAnh; }
            set { _hinhAnh = value; }
        }
    }
}
