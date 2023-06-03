CREATE TABLE [dbo].[TiposUsuario] (
    [Id_tipo]     INT          IDENTITY (1, 1) NOT NULL,
    [nombre_tipo] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([Id_tipo] ASC)
);

