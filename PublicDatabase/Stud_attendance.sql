CREATE TABLE [dbo].[Stud_attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[stud_id] [int] NOT NULL,
	[attendance] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Stud_attendance]  WITH CHECK ADD  CONSTRAINT [FK_Stud_attendance_Students] FOREIGN KEY([stud_id])
REFERENCES [dbo].[Students] ([Id])
GO

ALTER TABLE [dbo].[Stud_attendance] CHECK CONSTRAINT [FK_Stud_attendance_Students]
GO