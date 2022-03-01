USE [Karting]
GO

/****** Object:  Table [dbo].[Position]    Script Date: 01.03.2022 14:59:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Position](
	[ID_Position] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [varchar](100) NOT NULL,
	[PositionDescription] [varchar](200) NULL,
	[PayPeriod] [varchar](10) NOT NULL,
	[PayRate] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[ID_Position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Staff](
	[ID_Staff] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varbinary](80) NOT NULL,
	[LastName] [varbinary](80) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Gender] [varbinary](10) NOT NULL,
	[Position_ID] [int] NOT NULL,
	[Email] [varbinary](100) NOT NULL,
	[Comments] [varbinary](200) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[ID_Staff] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Staff] FOREIGN KEY([Position_ID])
REFERENCES [dbo].[Position] ([ID_Position])
GO

ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Staff]
GO

CREATE TABLE [dbo].[Timesheet](
	[ID_Timesheet] [int] IDENTITY(1,1) NOT NULL,
	[Staff_ID] [int] NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[PayAmount] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Timesheet] PRIMARY KEY CLUSTERED 
(
	[ID_Timesheet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Timesheet]  WITH CHECK ADD  CONSTRAINT [FK_Timesheet_Staff] FOREIGN KEY([Staff_ID])
REFERENCES [dbo].[Staff] ([ID_Staff])
GO

ALTER TABLE [dbo].[Timesheet] CHECK CONSTRAINT [FK_Timesheet_Staff]
GO


