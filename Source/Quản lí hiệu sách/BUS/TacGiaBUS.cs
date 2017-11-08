using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class TacGiaBUS
    {
        public static DataTable DanhSachTacGia()
        {
            return TacGiaDAO.DanhSachTacGia();
        }
        public static string GetIDTG()
        {
            return TacGiaDAO.GetIDTG();
        }
        public static bool ThemTG(TacGiaDTO TG)
        {
            return TacGiaDAO.ThemTG(TG);
        }
        public static bool XoaTG(string MaTG)
        {
            return TacGiaDAO.XoaTG(MaTG);
        }
        public static bool SuaTG(TacGiaDTO TG)
        {
            return TacGiaDAO.SuaTG(TG);
        }
    }
}
