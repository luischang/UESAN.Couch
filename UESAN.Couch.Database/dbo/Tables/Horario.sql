CREATE TABLE [dbo].[Horario] (
    [Id_horario]  INT      IDENTITY (1, 1) NOT NULL,
    [hora_inicio] TIME (7) NULL,
    [hora_fin]    TIME (7) NULL,
    PRIMARY KEY CLUSTERED ([Id_horario] ASC)
);

