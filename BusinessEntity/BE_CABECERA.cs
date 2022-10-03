using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_CABECERA
    {
        private int m_PK_TAREA;
        public int PK_TAREA
        {
            get { return m_PK_TAREA; }
            set { m_PK_TAREA = value; }
        }
        private string m_ID_PROYECTO;
        public string ID_PROYECTO
        {
            get { return m_ID_PROYECTO; }
            set { m_ID_PROYECTO = value; }
        }
        private string m_IDE_ACTIVIDAD;
        public string IDE_ACTIVIDAD
        {
            get { return m_IDE_ACTIVIDAD; }
            set { m_IDE_ACTIVIDAD = value; }
        }
        private string m_DES_ACTIVIDAD;
        public string DES_ACTIVIDAD
        {
            get { return m_DES_ACTIVIDAD; }
            set { m_DES_ACTIVIDAD = value; }
        }
        private string m_ID_TAREA;
        public string ID_TAREA
        {
            get { return m_ID_TAREA; }
            set { m_ID_TAREA = value; }
        }
        private string m_ID_FRENTE;
        public string ID_FRENTE
        {
            get { return m_ID_FRENTE; }
            set { m_ID_FRENTE = value; }
        }
        private string m_DES_FRENTE;
        public string DES_FRENTE
        {
            get { return m_DES_FRENTE; }
            set { m_DES_FRENTE = value; }
        }
        private string m_CTA_COSTO;
        public string CTA_COSTO
        {
            get { return m_CTA_COSTO; }
            set { m_CTA_COSTO = value; }
        }
        private string m_DES_TAREA;
        public string DES_TAREA
        {
            get { return m_DES_TAREA; }
            set { m_DES_TAREA = value; }
        }
        private string m_DES_UNIDAD;
        public string DES_UNIDAD
        {
            get { return m_DES_UNIDAD; }
            set { m_DES_UNIDAD = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private Decimal m_HORAS_HOMBRE;
        public Decimal HORAS_HOMBRE
        {
            get { return m_HORAS_HOMBRE; }
            set { m_HORAS_HOMBRE = value; }
        }
        private Decimal m_METRADOS;
        public Decimal METRADOS
        {
            get { return m_METRADOS; }
            set { m_METRADOS = value; }
        }
        private int m_FLG_ESTADO;
        public int FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private string m_DESCRIPCION;
        public string DESCRIPCION
        {
            get { return m_DESCRIPCION; }
            set { m_DESCRIPCION = value; }
        }
        private int m_TIPO;
        public int TIPO
        {
            get { return m_TIPO; }
            set { m_TIPO = value; }
        }
        private Decimal m_HORAS_HOMBRE_M;
        public Decimal HORAS_HOMBRE_M
        {
            get { return m_HORAS_HOMBRE_M; }
            set { m_HORAS_HOMBRE_M = value; }
        }
        private Decimal m_METRADOS_M;
        public Decimal METRADOS_M
        {
            get { return m_METRADOS_M; }
            set { m_METRADOS_M = value; }
        }
        private string m_CODIGO_TAREA;
        public string CODIGO_TAREA
        {
            get { return m_CODIGO_TAREA; }
            set { m_CODIGO_TAREA = value; }
        }
        private string m_TIPO_ARCHIVO;
        public string TIPO_ARCHIVO
        {
            get { return m_TIPO_ARCHIVO; }
            set { m_TIPO_ARCHIVO = value; }
        }

    }
}
