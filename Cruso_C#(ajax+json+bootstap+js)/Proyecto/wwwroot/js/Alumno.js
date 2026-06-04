

listar();

function listar() {
    // Se ejecuta cuando el DOM está listo
    $.get("Alumno/listarAlumnos", function (data) {
        crearListado(data);
    });
}


//creacion del combobox
$.get("Alumno/listarSexo", function (data) {

    llenarCombo(data, document.getElementById("cboSexo"), true);
})


function llenarCombo(data, control, primerElemento) {
    var contenido = "";
    if (primerElemento === true) {
        contenido += "<option value=''>--Seleccione--</option>";
    }
    for (var i = 0; i < data.length; i++) {
        contenido += "<option value='" + data[i].idd + "'>";
        contenido += data[i].nombre;
        contenido += "</option>";
    }
    control.innerHTML = contenido;
}

//Funcion Buscar por IDsexo
var btnBuscar = document.getElementById("btnBuscar");
btnBuscar.onclick = function () {
    var iidsexo = document.getElementById("cboSexo").value;

   
    $.get("Alumno/filtrarAlumnosPorSexo/?iidsexo=" + iidsexo, function (data) {
        crearListado(data);
    });
}

var btnLimpiar = document.getElementById("btnLimpiar");
btnLimpiar.onclick = function () {
    listar();
}

function crearListado(data) {
    var html = "";
    html += "<table id='tabla-alumno' class='table table-striped'>";
    html += "  <thead><tr><th>Id</th><th>Nombre</th><th>Apellido Paterno</th><th>Apellido Materno</th><th>Telefono Padre</th></tr></thead>";
    html += "  <tbody>";

    if (!data || data.length === 0) {
        html += "<tr><td colspan='3' class='text-center'>Sin datos</td></tr>";
    } else {
        for (var i = 0; i < data.length; i++) {
            var c = data[i];
            html += "<tr>";
            html += "  <td>" + (c.iidalumno ?? "") + "</td>";
            html += "  <td>" + (c.nombre ?? "") + "</td>";
            html += "  <td>" + (c.appaterno ?? "") + "</td>";
            html += "  <td>" + (c.apmaterno ?? "") + "</td>";
            html += "  <td>" + (c.telefonopadre ?? "") + "</td>";
            html += "</tr>";
        }
    }

    html += "  </tbody>";
    html += "</table>";

    $('#tabla').html(html);

    $('#tabla-alumno').DataTable(
        {
            searching: false,
            //lengthChange: false,
            //info: false,
        }
    );
}
