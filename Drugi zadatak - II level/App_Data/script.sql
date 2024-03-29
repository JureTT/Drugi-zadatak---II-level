USE [master]
GO
/****** Object:  Database [Drugi_zadatak___II_level.Service.VozilaDbContext]    Script Date: 9.7.2019. 11:15:08 ******/
CREATE DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Drugi_zadatak___II_level.Service.VozilaDbContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Drugi_zadatak___II_level.Service.VozilaDbContext.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Drugi_zadatak___II_level.Service.VozilaDbContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Drugi_zadatak___II_level.Service.VozilaDbContext_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Drugi_zadatak___II_level.Service.VozilaDbContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET  MULTI_USER 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET QUERY_STORE = OFF
GO
USE [Drugi_zadatak___II_level.Service.VozilaDbContext]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 9.7.2019. 11:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VoziloMarkas]    Script Date: 9.7.2019. 11:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoziloMarkas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[Kratica] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.VoziloMarkas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VoziloModels]    Script Date: 9.7.2019. 11:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoziloModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMarke] [int] NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
	[Kratica] [nvarchar](max) NULL,
	[VoziloMarka_Id] [int] NULL,
 CONSTRAINT [PK_dbo.VoziloModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201907072021215_AutomaticMigration', N'Drugi_zadatak___II_level.Migrations.Configuration', 0x1F8B0800000000000400ED59CD6EE33610BE17E83B103AB545D67292CB36B077B17592C2D8CD0FA224E8CDA0A5B14384A2549232EC2DFA643DF491FA0A1DEACF1225DBB2375B6CBBC55E626A383F1FBFE10C67FFFAE3CFC1DB65C8C902A46291183AC7BDBE4340F851C0C47CE8247AF6EAB5F3F6CDB7DF0C2E8270491E0BB95323873B851A3A4F5AC767AEABFC2708A9EA85CC97918A66BAE747A14B83C83DE9F77F748F8F5D40150EEA2264709708CD42487FE0CF51247C887542F955140057F93A7EF152ADE49A86A062EAC3D03997C99C4D3ED2806AFA3C994CC6E3098705F09E0772C17C70C83BCE28FAE5019F39840A1169AAD1EBB307059E9691987B312E507EBF8A01E566942BC8A3395B8B770DAC7F620273D71B0B557EA27414EEA9F0F83447CAB5B71F84B7532289585E20E67A65A24EF11C3A8FD147C6A32B2A9FA9436C7B67232E8DEC16C4B3C3EA55D41C915498E4C2E415198F492A7C5492073966FE1D9151C27522612820D192A2C46D32E5CC7F0FABFBE819C450249C5703C010F05B6D01976E651483D4AB3B98E5618D0387B8F57DAEBDB1DC56D993453B16FAF4C421D7689C4E3994FCA820E3E948C2CF2040520DC12DD51AA4303A2045B861DDB2754D3FB245610E1989A9E6902BBAFC0062AE9F860EFEE9904BB684A058C95D78100C3313376999408B8BDBCDBE476F994F5FC070D5CEC05DD3AA0BD90C655E806CE6C7FF64EB40B6716012137619FC8A188B76AEE982CD53782D8BB51BF10E782AA39E589C95932AFB2635D94B19857711AFF3BC2A32F1A2449AEA741F6D97BBA7720EBA5B92BD532AF259EA6433CB6A0ED6E3BF1001E9E86D86BC153B9E01A6138B3181D0ABA1F34303E1DD168A389B163244EB16FABDDEB18D4925FAE6CD832D85A60CB3A60A0C3D9F9A7558EA962B08DB83FC1652396DEC908C5E0F74832B88D3FA7CDA626980D3AAC940C436ABCA80B754553068D5576769457A07A1ED8BAF3B63CAE0ECB8DCFD75161C69EACC50B72FDE3A1A2D0954B262DD61BA598B59B4A2EE865E747045E318AF9F4A6F9AAF102F6B4C47AFBCFD7BB430D3E1FAAAA5552BBD2D2D612DA073B0BEA269F4F49249A5CFB1104EA9B9004741D810B37360032B0B6B4D9A374FB0A06AB1C7FC9DEDDBD5A7F7B6D06D0DEE25C61B62A54B4387561EB4EC4E1F0E9453D9527847114F42B1A9786FDB9D57C1AA827CA9BB8EB2A455B5948B4D3D03D702C23E02B77106564ED8C7BACFA16799FB394E3DBDCC0E3EF5F6DD9FE7D4CB06AAAEA2F506FADAD853BF6F3752A85E840E234B5DC71EBC3065A6BDCBDB546E9A3076A25555531BC50C98A527873B99D7D9039DDCDB31AC15014B1BCCB132ED7BD961770FDDAECB4D2A35CAB32D5212B92CD356391EE4A571F7FCA8512B33118720020B16983AE9AD9486B067047ADEAF7CC419A6CE5AE08A0A3603A5B387A373D23F3EB1864E5FCE00C8552AE0DDA740FFF803981960773E713FE5B92A1654FA4F547E17D2E5F79FFA04DDA8EC850623FF0DFCAD99436AE3DF78844D5DF6455709B0F19E1C8B009643E7B774EB1919FF32A9EF3E2237126F9333D227BF1F46A5177BFEAF0BF3212FF14D4FB9C3A707C86E90867C946349505A625168F42EB792099FC594B7C4D2AC8E5D12C7205D6AB5BF9C430CC264444BA05DCCED6E0F4A0B5636EF4263CF4948F3B1D875CE4177CD39B2523A74826984879FD1B922A0F69984EC1A846CB195F6005FCEA8A48A5CE3EDDA712CB269AEF2796620CD660A5958F92F3B4C06C5E66B15A64B14E0D7F857CA8CC52C2AD2C1F2A810B16ED92BD0E99BE09DD46C467D8D9F7D502A1DFE3E529EA0C8453885602C6E121D271A438670CA6BB370934EDBECA7839EBACF839B381DF7BE4408E826C310E046FC94301E947E5F362BD62615264FF3A26CCE529BE23C5F959AAE23D151510E5F79BDDC43187354A66E84471770886F0F0A3EC09CFAABA227DEAC64F741D4611F9C333A973454B98EF57EFC891C0EC2E59BBF016848C9AEB91E0000, N'6.2.0-61023')
SET IDENTITY_INSERT [dbo].[VoziloMarkas] ON 

INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (1, N'Mercedes-Benz', N'Merc')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (2, N'Bayerische Motoren Werke', N'BMW')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (3, N'Volkswagen', N'VW')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (4, N'Sociedad Española de Automóviles de Turismo', N'Seat')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (5, N'Tesla Motors', N'Tesla')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (6, N'Ford Motor Company', N'Ford')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (7, N'Rimac Automobili', N'Rimac')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (8, N'Škoda Auto', N'Škoda')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (9, N'Group Renault', N'Renault')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (10, N'Fiat Automobiles', N'Fiat')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (11, N'Toyota Motor Corporation', N'Toyota')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (12, N'Suzuki Motor Corporation', N'Suzuki')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (13, N'Nissan Motor Company', N'Nissan')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (14, N'Mitsubishi Motor Corporation', N'Mitsubishi')
INSERT [dbo].[VoziloMarkas] ([Id], [Naziv], [Kratica]) VALUES (15, N'Automobile Dacia', N'Dacia')
SET IDENTITY_INSERT [dbo].[VoziloMarkas] OFF
SET IDENTITY_INSERT [dbo].[VoziloModels] ON 

INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (1, 1, N'AMG GT', N'Merc', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (2, 1, N'CLK', N'Merc', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (3, 1, N'SLK', N'Merc', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (4, 2, N'M3', N'BMW', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (5, 2, N'M5', N'BMW', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (6, 2, N'X5', N'BMW', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (7, 3, N'Golf', N'VW', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (8, 3, N'Passat', N'VW', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (9, 3, N'up!', N'VW', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (10, 4, N'Ibiza', N'Seat', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (11, 4, N'Leon', N'Seat', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (12, 5, N'Model X', N'Tesla', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (13, 5, N'Model S', N'Tesla', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (14, 5, N'Model 3', N'Tesla', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (15, 6, N'Mustang', N'Ford', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (16, 6, N'Mondeo', N'Ford', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (17, 6, N'Focus', N'Ford', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (18, 7, N'Concept One', N'Rimac', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (19, 7, N'C_Two', N'Rimac', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (20, 8, N'Octavia', N'Škoda', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (21, 8, N'Fabia', N'Škoda', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (22, 9, N'Clio', N'Renault', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (23, 9, N'Twingo', N'Renault', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (24, 10, N'Punto', N'Fiat', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (25, 10, N'Bravo', N'Fiat', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (26, 11, N'Yaris', N'Toyota', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (27, 11, N'Corolla', N'Toyota', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (28, 12, N'Vitara', N'Suzuki', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (29, 12, N'Swift', N'Suzuki', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (30, 13, N'Primera', N'Nissan', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (31, 13, N'Almera', N'Nissan', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (32, 14, N'Lancer', N'Mitsubishi', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (33, 14, N'Pajero', N'Mitsubishi', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (34, 15, N'Logan', N'Dacia', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (35, 15, N'Sandero', N'Dacia', NULL)
INSERT [dbo].[VoziloModels] ([Id], [IdMarke], [Naziv], [Kratica], [VoziloMarka_Id]) VALUES (36, 15, N'Duster', N'Dacia', NULL)
SET IDENTITY_INSERT [dbo].[VoziloModels] OFF
/****** Object:  Index [IX_VoziloMarka_Id]    Script Date: 9.7.2019. 11:15:08 ******/
CREATE NONCLUSTERED INDEX [IX_VoziloMarka_Id] ON [dbo].[VoziloModels]
(
	[VoziloMarka_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VoziloModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.VoziloModels_dbo.VoziloMarkas_VoziloMarka_Id] FOREIGN KEY([VoziloMarka_Id])
REFERENCES [dbo].[VoziloMarkas] ([Id])
GO
ALTER TABLE [dbo].[VoziloModels] CHECK CONSTRAINT [FK_dbo.VoziloModels_dbo.VoziloMarkas_VoziloMarka_Id]
GO
USE [master]
GO
ALTER DATABASE [Drugi_zadatak___II_level.Service.VozilaDbContext] SET  READ_WRITE 
GO
