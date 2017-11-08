using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class NhaXuatBanBUS
    {
        public static DataTable DanhSachNXB()
        {
            return NhaXuatBanDAO.DanhSachNXB();
        }
        public static string GetIDNXB()
        {
            return NhaXuatBanDAO.GetIDNXB();
        }
        public static bool ThemNXB(NhaXuatBanDTO NXB)
        {
            return NhaXuatBanDAO.ThemNXB(NXB);
        }
        public static bool XoaNXB(string MaNXB)
        {
            return NhaXuatBanDAO.XoaNXB(MaNXB);
        }
        public static bool SuaNXB(NhaXuatBanDTO NXB)
        {
            return NhaXuatBanDAO.SuaNXB(NXB);
        }
    }
}
