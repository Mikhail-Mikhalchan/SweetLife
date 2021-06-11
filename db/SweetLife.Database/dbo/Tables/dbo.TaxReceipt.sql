CREATE TABLE [dbo].[TaxReceipt]
(
	[Id] BIGINT NOT NULL IDENTITY PRIMARY KEY,
	[EmployeeId] BIGINT NOT NULL,
	[FileId] BIGINT NOT NULL,
	[Date] DATE NOT NULL,
	[PaymentAmount] DECIMAL (8,2) NOT NULL,

	CONSTRAINT [FK_TaxReceipt_File] FOREIGN KEY ([FileId]) REFERENCES [dbo].[File]([Id]),
	CONSTRAINT [FK_TaxReceipt_Employee] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee]([Id]),
)

GO

CREATE UNIQUE INDEX [UX_TaxReceipt_1] ON [dbo].[TaxReceipt] ([EmployeeId], [Date])