CREATE TABLE [dbo].[Stud_Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[stud_id] [int] NOT NULL,
	[theme_id] [int] NOT NULL,
	[answer_percent] [int] NOT NULL,
	[answer_data] [date] NOT NULL,
 CONSTRAINT [PK__Stud_Ans__3214EC079E93F9F3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Stud_Answers]  WITH CHECK ADD  CONSTRAINT [FK_Stud_Answers_Students] FOREIGN KEY([stud_id])
REFERENCES [dbo].[Students] ([Id])
GO

ALTER TABLE [dbo].[Stud_Answers] CHECK CONSTRAINT [FK_Stud_Answers_Students]
GO

ALTER TABLE [dbo].[Stud_Answers]  WITH CHECK ADD  CONSTRAINT [FK_Stud_Answers_Themes] FOREIGN KEY([theme_id])
REFERENCES [dbo].[Themes] ([id])
GO

ALTER TABLE [dbo].[Stud_Answers] CHECK CONSTRAINT [FK_Stud_Answers_Themes]
GO