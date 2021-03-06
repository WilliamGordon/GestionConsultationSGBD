USE [master]
GO
/****** Object:  Database [GestionConsultation]    Script Date: 13-04-21 21:43:08 ******/
CREATE DATABASE [GestionConsultation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestionConsultation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER_SGBD\MSSQL\DATA\GestionConsultation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestionConsultation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER_SGBD\MSSQL\DATA\GestionConsultation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [GestionConsultation] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionConsultation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GestionConsultation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GestionConsultation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GestionConsultation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GestionConsultation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GestionConsultation] SET ARITHABORT OFF 
GO
ALTER DATABASE [GestionConsultation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GestionConsultation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GestionConsultation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GestionConsultation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GestionConsultation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GestionConsultation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GestionConsultation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GestionConsultation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GestionConsultation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GestionConsultation] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GestionConsultation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GestionConsultation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GestionConsultation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GestionConsultation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GestionConsultation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GestionConsultation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GestionConsultation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GestionConsultation] SET RECOVERY FULL 
GO
ALTER DATABASE [GestionConsultation] SET  MULTI_USER 
GO
ALTER DATABASE [GestionConsultation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GestionConsultation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GestionConsultation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GestionConsultation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GestionConsultation] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GestionConsultation', N'ON'
GO
ALTER DATABASE [GestionConsultation] SET QUERY_STORE = OFF
GO
USE [GestionConsultation]
GO
/****** Object:  User [patient]    Script Date: 13-04-21 21:43:08 ******/
CREATE USER [patient] FOR LOGIN [patient] WITH DEFAULT_SCHEMA=[patient]
GO
/****** Object:  User [medecin]    Script Date: 13-04-21 21:43:08 ******/
CREATE USER [medecin] FOR LOGIN [medecin] WITH DEFAULT_SCHEMA=[medecin]
GO
/****** Object:  DatabaseRole [role_patient]    Script Date: 13-04-21 21:43:08 ******/
CREATE ROLE [role_patient]
GO
/****** Object:  DatabaseRole [role_medecin]    Script Date: 13-04-21 21:43:08 ******/
CREATE ROLE [role_medecin]
GO
ALTER ROLE [role_patient] ADD MEMBER [patient]
GO
ALTER ROLE [role_medecin] ADD MEMBER [medecin]
GO
/****** Object:  Schema [db_medecin]    Script Date: 13-04-21 21:43:09 ******/
CREATE SCHEMA [db_medecin]
GO
/****** Object:  Schema [db_patient]    Script Date: 13-04-21 21:43:09 ******/
CREATE SCHEMA [db_patient]
GO
/****** Object:  Schema [medecin]    Script Date: 13-04-21 21:43:09 ******/
CREATE SCHEMA [medecin]
GO
/****** Object:  Schema [patient]    Script Date: 13-04-21 21:43:09 ******/
CREATE SCHEMA [patient]
GO
/****** Object:  Table [dbo].[Consultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultation](
	[Consultation_ID] [int] IDENTITY(1,1) NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[MedecinSpecialiteMaisonMedicale_ID] [int] NOT NULL,
	[Local_ID] [int] NOT NULL,
	[Starting] [datetime] NOT NULL,
	[Ending] [datetime] NOT NULL,
	[IsConfirmed] [bit] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Consultation] PRIMARY KEY CLUSTERED 
(
	[Consultation_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Local]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Local](
	[Local_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MaisonMedicale_ID] [int] NOT NULL,
 CONSTRAINT [PK_Local] PRIMARY KEY CLUSTERED 
(
	[Local_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaisonMedicale](
	[MaisonMedicale_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaisonMedicale] PRIMARY KEY CLUSTERED 
(
	[MaisonMedicale_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medecin](
	[Medecin_ID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Medecin] PRIMARY KEY CLUSTERED 
(
	[Medecin_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedecinSpecialite]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedecinSpecialite](
	[MedecinSpecialite_ID] [int] IDENTITY(1,1) NOT NULL,
	[Medecin_ID] [int] NOT NULL,
	[Specialite_ID] [int] NOT NULL,
 CONSTRAINT [PK_MedecinSpecialite] PRIMARY KEY CLUSTERED 
(
	[MedecinSpecialite_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedecinSpecialiteMaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedecinSpecialiteMaisonMedicale](
	[MedecinSpecialiteMaisonMedicale_ID] [int] IDENTITY(1,1) NOT NULL,
	[MedecinSpecialite_ID] [int] NOT NULL,
	[MaisonMedicale_ID] [int] NOT NULL,
	[MinimalDuration] [int] NOT NULL,
	[IsActif] [bit] NOT NULL,
 CONSTRAINT [PK_MedecinSpecialiteMaisonMedicale] PRIMARY KEY CLUSTERED 
(
	[MedecinSpecialiteMaisonMedicale_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[Patient_ID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Patient_2] PRIMARY KEY CLUSTERED 
(
	[Patient_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presence]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presence](
	[Presence_ID] [int] IDENTITY(1,1) NOT NULL,
	[Medecin_ID] [int] NOT NULL,
	[MaisonMedicale_ID] [int] NOT NULL,
	[Starting] [datetime] NOT NULL,
	[Ending] [datetime] NOT NULL,
 CONSTRAINT [PK_Presence] PRIMARY KEY CLUSTERED 
(
	[Presence_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialite]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialite](
	[Specialite_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Specialite] PRIMARY KEY CLUSTERED 
(
	[Specialite_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_Local] FOREIGN KEY([Local_ID])
REFERENCES [dbo].[Local] ([Local_ID])
GO
ALTER TABLE [dbo].[Consultation] CHECK CONSTRAINT [FK_Consultation_Local]
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_MedecinSpecialiteMaisonMedicale] FOREIGN KEY([MedecinSpecialiteMaisonMedicale_ID])
REFERENCES [dbo].[MedecinSpecialiteMaisonMedicale] ([MedecinSpecialiteMaisonMedicale_ID])
GO
ALTER TABLE [dbo].[Consultation] CHECK CONSTRAINT [FK_Consultation_MedecinSpecialiteMaisonMedicale]
GO
ALTER TABLE [dbo].[Consultation]  WITH CHECK ADD  CONSTRAINT [FK_Consultation_Patient] FOREIGN KEY([Patient_ID])
REFERENCES [dbo].[Patient] ([Patient_ID])
GO
ALTER TABLE [dbo].[Consultation] CHECK CONSTRAINT [FK_Consultation_Patient]
GO
ALTER TABLE [dbo].[Local]  WITH CHECK ADD  CONSTRAINT [FK_Local_MaisonMedicale] FOREIGN KEY([MaisonMedicale_ID])
REFERENCES [dbo].[MaisonMedicale] ([MaisonMedicale_ID])
GO
ALTER TABLE [dbo].[Local] CHECK CONSTRAINT [FK_Local_MaisonMedicale]
GO
ALTER TABLE [dbo].[MedecinSpecialite]  WITH CHECK ADD  CONSTRAINT [FK_MedecinSpecialite_Medecin] FOREIGN KEY([Medecin_ID])
REFERENCES [dbo].[Medecin] ([Medecin_ID])
GO
ALTER TABLE [dbo].[MedecinSpecialite] CHECK CONSTRAINT [FK_MedecinSpecialite_Medecin]
GO
ALTER TABLE [dbo].[MedecinSpecialite]  WITH CHECK ADD  CONSTRAINT [FK_MedecinSpecialite_Specialite] FOREIGN KEY([Specialite_ID])
REFERENCES [dbo].[Specialite] ([Specialite_ID])
GO
ALTER TABLE [dbo].[MedecinSpecialite] CHECK CONSTRAINT [FK_MedecinSpecialite_Specialite]
GO
ALTER TABLE [dbo].[MedecinSpecialiteMaisonMedicale]  WITH CHECK ADD  CONSTRAINT [FK_MedecinSpecialiteMaisonMedicale_MaisonMedicale] FOREIGN KEY([MaisonMedicale_ID])
REFERENCES [dbo].[MaisonMedicale] ([MaisonMedicale_ID])
GO
ALTER TABLE [dbo].[MedecinSpecialiteMaisonMedicale] CHECK CONSTRAINT [FK_MedecinSpecialiteMaisonMedicale_MaisonMedicale]
GO
ALTER TABLE [dbo].[MedecinSpecialiteMaisonMedicale]  WITH CHECK ADD  CONSTRAINT [FK_MedecinSpecialiteMaisonMedicale_MedecinSpecialite] FOREIGN KEY([MedecinSpecialite_ID])
REFERENCES [dbo].[MedecinSpecialite] ([MedecinSpecialite_ID])
GO
ALTER TABLE [dbo].[MedecinSpecialiteMaisonMedicale] CHECK CONSTRAINT [FK_MedecinSpecialiteMaisonMedicale_MedecinSpecialite]
GO
ALTER TABLE [dbo].[Presence]  WITH CHECK ADD  CONSTRAINT [FK_Presence_MaisonMedicale] FOREIGN KEY([MaisonMedicale_ID])
REFERENCES [dbo].[MaisonMedicale] ([MaisonMedicale_ID])
GO
ALTER TABLE [dbo].[Presence] CHECK CONSTRAINT [FK_Presence_MaisonMedicale]
GO
ALTER TABLE [dbo].[Presence]  WITH CHECK ADD  CONSTRAINT [FK_Presence_Medecin] FOREIGN KEY([Medecin_ID])
REFERENCES [dbo].[Medecin] ([Medecin_ID])
GO
ALTER TABLE [dbo].[Presence] CHECK CONSTRAINT [FK_Presence_Medecin]
GO
/****** Object:  StoredProcedure [dbo].[GetAllConsultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllConsultation]
	@Medecin_ID AS INT,
	@MaisonMedicale_ID AS INT,
	@Day AS DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation 
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = dbo.Consultation.MedecinSpecialiteMaisonMedicale_ID
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
		WHERE
			dbo.MedecinSpecialite.Medecin_ID = @Medecin_ID AND
			dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID = @MaisonMedicale_ID AND
			CONVERT(DATE, dbo.Consultation.Starting) = @Day AND
			CONVERT(DATE, dbo.Consultation.Ending) = @Day
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllConsultationForMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllConsultationForMedecin]
	@Medecin_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = dbo.Consultation.MedecinSpecialiteMaisonMedicale_ID
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialite.MedecinSpecialite_ID = dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID
		WHERE
			dbo.MedecinSpecialite.Medecin_ID = @Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllConsultationForMedecinForDay]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllConsultationForMedecinForDay]
	@Medecin_ID AS INT,
	@Day AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = dbo.Consultation.MedecinSpecialiteMaisonMedicale_ID
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialite.MedecinSpecialite_ID = dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID
		WHERE
			dbo.MedecinSpecialite.Medecin_ID = @Medecin_ID AND
			CONVERT(DATE, dbo.Consultation.Starting) = CONVERT(DATE, @Day)
END	
GO
/****** Object:  StoredProcedure [dbo].[GetAllConsultationForMedecinForOneDay]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllConsultationForMedecinForOneDay]
	@Medecin_ID AS INT,
	@Day AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = dbo.Consultation.MedecinSpecialiteMaisonMedicale_ID
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialite.MedecinSpecialite_ID = dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID
		WHERE	dbo.MedecinSpecialite.Medecin_ID = @Medecin_ID
			AND	@day = CONVERT(date, dbo.Consultation.Starting)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllConsultationForMMForADay]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllConsultationForMMForADay]	
	@MaisonMedicale_ID AS INT,
	@Day AS DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation 
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = dbo.Consultation.MedecinSpecialiteMaisonMedicale_ID
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
		WHERE	
			dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID = @MaisonMedicale_ID AND
			CONVERT(DATE, dbo.Consultation.Starting) = @Day AND
			CONVERT(DATE, dbo.Consultation.Ending) = @Day
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllConsultationForPatient]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllConsultationForPatient]
	@Patient_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation WHERE dbo.Consultation.Patient_ID = @Patient_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllLocalsForMSMM]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllLocalsForMSMM]
	@MedecinSpecialiteMaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.Local.Local_ID, dbo.Local.MaisonMedicale_ID, dbo.Local.Name FROM dbo.Local
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID = dbo.Local.MaisonMedicale_ID
		WHERE dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMaisonMedicale]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT dbo.MaisonMedicale.MaisonMedicale_ID, dbo.MaisonMedicale.Name FROM dbo.MaisonMedicale
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMaisonMedicaleForMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllMaisonMedicaleForMedecin]
	@Medecin_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT DISTINCT dbo.MaisonMedicale.MaisonMedicale_ID, dbo.MaisonMedicale.Name FROM dbo.MaisonMedicale
	INNER JOIN dbo.MedecinSpecialiteMaisonMedicale
		ON dbo.MaisonMedicale.MaisonMedicale_ID = dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID
	INNER JOIN dbo.MedecinSpecialite
		ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
	INNER JOIN dbo.Medecin
		ON dbo.MedecinSpecialite.Medecin_ID = dbo.Medecin.Medecin_ID
	INNER JOIN dbo.Specialite
		ON dbo.MedecinSpecialite.Specialite_ID = dbo.Specialite.Specialite_ID
	 WHERE dbo.Medecin.Medecin_ID = @Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMedecin]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM dbo.Medecin
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMedecinForMaisonMedicaleAndSpecialite]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMedecinForMaisonMedicaleAndSpecialite]
	@MaisonMedicale_ID AS INT,
	@Specialite_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.Medecin.Medecin_ID, dbo.Medecin.Firstname, dbo.Medecin.Lastname FROM [dbo].[Medecin]
		INNER JOIN dbo.MedecinSpecialite
			ON dbo.Medecin.Medecin_ID = dbo.MedecinSpecialite.Medecin_ID
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale
			ON dbo.MedecinSpecialite.MedecinSpecialite_ID = dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID
		
		WHERE 
				@MaisonMedicale_ID = dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID
			AND @Specialite_ID = dbo.MedecinSpecialite.Specialite_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMedecinPresentForMaisonMedicaleAndSpecialiteAndDay]
	@day AS DATETIME,
	@MaisonMedicale_ID AS INT,
	@Specialite_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT * FROM dbo.Presence
		INNER JOIN dbo.MedecinSpecialite
			ON dbo.Presence.Medecin_ID = dbo.MedecinSpecialite.Medecin_ID
		INNER JOIN dbo.Medecin
			ON dbo.Presence.Medecin_ID = dbo.Medecin.Medecin_ID
		
		WHERE 
				@day = CONVERT(date, Presence.Starting)
			AND @MaisonMedicale_ID = dbo.Presence.MaisonMedicale_ID
			AND @Specialite_ID = dbo.MedecinSpecialite.Specialite_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMedecinPresentInMaisonMedicaleWithSpecialite]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMedecinPresentInMaisonMedicaleWithSpecialite]
	@MaisonMedicale_ID AS INT,
	@Specialite_ID AS INT,
	@Day AS DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	-- GET ALL THE MEDECIN WHO ARE PRESENT IN THE MAISON MEDICALE AND HAVE THE SPECIALITE
		SELECT DISTINCT dbo.Presence.Medecin_ID, dbo.Medecin.Firstname, dbo.Medecin.Lastname FROM dbo.Presence 
		INNER JOIN dbo.MedecinSpecialite ON dbo.Presence.Medecin_ID = dbo.MedecinSpecialite.Medecin_ID
		INNER JOIN dbo.Medecin ON dbo.Presence.Medecin_ID = dbo.Medecin.Medecin_ID
		WHERE
			dbo.Presence.MaisonMedicale_ID = @MaisonMedicale_ID AND
			dbo.MedecinSpecialite.Specialite_ID = @Specialite_ID AND
			CONVERT(DATE, dbo.Presence.Starting) = @Day AND
			CONVERT(DATE, dbo.Presence.Ending) = @Day
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMedecinSpecialiteForMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMedecinSpecialiteForMedecin]
	@Medecin_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.MedecinSpecialite
	WHERE dbo.MedecinSpecialite.Medecin_ID = @Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllMMSForMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMMSForMedecin]
	@Medecin_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID, dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID, dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID, dbo.MedecinSpecialiteMaisonMedicale.MinimalDuration, dbo.MedecinSpecialiteMaisonMedicale.IsActif FROM dbo.MaisonMedicale
	INNER JOIN dbo.MedecinSpecialiteMaisonMedicale
		ON dbo.MaisonMedicale.MaisonMedicale_ID = dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID
	INNER JOIN dbo.MedecinSpecialite
		ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
	INNER JOIN dbo.Medecin
		ON dbo.MedecinSpecialite.Medecin_ID = dbo.Medecin.Medecin_ID
	INNER JOIN dbo.Specialite
		ON dbo.MedecinSpecialite.Specialite_ID = dbo.Specialite.Specialite_ID
	 WHERE dbo.Medecin.Medecin_ID = @Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPatient]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllPatient]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Patient 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPresence]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllPresence]
	@Medecin_ID AS INT,
	@MaisonMedicale_ID AS INT,
	@Day AS DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Presence 
		WHERE
			dbo.Presence.Medecin_ID = @Medecin_ID AND
			dbo.Presence.MaisonMedicale_ID = @MaisonMedicale_ID AND
			CONVERT(DATE, dbo.Presence.Starting) = @Day AND
			CONVERT(DATE, dbo.Presence.Ending) = @Day
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllPresenceForMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllPresenceForMedecin]
	@Medecin_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Presence WHERE dbo.Presence.Medecin_ID = @Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSpecialite]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSpecialite] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Specialite
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSpecialiteForAMedecinAndMaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllSpecialiteForAMedecinAndMaisonMedicale]
	@Medecin_ID AS INT,
	@MaisonMedicale_ID AS INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT dbo.Specialite.Specialite_ID, dbo.Specialite.Name FROM dbo.MaisonMedicale
	INNER JOIN dbo.MedecinSpecialiteMaisonMedicale
		ON dbo.MaisonMedicale.MaisonMedicale_ID = dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID
	INNER JOIN dbo.MedecinSpecialite
		ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
	INNER JOIN dbo.Medecin
		ON dbo.MedecinSpecialite.Medecin_ID = dbo.Medecin.Medecin_ID
	INNER JOIN dbo.Specialite
		ON dbo.MedecinSpecialite.Specialite_ID = dbo.Specialite.Specialite_ID
	 WHERE dbo.Medecin.Medecin_ID = @Medecin_ID AND dbo.MaisonMedicale.MaisonMedicale_ID = @MaisonMedicale_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSpecialiteForMaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSpecialiteForMaisonMedicale]
	@MaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT dbo.Specialite.Specialite_ID, dbo.Specialite.Name  FROM dbo.Specialite
	INNER JOIN dbo.MedecinSpecialite
		ON dbo.Specialite.Specialite_ID = dbo.MedecinSpecialite.Specialite_ID
	INNER JOIN dbo.MedecinSpecialiteMaisonMedicale
		ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
	WHERE dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID = @MaisonMedicale_ID

END
GO
/****** Object:  StoredProcedure [dbo].[GetAllSpecialiteForMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSpecialiteForMedecin] 
	@Medecin_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dbo.Specialite.Specialite_ID, dbo.Specialite.Name 
	FROM dbo.MedecinSpecialite
	INNER JOIN dbo.Specialite ON dbo.Specialite.Specialite_ID = dbo.MedecinSpecialite.Specialite_ID
	WHERE @Medecin_ID = dbo.MedecinSpecialite.Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetConsultationById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetConsultationById]
	@Consultation_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Consultation WHERE Consultation_ID = @Consultation_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetLocalById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLocalById]
	@Local_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Local WHERE Local_ID = @Local_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMaisonMedicaleById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMaisonMedicaleById]
	@MaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.MaisonMedicale WHERE MaisonMedicale_ID = @MaisonMedicale_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMaisonMedicaleFromMSMM]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMaisonMedicaleFromMSMM]
	@MedecinSpecialiteMaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT dbo.MaisonMedicale.MaisonMedicale_ID, dbo.MaisonMedicale.Name FROM dbo.MaisonMedicale
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID = dbo.MaisonMedicale.MaisonMedicale_ID
		WHERE
			dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMedecinById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMedecinById]
    -- Add the parameters for the stored procedure here
    @Medecin_ID INT
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT * FROM dbo.Medecin WHERE Medecin_ID = @Medecin_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMedecinFromMSMM]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMedecinFromMSMM]
	@MedecinSpecialiteMaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT * FROM dbo.Medecin
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialite.Medecin_ID = dbo.Medecin.Medecin_ID
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID= dbo.MedecinSpecialite.MedecinSpecialite_ID
		WHERE
			dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID 
END
GO
/****** Object:  StoredProcedure [dbo].[GetMedecinSpecialiteById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMedecinSpecialiteById]
	@MedecinSpecialite_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.MedecinSpecialite WHERE MedecinSpecialite_ID = @MedecinSpecialite_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMedecinSpecialiteMaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMedecinSpecialiteMaisonMedicale]
	@medecin_ID AS INT,
	@maisonMedicale_ID AS INT, 
	@specialite_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.MedecinSpecialiteMaisonMedicale
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
		WHERE
			dbo.MedecinSpecialiteMaisonMedicale.MaisonMedicale_ID = @maisonMedicale_ID AND
			dbo.MedecinSpecialite.Medecin_ID = @medecin_ID AND
			dbo.MedecinSpecialite.Specialite_ID = @specialite_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMedecinSpecialiteMaisonMedicaleById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMedecinSpecialiteMaisonMedicaleById]
	@MedecinSpecialiteMaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.MedecinSpecialiteMaisonMedicale WHERE MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetPatientById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPatientById]
    -- Add the parameters for the stored procedure here
    @Patient_ID INT
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT * FROM dbo.Patient WHERE Patient_ID = @Patient_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetPresenceById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPresenceById]
	@Presence_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Presence WHERE Presence_ID = @Presence_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetSpecialiteById]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpecialiteById]
	@Specialite_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Specialite WHERE Specialite_ID = @Specialite_ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetSpecialiteFromMSMM]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpecialiteFromMSMM]
	@MedecinSpecialiteMaisonMedicale_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT dbo.Specialite.Specialite_ID, dbo.Specialite.Name FROM dbo.Specialite
		INNER JOIN dbo.MedecinSpecialite ON dbo.MedecinSpecialite.Specialite_ID = dbo.Specialite.Specialite_ID
		INNER JOIN dbo.MedecinSpecialiteMaisonMedicale ON dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialite_ID = dbo.MedecinSpecialite.MedecinSpecialite_ID
		WHERE
			dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID
END
GO
/****** Object:  StoredProcedure [medecin].[AddMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[AddMedecin]
	@Firstname AS NVARCHAR(50),
	@Lastname AS NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT * FROM dbo.Medecin WHERE Firstname = @Firstname AND Lastname = @Lastname) 
	BEGIN
		RAISERROR('Ce medecin existe déjà', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Medecin (Firstname, Lastname) 
		VALUES (@Firstname, @Lastname)
	
		SELECT * FROM dbo.Medecin WHERE dbo.Medecin.Medecin_ID = @@identity
	END
END
GO
/****** Object:  StoredProcedure [medecin].[AddMedecinSpecialite]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[AddMedecinSpecialite]
	@Medecin_ID AS INT,
	@Specialite_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM dbo.MedecinSpecialite WHERE Medecin_ID = @Medecin_ID AND Specialite_ID = @Specialite_ID) 
	BEGIN
		RAISERROR('Le medecin a déjà cette spécialité', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		INSERT INTO dbo.MedecinSpecialite (Medecin_ID, Specialite_ID)
        VALUES(@Medecin_ID, @Specialite_ID)

		SELECT * FROM dbo.MedecinSpecialite WHERE dbo.MedecinSpecialite.MedecinSpecialite_ID = @@identity
	END
END
GO
/****** Object:  StoredProcedure [medecin].[AddMedecinSpecialiteMaisonMedicale]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[AddMedecinSpecialiteMaisonMedicale]
	@MedecinSpecialite_ID AS INT,
	@MaisonMedicale_ID AS INT,
	@MinimalDuration AS INT,
	@IsActif AS BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS (SELECT * FROM dbo.MedecinSpecialiteMaisonMedicale WHERE 
			MedecinSpecialite_ID = @MedecinSpecialite_ID 
		AND MaisonMedicale_ID = @MaisonMedicale_ID) 
	BEGIN
		RAISERROR('Vous êtes déjà inscrit dans cette maison médicale avec cette spécialité', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		IF (@MinimalDuration < 10) 
		BEGIN
			RAISERROR('La durée minimum pour une consultation est de 10 minutes', 16, 1) --change to > 10
			RETURN --exit now
		END
		ELSE
		BEGIN
			INSERT INTO dbo.MedecinSpecialiteMaisonMedicale(
				MedecinSpecialite_ID, 
				MaisonMedicale_ID,
				MinimalDuration,
				IsActif
			) 
			VALUES (@MedecinSpecialite_ID, @MaisonMedicale_ID, @MinimalDuration, 1)
	
			SELECT * FROM dbo.MedecinSpecialiteMaisonMedicale WHERE dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = @@identity
		END
	END
END
GO
/****** Object:  StoredProcedure [medecin].[AddPresence]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[AddPresence]
	@Medecin_ID AS INT,
	@MaisonMedicale_ID AS INT,
	@Starting AS DATETIME,
	@Ending AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS (SELECT * FROM dbo.Presence WHERE 
			Medecin_ID = @Medecin_ID 
		AND MaisonMedicale_ID = @MaisonMedicale_ID
		AND Starting = @Starting
		AND Ending = @Ending
		) 
	BEGIN
		RAISERROR('Cette presence existe déjà', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		IF (@Ending <= @Starting) 
		BEGIN
			RAISERROR('L''heure du commencement de votre présence ne peut pas être postérieur ou égale à l''heure de fin', 16, 1) --change to > 10
			RETURN --exit now
		END
		ELSE
		BEGIN
			IF EXISTS (SELECT * FROM dbo.Presence WHERE 
					Medecin_ID = @Medecin_ID 
				AND MaisonMedicale_ID != @MaisonMedicale_ID
				AND CONVERT(DATE, Starting) = CONVERT(DATE, @Starting)
				) 
			BEGIN
				RAISERROR('Impossible de travail dans deux maison médicale différentes le même jours', 16, 1) --change to > 10
				RETURN --exit now
			END
			ELSE
			BEGIN

				INSERT INTO dbo.Presence(
					Medecin_ID, 
					MaisonMedicale_ID,
					Starting,
					Ending
				) 
				VALUES (@Medecin_ID, @MaisonMedicale_ID, @Starting, @Ending)
	
				SELECT * FROM dbo.Presence WHERE dbo.Presence.Presence_ID = @@identity

			END
		END
	END
END
GO
/****** Object:  StoredProcedure [medecin].[ConfirmConsultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[ConfirmConsultation]
	@consultation_ID AS INT
AS
BEGIN
	UPDATE dbo.Consultation
		SET IsConfirmed = 1
		WHERE dbo.Consultation.Consultation_ID = @consultation_ID;

	SELECT * FROM dbo.Consultation WHERE dbo.Consultation.Consultation_ID = @consultation_ID
END
GO
/****** Object:  StoredProcedure [medecin].[GetAllMedecin]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[GetAllMedecin]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT * FROM dbo.Medecin
END
GO
/****** Object:  StoredProcedure [medecin].[UpdateMinimalDurationOfConsultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [medecin].[UpdateMinimalDurationOfConsultation]
	@MedecinSpecialiteMaisonMedicale_ID AS INT,
	@MinimalDuration AS INT
AS
BEGIN

	IF (@MinimalDuration < 10) 
	BEGIN
		RAISERROR('La durée minimum pour une consultation est de 10 minutes', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		UPDATE dbo.MedecinSpecialiteMaisonMedicale
		SET MinimalDuration = @MinimalDuration
		WHERE MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID

		SELECT * FROM dbo.MedecinSpecialiteMaisonMedicale WHERE dbo.MedecinSpecialiteMaisonMedicale.MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID
	END
END
GO
/****** Object:  StoredProcedure [patient].[AddConsultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [patient].[AddConsultation]
	@Patient_ID AS INT,
	@MedecinSpecialiteMaisonMedicale_ID AS INT,
	@Local_ID AS INT,
	@Starting AS DATETIME,
	@Ending AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS (SELECT * FROM dbo.Consultation WHERE Patient_ID = @Patient_ID 
		AND MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID
		AND Local_ID = @Local_ID
		AND Starting = @Starting
		AND Ending = @Ending
		) 
	BEGIN
		RAISERROR('Cette Consultation existe déjà', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Consultation(
			Patient_ID, 
			MedecinSpecialiteMaisonMedicale_ID,
			Local_ID,
			Starting,
			Ending,
			IsConfirmed,
			LastModified,
			Created
		) 
		VALUES (@Patient_ID, @MedecinSpecialiteMaisonMedicale_ID, @Local_ID, @Starting, @Ending, 0, SYSDATETIME(), SYSDATETIME())
		
		SELECT * FROM dbo.Consultation WHERE dbo.Consultation.Consultation_ID = @@identity
	END
END
GO
/****** Object:  StoredProcedure [patient].[AddPatient]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [patient].[AddPatient]
    -- Add the parameters for the stored procedure here
    @Firstname varchar(50),
    @Lastname varchar(50)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	IF EXISTS (SELECT * FROM dbo.Patient WHERE Firstname = @Firstname AND Lastname = @Lastname) 
	BEGIN
		RAISERROR('Patient already exist', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Patient (Firstname, Lastname) 
		VALUES (@Firstname, @Lastname)
	
		SELECT * FROM dbo.Patient WHERE dbo.Patient.Patient_ID = @@identity
	END
END
GO
/****** Object:  StoredProcedure [patient].[DeleteConsultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [patient].[DeleteConsultation]
	@Consultation_ID AS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @Confirmed BIT
	
	SELECT @Confirmed = dbo.Consultation.IsConfirmed FROM dbo.Consultation WHERE dbo.Consultation.Consultation_ID = @Consultation_ID

	IF (@Confirmed = 1) 
	BEGIN
		RAISERROR('Cette consultation a été confirmée par le médecin, impossible de la supprimer ou de la modifier', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		DELETE dbo.Consultation WHERE dbo.Consultation.Consultation_ID = @Consultation_ID
	END
END
GO
/****** Object:  StoredProcedure [patient].[UpdateConsultation]    Script Date: 13-04-21 21:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [patient].[UpdateConsultation]
	@Consultation_ID AS INT,
	@Patient_ID AS INT,
	@MedecinSpecialiteMaisonMedicale_ID AS INT,
	@Local_ID AS INT,
	@Starting AS DATETIME,
	@Ending AS DATETIME,
	@IsConfirmed AS BIT
AS
BEGIN
	 -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

	DECLARE @Confirmed BIT
	
	SELECT @Confirmed = dbo.Consultation.IsConfirmed FROM dbo.Consultation WHERE dbo.Consultation.Consultation_ID = @Consultation_ID

	IF (@Confirmed = 1) 
	BEGIN
		RAISERROR('Cette consultation a été confirmée par le médecin, impossible de la supprimer ou de la modifier', 16, 1) --change to > 10
		RETURN --exit now
	END
	ELSE
	BEGIN
		UPDATE dbo.Consultation
		SET 
			Patient_ID = @Patient_ID,
			MedecinSpecialiteMaisonMedicale_ID = @MedecinSpecialiteMaisonMedicale_ID,
			Local_ID = @Local_ID,
			Starting = @Starting,
			Ending = @Ending,
			IsConfirmed = @IsConfirmed
		WHERE Consultation_ID = @Consultation_ID;

		SELECT * FROM dbo.Consultation WHERE dbo.Consultation.Consultation_ID = @consultation_ID
	END

    
END
GO
USE [master]
GO
ALTER DATABASE [GestionConsultation] SET  READ_WRITE 
GO
