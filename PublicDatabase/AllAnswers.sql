﻿CREATE TABLE [dbo].[AllAnswers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AllQuest_Id] [int] NOT NULL,
	[Answers] [text] NOT NULL,
	[right_Answ_id] [int] NOT NULL,
 CONSTRAINT [PK_AllAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[AllAnswers]  WITH CHECK ADD  CONSTRAINT [FK_AllAnswers_AllQuestions] FOREIGN KEY([AllQuest_Id])
REFERENCES [dbo].[AllQuestions] ([Id])
GO

ALTER TABLE [dbo].[AllAnswers] CHECK CONSTRAINT [FK_AllAnswers_AllQuestions]
GO
