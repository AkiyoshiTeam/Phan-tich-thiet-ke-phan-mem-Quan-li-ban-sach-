using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class PhieuNhapDAO
    {
        public static string GetIDPhieuNhap()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDPhieuNhap", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sopn", SqlDbType.NChar);
            cmd.Parameters["@sopn"].Direction = ParameterDirection.Output;
            cmd.Parameters["@sopn"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaSach = cmd.Parameters["@sopn"].Value.ToString();
            con.Close();
            return MaSach;
        }
        public static bool ThemPN(PhieuNhapDTO PN)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemPN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sopn", SqlDbType.NChar);
                cmd.Parameters.Add("@ngaynhap", SqlDbType.Date);
                cmd.Parameters.Add("@maNXB", SqlDbType.NChar);
                cmd.Parameters.Add("@image", SqlDbType.Image);
                cmd.Parameters["@sopn"].Value = PN.SoPN;
                cmd.Parameters["@ngaynhap"].Value = PN.NgayNhap;
                cmd.Parameters["@maNXB"].Value = PN.MaNXB;
                cmd.Parameters["@image"].Value = PN.HinhAnh;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ThemCTPN(ChiTietPhieuNhapDTO PN)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemCTPhieuNhap", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sopn", SqlDbType.NChar);
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters.Add("@soluongnhap", SqlDbType.Int);
                cmd.Parameters.Add("@gianhap", SqlDbType.BigInt);
                cmd.Parameters["@sopn"].Value = PN.SoPN;
                cmd.Parameters["@masach"].Value = PN.MaSach;
                cmd.Parameters["@soluongnhap"].Value = PN.SoLuongNhap;
                cmd.Parameters["@gianhap"].Value = PN.GiaNhap;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool XoaPN(string SoPN)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaPN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sopn", SqlDbType.NChar);
                cmd.Parameters["@sopn"].Value = SoPN;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable DanhSachCTPN(string SoPN)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach,S.TenSach,TL.TenTL,TG.TenTG,CT.SoLuongNhap,CT.GiaNhap " +
                          "From (((ChiTietPhieuNhap CT join PhieuNhap PN on CT.SoPN=PN.SoPN) join Sach S on CT.MaSach=S.MaSach) " +
                          "join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG " +
                          "Where PN.SoPN='" + SoPN + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable DanhSachPN()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select PN.SoPN, PN.NgayNhap, PN.TongTien, NXB.TenNXB From PhieuNhap PN join NhaXxuatBan NXB on PN.MaNXB=NXB.MaNXB";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool UpdateTT(string SoPN,long TongTien)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                string sql = @"Update PhieuNhap set TongTien='" + TongTien.ToString() + "' Where SoPN='" + SoPN + "'";
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
        public static DataSet XuatPhieuNhapSach(string SoPN)
        {
            SqlConnection con = DataProvider.Connection();
            DataSet dtset = new DataSet();
            string sql = @"Select PN.SoPN, PN.NgayNhap, NXB.TenNXB, PN.TongTien, S.MaSach, S.TenSach, CT.SoLuongNhap, CT.GiaNhap,PN.HinhAnh " +
                          "From ((PhieuNhap PN join ChiTietPhieuNhap CT on PN.SoPN=CT.SoPN) join Sach S on CT.MaSach=S.MaSach) " +
                          "join NhaXxuatBan NXB on PN.MaNXB=NXB.MaNXB Where PN.SoPN='" + SoPN + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dtset, "dtXuatPhieuNhap");
            con.Close();
            return dtset;
        }
    }
}
