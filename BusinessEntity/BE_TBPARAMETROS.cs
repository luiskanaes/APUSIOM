using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public class BE_TBPARAMETROS
    {
        private int m_IDE_PARAMETRO;
        public int IDE_PARAMETRO
        {
            get { return m_IDE_PARAMETRO; }
            set { m_IDE_PARAMETRO = value; }
        }
        private string m_DES_TABLA;
        public string DES_TABLA
        {
            get { return m_DES_TABLA; }
            set { m_DES_TABLA = value; }
        }
        private string m_DES_CAMPO;
        public string DES_CAMPO
        {
            get { return m_DES_CAMPO; }
            set { m_DES_CAMPO = value; }
        }
        private string m_DES_ASUNTO;
        public string DES_ASUNTO
        {
            get { return m_DES_ASUNTO; }
            set { m_DES_ASUNTO = value; }
        }
        private int m_INT_ORDEN;
        public int INT_ORDEN
        {
            get { return m_INT_ORDEN; }
            set { m_INT_ORDEN = value; }
        }
        private Boolean m_FLG_ESTADO;
        public Boolean FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private string m_DES_ABREVIADO;
        public string DES_ABREVIADO
        {
            get { return m_DES_ABREVIADO; }
            set { m_DES_ABREVIADO = value; }
        }
        private string m_CENTRO_COSTO;
        public string CENTRO_COSTO
        {
            get { return m_CENTRO_COSTO; }
            set { m_CENTRO_COSTO = value; }
        }
        private string m_FECHA;
        public string FECHA
        {
            get { return m_FECHA; }
            set { m_FECHA = value; }
        }

        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }

        private string m_DATO;
        public string DATO
        {
            get { return m_DATO; }
            set { m_DATO = value; }
        }
    }
}
