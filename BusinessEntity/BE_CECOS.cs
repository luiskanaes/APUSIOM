using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public  class BE_CECOS
    {
        private string m_ID;
        public string ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }
        private string m_COD_PROYECTO;
        public string COD_PROYECTO
        {
            get { return m_COD_PROYECTO; }
            set { m_COD_PROYECTO = value; }
        }
        private string m_DESCRIPCION;
        public string DESCRIPCION
        {
            get { return m_DESCRIPCION; }
            set { m_DESCRIPCION = value; }
        }
        private string m_NOMBRE_CORTO;
        public string NOMBRE_CORTO
        {
            get { return m_NOMBRE_CORTO; }
            set { m_NOMBRE_CORTO = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private int m_FLG_ESTADO;
        public int FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private int m_FLG_CORREO;
        public int FLG_CORREO
        {
            get { return m_FLG_CORREO; }
            set { m_FLG_CORREO = value; }
        }
        private string m_CLIENTE;
        public string CLIENTE
        {
            get { return m_CLIENTE; }
            set { m_CLIENTE = value; }
        }
        private string m_UBICACION;
        public string UBICACION
        {
            get { return m_UBICACION; }
            set { m_UBICACION = value; }
        }

        private int m_T_STANDAR;
        public int T_STANDAR
        {
            get { return m_T_STANDAR; }
            set { m_T_STANDAR = value; }
        }

        private int m_T_PERSONZALIZADO;
        public int T_PERSONZALIZADO
        {
            get { return m_T_PERSONZALIZADO; }
            set { m_T_PERSONZALIZADO = value; }
        }

        private string m_COD_PLANILLA;
        public string COD_PLANILLA
        {
            get { return m_COD_PLANILLA; }
            set { m_COD_PLANILLA = value; }
        }
    }
}
