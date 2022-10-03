using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace UserCode
{
    public class Conversion_DataTable_Lista
    {
        public class ucTablaLista<T>
        {
            public static List<T> TablaALista(DataTable tabla)
            {
                List<T> lista = new List<T>();
                Type tipo = typeof(T);
                object obe = null;
                string tipoDato;
                string campo;
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    obe = Activator.CreateInstance(tipo);
                    for (int j = 0; j < tabla.Columns.Count; j++)
                    {
                        campo = tabla.Columns[j].ColumnName;
                        tipoDato = tabla.Columns[j].DataType.ToString().ToLower();
                        if (tipoDato.Contains("int16")) obe.GetType().GetProperty(campo).SetValue(obe, (short)tabla.Rows[i][j]);
                        else
                        {
                            if (tipoDato.Contains("int32")) obe.GetType().GetProperty(campo).SetValue(obe, (int)tabla.Rows[i][j]);
                            else
                            {
                                if (tipoDato.Contains("decimal")) obe.GetType().GetProperty(campo).SetValue(obe, (decimal)tabla.Rows[i][j]);
                                else obe.GetType().GetProperty(campo).SetValue(obe, tabla.Rows[i][j].ToString());
                            }
                        }
                    }
                    lista.Add((T)obe);
                }
                return (lista);
            }

            public static DataTable ListaATabla(List<T> lista)
            {
                DataTable tabla = new DataTable();
                //Crear la Estructura de la Tabla a partir de la Lista de Objetos
                PropertyInfo[] propiedades = lista[0].GetType().GetProperties();
                for (int i = 0; i < propiedades.Length; i++)
                {
                    tabla.Columns.Add(propiedades[i].Name, propiedades[i].PropertyType);
                }
                //Llenar la Tabla desde la Lista de Objetos
                DataRow fila = null;
                for (int i = 0; i < lista.Count; i++)
                {
                    propiedades = lista[i].GetType().GetProperties();
                    fila = tabla.NewRow();
                    for (int j = 0; j < propiedades.Length; j++)
                    {
                        fila[j] = propiedades[j].GetValue(lista[i], null);
                    }
                    tabla.Rows.Add(fila);
                }
                return (tabla);
            }
        }
    }

    
}
