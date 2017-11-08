using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class SachDAO
    {
        public static DataTable DanhSachSach()
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach, S.TenSach, S.MaTL, TL.TenTL, S.MaNXB, NXB.TenNXB, S.MaTG, TG.TenTG, S.SoLuongTon, S.GiaBan " +
                          "From ((Sach S join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG)" +
                          "join NhaXxuatBan NXB on S.MaNXB=NXB.MaNXB";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static string GetIDSach()
        {
            SqlConnection con = DataProvider.Connection();
            SqlCommand cmd = new SqlCommand("sp_GetIDSach", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@masach", SqlDbType.NChar);
            cmd.Parameters["@masach"].Direction = ParameterDirection.Output;
            cmd.Parameters["@masach"].Size = 10;
            cmd.ExecuteNonQuery();
            string MaSach = cmd.Parameters["@masach"].Value.ToString();
            con.Close();
            return MaSach;
        }
        public static bool ThemSach(SachDTO S)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_ThemSach", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters.Add("@tensach", SqlDbType.NVarChar);
                cmd.Parameters.Add("@maTL", SqlDbType.NChar);
                cmd.Parameters.Add("@maNXB", SqlDbType.NChar);
                cmd.Parameters.Add("@maTG", SqlDbType.NChar);
                cmd.Parameters["@masach"].Value = S.MaSach;
                cmd.Parameters["@tensach"].Value = S.TenSach;
                cmd.Parameters["@maTL"].Value = S.MaTL;
                cmd.Parameters["@maNXB"].Value = S.MaNXB;
                cmd.Parameters["@maTG"].Value = S.MaTG;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool XoaSach(string MaSach)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_XoaSach", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters["@masach"].Value = MaSach;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SuaSach(SachDTO S)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_SuaSach", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters.Add("@tensach", SqlDbType.NVarChar);
                cmd.Parameters.Add("@maTL", SqlDbType.NChar);
                cmd.Parameters.Add("@maNXB", SqlDbType.NChar);
                cmd.Parameters.Add("@maTG", SqlDbType.NChar);
                cmd.Parameters["@masach"].Value = S.MaSach;
                cmd.Parameters["@tensach"].Value = S.TenSach;
                cmd.Parameters["@maTL"].Value = S.MaTL;
                cmd.Parameters["@maNXB"].Value = S.MaNXB;
                cmd.Parameters["@maTG"].Value = S.MaTG;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable DanhSachTenSachTheoNXB(string maNXB)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select TenSach From Sach Where MaNXB='" + maNXB + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable DanhSachSachTheoTen(string Tensach)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach, TL.TenTL, TG.TenTG,S.GiaBan,S.SoLuongTon " +
                          "From (Sach S join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG " +
                          "Where S.TenSach=N'" + Tensach + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable DanhSachSachTheoMa(string MaSach)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select TenSach, GiaBan " +
                          "From Sach  " +
                          "Where MaSach=N'" + MaSach + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static bool UpdateSLTvaGB(string MaSach,long GiaNhap,int SoLuongNhap)
        {
            try
            {
                SqlConnection con = DataProvider.Connection();
                SqlCommand cmd = new SqlCommand("sp_UpdateSLTvaGB", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@masach", SqlDbType.NChar);
                cmd.Parameters.Add("@gianhap", SqlDbType.BigInt);
                cmd.Parameters.Add("@soluongnhap", SqlDbType.Int);
                cmd.Parameters["@masach"].Value = MaSach;
                cmd.Parameters["@gianhap"].Value = GiaNhap;
                cmd.Parameters["@soluongnhap"].Value = SoLuongNhap;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static DataTable TimKiemTheoTenSach(string TenSach)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach, S.TenSach, S.MaTL, TL.TenTL, S.MaNXB, NXB.TenNXB, S.MaTG, TG.TenTG, S.SoLuongTon, S.GiaBan " +
                          "From ((Sach S join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG)" +
                          "join NhaXxuatBan NXB on S.MaNXB=NXB.MaNXB Where S.TenSach LIKE N'%" + TenSach + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable TimKiemTheoTheLoai(string MaTL)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach, S.TenSach, S.MaTL, TL.TenTL, S.MaNXB, NXB.TenNXB, S.MaTG, TG.TenTG, S.SoLuongTon, S.GiaBan " +
                          "From ((Sach S join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG)" +
                          "join NhaXxuatBan NXB on S.MaNXB=NXB.MaNXB Where TL.MaTL='" + MaTL + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable TimKiemTheoTacGia(string TenTG)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach, S.TenSach, S.MaTL, TL.TenTL, S.MaNXB, NXB.TenNXB, S.MaTG, TG.TenTG, S.SoLuongTon, S.GiaBan " +
                          "From ((Sach S join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG)" +
                          "join NhaXxuatBan NXB on S.MaNXB=NXB.MaNXB Where TG.TenTG LIKE N'%" + TenTG + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable TimKiemTheoNXB(string MaNXB)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach, S.TenSach, S.MaTL, TL.TenTL, S.MaNXB, NXB.TenNXB, S.MaTG, TG.TenTG, S.SoLuongTon, S.GiaBan " +
                          "From ((Sach S join TheLoai TL on S.MaTL=TL.MaTL) join TacGia TG on S.MaTG=TG.MaTG)" +
                          "join NhaXxuatBan NXB on S.MaNXB=NXB.MaNXB Where NXB.MaNXB='" + MaNXB + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataTable BaoCaoDoanhThu(DateTime Ngay)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach,S.TenSach,CT.SoLuongBan,S.GiaBan,HD.NgayBan,CT.ThanhTien " +
                          "From (HoaDon HD join ChiTietHoaDon CT on HD.SoHD=CT.SoHD) join Sach S on CT.MaSach=S.MaSach " +
                          "Where HD.NgayBan='" + Ngay.Year + "-" + Ngay.Month + "-" + Ngay.Day + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataSet BaoCaoDoanhThuS(DateTime Ngay)
        {
            SqlConnection con = DataProvider.Connection();
            DataSet ds = new DataSet();
            string sql = @"Select S.MaSach,S.TenSach,CT.SoLuongBan,S.GiaBan,HD.NgayBan,CT.ThanhTien " +
                          "From (HoaDon HD join ChiTietHoaDon CT on HD.SoHD=CT.SoHD) join Sach S on CT.MaSach=S.MaSach " +
                          "Where HD.NgayBan='" + Ngay.Year + "-" + Ngay.Month + "-" + Ngay.Day + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "dtBaoCaoDoanhThu");
            con.Close();
            return ds;
        }
        public static DataSet ThongKeTonKho()
        {
            SqlConnection con = DataProvider.Connection();
            DataSet ds = new DataSet();
            string sql = @"Select MaSach, TenSach,SoLuongTon From Sach";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds, "dtTonKho");
            con.Close();
            return ds;
        }
        public static DataTable BaoCaoNhapKho(DateTime Ngay)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select S.MaSach,S.TenSach,CT.SoLuongNhap " +
                          "From (PhieuNhap PN join ChiTietPhieuNhap CT on PN.SoPN=CT.SoPN) join Sach S on CT.MaSach=S.MaSach " +
                          "where PN.NgayNhap= '" + Ngay.Year + "-" + Ngay.Month + "-" + Ngay.Day + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public static DataSet BaoCaoNhapKhoS(DateTime Ngay)
        {
            SqlConnection con = DataProvider.Connection();
            DataSet ds = new DataSet();
            string sql = @"Select S.MaSach,S.TenSach,CT.SoLuongNhap,PN.NgayNhap " +
                          "From (PhieuNhap PN join ChiTietPhieuNhap CT on PN.SoPN=CT.SoPN) join Sach S on CT.MaSach=S.MaSach " +
                          "where PN.NgayNhap= '" + Ngay.Year + "-" + Ngay.Month + "-" + Ngay.Day + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds,"dtNhapKho");
            con.Close();
            return ds;
        }
        public static DataTable BieuDo(DateTime Tu,DateTime Den)
        {
            SqlConnection con = DataProvider.Connection();
            DataTable dt = new DataTable();
            string sql = @"Select NgayBan,SUM(Tongtien) as 'Doanhthu' From HoaDon " +
                           "Where NgayBan between '" + Tu.Year + "-" + Tu.Month + "-" + Tu.Day + "' and '" + Den.Year + "-" + Den.Month + "-" + Den.Day + "' " +
                           "Group by NgayBan";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
