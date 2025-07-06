-- ================================================
-- Crear tabla InventarioMovimiento
-- ================================================
CREATE TABLE InventarioMovimiento (
    MovimientoId INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT NOT NULL,
    TipoMovimiento NVARCHAR(50) NOT NULL, -- 'Entrada' o 'Salida'
    Cantidad INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    UsuarioId INT NOT NULL,
    FOREIGN KEY (ProductoId) REFERENCES Productos(ProductoId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(UsuarioId)
);
GO

-- ================================================
-- Insertar InventarioMovimiento
-- ================================================
CREATE PROCEDURE InsertarInventarioMovimiento
    @ProductoId INT,
    @TipoMovimiento NVARCHAR(50),
    @Cantidad INT,
    @UsuarioId INT
AS
BEGIN
    INSERT INTO InventarioMovimiento (ProductoId, TipoMovimiento, Cantidad, UsuarioId)
    VALUES (@ProductoId, @TipoMovimiento, @Cantidad, @UsuarioId);

    -- Actualiza el stock del producto
    IF @TipoMovimiento = 'Entrada'
        UPDATE Productos SET Stock = Stock + @Cantidad WHERE ProductoId = @ProductoId;
    ELSE IF @TipoMovimiento = 'Salida'
        UPDATE Productos SET Stock = Stock - @Cantidad WHERE ProductoId = @ProductoId;
END;
GO

-- ================================================
-- Obtener todos los InventarioMovimientos
-- ================================================
CREATE PROCEDURE ObtenerInventarioMovimientos
AS
BEGIN
    SELECT MovimientoId, ProductoId, TipoMovimiento, Cantidad, Fecha, UsuarioId
    FROM InventarioMovimiento
    ORDER BY Fecha DESC;
END;
GO

-- ================================================
-- Obtener InventarioMovimiento por Id
-- ================================================
CREATE PROCEDURE ObtenerInventarioMovimientoPorId
    @MovimientoId INT
AS
BEGIN
    SELECT MovimientoId, ProductoId, TipoMovimiento, Cantidad, Fecha, UsuarioId
    FROM InventarioMovimiento
    WHERE MovimientoId = @MovimientoId;
END;
GO

-- ================================================
-- Actualizar InventarioMovimiento (NO recomendado en auditoría, solo si tu rúbrica lo exige)
-- ================================================
CREATE PROCEDURE ActualizarInventarioMovimiento
    @MovimientoId INT,
    @TipoMovimiento NVARCHAR(50),
    @Cantidad INT
AS
BEGIN
    UPDATE InventarioMovimiento
    SET TipoMovimiento = @TipoMovimiento,
        Cantidad = @Cantidad
    WHERE MovimientoId = @MovimientoId;
END;
GO

-- ================================================
-- Eliminar InventarioMovimiento (NO recomendado en auditoría, solo si tu rúbrica lo exige)
-- ================================================
CREATE PROCEDURE EliminarInventarioMovimiento
    @MovimientoId INT
AS
BEGIN
    DELETE FROM InventarioMovimiento
    WHERE MovimientoId = @MovimientoId;
END;
GO
