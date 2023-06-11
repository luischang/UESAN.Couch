CREATE TABLE [dbo].[DetalleCoachServicio] (
    [Id_detCoachServicio] INT IDENTITY (1, 1) NOT NULL,
    [id_coach]            INT NULL,
    [id_plan]             INT NULL,
    [multiplicador]       INT NULL,
    [id_servicio]         INT NULL,
    [Id_horario]          INT NULL,
    [IsActive] BIT NULL, 
    PRIMARY KEY CLUSTERED ([Id_detCoachServicio] ASC),
    FOREIGN KEY ([id_coach]) REFERENCES [dbo].[Coaches] ([id_coach]),
    FOREIGN KEY ([Id_horario]) REFERENCES [dbo].[Horario] ([Id_horario]),
    FOREIGN KEY ([id_plan]) REFERENCES [dbo].[TipoPlan] ([id_plan]),
    FOREIGN KEY ([id_servicio]) REFERENCES [dbo].[ServiciosCoaching] ([id_servicio])
);

