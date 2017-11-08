using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class TheLoaiBUS
    {
        public static DataTable DanhSachTheLoai()
        {
            return TheLoaiDAO.DanhSachTheLoai();
        }
        public static string GetIDTheLoai()
        {
            return TheLoaiDAO.GetIDTheLoai();
        }
        public static bool ThemTL(TheLoaiDTO TL)
        {
            return TheLoaiDAO.ThemTL(TL);
        }
        public static bool XoaTL(string MaTL)
        {
            return TheLoaiDAO.XoaTL(MaTL);
        }
        public static bool SuaTL(TheLoaiDTO TL)
        {
            return TheLoaiDAO.SuaTL(TL);
        }
    }
}
