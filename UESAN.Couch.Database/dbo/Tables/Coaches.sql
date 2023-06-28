CREATE TABLE [dbo].[Coaches] (
    [id_coach]    INT             IDENTITY (1, 1) NOT NULL,
    [tarifa_hora] DECIMAL (10, 2) NULL,
    [IsActive]    BIT             NULL,
    [id_Servicio] INT             NULL,
    [Id_Persona]  INT             NULL,
    PRIMARY KEY CLUSTERED ([id_coach] ASC),
    CONSTRAINT [FK_Persona] FOREIGN KEY ([Id_Persona]) REFERENCES [dbo].[Usuarios] ([id_persona]),
    CONSTRAINT [FK_Servicio] FOREIGN KEY ([id_Servicio]) REFERENCES [dbo].[ServiciosCoaching] ([id_servicio])
);







