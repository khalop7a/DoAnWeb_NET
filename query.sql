create database QL_NhaTro
go
use QL_NhaTro
go
create table NguoiDung
(
NguoiDung_ID nvarchar(100) primary key,
MatKhau varchar(32) not null,
HoTen nvarchar(100) not null,
GioiTinh bit,
SDT varchar(11) not null,
DiaChi nvarchar(max),
Email varchar(320) not null,
)
go
 insert into NguoiDung values('Kha', '123', N'Lê Minh Kha', 1, '0964452406', N'Cà Mau' ,'huynhhuetruc@gmail.com')
go
create table ChuTro
(
ChuTro_ID nvarchar(100) primary key,
MatKhau varchar(32) not null, 
Email varchar(320) not null,
SDT varchar(11) not null,
TenNhaTro nvarchar(255) not null,
DiaChi nvarchar(max) not null
)
go 
 insert into ChuTro values('Truc', '345', 'huynhhuetruc@gmail.com', '0964452406', 'Nhà trọ Cô Trúc kkk','Long Phú - Sóc Trăng')
 go 
 create table LoaiPhong 
 (
 LoaiPhong_ID int identity primary key,
 TenLoai nvarchar(100) not null,
 )
 go
 insert into LoaiPhong values(N'Nhà trọ chung chủ'),(N'Dãy nhà trọ tự quản lý'), (N'Chung cư'), (N'Chung cư mini'), (N'Nhà tọ homestay')
 go
 create table Phong
 (
 Phong_ID int identity primary key,
 LoaiPhong_ID int,
 ChuTro_ID nvarchar(100),
 DienTich nvarchar(100) not null,
 Gia float not null,
 DiaChi nvarchar(max) not null,
 MoTa nvarchar(max),
 SoLuong int,
 foreign key (ChuTro_ID) references ChuTro(ChuTro_ID),
 foreign key (LoaiPhong_ID) references LoaiPhong(LoaiPhong_ID)
 )
 go
 insert into Phong values('1', 'Truc', '5 mét vuông', 1200000, N'Hẻm 51, đường 3/2, Ninh Kiều, Cần Thơ', N'Có gác lững',20 )
 go 
 create table TinTuc
 (
 TinTuc_ID int identity primary key,
 TieuDe nvarchar(255) not null,
 NgayDang Date not null,
 NgayChinhSua Date,
 Phong_ID int,
 foreign key (Phong_ID) references Phong(Phong_ID)
 )
 go
 insert into TinTuc values(N'Cho thuê phòng trọ', '2020/01/07', null, '1')
 go
 create table DanhGia
 (
 DanhGia_ID int identity primary key,
 NguoiDung_ID nvarchar(100),
 Phong_ID int,
 NoiDung nvarchar(max),
 foreign key (NguoiDung_ID) references NguoiDung(NguoiDung_ID),
 foreign key (Phong_ID) references Phong(Phong_ID)
 )
 go
 insert into DanhGia values( N'Kha', '1', N'Chất lượng tốt')

