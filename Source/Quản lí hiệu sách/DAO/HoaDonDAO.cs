using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class HoaDonDAO
    {
        public static DataTable LoadDSHoaDon()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select * From HoaDon";
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable LoadDSCTHoaDon(string SoHD)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach,S.TenSach,CTHD.SoLuongBan,CTHD.GiaBan,CTHD.ThanhTien " +
                          "From (HoaDon HD join ChiTietHoaDon CTHD on HD.SoHD=CTHD.SoHD) join Sach S on CTHD.MaSach=S.MaSach " +
                          "Where HD.SoHD='" + SoHD + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool XoaHD(string SoHD)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaHD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@soHD", SqlDbType.NChar);
                cmd.Parameters["@soHD"].Value = SoHD;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetIDHoaDon()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDHoaDon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sohd", SqlDbType.NChar);
            cmd.Parameters["@sohd"].Direction = ParameterDirection.Output;
            cmd.Parameters["@sohd"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaSach = cmd.Parameters["@sohd"].Value.ToString();
            con.Close();
            return MaSach;
        }
        public static bool ThemHD(HoaDonDTO HD)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemHD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sohd", SqlDbType.NChar);
                cmd.Parameters.Add("@ngayban", SqlDbType.Date);
                cmd.Parameters.Add("@image", SqlDbType.Image);
                cmd.Parameters["@sohd"].Value = HD.SoHD;
                cmd.Parameters["@ngayban"].Value = HD.NgayBan;
                cmd.Parameters["@image"].Value = HD.HinhAnh;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ThemCTHD(ChiTietHoaDonDTO CTHD)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemCTHD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sohd", SqlDbType.NChar);
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters.Add("@soluongban", SqlDbType.Int);
                cmd.Parameters.Add("@giaban", SqlDbType.BigInt);
                cmd.Parameters.Add("@thanhtien", SqlDbType.BigInt);
                cmd.Parameters["@sohd"].Value = CTHD.SoHD;
                cmd.Parameters["@masach"].Value = CTHD.MaSach;
                cmd.Parameters["@soluongban"].Value = CTHD.SoLuongBan;
                cmd.Parameters["@giaban"].Value = CTHD.GiaBan;
                cmd.Parameters["@thanhtien"].Value = CTHD.ThanhTien;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateTT(string SoHD, long TongTien)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                string sql = @"Update HoaDon set TongTien='" + TongTien.ToString() + "' Where SoHD='" + SoHD + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateSLT(string MaSach,int SoLuongBan)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_UpdateSLT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters.Add("@soluongban", SqlDbType.Int);
                cmd.Parameters["@masach"].Value = MaSach;
                cmd.Parameters["@soluongban"].Value = SoLuongBan;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataSet XuatHoaDon(string SoHD)
        {
            SqlConnection con = DataProvider.Connection();
            DataSet dtset = new DataSet();
            string sql = @"Select HD.SoHD,HD.NgayBan,HD.Tongtien,S.MaSach,S.TenSach,CT.SoLuongBan,S.GiaBan,HD.HinhAnh " +
                          "From (HoaDon HD join ChiTietHoaDon CT on HD.SoHD=CT.SoHD) join Sach S on CT.MaSach=S.MaSach " +
                          "Where HD.SoHD='" + SoHD + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dtset, "dtHoaDon");
            con.Close();
            return dtset;
        }
    }
}
