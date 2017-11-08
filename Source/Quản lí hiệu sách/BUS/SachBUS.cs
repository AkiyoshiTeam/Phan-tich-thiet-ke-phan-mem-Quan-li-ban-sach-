using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class SachBUS
    {
        public static DataTable DanhSachSach()
        {
            return SachDAO.DanhSachSach();
        }
        public static string GetIDSach()
        {
            return SachDAO.GetIDSach();
        }
        public static bool ThemSach(SachDTO S)
        {
            return SachDAO.ThemSach(S);
        }
        public static bool XoaSach(string MaSach)
        {
            return SachDAO.XoaSach(MaSach);
        }
        public static bool SuaSach(SachDTO S)
        {
            return SachDAO.SuaSach(S);
        }
        public static DataTable DanhSachTenSachTheoNXB(string maNXB)
        {
            return SachDAO.DanhSachTenSachTheoNXB(maNXB);
        }
        public static DataTable DanhSachSachTheoTen(string Tensach)
        {
            return SachDAO.DanhSachSachTheoTen(Tensach);
        }
         public static DataTable DanhSachSachTheoMa(string MaSach)
        {
            return SachDAO.DanhSachSachTheoMa(MaSach);
        }
        public static bool UpdateSLTvaGB(string MaSach, long GiaNhap, int SoLuongNhap)
        {
            return SachDAO.UpdateSLTvaGB(MaSach, GiaNhap, SoLuongNhap);
        }
        public static DataTable TimKiemTheoTenSach(string TenSach)
        {
            return SachDAO.TimKiemTheoTenSach(TenSach);
        }
        public static DataTable TimKiemTheoTheLoai(string MaTL)
        {
            return SachDAO.TimKiemTheoTheLoai(MaTL);
        }
        public static DataTable TimKiemTheoTacGia(string TenTG)
        {
            return SachDAO.TimKiemTheoTacGia(TenTG);
        }
        public static DataTable TimKiemTheoNXB(string MaNXB)
        {
            return SachDAO.TimKiemTheoNXB(MaNXB);
        }
        public static DataTable BaoCaoDoanhThu(DateTime Ngay)
        {
            return SachDAO.BaoCaoDoanhThu(Ngay);
        }
        public static DataSet BaoCaoDoanhThuS(DateTime Ngay)
        {
            return SachDAO.BaoCaoDoanhThuS(Ngay);
        }
        public static DataSet ThongKeTonKho()
        {
            return SachDAO.ThongKeTonKho();
        }
        public static DataTable BaoCaoNhapKho(DateTime Ngay)
        {
            return SachDAO.BaoCaoNhapKho(Ngay);
        }
        public static DataSet BaoCaoNhapKhoS(DateTime Ngay)
        {
            return SachDAO.BaoCaoNhapKhoS(Ngay);
        }
        public static DataTable BieuDo(DateTime Tu, DateTime Den)
        {
            return SachDAO.BieuDo(Tu, Den);
        }
    }
}
