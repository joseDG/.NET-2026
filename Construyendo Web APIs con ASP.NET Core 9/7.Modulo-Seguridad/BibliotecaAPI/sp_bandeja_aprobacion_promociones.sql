CREATE OR REPLACE PROCEDURE sp_bandeja_aprobacion_promociones (
    p_id_promocion         IN NUMBER   DEFAULT NULL,
    p_solicitud            IN VARCHAR2 DEFAULT NULL,
    p_estado               IN VARCHAR2 DEFAULT NULL,
    p_usuario_solicita     IN VARCHAR2 DEFAULT NULL,
    p_fecha_solicitud_ini  IN DATE     DEFAULT NULL,
    p_fecha_solicitud_fin  IN DATE     DEFAULT NULL,
    p_fecha_inicio_ini     IN DATE     DEFAULT NULL,
    p_fecha_inicio_fin     IN DATE     DEFAULT NULL,
    p_fecha_fin_ini        IN DATE     DEFAULT NULL,
    p_fecha_fin_fin        IN DATE     DEFAULT NULL,
    p_canal_codigo         IN VARCHAR2 DEFAULT NULL,
    p_grupo_codigo         IN VARCHAR2 DEFAULT NULL,
    p_almacen_codigo       IN VARCHAR2 DEFAULT NULL,
    p_tipocliente_codigo   IN VARCHAR2 DEFAULT NULL,
    p_mediopago_codigo     IN VARCHAR2 DEFAULT NULL,
    p_page                 IN NUMBER   DEFAULT 1,
    p_page_size            IN NUMBER   DEFAULT 50,
    p_total_registros      OUT NUMBER,
    p_resultado            OUT SYS_REFCURSOR
)
AS
    v_page      NUMBER := NVL(p_page, 1);
    v_page_size NUMBER := NVL(p_page_size, 50);
    v_row_ini   NUMBER;
    v_row_fin   NUMBER;
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

    /*
      Requiere la vista VW_BANDEJA_APROBACION_PROMO con estas columnas:
      accion, solicitud, id_promocion, descripcion, motivo, clase_promocion,
      fecha_solicitud, usuario_solicita, fecha_inicio, fecha_fin,
      regalo_flag, soporte_flag, estado,
      canal_codigo, grupo_codigo, almacen_codigo, tipocliente_codigo, mediopago_codigo
    */

    SELECT COUNT(1)
      INTO p_total_registros
      FROM vw_bandeja_aprobacion_promo b
     WHERE (p_id_promocion IS NULL OR b.id_promocion = p_id_promocion)
       AND (p_solicitud IS NULL OR UPPER(b.solicitud) = UPPER(p_solicitud))
       AND (p_estado IS NULL OR UPPER(b.estado) = UPPER(p_estado))
       AND (p_usuario_solicita IS NULL OR UPPER(b.usuario_solicita) = UPPER(p_usuario_solicita))
       AND (p_fecha_solicitud_ini IS NULL OR TRUNC(b.fecha_solicitud) >= TRUNC(p_fecha_solicitud_ini))
       AND (p_fecha_solicitud_fin IS NULL OR TRUNC(b.fecha_solicitud) <= TRUNC(p_fecha_solicitud_fin))
       AND (p_fecha_inicio_ini IS NULL OR TRUNC(b.fecha_inicio) >= TRUNC(p_fecha_inicio_ini))
       AND (p_fecha_inicio_fin IS NULL OR TRUNC(b.fecha_inicio) <= TRUNC(p_fecha_inicio_fin))
       AND (p_fecha_fin_ini IS NULL OR TRUNC(b.fecha_fin) >= TRUNC(p_fecha_fin_ini))
       AND (p_fecha_fin_fin IS NULL OR TRUNC(b.fecha_fin) <= TRUNC(p_fecha_fin_fin))
       AND (p_canal_codigo IS NULL OR p_canal_codigo = 'TODOS' OR b.canal_codigo = p_canal_codigo)
       AND (p_grupo_codigo IS NULL OR p_grupo_codigo = 'TODOS' OR b.grupo_codigo = p_grupo_codigo)
       AND (p_almacen_codigo IS NULL OR p_almacen_codigo = 'TODOS' OR b.almacen_codigo = p_almacen_codigo)
       AND (p_tipocliente_codigo IS NULL OR p_tipocliente_codigo = 'TODOS' OR b.tipocliente_codigo = p_tipocliente_codigo)
       AND (p_mediopago_codigo IS NULL OR p_mediopago_codigo = 'TODOS' OR b.mediopago_codigo = p_mediopago_codigo);

    OPEN p_resultado FOR
        SELECT accion,
               solicitud,
               id_promocion,
               descripcion,
               motivo,
               clase_promocion,
               fecha_solicitud,
               usuario_solicita,
               fecha_inicio,
               fecha_fin,
               CASE
                   WHEN regalo_flag IN ('S', 'Y', '1') THEN 'SI'
                   ELSE 'NO'
               END AS regalo,
               CASE
                   WHEN soporte_flag IN ('S', 'Y', '1') THEN 'SI'
                   ELSE 'NO'
               END AS soporte,
               estado
          FROM (
                SELECT b.accion,
                       b.solicitud,
                       b.id_promocion,
                       b.descripcion,
                       b.motivo,
                       b.clase_promocion,
                       b.fecha_solicitud,
                       b.usuario_solicita,
                       b.fecha_inicio,
                       b.fecha_fin,
                       b.regalo_flag,
                       b.soporte_flag,
                       b.estado,
                       ROW_NUMBER() OVER (
                           ORDER BY b.fecha_solicitud DESC, b.id_promocion DESC
                       ) rn
                  FROM vw_bandeja_aprobacion_promo b
                 WHERE (p_id_promocion IS NULL OR b.id_promocion = p_id_promocion)
                   AND (p_solicitud IS NULL OR UPPER(b.solicitud) = UPPER(p_solicitud))
                   AND (p_estado IS NULL OR UPPER(b.estado) = UPPER(p_estado))
                   AND (p_usuario_solicita IS NULL OR UPPER(b.usuario_solicita) = UPPER(p_usuario_solicita))
                   AND (p_fecha_solicitud_ini IS NULL OR TRUNC(b.fecha_solicitud) >= TRUNC(p_fecha_solicitud_ini))
                   AND (p_fecha_solicitud_fin IS NULL OR TRUNC(b.fecha_solicitud) <= TRUNC(p_fecha_solicitud_fin))
                   AND (p_fecha_inicio_ini IS NULL OR TRUNC(b.fecha_inicio) >= TRUNC(p_fecha_inicio_ini))
                   AND (p_fecha_inicio_fin IS NULL OR TRUNC(b.fecha_inicio) <= TRUNC(p_fecha_inicio_fin))
                   AND (p_fecha_fin_ini IS NULL OR TRUNC(b.fecha_fin) >= TRUNC(p_fecha_fin_ini))
                   AND (p_fecha_fin_fin IS NULL OR TRUNC(b.fecha_fin) <= TRUNC(p_fecha_fin_fin))
                   AND (p_canal_codigo IS NULL OR p_canal_codigo = 'TODOS' OR b.canal_codigo = p_canal_codigo)
                   AND (p_grupo_codigo IS NULL OR p_grupo_codigo = 'TODOS' OR b.grupo_codigo = p_grupo_codigo)
                   AND (p_almacen_codigo IS NULL OR p_almacen_codigo = 'TODOS' OR b.almacen_codigo = p_almacen_codigo)
                   AND (p_tipocliente_codigo IS NULL OR p_tipocliente_codigo = 'TODOS' OR b.tipocliente_codigo = p_tipocliente_codigo)
                   AND (p_mediopago_codigo IS NULL OR p_mediopago_codigo = 'TODOS' OR b.mediopago_codigo = p_mediopago_codigo)
               )
         WHERE rn BETWEEN v_row_ini AND v_row_fin
         ORDER BY rn;
END sp_bandeja_aprobacion_promociones;
/
