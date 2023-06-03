CREATE TABLE [dbo].[Coaches] (
    [id_coach]    INT             IDENTITY (1, 1) NOT NULL,
    [id_persona]  INT             NULL,
    [tarifa_hora] DECIMAL (10, 2) NULL,
    [IsActive]    BIT             NULL,
    PRIMARY KEY CLUSTERED ([id_coach] ASC),
    FOREIGN KEY ([id_persona]) REFERENCES [dbo].[Usuarios] ([id_persona])
);

