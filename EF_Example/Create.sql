
Create Database [GameHighScores]
Go

Use [GameHighScores]
Go

CREATE TABLE [dbo].[Game] (
    [GameId]     INT        IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (20) NOT NULL,
    [MinimumAge] INT        NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([GameId] ASC)
);
Go
CREATE TABLE [dbo].[Player] (
    [PlayerId]  INT        IDENTITY (1, 1) NOT NULL,
    [Name]      NCHAR (20) NOT NULL,
    [BirthYear] INT        NOT NULL,
    CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED ([PlayerId] ASC)
);
Go
CREATE TABLE [dbo].[HighScores] (
    [GameId]    INT NOT NULL,
    [PlayerId]  INT NOT NULL,
    [Score] INT NOT NULL,
    CONSTRAINT [PK_HighScore] PRIMARY KEY CLUSTERED ([GameId] ASC, [PlayerId] ASC),
    CONSTRAINT [FK_HighScore_Game] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Game] ([GameId]),
    CONSTRAINT [FK_HighScore_Player] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Player] ([PlayerId])
);
Go
SET IDENTITY_INSERT [dbo].[Game] ON
INSERT INTO [dbo].[Game] ([GameId], [Name], [MinimumAge]) VALUES (1, N'Rocket Leage        ', 13)
INSERT INTO [dbo].[Game] ([GameId], [Name], [MinimumAge]) VALUES (2, N'Lego StarWars       ', 7)
INSERT INTO [dbo].[Game] ([GameId], [Name], [MinimumAge]) VALUES (3, N'Pacman              ', 7)
INSERT INTO [dbo].[Game] ([GameId], [Name], [MinimumAge]) VALUES (4, N'Tetris              ', 4)
SET IDENTITY_INSERT [dbo].[Game] OFF

SET IDENTITY_INSERT [dbo].[Player] ON
INSERT INTO [dbo].[Player] ([PlayerId], [Name], [BirthYear]) VALUES (1, N'Ofer                ', 1972)
INSERT INTO [dbo].[Player] ([PlayerId], [Name], [BirthYear]) VALUES (2, N'Adi                 ', 2012)
INSERT INTO [dbo].[Player] ([PlayerId], [Name], [BirthYear]) VALUES (3, N'Uri                 ', 2006)
SET IDENTITY_INSERT [dbo].[Player] OFF

INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (1, 1, 500)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (1, 2, 700)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (1, 3, 10000)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (2, 1, 1000)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (2, 2, 12000)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (2, 3, 5000)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (3, 1, 78000)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (3, 2, 9000)
INSERT INTO [dbo].[HighScores] ([GameId], [PlayerId], [Score]) VALUES (3, 3, 8000)
