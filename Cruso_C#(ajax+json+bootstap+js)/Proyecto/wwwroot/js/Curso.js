// Se ejecuta cuando el DOM está listo
$.get("Curso/ListarCurso", function (data) {
    crearListado(data);
});

//crear la parte del buscador
var btnBuscar = document.getElementById("btnBuscar");
btnBuscar.onclick = function () {
    //aqui 
    var nombre = document.getElementById("txtNombre").value;
    $.get("Curso/buscarCursoPorNombre/?nombre=" + nombre, function (data) {
        crearListado(data);
    });
}

//BOTON LIMPIAR
var btnLimpiar = document.getElementById("btnLimpiar");
btnLimpiar.onclick = function () {

    $.get("Curso/ListarCurso", function (data) {
        crearListado(data);
    });

    document.getElementById("txtNombre").value = "";
}

function crearListado(data) {
    var html = "";
    html += "<table id='tabla-curso' class='table table-striped'>";
    html += "  <thead><tr><th>Id</th><th>Nombre</th><th>Descripcion</th><th>Operaciones</th></tr></thead>";
    html += "  <tbody>";

    if (!data || data.length === 0) {
        html += "<tr><td colspan='3' class='text-center'>Sin datos</td></tr>";
    } else {
        for (var i = 0; i < data.length; i++) {
            var c = data[i];
            html += "<tr>";
            html += "  <td>" + (c.iidcurso ?? "") + "</td>";
            html += "  <td>" + (c.nombre ?? "") + "</td>";
            html += "  <td>" + (c.descripcion ?? "") + "</td>";
            html += `
                     <td class="align-middle">
                      <div class="d-flex  gap-2 ms-3"   >
                        <button type="button" class="btn btn-sm btn-outline-primary btn-edit" onclick='abrirModal(${c.iidcurso})'
                                data-bs-toggle="modal" data-bs-target="#exampleModal"
                                data-bs-toggle="tooltip" data-bs-title="Editar" aria-label="Editar">
                          <i class="bi bi-pencil-square" aria-hidden="true"></i>
                          <span class="visually-hidden">Editar</span>
                        </button>
                        <button type="button" class="btn btn-sm btn-outline-danger btn-delete"
                                data-bs-toggle="tooltip" data-bs-title="Eliminar" aria-label="Eliminar">
                          <i class="bi bi-trash" aria-hidden="true"></i>
                          <span class="visually-hidden">Eliminar</span>
                        </button>
                      </div>
                    </td>
                    `;
            html += "</tr>";
        }
    }

    html += "  </tbody>";
    html += "</table>";

    $('#tabla').html(html);

    $('#tabla-curso').DataTable(
        {
            searching: false,
            //lengthChange: false,
            //info: false,
        }
    );
}

function abrirModal(iidcurso) {
    if (iidcurso == 0) {
        borrarDatos();
    } else {
        $.get("Curso/recuperarDatos/?id=" + iidcurso, function (data) {
            const curso = data[0];
             
            document.getElementById("txtIdCurso").value = curso.iidcurso;
            document.getElementById("nombre").value = curso.nombre;
            document.getElementById("txtDescripcion").value = curso.descripcion;
        })
    }
}



function borrarDatos() {
    var controles = document.getElementsByClassName("borrar");
    var ncontroles = controles.length;
    for (var i = 0; i < ncontroles; i++) {
        controles[i].value = "";
    }
}

function Agregar() {
    datosObligatorios();
}

function datosObligatorios() {
    var exito = true;
    var contrlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = contrlesObligatorios.length;
    for (var i = 0; i < ncontroles; i++) {
        if (contrlesObligatorios[i].value = "") {
            exito = false;
            contrlesObligatorios[i].parentNode.classList.add("error");
        } else {

        }
    }

    return exito;
}