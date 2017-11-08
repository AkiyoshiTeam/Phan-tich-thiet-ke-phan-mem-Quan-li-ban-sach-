using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class PhieuNhapBUS
    {
        public static string GetIDPhieuNhap()
        {
            return PhieuNhapDAO.GetIDPhieuNhap();
        }
        public static bool ThemPN(PhieuNhapDTO PN)
        {
            return PhieuNhapDAO.ThemPN(PN);
        }
        public static bool ThemCTPN(ChiTietPhieuNhapDTO PN)
        {
            return PhieuNhapDAO.ThemCTPN(PN);
        }
        public static bool XoaPN(string SoPN)
        {
            return PhieuNhapDAO.XoaPN(SoPN); 
        }
        public static DataTable DanhSachCTPN(string SoPN)
        {
            return PhieuNhapDAO.DanhSachCTPN(SoPN);
        }
        public static DataTable DanhSachPN()
        {
            return PhieuNhapDAO.DanhSachPN();
        }
        public static bool UpdateTT(string SoPN,long TongTien)
        {
            return PhieuNhapDAO.UpdateTT(SoPN, TongTien);
        }
        public static DataSet XuatPhieuNhapSach(string SoPN)
        {
            return PhieuNhapDAO.XuatPhieuNhapSach(SoPN);
        }
    }
}
