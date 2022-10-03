using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_ASIGNACION_TAREO
    {
        private int m_IDE_TAREO_ASIGNACION;
        public int IDE_TAREO_ASIGNACION
        {
            get { return m_IDE_TAREO_ASIGNACION; }
            set { m_IDE_TAREO_ASIGNACION = value; }
        }
        private string m_IDE_EMPRESA;
        public string IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_IDE_CECOS;
        public string IDE_CECOS
        {
            get { return m_IDE_CECOS; }
            set { m_IDE_CECOS = value; }
        }
        private int m_INT_ANIO;
        public int INT_ANIO
        {
            get { return m_INT_ANIO; }
            set { m_INT_ANIO = value; }
        }
        private int m_INT_MES;
        public int INT_MES
        {
            get { return m_INT_MES; }
            set { m_INT_MES = value; }
        }
        private int m_INT_SEM;
        public int INT_SEM
        {
            get { return m_INT_SEM; }
            set { m_INT_SEM = value; }
        }
        private string m_COD_PROYECTO;
        public string COD_PROYECTO
        {
            get { return m_COD_PROYECTO; }
            set { m_COD_PROYECTO = value; }
        }
        private string  m_FEC_TAREO;
        public string FEC_TAREO
        {
            get { return m_FEC_TAREO; }
            set { m_FEC_TAREO = value; }
        }
        private string m_IDE_CLIENTE;
        public string IDE_CLIENTE
        {
            get { return m_IDE_CLIENTE; }
            set { m_IDE_CLIENTE = value; }
        }
        private string m_IDE_UBICACIONES;
        public string IDE_UBICACIONES
        {
            get { return m_IDE_UBICACIONES; }
            set { m_IDE_UBICACIONES = value; }
        }
        private int m_FLG_ESTADO;
        public int FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
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
        private int m_IDE_TURNO;
        public int IDE_TURNO
        {
            get { return m_IDE_TURNO; }
            set { m_IDE_TURNO = value; }
        }
        private string m_NOMBRE_DIA;
        public string NOMBRE_DIA
        {
            get { return m_NOMBRE_DIA; }
            set { m_NOMBRE_DIA = value; }
        }

        private int m_TIPO;
        public int  TIPO
        {
            get { return m_TIPO; }
            set { m_TIPO = value; }
        }
        private string m_GUID_CABECERA;
        public string GUID_CABECERA
        {
            get { return m_GUID_CABECERA; }
            set { m_GUID_CABECERA = value; }
        }
        private int m_IDE_DISCIPLINA;
        public int IDE_DISCIPLINA
        {
            get { return m_IDE_DISCIPLINA; }
            set { m_IDE_DISCIPLINA = value; }
        }
        private string m_DISCIPLINA;
        public string DISCIPLINA
        {
            get { return m_DISCIPLINA; }
            set { m_DISCIPLINA = value; }
        }
    }
}
