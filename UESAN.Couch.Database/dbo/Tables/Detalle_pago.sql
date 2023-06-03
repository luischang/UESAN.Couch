CREATE TABLE [dbo].[Detalle_pago] (
    [id_Detpago]          INT IDENTITY (1, 1) NOT NULL,
    [id_pago]             INT NULL,
    [Id_detCoachServicio] INT NULL,
    [Nro_solicitudes]     INT NULL,
    PRIMARY KEY CLUSTERED ([id_Detpago] ASC),
    FOREIGN KEY ([Id_detCoachServicio]) REFERENCES [dbo].[DetalleCoachServicio] ([Id_detCoachServicio]),
    FOREIGN KEY ([id_pago]) REFERENCES [dbo].[Pago] ([id_pago])
);

