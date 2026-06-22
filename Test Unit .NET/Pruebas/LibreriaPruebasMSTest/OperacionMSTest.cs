using LibreriaPruebas;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaPruebasMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
        public void SumarNumero_InputDosNumeros_GetValorCorrecto() 
        {
            // 1. Arrange
            //Inicialiar las varibla o componentes qeu ejecutaron el test
            Operacion op = new();
            int numero1Test = 50;
            int numero2Test = 69;

            //2. Act
            int resultado = op.SumarNumero(numero1Test, numero2Test);

            //3. Assert
            Assert.AreEqual(119, resultado);
        }
    }
}
