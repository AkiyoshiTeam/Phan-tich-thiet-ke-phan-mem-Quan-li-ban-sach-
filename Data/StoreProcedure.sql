use QLHieuSach
go
-- SÁCH --
-- Phát sinh mã sách mới --
Create proc sp_GetIDSach
@masach nchar(10) output
as
begin
   declare @n numeric
   declare @W nchar(8)   
   if exists (Select top 1 * From Sach)
       Select @n= cast(MaSach as numeric) From Sach 
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(8))
   While len(@W)<8
      set @W='0'+@W
   set @masach = @W
end
go
-- Thêm sách mới --
Create proc sp_ThemSach
@masach nchar(10),
@tensach nvarchar(100),
@maTL nchar(10),
@maNXB nchar(10),
@maTG nchar(10)
as
begin
   Insert into Sach(MaSach,TenSach,MaTL,MaNXB,MaTG,SoLuongTon)
   Values (@masach,@tensach,@maTL,@maNXB,@maTG,'0')
end
go
-- Xóa sách --
Create proc sp_XoaSach
@masach nchar(10)
as
begin
   Delete from ChiTietHoaDon where MaSach=@masach
   Delete from ChiTietPhieuNhap where MaSach=@masach
   Delete from Sach where MaSach=@masach 
end
go
-- Sửa sách --
Create proc sp_SuaSach
@masach nchar(10),
@tensach nvarchar(100),
@maTL nchar(10),
@maNXB nchar(10),
@maTG nchar(10)
as
begin
   Update Sach 
   set TenSach=@tensach,MaTL=@maTL,MaNXB=@maNXB,MaTG=@maTG
   where MaSach=@masach
end
go
-- PHIẾU NHẬP --
-- Phát sinh tự động số phiếu nhập --
Create proc sp_GetIDPhieuNhap
@sopn nchar(10) output
as
begin
   declare @n numeric
   declare @Z nchar(2),@W nchar(8)
   set @Z='PN'   
   if exists (Select top 1 * From PhieuNhap)
       Select @n= max(cast(Substring(SoPN,3,8) as numeric)) From PhieuNhap
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(8))
   While len(@W)<8
      set @W='0'+@W
   set @sopn = @Z+@W
end
go
-- Thêm phiếu nhập --
Create proc sp_ThemPN
@sopn nchar(10),
@ngaynhap date,
@maNXB nchar(10),
@image image
as
begin
   Insert into PhieuNhap(SoPN,NgayNhap,MaNXB,HinhAnh)
   values (@sopn,@ngaynhap,@maNXB,@image)
end
go
-- Xóa phiếu nhập --
Create proc sp_XoaPN
@sopn nchar(10)
as
begin
   Delete from ChiTietPhieuNhap Where SoPN=@sopn
   Delete from PhieuNhap Where SoPN=@sopn
end
go
-- Thêm CT phiếu nhập --
Create proc sp_ThemCTPhieuNhap
@sopn nchar(10),
@masach nchar(10),
@soluongnhap int,
@gianhap bigint
as
begin
  Insert into ChiTietPhieuNhap(SoPN,MaSach,SoLuongNhap,GiaNhap)
  Values (@sopn,@masach,@soluongnhap,@gianhap)
end
go
-- Cập nhật số lượng tồn và giá bán quyển sách --
-- Tiền lời: 10.000 VNĐ ---
-- Thuế VAT: 5% --
-- Giá bán = Giá nhập + [(Giá nhập*5)/100] + Tiền lời (30% giá nhập)--
Create proc sp_UpdateSLTvaGB
@masach nchar(10),
@gianhap bigint,
@soluongnhap int
as
begin
   -- lấy số lượng tồn ban đầu + số lượng nhập --
   declare @soluongton int
   select @soluongton= SoLuongTon
   from Sach
   where MaSach=@masach
   set @soluongton=@soluongton+@soluongnhap
   -- Tính giá bán --
   declare @giaban bigint
   declare @tienloi bigint
   set @tienloi=(@gianhap*30)/100
   set @giaban = @gianhap +((@gianhap*5)/100)+ @tienloi
   -- cập nhật lại số lượng tồn và giá bán --
   Update Sach set SoLuongTon=@soluongton, GiaBan=@giaban where MaSach=@masach
end
go
-- THỂ LOẠI --
-- Phát sinh tự động mã thể loại --
Create proc sp_GetIDTheLoai
@matl nchar(10) output
as
begin
   declare @n numeric
   declare @Z nchar(2),@W nchar(8)
   set @Z='TL'   
   if exists (Select top 1 * From TheLoai)
       Select @n= max(cast(Substring(MaTL,3,2) as numeric)) From TheLoai
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(2))
   While len(@W)<2
      set @W='0'+@W
   set @matl = @Z+@W
end
go
-- Thêm thể loại --
Create proc sp_ThemTL
@matl nchar(10),
@tentl nvarchar(50)
as
begin
   insert into TheLoai(MaTL,TenTL)
   values (@matl,@tentl)
end
go
-- Xóa thể loại --
Create proc sp_XoaTL
@matl nchar(10)
as
begin
   delete from TheLoai where MaTL=@matl
end
go
-- Sửa thể loại --
create proc sp_SuaTL
@matl nchar(10),
@tentl nvarchar(50)
as
begin
   update TheLoai
   set TenTL=@tentl where MaTL=@matl
end
go
-- NHÀ XUẤT BẢN --
-- Phát sinh mã nhà xuất bản tự động --
Create proc sp_GetIDNXB
@manxb nchar(10) output
as
begin
   declare @n numeric
   declare @Z nchar(3),@W nchar(7)
   set @Z='NXB'   
   if exists (Select top 1 * From NhaXxuatBan)
       Select @n= max(cast(Substring(MaNXB,4,5) as numeric)) From NhaXxuatBan
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(5))
   While len(@W)<5
      set @W='0'+@W
   set @manxb = @Z+@W
end
go
-- Thêm nhà xuất bản --
Create proc sp_ThemNXB
@manxb nchar(10),
@tennxb nvarchar(50),
@diachi nvarchar(50),
@dienthoai nchar(12)
as
begin
   insert into NhaXxuatBan(MaNXB,TenNXB,DiaChi,DienThoai)
   values (@manxb,@tennxb,@diachi,@dienthoai)
end
go
-- Xóa nhà xuất bản --
Create proc sp_XoaNXB
@manxb nchar(10)
as
begin
   delete from NhaXxuatBan where MaNXB=@manxb
end
go
-- Sửa nhà xuất bản --
Create proc sp_SuaNXB
@manxb nchar(10),
@tennxb nvarchar(50),
@diachi nvarchar(50),
@dienthoai nchar(12)
as
begin
   update NhaXxuatBan 
   set TenNXB=@tennxb,DiaChi=@diachi,DienThoai=@dienthoai
   where MaNXB=@manxb
end
go
-- TÁC GIẢ --
-- Phát sinh mã tác giả tự động --
Create proc sp_GetIDTG
@matg nchar(10) output
as
begin
   declare @n numeric
   declare @Z nchar(2),@W nchar(8)
   set @Z='TG'   
   if exists (Select top 1 * From TacGia)
       Select @n= max(cast(Substring(MaTG,3,6) as numeric)) From TacGia
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(6))
   While len(@W)<6
      set @W='0'+@W
   set @matg = @Z+@W
end
go
-- Thêm tác giả --
Create proc sp_ThemTG
@matg nchar(10),
@tentg nvarchar(50),
@diachi nvarchar(50)
as
begin
   insert into TacGia(MaTG,TenTG,DiaChi)
   values (@matg,@tentg,@diachi)
end
go
-- Xóa tác giả --
Create proc sp_XoaTG
@matg nchar(10)
as
begin
   delete from TacGia where MaTG=@matg
end
go
-- Sửa tác giả --
Create proc sp_SuaTG
@matg nchar(10),
@tentg nvarchar(50),
@diachi nvarchar(50)
as
begin
   update TacGia
   set TenTG=@tentg,DiaChi=@diachi
   where MaTG=@matg
end
go
-- HÓA ĐƠN --
-- Xóa hóa đơn --
Create proc sp_XoaHD
@soHD nchar(10)
as
begin
   Delete from ChiTietHoaDon Where SoHD=@soHD
   Delete from HoaDon Where SoHD=@soHD
end
go
-- Phát sinh số hóa đơn tự động --
Create proc sp_GetIDHoaDon
@sohd nchar(10) output
as
begin
   declare @n numeric
   declare @Z nchar(2),@W nchar(8)
   set @Z='HD'   
   if exists (Select top 1 * From HoaDon)
       Select @n= max(cast(Substring(SoHD,3,8) as numeric)) From HoaDon
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(8))
   While len(@W)<8
      set @W='0'+@W
   set @sohd = @Z+@W
end
go
-- Thêm hóa đơn --
Create proc sp_ThemHD
@sohd nchar(10),
@ngayban date,
@image image
as
begin
   insert into HoaDon(SoHD,NgayBan,HinhAnh)
   values(@sohd,@ngayban,@image)
end
go
-- Thêm CTHD --
Create proc sp_ThemCTHD
@sohd nchar(10),
@masach nchar(10),
@soluongban int,
@giaban bigint,
@thanhtien bigint
as
begin
   insert into ChiTietHoaDon(SoHD,MaSach,SoLuongBan,GiaBan,ThanhTien)
   values(@sohd,@masach,@soluongban,@giaban,@thanhtien)
end
go
-- Update số lượng tồn --
Create proc sp_UpdateSLT
@masach nchar(10),
@soluongban int
as
begin
   -- lấy số lượng tồn ban đầu - số lượng bán --
   declare @soluongton int
   select @soluongton= SoLuongTon
   from Sach
   where MaSach=@masach
   set @soluongton=@soluongton-@soluongban
   Update Sach set SoLuongTon=@soluongton where MaSach=@masach
end
go
-- NGƯỜI DÙNG --
-- Update password --
Create proc sp_ChangePassword
@username nchar(7),
@newpass nchar(6)
as
begin
   Update NguoiDung  set Password=@newpass where Username= @username
end
go
-- Phát sinh mã người dùng tự động --
Create proc sp_GetIDNguoiDung
@mand nchar(10) output
as
begin
   declare @n numeric
   declare @Z nchar(2),@W nchar(2)
   set @Z='ND'   
   if exists (Select top 1 * From NguoiDung)
       Select @n= max(cast(Substring(MaND,3,2) as numeric)) From NguoiDung
   else
       set @n = 0
   set @n=@n+1
   set @W = cast(@n as nchar(2))
   While len(@W)<2
      set @W='0'+@W
   set @mand = @Z+@W
end
go
-- Thêm người dùng --
Create proc sp_ThemND
@mand nchar(10),
@hoten nvarchar(50),
@username char(7),
@pass char(6),
@diachi nvarchar(100),
@cmnd nchar(12),
@phanquyen nchar(5),
@dienthoai nchar(11),
@gioitinh nvarchar(3)
as
begin
   Insert into NguoiDung(MaND,HoTen,Username,Password,DiaChi,SoCMND,PhanQuyen,DienThoai, GioiTinh)
   Values (@mand,@hoten,@username,@pass,@diachi,@cmnd,@phanquyen,@dienthoai,@gioitinh)
end
go
-- Xóa người dùng --
Create proc sp_XoaND
@mand nchar(10)
as
begin
   Delete from NguoiDung Where MaND=@mand
end
go
-- Sửa người dùng --
Create proc sp_SuaND
@mand nchar(10),
@hoten nvarchar(50),
@username char(7),
@diachi nvarchar(100),
@cmnd nchar(12),
@phanquyen nchar(5),
@dienthoai nchar(11),
@gioitinh nvarchar(3)
as
begin
   Update NguoiDung
   set HoTen=@hoten, Username=@username, DiaChi=@diachi, SoCMND=@cmnd, PhanQuyen=@phanquyen, DienThoai=@dienthoai, GioiTinh=@gioitinh
   where MaND=@mand
end
go