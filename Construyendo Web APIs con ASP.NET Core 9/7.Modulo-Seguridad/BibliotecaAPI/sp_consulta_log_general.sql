CREATE OR REPLACE PROCEDURE sp_consulta_log_general (
    p_entidad             IN NUMBER    DEFAULT NULL,
    p_identidad           IN NUMBER    DEFAULT NULL
)
AS
    v_resultado SYS_REFCURSOR;
BEGIN
    OPEN v_resultado FOR
        SELECT l.idlog,
               TO_CHAR(l.fechahoratrx, 'YYYY-MM-DD HH24:MI:SS') AS fecha,
               l.iduser AS usuario,
               TO_CHAR(NVL(l.idopcion, l.idcontrolinterfaz)) AS opcion,
               TO_CHAR(l.idevento) AS accion,
               TO_CHAR(l.entidad) AS entidad,
               TO_CHAR(l.idtipoproceso) AS tipo_proceso,
               l.datos
          FROM apl_tb_log l
         WHERE (p_entidad IS NULL OR l.entidad = p_entidad)
           AND (p_identidad IS NULL OR l.identidad = p_identidad)
         ORDER BY l.idlog DESC;

    DBMS_SQL.RETURN_RESULT(v_resultado);
END sp_consulta_log_general;
/
