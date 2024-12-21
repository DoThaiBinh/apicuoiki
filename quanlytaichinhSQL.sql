create database appquanlytaichinh
go
use appquanlytaichinh
go
create table NGUOIDUNG(
	IDNGUOIDUNG char(10) primary key,
	TENNGUOIDUNG NVARCHAR(50)  NOT NULL,
	EMAIL VARCHAR(50)  NOT NULL,
	PASSW CHAR(10)  NOT NULL,
	GIOITINH VARCHAR(10)  NOT NULL,
	ANHDAIDIEN VARCHAR(100) ,
	NGAYBATDAU INT NOT NULL,
	NGAYKETTHUC INT NOT NULL
)

CREATE TABLE KHOANTHUCHI(
	IDKHOANGTHUCHI CHAR(14) PRIMARY KEY,
	TENTHUCHI NVARCHAR(50)  NOT NULL,
	IDNGUOIDUNG char(10)foreign key  references NGUOIDUNG(IDNGUOIDUNG) on delete cascade on update cascade,
	HINHANH NVARCHAR(50)
)


CREATE TABLE THUCHI(
	IDKHOANGTHUCHI CHAR(14) foreign key  references KHOANTHUCHI(IDKHOANGTHUCHI) on delete cascade on update cascade,
	IDTHOIGIANTHEM DATE,
	SOTIEN MONEY  NOT NULL,
	PRIMARY KEY(IDKHOANGTHUCHI,IDTHOIGIANTHEM)	
)

CREATE TABLE TIENTE(
	IDTIENTE INT PRIMARY KEY,
	TENDONVITIENTE NVARCHAR(50),
	TIGIASOVOIVND MONEY,
	KIHIEU NVARCHAR(10)
)


ALTER TABLE NGUOIDUNG
ADD CONSTRAINT CK_NGUOIDUNG check(IDNGUOIDUNG like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	CONSTRAINT CK_NGUOIDUNG_Email CHECK (Email LIKE '[a-zA-Z]%@%gmail.com' or
										Email LIKE '[a-zA-Z]%@%yahoo.com' or
										Email LIKE '[a-zA-Z]%@%ute.udn.vn'),
	CONSTRAINT CK_NGUOIDUNG_PASSW_LEN CHECK(LEN(PASSW)=10),
	CONSTRAINT CK_NGUOIDUNG_PASSW CHECK(PASSW LIKE '[a-zA-Z0-9]%'),
	CONSTRAINT CK_NGUOIDUNG_GIOITINH check (gioiTinh  in ('NAM', 'NU') ),
	CONSTRAINT CK_NGUOIDUNG_NGAYBD CHECK(NGAYBATDAU>=1 AND NGAYBATDAU<=31),
	CONSTRAINT CK_NGUOIDUNG_NGAYKT CHECK(NGAYKETTHUC>=1 AND NGAYKETTHUC<=31)

--===============================================================
ALTER TABLE THUCHI
ADD CONSTRAINT CK_THUCHI_SOTIEN CHECK (SOTIEN>=0)

ALTER TABLE TIENTE
ADD CONSTRAINT CK_TIENTE_TIGIA CHECK (TIGIASOVOIVND>0);

set dateformat dmy

INSERT INTO NGUOIDUNG
VALUES ('0839976113',N'Đỗ Thái Bình','dothaibinh021218@gmail.com','1234567899','NAM','',1,1),
		('0839976115',N'Thiện Tâm','tam123@gmail.com','1234567899','NAM','',15,15),
		('0839976116',N'Tán Quang Huy','huydz@gmail.com','1234567899','NAM','',10,10),
				
--go 
--CREATE PROCEDURE InsertNewDayRecord
--AS
--BEGIN
--    DECLARE @ngayHienTai DATE = CAST(GETDATE() AS DATE);
--    DECLARE @id CHAR(6) = FORMAT(@ngayHienTai, 'ddMMyy');

--    IF NOT EXISTS (SELECT 1 FROM THOIGIANNGAY WHERE ngay = @ngayHienTai)
--    BEGIN
--        INSERT INTO THOIGIANNGAY(IDTHOIGIANNGAY, ngay)
--        VALUES (@id, @ngayHienTai);
--    END
--END
--go

--=====================================================================
INSERT INTO TIENTE
VALUES (1,N'Đô la Mỹ',23400,N'$'),
(2,N'Euro',25070,N'€'),
(3,N'Yên Nhật',154,N'¥'),
(4,N'Nhân dân tệ',3504,N'¥'),
(5,N'Bảng Anh',29960,N'¥'),
(6,N'Đô la Úc',3504,N'¥'),
(7,N'Đô la Canada',16657,N'¥'),
(8,N'Rúp Nga',250,N'¥'),
(9,N'Đô la Singapore',18539,N'¥'),
(10,N'Bath Thái',722,N'¥'),
(11,N'Won Hàn Quốc',18,N'¥'),
(12,N'Kíp Lào',1,N'¥'),
(13,N'Pataca Macao',3021,N'¥'),
(14,N'Phơ răng Thuỵ Sĩ',28180,N'¥'),
(15,N'Riêl Cămpuchia',6,N'¥')

----========================
--insert into KHOANTHUCHI 
--values ('0839976113T001',N'Cho tặng','0839976113',''),
--('0839976113T002',N'Lãi suất','0839976113',''),
--('0839976113T003',N'Làm thêm','0839976113',''),
--('0839976113T004',N'Đầu tư','0839976113',''),
--('0839976113C001',N'Ăn uống','0839976113',''),
--('0839976113C002',N'Mua sắm','0839976113',''),
--('0839976113C003',N'Nhà cửa','0839976113',''),
--('0839976113C004',N'Đám tiệc','0839976113','')


----================
--set dateformat dmy
--insert into THUCHI
--values ('0839976113T001','27/10/2024',100000),
--('0839976113T003','27/10/2024',150000),
--('0839976113T003','28/10/2024',100000)
----===========================
