CREATE TABLE [dbo].[EntityDummy](
	[EntityDummyId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Canceled] BIT NOT NULL DEFAULT ((0))
	CONSTRAINT [PK_EntityDummyId] PRIMARY KEY CLUSTERED 
(
	[EntityDummyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]