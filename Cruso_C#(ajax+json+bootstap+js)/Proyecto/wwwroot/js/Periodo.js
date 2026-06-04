
$("#datepickerInicio").datepicker(
    {
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true
    }
);

$("#datepickerFin").datepicker(
    {
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true
    }
);


$.get("Periodo/listarPeriodo", function (data) {
    crearListado(data);
});

var nombrePeriodo = document.getElementById("txtNombre");
nombrePeriodo.onkeyup = function () {
    //ss
    var nombre = document.getElementById("txtNombre").value;
    $.get("Periodo/buscarPeriodoPorNombre/?nombrePeriodo=" + nombre, function (data) {
        crearListado(data);
    });
}

function crearListado(data) {
    var html = "";
    html += "<table id='tabla-curso' class='table table-striped'>";
    html += "  <thead><tr><th>Id</th><th>Nombre</th><th>Fecha inicio</th><th>Fecha fin</th><th>Operaciones</th></tr></thead>";
    html += "  <tbody>";

    if (!data || data.length === 0) {
        html += "<tr><td colspan='3' class='text-center'>Sin datos</td></tr>";
    } else {
        for (var i = 0; i < data.length; i++) {
            var c = data[i];
            html += "<tr>";
            html += "  <td>" + (c.iidperiodo ?? "") + "</td>";
            html += "  <td>" + (c.nombre ?? "") + "</td>";
            html += "  <td>" + (c.fechainicio ?? "") + "</td>";
            html += "  <td>" + (c.fechafin ?? "") + "</td>";
            html += `
                     <td class="align-middle">
                      <div class="d-flex  gap-2 ms-3"   >
                        <button type="button" class="btn btn-sm btn-outline-primary btn-edit"
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
