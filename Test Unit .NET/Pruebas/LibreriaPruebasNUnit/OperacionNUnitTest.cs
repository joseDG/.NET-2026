using LibreriaPruebas;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace LibreriaPrueba
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
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

        [Test]
        public void IsValorPar_InputNumeroImpar_ReturnFalse() 
        {
            Operacion op = new();
            int numeroImpar = 7;

            bool isPar = op.IsValorPar(numeroImpar);

            Assert.IsFalse(isPar);
            Assert.That(isPar, Is.EqualTo(false));
        }


        [Test]
        [TestCase(4)]
        [TestCase(8)]
        public void IsValorPar_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            Operacion op = new();
            

            bool isPar = op.IsValorPar(numeroPar);

            Assert.IsTrue(isPar);
            Assert.That(isPar, Is.EqualTo(true));
        }
    }
}
