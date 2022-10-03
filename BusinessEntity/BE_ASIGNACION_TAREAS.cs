using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_ASIGNACION_TAREAS
    {
        private int m_IDE_TAREA;
        public int IDE_TAREA
        {
            get { return m_IDE_TAREA; }
            set { m_IDE_TAREA = value; }
        }
        private int m_IDE_TAREO_ASIGNACION;
        public int IDE_TAREO_ASIGNACION
        {
            get { return m_IDE_TAREO_ASIGNACION; }
            set { m_IDE_TAREO_ASIGNACION = value; }
        }
        private int m_ITEM_ACTIVIDAD;
        public int ITEM_ACTIVIDAD
        {
            get { return m_ITEM_ACTIVIDAD; }
            set { m_ITEM_ACTIVIDAD = value; }
        }
        private string m_IDE_ACTIVIDAD;
        public string IDE_ACTIVIDAD
        {
            get { return m_IDE_ACTIVIDAD; }
            set { m_IDE_ACTIVIDAD = value; }
        }
        private string m_DET_TAREA;
        public string DET_TAREA
        {
            get { return m_DET_TAREA; }
            set { m_DET_TAREA = value; }
        }
        private string m_ID_FRENTE;
        public string ID_FRENTE
        {
            get { return m_ID_FRENTE; }
            set { m_ID_FRENTE = value; }
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
        private string m_HORA_INICIO;
        public string HORA_INICIO
        {
            get { return m_HORA_INICIO; }
            set { m_HORA_INICIO = value; }
        }
        private string m_HORA_FIN;
        public string HORA_FIN
        {
            get { return m_HORA_FIN; }
            set { m_HORA_FIN = value; }
        }
        private decimal m_PROGRAMADO;
        public decimal PROGRAMADO
        {
            get { return m_PROGRAMADO; }
            set { m_PROGRAMADO = value; }
        }
        private decimal m_EJECUTADO;
        public decimal EJECUTADO
        {
            get { return m_EJECUTADO; }
            set { m_EJECUTADO = value; }
        }
        private int m_FLG_ESTADO;
        public int FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private string m_OBSERVACIONES;
        public string OBSERVACIONES
        {
            get { return m_OBSERVACIONES; }
            set { m_OBSERVACIONES = value; }
        }
        private int m_AREAS;
        public int AREAS
        {
            get { return m_AREAS; }
            set { m_AREAS = value; }
        }
        private string  m_DES_AREAS;
        public string DES_AREAS
        {
            get { return m_DES_AREAS; }
            set { m_DES_AREAS = value; }
        }
        private string m_USUARIO_REGISTRO;
        public string USUARIO_REGISTRO
        {
            get { return m_USUARIO_REGISTRO; }
            set { m_USUARIO_REGISTRO = value; }
        }
        private DateTime m_FECHA_REGISTRO;
        public DateTime FECHA_REGISTRO
        {
            get { return m_FECHA_REGISTRO; }
            set { m_FECHA_REGISTRO = value; }
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
        private string m_IDE_PERSONAL;
        public string IDE_PERSONAL
        {
            get { return m_IDE_PERSONAL; }
            set { m_IDE_PERSONAL = value; }
        }
        private string m_ASISTENCIA;
        public string ASISTENCIA
        {
            get { return m_ASISTENCIA; }
            set { m_ASISTENCIA = value; }
        }
        private string m_FILE;
        public string FILE
        {
            get { return m_FILE; }
            set { m_FILE = value; }
        }
        private string m_NOMBRE_TRABAJOR;
        public string NOMBRE_TRABAJOR
        {
            get { return m_NOMBRE_TRABAJOR; }
            set { m_NOMBRE_TRABAJOR = value; }
        }
        private Boolean m_RETRABAJO;
        public Boolean RETRABAJO
        {
            get { return m_RETRABAJO; }
            set { m_RETRABAJO = value; }
        }
        private string m_DES_ACTIVIDAD;
        public string DES_ACTIVIDAD
        {
            get { return m_DES_ACTIVIDAD; }
            set { m_DES_ACTIVIDAD = value; }
        }
        private string m_DES_FRENTE;
        public string DES_FRENTE
        {
            get { return m_DES_FRENTE; }
            set { m_DES_FRENTE = value; }
        }
        private string m_CENTRO_COSTO;
        public string CENTRO_COSTO
        {
            get { return m_CENTRO_COSTO; }
            set { m_CENTRO_COSTO = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_FECHA_TAREO;
        public string FECHA_TAREO
        {
            get { return m_FECHA_TAREO; }
            set { m_FECHA_TAREO = value; }
        }
        private string m_FECHA_TAREO_FORMAT;
        public string FECHA_TAREO_FORMAT
        {
            get { return m_FECHA_TAREO_FORMAT; }
            set { m_FECHA_TAREO_FORMAT = value; }
        }

        private string m_PK_TAREA;
        public string PK_TAREA
        {
            get { return m_PK_TAREA; }
            set { m_PK_TAREA = value; }
        }
        private string m_COD_CABECERA;
        public string COD_CABECERA
        {
            get { return m_COD_CABECERA; }
            set { m_COD_CABECERA = value; }
        }
        private int m_IDE_DISCIPLINA;
        public int IDE_DISCIPLINA
        {
            get { return m_IDE_DISCIPLINA; }
            set { m_IDE_DISCIPLINA = value; }
        }
        private string m_CODIGO_AREA;
        public string CODIGO_AREA
        {
            get { return m_CODIGO_AREA; }
            set { m_CODIGO_AREA = value; }
        }
        private string m_CODIGO_MARCA;
        public string CODIGO_MARCA
        {
            get { return m_CODIGO_MARCA; }
            set { m_CODIGO_MARCA = value; }
        }
        private string m_ESTADO;
        public string ESTADO
        {
            get { return m_ESTADO; }
            set { m_ESTADO = value; }
        }

        private string m_NOMBRE_INGCAMPO;
        public string NOMBRE_INGCAMPO
        {
            get { return m_NOMBRE_INGCAMPO; }
            set { m_NOMBRE_INGCAMPO = value; }
        }
        private string m_NOMBRE_CAPATAZ;
        public string NOMBRE_CAPATAZ
        {
            get { return m_NOMBRE_CAPATAZ; }
            set { m_NOMBRE_CAPATAZ = value; }
        }

        private string m_SECTOR;
        public string SECTOR
        {
            get { return m_SECTOR; }
            set { m_SECTOR = value; }
        }

        private string m_NRO_FOLIO;
        public string NRO_FOLIO
        {
            get { return m_NRO_FOLIO; }
            set { m_NRO_FOLIO = value; }
        }


        private string m_SI;
        public string SI
        {
            get { return m_SI; }
            set { m_SI = value; }
        }

        private string m_NOMBRE_DIA;
        public string NOMBRE_DIA
        {
            get { return m_NOMBRE_DIA; }
            set { m_NOMBRE_DIA = value; }
        }

        private string m_DNI_VARIOS;
        public string DNI_VARIOS
        {
            get { return m_DNI_VARIOS; }
            set { m_DNI_VARIOS = value; }
        }
    }
}
