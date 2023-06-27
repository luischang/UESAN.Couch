CREATE TABLE [dbo].[ServicioCoach] (
    [id_ServicioCoach] INT IDENTITY (1, 1) NOT NULL,
    [id_Servicio]      INT NULL,
    [id_Coach]         INT NULL,
    [IsActive]         BIT NULL,
    PRIMARY KEY CLUSTERED ([id_ServicioCoach] ASC),
    CONSTRAINT [fk_Coaches] FOREIGN KEY ([id_Coach]) REFERENCES [dbo].[Coaches] ([id_coach]),
    CONSTRAINT [fk_servicio] FOREIGN KEY ([id_Servicio]) REFERENCES [dbo].[ServiciosCoaching] ([id_servicio])
);

