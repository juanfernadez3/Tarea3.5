using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroInscripcion1.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroInscripcion1.Entidades;

namespace RegistroInscripcion1.BLL.Tests
{
    [TestClass()]
    public class EstudiantesBLLTests
    {
        [TestMethod()]
        public void ActualizarBalanceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Estudiantes estudiantes = new Estudiantes();

            estudiantes.EstudianteId = 1;
            estudiantes.Nombre = "test1";
            estudiantes.Cedula = "000-111-222";
            estudiantes.Telefono = "000-111-222";
            estudiantes.Direccion = "sfm";
            estudiantes.FechaNacimiento = DateTime.Now;
            estudiantes.Balance = 0;
            paso = EstudiantesBLL.Guardar(estudiantes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Estudiantes estudiantes = new Estudiantes();

            estudiantes.EstudianteId = 1;
            estudiantes.Nombre = "test1";
            estudiantes.Cedula = "000-111-222";
            estudiantes.Telefono = "000-111-222";
            estudiantes.Direccion = "sfm";
            estudiantes.FechaNacimiento = DateTime.Now;
            estudiantes.Balance = 0;
            paso = EstudiantesBLL.Modificar(estudiantes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            Estudiantes estudiantes = new Estudiantes();

            estudiantes.EstudianteId = 1;
            paso = EstudiantesBLL.Eliminar(estudiantes.EstudianteId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}