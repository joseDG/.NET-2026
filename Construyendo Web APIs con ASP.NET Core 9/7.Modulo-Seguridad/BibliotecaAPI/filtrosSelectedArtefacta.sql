CREATE OR REPLACE PROCEDURE filtrosSelectedArtefacta (
    p_canal        OUT SYS_REFCURSOR,
    p_grupo        OUT SYS_REFCURSOR,
    p_almacen      OUT SYS_REFCURSOR,
    p_tipocliente  OUT SYS_REFCURSOR,
    p_mediopago    OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_canal FOR
        SELECT codigo, nombre
        FROM (
            SELECT 'TODOS' AS codigo, 'Todos' AS nombre, 0 AS orden FROM dual
            UNION ALL
            SELECT codigo, nombre, 1 AS orden
            FROM apl_tb_artefacta_canal
            WHERE codigo IS NOT NULL AND nombre IS NOT NULL
        )
        ORDER BY orden, nombre;

    OPEN p_grupo FOR
        SELECT codigo, nombre
        FROM (
            SELECT 'TODOS' AS codigo, 'Todos' AS nombre, 0 AS orden FROM dual
            UNION ALL
            SELECT codigo, nombre, 1 AS orden
            FROM apl_tb_artefacta_grupo
            WHERE codigo IS NOT NULL AND nombre IS NOT NULL
        )
        ORDER BY orden, nombre;

    OPEN p_almacen FOR
        SELECT codigo, nombre
        FROM (
            SELECT 'TODOS' AS codigo, 'Todos' AS nombre, 0 AS orden FROM dual
            UNION ALL
            SELECT codigo, nombre, 1 AS orden
            FROM apl_tb_artefacta_almacen
            WHERE codigo IS NOT NULL AND nombre IS NOT NULL
        )
        ORDER BY orden, nombre;

    OPEN p_tipocliente FOR
        SELECT codigo, nombre
        FROM (
            SELECT 'TODOS' AS codigo, 'Todos' AS nombre, 0 AS orden FROM dual
            UNION ALL
            SELECT codigo, nombre, 1 AS orden
            FROM apl_tb_artefacta_tipocliente
            WHERE codigo IS NOT NULL AND nombre IS NOT NULL
        )
        ORDER BY orden, nombre;

    OPEN p_mediopago FOR
        SELECT codigo, nombre
        FROM (
            SELECT 'TODOS' AS codigo, 'Todos' AS nombre, 0 AS orden FROM dual
            UNION ALL
            SELECT codigo, nombre, 1 AS orden
            FROM apl_tb_artefacta_mediopago
            WHERE codigo IS NOT NULL AND nombre IS NOT NULL
        )
        ORDER BY orden, nombre;
END filtrosSelectedArtefacta;
/
