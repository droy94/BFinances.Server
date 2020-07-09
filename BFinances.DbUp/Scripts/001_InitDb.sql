USE [BFinances]

CREATE TABLE [dbo].[Contractors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar](200) NOT NULL,
	[Nip] [varchar](10) NOT NULL
)
GO

CREATE TABLE [dbo].[Pkwiu](
	[Id] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Code] [varchar](30) NOT NULL,
	[Name] [varchar](200) NOT NULL
)
GO

CREATE TABLE [dbo].[Invoices](
	[Id] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ServiceName] [varchar(500)] NOT NULL,
	[InvoiceNo] [varchar](50) NOT NULL,
	[FromContractorId] [bigint] FOREIGN KEY REFERENCES Contractors(Id) NOT NULL,
	[ForContractorId] [bigint] FOREIGN KEY REFERENCES Contractors(Id) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[SaleDate] [datetime] NOT NULL,
	[DueDays] [int] NULL,
	[NetSum] [decimal](18, 0) NOT NULL,
)
GO

CREATE TABLE [dbo].[InvoiceItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[InvoiceId] [bigint] FOREIGN KEY REFERENCES Invoices(Id) NOT NULL,
	[NetAmount] [decimal](18, 0) NOT NULL,
	[VatPercent] [decimal](18, 0) NOT NULL,
	[NumberOfUnits] [int] NOT NULL,
	[UnitName] [varchar](20) NOT NULL,
	[PkwiuId] [bigint] FOREIGN KEY REFERENCES Pkwiu(Id) NOT NULL
)
GO