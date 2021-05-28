CREATE TABLE [dbo].[Employee]
(
	[Id] BIGINT NOT NULL IDENTITY PRIMARY KEY,

	[LastName] NVARCHAR(100) NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
	[Patronymic] NVARCHAR(100) NULL,

	[BirthDate] DATE NOT NULL,
	[Gender] INT NOT NULL,

	[PassportSeries] VARCHAR(50) NOT NULL,
	[PassportNumber] VARCHAR(50) NOT NULL,
	[PassportReleaseDate] DATE NOT NULL,
	[PassportRegistrationAddress] NVARCHAR(200) NOT NULL,

	[TemporaryRegistrationAddress] NVARCHAR(200) NULL,

	[MigrationCardSeries] VARCHAR(50) NULL,
	[MigrationCardNumber] VARCHAR(50) NULL,

	[PatentSeries] VARCHAR(50) NULL,
	[PatentNumber] VARCHAR(50) NULL,

	[IsFired] BIT NOT NULL,

	[NotificationFileId] BIGINT NULL,
	[LastTaxReceiptFileId] BIGINT NULL,

	CONSTRAINT [FK_Employee_File_NotificationFileId] FOREIGN KEY ([NotificationFileId]) REFERENCES [dbo].[File]([Id]),
	CONSTRAINT [FK_Employee_File_LastTaxReceiptFileId] FOREIGN KEY ([LastTaxReceiptFileId]) REFERENCES [dbo].[File]([Id]),
)
