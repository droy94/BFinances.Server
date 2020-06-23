USE [BFinances]

CREATE TABLE [dbo].[Contractor](
	[Name] [varchar](200) NOT NULL,
	[Nip] [varchar](10) NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL
)
GO

CREATE TABLE [dbo].[Pkwiu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](30) NOT NULL,
	[Name] [varchar](200) NOT NULL
)
GO

CREATE TABLE [dbo].[Invoice](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[FromContractorId] [bigint] NOT NULL,
	[ForContractorId] [bigint] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[NetAmount] [decimal](18, 0) NOT NULL,
	[NetCurrency] [varchar](3) NOT NULL,
	[VatPercent] [decimal](18, 0) NOT NULL,
	[NumberOfUnits] [int] NOT NULL,
	[UnitName] [varchar](20) NOT NULL,
	[PkwiuId] [bigint] NOT NULL
)
GO