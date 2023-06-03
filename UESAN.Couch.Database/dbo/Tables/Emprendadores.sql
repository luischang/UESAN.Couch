CREATE TABLE [dbo].[Emprendadores] (
    [id_emprendedor] INT IDENTITY (1, 1) NOT NULL,
    [id_persona]     INT NULL,
    [IsActive]       BIT NULL,
    PRIMARY KEY CLUSTERED ([id_emprendedor] ASC),
    FOREIGN KEY ([id_persona]) REFERENCES [dbo].[Usuarios] ([id_persona])
);

