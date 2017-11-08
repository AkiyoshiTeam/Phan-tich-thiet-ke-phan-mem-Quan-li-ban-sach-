using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class TacGiaDAO
    {
        public static DataTable DanhSachTacGia()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select * From TacGia";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static string GetIDTG()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDTG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@matg", SqlDbType.NChar);
            cmd.Parameters["@matg"].Direction = ParameterDirection.Output;
            cmd.Parameters["@matg"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaSach = cmd.Parameters["@matg"].Value.ToString();
            con.Close();
            return MaSach;
        }
        public static bool ThemTG(TacGiaDTO TG)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemTG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@matg", SqlDbType.NChar);
                cmd.Parameters.Add("@tentg", SqlDbType.NVarChar);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
                cmd.Parameters["@matg"].Value = TG.MaTG;
                cmd.Parameters["@tentg"].Value = TG.TenTG;
                cmd.Parameters["@diachi"].Value = TG.DiaChi;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool XoaTG(string MaTG)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaTG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@matg", SqlDbType.NChar);
                cmd.Parameters["@matg"].Value = MaTG;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTG(TacGiaDTO TG)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_SuaTG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@matg", SqlDbType.NChar);
                cmd.Parameters.Add("@tentg", SqlDbType.NVarChar);
                cmd.Parameters.Add("@diachi", SqlDbType.NVarChar);
                cmd.Parameters["@matg"].Value = TG.MaTG;
                cmd.Parameters["@tentg"].Value = TG.TenTG;
                cmd.Parameters["@diachi"].Value = TG.DiaChi;
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
