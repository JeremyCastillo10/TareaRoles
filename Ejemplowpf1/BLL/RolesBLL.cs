using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ejemplowpf1
{
    public class RolesBLL{
    public static bool Insertar(Roles rol){
        bool paso = false;
        using(var contexto = new Contexto()){
            contexto.Roles.Add(rol);
            paso = contexto.SaveChanges() > 0;
        }
        return paso;
    }

    public static List<Roles> GetLista(){
        using(var contexto = new Contexto()){
            return contexto.Roles.ToList ();
        }
    }

     public static bool Modificar(Roles rol)

        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try

            {
                contexto.Entry(rol).State = EntityState.Modified;

                paso = contexto.SaveChanges() > 0;

            }

            catch (Exception)

            {

                throw;

            }

            finally

            {

                contexto.Dispose();

            }

            return paso;

        }

        public static bool Eliminar(string id)

        {

            bool paso = false;

            Contexto contexto = new Contexto();

            try

            {

                var contextos = contexto.Roles.Find(id);

                if (contextos != null){
                    contexto.Roles.Remove(contextos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally

            {
                contexto.Dispose();
            }
            return paso;

        }

         public static bool Buscar(string id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.Rolid == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool BuscarAdmin(string rol)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.Descripcion == rol);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    
}

}

