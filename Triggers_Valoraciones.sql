--TRIGGER: Al crear productos, agregar a valoraciones_promedios
USE Ecommerce;

CREATE TRIGGER tr_producto_creado
ON Ecommerce.dbo.productos 
AFTER INSERT
AS
BEGIN
    INSERT INTO Valoraciones.dbo.valoracion_promedio (nombre, promedio)
    SELECT i.id, 0.0  
    FROM inserted i;
END;

--TRIGGER: Cuando se actualiza productos, sacar promedio de valoraciones
USE Valoraciones;

CREATE TRIGGER tr_actualizar_promedio
ON Valoraciones.dbo.valoraciones
AFTER INSERT, UPDATE
AS
BEGIN
    -- Actualiza el promedio para cada producto
    UPDATE valoracion_promedio 
    SET promedio = (
        SELECT AVG(puntuacion)
        FROM valoraciones v
        WHERE v.producto_id = i.producto_id
    )
    FROM valoracion_promedio
    INNER JOIN inserted i ON valoracion_promedio.nombre = i.producto_id;
END;



--Pruebas
/*
 	INSERT INTO productos
	(nombre, precio, descripcion)
	VALUES('TEST2', 100, 'TESTTRIGGER');
	
	INSERT INTO valoraciones
	(puntuacion, comentario, producto_id)
	VALUES(1, 'z', 4);
	
	SELECT * FROM Ecommerce.dbo.productos p 
	SELECT * FROM Valoraciones.dbo.valoracion_promedio vp
	SELECT * FROM Valoraciones.dbo.valoraciones v 
 */


