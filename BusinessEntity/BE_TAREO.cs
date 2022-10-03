using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public  class BE_TAREO
    {
        private int m_IDE_TRABAJO;
        public int IDE_TRABAJO
        {
            get { return m_IDE_TRABAJO; }
            set { m_IDE_TRABAJO = value; }
        }
        private int m_IDE_TAREA;
        public int IDE_TAREA
        {
            get { return m_IDE_TAREA; }
            set { m_IDE_TAREA = value; }
        }
        private string m_DES_DNI;
        public string DES_DNI
        {
            get { return m_DES_DNI; }
            set { m_DES_DNI = value; }
        }
        private decimal m_HORA_EMPLEADA;
        public decimal HORA_EMPLEADA
        {
            get { return m_HORA_EMPLEADA; }
            set { m_HORA_EMPLEADA = value; }
        }
        private string m_IDE_INGCAMPO;
        public string IDE_INGCAMPO
        {
            get { return m_IDE_INGCAMPO; }
            set { m_IDE_INGCAMPO = value; }
        }
        private string m_IDE_CAPATAZ;
        public string IDE_CAPATAZ
        {
            get { return m_IDE_CAPATAZ; }
            set { m_IDE_CAPATAZ = value; }
        }
        private Boolean m_FLG_ESTADO;
        public Boolean FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private string m_USUARIO_REGISTRA;
        public string USUARIO_REGISTRA
        {
            get { return m_USUARIO_REGISTRA; }
            set { m_USUARIO_REGISTRA = value; }
        }
        private DateTime m_FECHA_REGISTRO;
        public DateTime FECHA_REGISTRO
        {
            get { return m_FECHA_REGISTRO; }
            set { m_FECHA_REGISTRO = value; }
        }
        private string m_FECHA;
        public string FECHA
        {
            get { return m_FECHA; }
            set { m_FECHA = value; }
        }
        private int m_TIPO;
        public int TIPO
        {
            get { return m_TIPO; }
            set { m_TIPO = value; }
        }

        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_CCENTRO;
        public string CCENTRO
        {
            get { return m_CCENTRO; }
            set { m_CCENTRO = value; }
        }
        private int m_IDE_BONIFICACION;
        public int IDE_BONIFICACION
        {
            get { return m_IDE_BONIFICACION; }
            set { m_IDE_BONIFICACION = value; }
        }
        private string m_ITEM_ACTIVIDAD;
        public string ITEM_ACTIVIDAD
        {
            get { return m_ITEM_ACTIVIDAD; }
            set { m_ITEM_ACTIVIDAD = value; }
        }
        private string m_DES_ASISTENCIA;
        public string DES_ASISTENCIA
        {
            get { return m_DES_ASISTENCIA; }
            set { m_DES_ASISTENCIA = value; }
        }

        private string m_ID_ESPECIALIDAD;
        public string ID_ESPECIALIDAD
        {
            get { return m_ID_ESPECIALIDAD; }
            set { m_ID_ESPECIALIDAD = value; }
        }

        private string m_ID_CATEGORIA;
        public string ID_CATEGORIA
        {
            get { return m_ID_CATEGORIA; }
            set { m_ID_CATEGORIA = value; }
        }
    }
}
