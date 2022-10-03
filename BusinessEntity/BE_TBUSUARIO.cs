using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public  class BE_TBUSUARIO
    {
          private string m_IDE_USUARIO;
        public string IDE_USUARIO
        {
            get { return m_IDE_USUARIO; }
            set { m_IDE_USUARIO = value; }
        }
        private string m_DES_NOMBRE_USUARIO;
        public string DES_NOMBRE_USUARIO
        {
            get { return m_DES_NOMBRE_USUARIO; }
            set { m_DES_NOMBRE_USUARIO = value; }
        }
        private string m_DES_PASSWORD;
        public string DES_PASSWORD
        {
            get { return m_DES_PASSWORD; }
            set { m_DES_PASSWORD = value; }
        }
        private string m_DES_NOMBRE;
        public string DES_NOMBRE
        {
            get { return m_DES_NOMBRE; }
            set { m_DES_NOMBRE = value; }
        }
        private Boolean m_FLG_ESTADO;
        public Boolean FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private string m_CreatedBy;
        public string CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }
        private DateTime m_CreatedDate;
        public DateTime CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }
        private string m_CORREO;
        public string CORREO
        {
            get { return m_CORREO; }
            set { m_CORREO = value; }
        }
        private string m_DES_APELLIDOS;
        public string DES_APELLIDOS
        {
            get { return m_DES_APELLIDOS; }
            set { m_DES_APELLIDOS = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_CCOSTO;
        public string CCOSTO
        {
            get { return m_CCOSTO; }
            set { m_CCOSTO = value; }
        }

        private string m_SERVER;
        public string SERVER
        {
            get { return m_SERVER; }
            set { m_SERVER = value; }
        }

    }
}
