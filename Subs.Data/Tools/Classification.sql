USE [MIMS3]
GO

/****** Object:  Table [dbo].[Classification]    Script Date: 2019-08-05 01:41:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Classification](
	[ClassificationId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Classification] [nvarchar](50) NOT NULL,
	[ModifiedBy] [nvarchar](50) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Classification] PRIMARY KEY CLUSTERED 
(
	[ClassificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Classification]  WITH NOCHECK ADD  CONSTRAINT [FK_Classification_Classification] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Classification] ([ClassificationId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_Classification]
GO


set Identity_insert [dbo].[Classification] on

insert into [dbo].[Classification]([ClassificationId], [ParentId], [Classification], [ModifiedBy], [ModifiedOn])
select 'ClassificationId' = [ClassificationIdInt], 'ParentId' = [ParentIdInt], 'Classification' = [Description], [ModifiedBy], [ModifiedOn]
from Classification2

set Identity_insert [dbo].[Classification] off

