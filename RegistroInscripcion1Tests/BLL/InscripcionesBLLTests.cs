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
    public class InscripcionesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Estudiantes estudiantes = new Estudiantes();
            Inscripciones inscripciones = new Inscripciones();
            bool paso;

            inscripciones.InscripcionId = 1;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.EstudianteID = 1;
            inscripciones.Comentario = "estamos haciendo pruebas";
            inscripciones.Monto = 1000;
            inscripciones.Balance = 1000;
            paso = InscripcionesBLL.Guardar(inscripciones);
            estudiantes = EstudiantesBLL.Buscar(inscripciones.EstudianteID);

            decimal balanceEstudiante = estudiantes.Balance;
            decimal nuevoBalance = (balanceEstudiante + inscripciones.Balance);
            EstudiantesBLL.ActualizarBalance(inscripciones.EstudianteID, nuevoBalance);

            if (estudiantes.Balance == balanceEstudiante)
            {
                Assert.AreEqual(paso, true);
            }
            else
            {
                paso = false;
            }
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Estudiantes estudiantes = new Estudiantes();
            Inscripciones inscripciones = new Inscripciones();
            bool paso;

            inscripciones.InscripcionId = 1;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.EstudianteID = 1;
            inscripciones.Comentario = "estamos haciendo pruebas";
            inscripciones.Monto = 1000;
            inscripciones.Balance = 1000;


            if (InscripcionesBLL.Modificar(inscripciones))
            {
                paso = EstudiantesBLL.ActualizarBalance(inscripciones.EstudianteID, inscripciones.Balance);
                Assert.AreEqual(paso, true);

            }
            else
            {
                paso = false;
            }
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            decimal balanceInscripcion;
            decimal balanceEstudiante;

            Inscripciones inscripcion = new Inscripciones();
            Estudiantes estudiantes = new Estudiantes();

            inscripcion.InscripcionId = 32;
            inscripcion.EstudianteID = 10;

            inscripcion = InscripcionesBLL.Buscar(inscripcion.InscripcionId);
            estudiantes = EstudiantesBLL.Buscar(inscripcion.EstudianteID);
            balanceEstudiante = estudiantes.Balance;
            balanceInscripcion = inscripcion.Balance;
            EstudiantesBLL.ActualizarBalance(inscripcion.EstudianteID, (balanceEstudiante - balanceInscripcion));

            if (InscripcionesBLL.Eliminar(inscripcion.InscripcionId))
            {
                paso = true;
                Assert.AreEqual(paso, true);
            }
            else
            {
                paso = false;
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}