using App04;

var documento = new Documento("Jose Diaz");

if (documento is IOperaciones)
{
    documento.Guardar();
}

IOperaciones ioperaciones = documento as IOperaciones;

if (ioperaciones is not null)
{
    ioperaciones.Cargar();
}

documento.EnviarNotification();
documento.EnviarMensajeTexto();
documento.EnviarEmail();

IMensajeria imensajeria = documento as IMensajeria;
imensajeria.EnviarMensajeTexto();