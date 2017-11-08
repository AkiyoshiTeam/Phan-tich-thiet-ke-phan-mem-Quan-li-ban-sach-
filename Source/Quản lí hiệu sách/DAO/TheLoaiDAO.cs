using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class TheLoaiDAO
    {
        public static DataTable DanhSachTheLoai()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select * From TheLoai";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static string GetIDTheLoai()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDTheLoai", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@matl", SqlDbType.NChar);
            cmd.Parameters["@matl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@matl"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaSach = cmd.Parameters["@matl"].Value.ToString();
            con.Close();
            return MaSach;
        }
        public static bool ThemTL(TheLoaiDTO TL)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@matl", SqlDbType.NChar);
                cmd.Parameters.Add("@tentl", SqlDbType.NVarChar);
                cmd.Parameters["@matl"].Value = TL.MaTL;
                cmd.Parameters["@tentl"].Value = TL.TenTL;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool XoaTL(string MaTL)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@matl", SqlDbType.NChar);
                cmd.Parameters["@matl"].Value = MaTL;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaTL(TheLoaiDTO TL)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_SuaTL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@matl", SqlDbType.NChar);
                cmd.Parameters.Add("@tentl", SqlDbType.NVarChar);
                cmd.Parameters["@matl"].Value = TL.MaTL;
                cmd.Parameters["@tentl"].Value = TL.TenTL;
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
