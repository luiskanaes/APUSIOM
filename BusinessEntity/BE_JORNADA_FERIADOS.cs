using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_JORNADA_FERIADOS
    {
        private int m_IDE_FERIADO;
        public int IDE_FERIADO
        {
            get { return m_IDE_FERIADO; }
            set { m_IDE_FERIADO = value; }
        }
        private string m_FECHA;
        public string FECHA
        {
            get { return m_FECHA; }
            set { m_FECHA = value; }
        }
        private int m_NRO_DIA;
        public int NRO_DIA
        {
            get { return m_NRO_DIA; }
            set { m_NRO_DIA = value; }
        }
        private string m_DES_CRIPCION;
        public string DES_CRIPCION
        {
            get { return m_DES_CRIPCION; }
            set { m_DES_CRIPCION = value; }
        }
        private Decimal m_HORAS_TRABAJO;
        public Decimal HORAS_TRABAJO
        {
            get { return m_HORAS_TRABAJO; }
            set { m_HORAS_TRABAJO = value; }
        }
        private int m_FLG_ESTADO;
        public int FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
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
    }
}
