using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_ARCHIVOS_MIGRACION
    {
        private int m_IDE_ENVIO;
        public int IDE_ENVIO
        {
            get { return m_IDE_ENVIO; }
            set { m_IDE_ENVIO = value; }
        }
        private string m_ARCHIVO;
        public string ARCHIVO
        {
            get { return m_ARCHIVO; }
            set { m_ARCHIVO = value; }
        }
        private string m_RUTA_FILE;
        public string RUTA_FILE
        {
            get { return m_RUTA_FILE; }
            set { m_RUTA_FILE = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private string m_CENTRO_COSTO;
        public string CENTRO_COSTO
        {
            get { return m_CENTRO_COSTO; }
            set { m_CENTRO_COSTO = value; }
        }
        private DateTime m_FECHA_ENVIO;
        public DateTime FECHA_ENVIO
        {
            get { return m_FECHA_ENVIO; }
            set { m_FECHA_ENVIO = value; }
        }
        private string  m_FLG_ENVIO;
        public string FLG_ENVIO
        {
            get { return m_FLG_ENVIO; }
            set { m_FLG_ENVIO = value; }
        }
        private string m_USUARIO_ENVIA;
        public string USUARIO_ENVIA
        {
            get { return m_USUARIO_ENVIA; }
            set { m_USUARIO_ENVIA = value; }
        }

        private string m_FECHA_TAREO;
        public string FECHA_TAREO
        {
            get { return m_FECHA_TAREO; }
            set { m_FECHA_TAREO = value; }
        }
        private string m_USUARIO_REGISTRO;
        public string USUARIO_REGISTRO
        {
            get { return m_USUARIO_REGISTRO; }
            set { m_USUARIO_REGISTRO = value; }
        }
        private string m_TIPO_FILE;
        public string TIPO_FILE
        {
            get { return m_TIPO_FILE; }
            set { m_TIPO_FILE = value; }
        }
        private string m_FILE_ZIPEADO;
        public string FILE_ZIPEADO
        {
            get { return m_FILE_ZIPEADO; }
            set { m_FILE_ZIPEADO = value; }
        }
    }
}
