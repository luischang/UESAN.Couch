CREATE TABLE [dbo].[Horario] (
    [Id_horario]  INT      IDENTITY (1, 1) NOT NULL,
    [hora_inicio] DATETIME NULL,
    [hora_fin]    DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id_horario] ASC)
);

