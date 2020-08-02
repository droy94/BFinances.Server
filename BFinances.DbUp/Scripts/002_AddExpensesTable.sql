CREATE TABLE [dbo].[Expenses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ExpenseNo] [varchar](50) NOT NULL,
	[FromContractorId] [bigint] FOREIGN KEY REFERENCES Contractors(Id) NOT NULL,
	[ForContractorId] [bigint] FOREIGN KEY REFERENCES Contractors(Id) NOT NULL,
	[ExpenseDate] [datetime] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[NetSum] [decimal](18, 0) NOT NULL,
	[GrossSum] [decimal](18, 0) NOT NULL,
	[VatSum] [decimal](18, 0) NOT NULL
)
GO