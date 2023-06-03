CREATE TABLE [dbo].[Pago] (
    [id_pago]        INT             IDENTITY (1, 1) NOT NULL,
    [fechaRegistro]  DATETIME        NULL,
    [id_emprendedor] INT             NULL,
    [total_pago]     DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([id_pago] ASC),
    FOREIGN KEY ([id_emprendedor]) REFERENCES [dbo].[Emprendadores] ([id_emprendedor])
);

