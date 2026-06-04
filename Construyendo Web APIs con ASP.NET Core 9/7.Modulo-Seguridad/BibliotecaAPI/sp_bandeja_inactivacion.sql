CREATE OR REPLACE PROCEDURE sp_bandeja_inactivacion (
    p_id_promocion     IN NUMBER DEFAULT NULL,
    p_page             IN NUMBER DEFAULT 1,
    p_page_size        IN NUMBER DEFAULT 50,
    p_total_registros  OUT NUMBER,
    p_resultado        OUT SYS_REFCURSOR
)
AS
    v_page            NUMBER := NVL(p_page, 1);
    v_page_size       NUMBER := NVL(p_page_size, 50);
    v_row_ini         NUMBER;
    v_row_fin         NUMBER;
    v_entidad         NUMBER;
    v_tipo_proceso    NUMBER;
    v_estado_nuevo    NUMBER;
    v_estado_aprobado NUMBER;
    v_estado_vigente  NUMBER;
BEGIN
    IF v_page < 1 THEN
        v_page := 1;
    END IF;

    IF v_page_size < 1 THEN
        v_page_size := 50;
    ELSIF v_page_size > 500 THEN
        v_page_size := 500;
    END IF;

    v_row_ini := ((v_page - 1) * v_page_size) + 1;
    v_row_fin := v_page * v_page_size;

    v_entidad := IdCatalogo('ENTPROMOCION');
    v_tipo_proceso := IdCatalogo('TPINACTIVACION');
    v_estado_nuevo := IdCatalogo('ESTADONUEVO');
    v_estado_aprobado := IdCatalogo('ESTADOAPROBADO');
    v_estado_vigente := IdCatalogo('ESTADOVIGENTE');

    /*
      Regla clave:
      Si existen varios registros de aprobacion para la misma promocion (IDENTIDAD),
      se conserva unicamente el de menor NIVELAPROBACION.
    */
    SELECT COUNT(1)
      INTO p_total_registros
      FROM (
            SELECT 1
              FROM (
                    SELECT a.identidad,
                           ROW_NUMBER() OVER (
                               PARTITION BY a.identidad
                               ORDER BY NVL(a.nivelaprobacion, 999999999),
                                        a.fechasolicitud,
                                        a.idaprobacion
                           ) rn
                      FROM apl_tb_aprobacion a
                      JOIN apl_tb_promocion p
                        ON p.idpromocion = a.identidad
                     WHERE a.entidad = v_entidad
                       AND a.idtipoproceso = v_tipo_proceso
                       AND a.idestadoregistro = v_estado_nuevo
                       AND p.estadoregistro IN (v_estado_aprobado, v_estado_vigente)
                       AND (p_id_promocion IS NULL OR a.identidad = p_id_promocion)
                   )
             WHERE rn = 1
           );

    OPEN p_resultado FOR
        SELECT idaprobacion,
               entidad,
               identidad AS id_promocion,
               descripcion_promocion,
               motivo_promocion,
               clase_promocion,
               fecha_hora_inicio,
               fecha_hora_fin,
               marca_regalo,
               estado_registro_promocion,
               marca_proceso_aprobacion,
               lote_aprobacion,
               archivo_soporte,
               idtipoproceso,
               idusersolicitud,
               nombreusersolicitud,
               fechasolicitud,
               iduseraprobador,
               fechaaprobacion,
               comentario,
               nivelaprobacion,
               idestadoregistro
          FROM (
                SELECT x.*,
                       ROW_NUMBER() OVER (
                           ORDER BY x.fechasolicitud DESC, x.identidad DESC, x.idaprobacion DESC
                       ) rn_global
                  FROM (
                        SELECT a.idaprobacion,
                               a.entidad,
                               a.identidad,
                               p.descripcion AS descripcion_promocion,
                               p.motivo AS motivo_promocion,
                               p.clasepromocion AS clase_promocion,
                               p.fechahorainicio AS fecha_hora_inicio,
                               p.fechahorafin AS fecha_hora_fin,
                               p.marcaregalo AS marca_regalo,
                               p.estadoregistro AS estado_registro_promocion,
                               p.marcaprocesoaprobacion AS marca_proceso_aprobacion,
                               p.numeroloteaprobacion AS lote_aprobacion,
                               p.archivosoporte AS archivo_soporte,
                               a.idtipoproceso,
                               a.idusersolicitud,
                               a.nombreusersolicitud,
                               a.fechasolicitud,
                               a.iduseraprobador,
                               a.fechaaprobacion,
                               a.comentario,
                               a.nivelaprobacion,
                               a.idestadoregistro,
                               ROW_NUMBER() OVER (
                                   PARTITION BY a.identidad
                                   ORDER BY NVL(a.nivelaprobacion, 999999999),
                                            a.fechasolicitud,
                                            a.idaprobacion
                               ) rn_por_promocion
                          FROM apl_tb_aprobacion a
                          JOIN apl_tb_promocion p
                            ON p.idpromocion = a.identidad
                         WHERE a.entidad = v_entidad
                           AND a.idtipoproceso = v_tipo_proceso
                           AND a.idestadoregistro = v_estado_nuevo
                           AND p.estadoregistro IN (v_estado_aprobado, v_estado_vigente)
                           AND (p_id_promocion IS NULL OR a.identidad = p_id_promocion)
                       ) x
                 WHERE x.rn_por_promocion = 1
               )
         WHERE rn_global BETWEEN v_row_ini AND v_row_fin
         ORDER BY rn_global;
END sp_bandeja_inactivacion;
/
