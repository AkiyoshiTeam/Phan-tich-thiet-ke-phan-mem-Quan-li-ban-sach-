using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class NguoiDungDAO
    {
        public static DataTable DangNhap(string Username)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select * From NguoiDung Where Username='" + Username + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool ChangePassword (string Username, string Password)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NChar);
                cmd.Parameters.Add("@newpass", SqlDbType.NChar);
                cmd.Parameters["@username"].Value = Username;
                cmd.Parameters["@newpass"].Value = Password;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable LoadDSNhanVien()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select * From NguoiDung";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static string GetIDNguoidung()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDNguoiDung", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mand", SqlDbType.NChar);
            cmd.Parameters["@mand"].Direction = ParameterDirection.Output;
            cmd.Parameters["@mand"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaND = cmd.Parameters["@mand"].Value.ToString();
            con.Close();
            return MaND;
        }
        public static bool ThemND(NguoiDungDTO ND)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemND", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mand", SqlDbType.NChar);
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar);
                cmd.Parameters.Add("@username", SqlDbType.Char);
                cmd.Parameters.Add("@pass", SqlDbType.Char);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
                cmd.Parameters.Add("@cmnd", SqlDbType.NChar);
                cmd.Parameters.Add("@phanquyen", SqlDbType.NChar);
                cmd.Parameters.Add("@dienthoai", SqlDbType.NChar);
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar);
                cmd.Parameters["@mand"].Value = ND.MaND;
                cmd.Parameters["@hoten"].Value = ND.HoTen;
                cmd.Parameters["@username"].Value = ND.Username;
                cmd.Parameters["@pass"].Value = ND.Password;
                cmd.Parameters["@diachi"].Value = ND.DiaChi;
                cmd.Parameters["@cmnd"].Value = ND.SoCMND;
                cmd.Parameters["@phanquyen"].Value = ND.PhanQuyen;
                cmd.Parameters["@dienthoai"].Value = ND.DienThoai;
                cmd.Parameters["@gioitinh"].Value = ND.GioiTinh;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool XoaND(string MaND)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaND", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mand", SqlDbType.NChar);
                cmd.Parameters["@mand"].Value = MaND;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaND(NguoiDungDTO ND)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_SuaND", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@mand", SqlDbType.NChar);
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar);
                cmd.Parameters.Add("@username", SqlDbType.Char);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
                cmd.Parameters.Add("@cmnd", SqlDbType.NChar);
                cmd.Parameters.Add("@phanquyen", SqlDbType.NChar);
                cmd.Parameters.Add("@dienthoai", SqlDbType.NChar);
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar);
                cmd.Parameters["@mand"].Value = ND.MaND;
                cmd.Parameters["@hoten"].Value = ND.HoTen;
                cmd.Parameters["@username"].Value = ND.Username;
                cmd.Parameters["@diachi"].Value = ND.DiaChi;
                cmd.Parameters["@cmnd"].Value = ND.SoCMND;
                cmd.Parameters["@phanquyen"].Value = ND.PhanQuyen;
                cmd.Parameters["@dienthoai"].Value = ND.DienThoai;
                cmd.Parameters["@gioitinh"].Value = ND.GioiTinh;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
