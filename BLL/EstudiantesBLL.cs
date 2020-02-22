using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RegistroInscripcion1.Entidades;
using RegistroInscripcion1.DAL;
//using RegistroInscripcion1.UI;

namespace RegistroInscripcion1.BLL
{
    public class EstudiantesBLL
    {
        public static bool ActualizarBalance(int id, decimal valorBalance) //Actualiza el balance de la persona dependiendo de la inscripcion
        {
            bool paso = false;
            Contexto db = new Contexto();
            Estudiantes estudiantes = new Estudiantes();
            estudiantes = db.Estudiantes.Find(id);
            try
            {
                if (estudiantes != null)
                {
                    estudiantes.Balance = valorBalance;
                    db.Entry(estudiantes).State = EntityState.Modified;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Estudiantes estudiantes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Estudiantes.Add(estudiantes) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Estudiantes estudiantes)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(estudiantes).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Estudiantes.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Estudiantes Buscar(int id)
        {
            Estudiantes persona = new Estudiantes();
            Contexto db = new Contexto();

            try
            {
                persona = db.Estudiantes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return persona;
        }

        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> estudiantes)
        {
            List<Estudiantes> lista = new List<Estudiantes>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Estudiantes.Where(estudiantes).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
