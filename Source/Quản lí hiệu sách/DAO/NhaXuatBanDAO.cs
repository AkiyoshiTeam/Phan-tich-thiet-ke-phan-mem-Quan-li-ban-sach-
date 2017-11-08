using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class NhaXuatBanDAO
    {
        public static DataTable DanhSachNXB()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select * From NhaXxuatBan";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static string GetIDNXB()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDNXB", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@manxb", SqlDbType.NChar);
            cmd.Parameters["@manxb"].Direction = ParameterDirection.Output;
            cmd.Parameters["@manxb"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaSach = cmd.Parameters["@manxb"].Value.ToString();
            con.Close();
            return MaSach;
        }
        public static bool ThemNXB(NhaXuatBanDTO NXB)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemNXB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@manxb", SqlDbType.NChar);
                cmd.Parameters.Add("@tennxb", SqlDbType.NVarChar);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
                cmd.Parameters.Add("@dienthoai", SqlDbType.NChar);
                cmd.Parameters["@manxb"].Value = NXB.MaNXB;
                cmd.Parameters["@tennxb"].Value = NXB.TenNXB;
                cmd.Parameters["@diachi"].Value = NXB.DiaChi;
                cmd.Parameters["@dienthoai"].Value = NXB.DienThoai;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool XoaNXB(string MaNXB)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaNXB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@manxb", SqlDbType.NChar);
                cmd.Parameters["@manxb"].Value = MaNXB;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaNXB(NhaXuatBanDTO NXB)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_SuaNXB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@manxb", SqlDbType.NChar);
                cmd.Parameters.Add("@tennxb", SqlDbType.NVarChar);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
                cmd.Parameters.Add("@dienthoai", SqlDbType.NChar);
                cmd.Parameters["@manxb"].Value = NXB.MaNXB;
                cmd.Parameters["@tennxb"].Value = NXB.TenNXB;
                cmd.Parameters["@diachi"].Value = NXB.DiaChi;
                cmd.Parameters["@dienthoai"].Value = NXB.DienThoai;
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
