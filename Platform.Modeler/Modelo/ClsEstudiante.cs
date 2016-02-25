using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//importaciones adicionales;
using Platform.Modeler.Entity;
//RECORDAR COLOCAR LA REFERENCIA Data.entity en el proyecto negocio

namespace Platform.Modeler.Modelo
{
    public class ClsEstudiante
    {
        EntEstudianteDataContext db;


        #region constructor

        public ClsEstudiante()
        {
            db = new EntEstudianteDataContext();
        }

        #endregion


        #region Funciones LINQ Basicas


        public bool guardar(String codigo, String nombre, String apellido, int edad, String carrera, String semestre)
        {
            try
            {
                estudiante est = new estudiante();

                est.codigo = codigo;
                est.nombre = nombre;
                est.apellido = apellido;
                est.edad = edad;
                est.carrera = carrera;
                est.semestre = semestre;

                db.estudiante.InsertOnSubmit(est);//ingresa el objeto temporal estudiante en la tabla
                db.SubmitChanges();//se hace submit;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LinkedList<String> buscar(String codigo)
        {
            LinkedList<String> temp = new LinkedList<String>();

            var consulta = from x in db.estudiante where x.codigo == codigo select x;
            consulta.First();

            foreach (estudiante est in consulta)
            {
                temp.AddLast(est.codigo);
                temp.AddLast(est.nombre);
                temp.AddLast(est.apellido);
                temp.AddLast(est.edad.ToString());
                temp.AddLast(est.carrera);
                temp.AddLast(est.semestre);
            }

            return temp;
        }


        public bool modificar(String codigo, String nombre, String apellido, int edad, String carrera, String semestre)
        {
            try
            {
                var consulta = from x in db.estudiante where x.codigo == codigo select x;
                consulta.First();

                foreach (estudiante est in consulta)
                {
                    est.codigo = codigo;
                    est.nombre = nombre;
                    est.apellido = apellido;
                    est.edad = edad;
                    est.carrera = carrera;
                    est.semestre = semestre;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool eliminar(String codigo)
        {
            try
            {
                var consulta = from x in db.estudiante where x.codigo == codigo select x;

                foreach (estudiante est in consulta)
                {
                    db.estudiante.DeleteOnSubmit(est);
                }

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion


        #region funciones LINQ con procedimientos almacenados

        public bool guardarP(String codigo, String nombre, String apellido, int edad, String carrera, String semestre)
        {
            try
            {
                db.guardarEstudiante(codigo, nombre, apellido, Convert.ToInt32(edad), carrera, Convert.ToInt32(semestre));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public LinkedList<String> buscarP(String codigo)
        {            
            LinkedList<String> temp = new LinkedList<String>();

            var consulta = db.buscarEstudiante(codigo);
            consulta.First();

            foreach (var dato in consulta)
            {
                temp.AddLast(dato.codigo);
                temp.AddLast(dato.nombre);
                temp.AddLast(dato.apellido);
                temp.AddLast(dato.edad.ToString());
                temp.AddLast(dato.carrera);
                temp.AddLast(dato.semestre);
            }

            return temp;
        }



        public bool modificarP(String codigo, String nombre, String apellido, int edad, String carrera, String semestre)
        {
            try
            {
                db.modificarEstudiante(codigo, nombre, apellido, Convert.ToInt32(edad), carrera, Convert.ToInt32(semestre));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool eliminarP(String codigo)
        {
            try
            {
                db.eliminarEstudiante(codigo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

    }
}
