CREATE DATABASE CafeteriaDb;
GO

USE CafeteriaDb;
GO

CREATE TABLE TbHccMesas (
    MesId INT PRIMARY KEY,
    MesLugares SMALLINT NOT NULL,
    MesDisponible TINYINT NOT NULL,
    MesEstatus TINYINT NOT NULL
);

CREATE TABLE TbHccCatEstatusOrden (
    CatOrdId INT PRIMARY KEY,
    CatOrdNombre VARCHAR(50) NOT NULL,
    CatOrdEstatus TINYINT NOT NULL
);

CREATE TABLE TbHccProductos (
    ProId INT PRIMARY KEY,
    AlmId INT NOT NULL,
    ProNombre VARCHAR(50) NOT NULL,
    ProDescripcion VARCHAR(120) NOT NULL,
    ProPrecio DECIMAL(10, 4) NOT NULL,
    ProEstatus TINYINT NOT NULL
);

CREATE TABLE TbHccAlmacen (
    AlmId INT PRIMARY KEY,
    AlmCantidad INT NOT NULL,
    AlmFechaActualizacion DATE NOT NULL,
    AlmEstatus TINYINT NOT NULL
);

CREATE TABLE TbHccOrdenes (
    OrdId INT PRIMARY KEY,
    MesId INT NOT NULL,
    CatOrdId INT NOT NULL,
    OrdFechaInicio DATE NOT NULL,
    OrdEstatus TINYINT NOT NULL,
    FOREIGN KEY (MesId) REFERENCES TbHccMesas(MesId),
    FOREIGN KEY (CatOrdId) REFERENCES TbHccCatEstatusOrden(CatOrdId)
);

CREATE TABLE TbHccOrdenesDetalle (
    OrdDetId INT PRIMARY KEY,
    OrdId INT NOT NULL,
    ProId INT NOT NULL,
    OrdDetCantidad SMALLINT NOT NULL,
    OrdDetEstatus TINYINT NOT NULL,
    FOREIGN KEY (OrdId) REFERENCES TbHccOrdenes(OrdId),
    FOREIGN KEY (ProId) REFERENCES TbHccProductos(ProId)
);

-- Insertar datos de ejemplo
INSERT INTO TbHccMesas (MesId, MesLugares, MesDisponible, MesEstatus)
VALUES (1, 4, 1, 1), (2, 2, 1, 1);

INSERT INTO TbHccCatEstatusOrden (CatOrdId, CatOrdNombre, CatOrdEstatus)
VALUES (1, 'nueva orden', 1), (2, 'orden recibida', 1), (3, 'orden en preparación', 1), (4, 'orden lista', 1), (5, 'orden pagada', 1);

INSERT INTO TbHccAlmacen (AlmId, AlmCantidad, AlmFechaActualizacion, AlmEstatus)
VALUES (1, 50, GETDATE(), 1), (2, 20, GETDATE(), 1);

INSERT INTO TbHccProductos (ProId, AlmId, ProNombre, ProDescripcion, ProPrecio, ProEstatus)
VALUES (1, 1, 'Café Americano', 'Café negro caliente', 2.50, 1), (2, 2, 'Té Verde', 'Té verde caliente', 2.00, 1);