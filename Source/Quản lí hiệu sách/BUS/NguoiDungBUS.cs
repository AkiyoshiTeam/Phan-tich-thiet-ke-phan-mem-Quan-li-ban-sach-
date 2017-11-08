using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class NguoiDungBUS
    {
        public static DataTable DangNhap(string Username)
        {
            return NguoiDungDAO.DangNhap(Username);
        }
        public static bool ChangePassword (string Username, string Password)
        {
            return NguoiDungDAO.ChangePassword(Username, Password);
        }
        public static DataTable LoadDSNhanVien()
        {
            return NguoiDungDAO.LoadDSNhanVien();
        }
        public static string GetIDNguoidung()
        {
            return NguoiDungDAO.GetIDNguoidung();
        }
        public static bool ThemND(NguoiDungDTO ND)
        {
            return NguoiDungDAO.ThemND(ND);
        }
        public static bool XoaND(string MaND)
        {
            return NguoiDungDAO.XoaND(MaND);
        }
        public static bool SuaND(NguoiDungDTO ND)
        {
            return NguoiDungDAO.SuaND(ND);
        }
    }
}
