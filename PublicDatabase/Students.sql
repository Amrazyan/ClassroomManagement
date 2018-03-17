CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Father_Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Groupe] [nvarchar](50) NOT NULL,
	[Course] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO