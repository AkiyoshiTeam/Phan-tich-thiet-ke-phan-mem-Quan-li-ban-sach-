using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DTO;
using DAO;
namespace BUS
{
    public class HoaDonBUS
    {
        public static DataTable LoadDSHoaDon()
        {
            return HoaDonDAO.LoadDSHoaDon();
        }
        public static DataTable LoadDSCTHoaDon(string SoHD)
        {
            return HoaDonDAO.LoadDSCTHoaDon(SoHD);
        }
        public static bool XoaHD(string SoHD)
        {
            return HoaDonDAO.XoaHD(SoHD);
        }
        public static string GetIDHoaDon()
        {
            return HoaDonDAO.GetIDHoaDon();
        }
        public static bool ThemHD(HoaDonDTO HD)
        {
            return HoaDonDAO.ThemHD(HD);
        }
        public static bool ThemCTHD(ChiTietHoaDonDTO CTHD)
        {
            return HoaDonDAO.ThemCTHD(CTHD);
        }
        public static bool UpdateTT(string SoHD, long TongTien)
        {
            return HoaDonDAO.UpdateTT(SoHD, TongTien);
        }
        public static bool UpdateSLT(string MaSach,int SoLuongBan)
        {
            return HoaDonDAO.UpdateSLT(MaSach, SoLuongBan);
        }
        public static DataSet XuatHoaDon(string SoHD)
        {
            return HoaDonDAO.XuatHoaDon(SoHD);
        }
    }
}
