CREATE TABLE [dbo].[Usuarios] (
    [id_persona]         INT           IDENTITY (1, 1) NOT NULL,
    [nombre]             VARCHAR (50)  NULL,
    [apellido]           VARCHAR (50)  NULL,
    [genero]             VARCHAR(50)      NULL,
    [Nro_Contacto]       VARCHAR (20)  NULL,
    [correo_electronico] VARCHAR (100) NULL,
    [contrasena]         VARCHAR (100) NULL,
    [isActive]           BIT           NULL,
    [Id_tipo]            INT           NULL,
    PRIMARY KEY CLUSTERED ([id_persona] ASC),
    FOREIGN KEY ([Id_tipo]) REFERENCES [dbo].[TiposUsuario] ([Id_tipo])
);

