USE [master]
GO

CREATE DATABASE [VNVCTest1]
GO

USE [VNVCTest]
GO
/****** Object:  Table [dbo].[DatSo]    Script Date: 2023-12-13 12:33:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatSo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IDNguoiChoi] [int] NULL,
	[Ngay] [datetime] NULL,
	[Gio] [int] NULL,
	[GiaTri] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NgaySua] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQua]    Script Date: 2023-12-13 12:33:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQua](
	[Ngay] [datetime] NOT NULL,
	[Gio] [int] NOT NULL,
	[KetQua] [int] NULL,
	[NgayTao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ngay] ASC,
	[Gio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiChoi]    Script Date: 2023-12-13 12:33:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiChoi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DienThoai] [nvarchar](10) NULL,
	[HoDem] [nvarchar](200) NULL,
	[Ten] [nvarchar](100) NULL,
	[NgaySinh] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetDanhSachDatSo]    Script Date: 2023-12-13 12:33:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetDanhSachDatSo]
    @IDNguoiChoi INT,
	@NgayDat DATE,
	@GioDat INT
AS
BEGIN
    SELECT TOP (1000)
		ds.Id, ds.IDNguoiChoi, ds.Ngay, ds.Gio, ds.GiaTri, ds.NgayTao, ds.NgaySua, 
		HoTen = u.HoDem + ' ' + u.Ten,
		kq.KetQua, 
		IsTrung = CAST((CASE WHEN ds.GiaTri = kq.KetQua THEN 1 ELSE 0 END) AS BIT),
		NgayGioDatStr = CONVERT(VARCHAR(10), ds.Ngay, 103) + ' ' + CAST(ds.Gio AS VARCHAR(2)) + N' giờ'
	FROM dbo.DatSo ds
		INNER JOIN dbo.NguoiChoi u ON u.Id = ds.IDNguoiChoi
		LEFT JOIN dbo.KetQua kq ON kq.Ngay = ds.Ngay AND kq.Gio = ds.Gio
	WHERE 1=1
		AND (@IDNguoiChoi IS NULL OR ds.IDNguoiChoi = @IDNguoiChoi)
		AND (@NgayDat IS NULL OR ds.Ngay = @NgayDat)
		AND (@GioDat IS NULL OR ds.Gio = @GioDat)
	ORDER BY ds.Ngay DESC, ds.Gio DESC
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetDate]    Script Date: 2023-12-13 12:33:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SET QUOTED_IDENTIFIER ON|OFF
--SET ANSI_NULLS ON|OFF
--GO
CREATE PROCEDURE [dbo].[SP_GetDate]
AS
BEGIN
    SELECT ThoiGian = GETDATE()
END
GO
/****** Object:  StoredProcedure [dbo].[SP_TaoKetQua]    Script Date: 2023-12-13 6:00:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_TaoKetQua]
    @DenNgay DATETIME,
	@NgayTao DATETIME
AS
-- Tạo kết quả @DenNgay
BEGIN
    DECLARE
		@Ngay DATETIME,
		@Gio INT,
		@TuNgay DATETIME
	DECLARE @TblKetQuaMoi TABLE(Ngay DATETIME, Gio INT)

	-- lấy ngày, giờ
	IF @DenNgay IS NULL SET @DenNgay = GETDATE()
	SET @DenNgay = DATEADD(HOUR, DATEPART(HOUR, @DenNgay), CAST(CAST(@DenNgay AS DATE) AS DATETIME))

	SELECT TOP (1) @Ngay = kq.Ngay, @Gio = kq.Gio
	FROM dbo.KetQua kq 
	ORDER BY kq.Ngay DESC, kq.Gio DESC

	IF @Ngay IS NULL OR @Gio IS NULL
	BEGIN
		SELECT TOP (1) @Ngay = ds.Ngay, @Gio = ds.Gio
		FROM dbo.DatSo ds 
		ORDER BY ds.Ngay ASC, ds.Gio ASC
	END

	IF @Ngay IS NULL OR @Gio IS NULL
	BEGIN
		SET @Ngay = CAST(@DenNgay AS DATE)
		SET @Gio = DATEPART(HOUR, @DenNgay)
	END

	SET @TuNgay = DATEADD(HOUR, @Gio, CAST(CAST(@Ngay AS DATE) AS DATETIME))

	-- thêm kết quả
	BEGIN TRANSACTION
	BEGIN TRY
		;WITH RecKetQua AS (
			SELECT NgayGio = @TuNgay
			UNION ALL
			SELECT NgayGio = DATEADD(HOUR, 1, r.NgayGio)
			FROM RecKetQua r
			WHERE r.NgayGio < @DenNgay
		)

		INSERT dbo.KetQua (Ngay, Gio, KetQua, NgayTao)
		OUTPUT Inserted.Ngay, Inserted.Gio 
		INTO @TblKetQuaMoi(Ngay, Gio)
		SELECT cr.Ngay, cr.Gio, KetQua = CAST(NULL AS INT), @NgayTao
		FROM RecKetQua r
			CROSS APPLY(SELECT 
				Ngay = CAST(r.NgayGio AS DATE),
				Gio = DATEPART(HOUR, r.NgayGio)) cR
		WHERE NOT EXISTS(SELECT 1 FROM dbo.KetQua kq 
				WHERE kq.Ngay = cR.Ngay AND kq.Gio = cR.Gio)
			AND EXISTS(SELECT 1 FROM dbo.DatSo ds
				WHERE ds.Ngay = cR.Ngay AND ds.Gio = cR.Gio)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		DELETE @TblKetQuaMoi
		--DECLARE @ErrorMessage NVARCHAR(4000);
		--DECLARE @ErrorSeverity INT;
		--DECLARE @ErrorState INT;

		--SELECT 
		--	@ErrorMessage = ERROR_MESSAGE() + ' ' +
		--		'ERROR_NUMBER=' + CAST(ERROR_NUMBER() AS VARCHAR(5)) + ' ' +
		--		'ERROR_LINE=' + CAST(ERROR_LINE() AS VARCHAR(5)),
		--	@ErrorSeverity = ERROR_SEVERITY(),
		--	@ErrorState = ERROR_STATE();

		--RAISERROR (@ErrorMessage,
		--		   @ErrorSeverity,
		--		   @ErrorState
		--		   );
	END CATCH

	-- random
	DECLARE cursor_kqMoi CURSOR FOR
	SELECT Ngay, Gio
	FROM @TblKetQuaMoi

	OPEN cursor_kqMoi

	DECLARE @cNgay DATETIME, @cGio INT

	FETCH NEXT FROM cursor_kqMoi INTO @cNgay, @cGio

	WHILE @@FETCH_STATUS = 0
	BEGIN
		UPDATE kq 
		SET kq.KetQua = ABS(CHECKSUM(NEWID())) % 10
		FROM dbo.KetQua kq
		WHERE kq.Ngay = @cNgay AND kq.Gio = @cGio
		FETCH NEXT FROM cursor_kqMoi INTO @cNgay, @cGio
	END

	CLOSE cursor_kqMoi
	DEALLOCATE cursor_kqMoi
	
	-- trả về Id kết quả
	SELECT Ngay, Gio FROM @TblKetQuaMoi
END
