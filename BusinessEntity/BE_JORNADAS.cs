using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public  class BE_JORNADAS
    {
        private int m_IDE_HORARIOS;
        public int IDE_HORARIOS
        {
            get { return m_IDE_HORARIOS; }
            set { m_IDE_HORARIOS = value; }
        }
        private string m_DES_DIA;
        public string DES_DIA
        {
            get { return m_DES_DIA; }
            set { m_DES_DIA = value; }
        }
        private int m_NRO_DIA;
        public int NRO_DIA
        {
            get { return m_NRO_DIA; }
            set { m_NRO_DIA = value; }
        }
        private Decimal m_HORAS_TRABAJO;
        public Decimal HORAS_TRABAJO
        {
            get { return m_HORAS_TRABAJO; }
            set { m_HORAS_TRABAJO = value; }
        }
        private string m_CCOSTO;
        public string CCOSTO
        {
            get { return m_CCOSTO; }
            set { m_CCOSTO = value; }
        }
        private int m_IDE_EMPRESA;
        public int IDE_EMPRESA
        {
            get { return m_IDE_EMPRESA; }
            set { m_IDE_EMPRESA = value; }
        }
        private Boolean m_FLG_100;
        public Boolean FLG_100
        {
            get { return m_FLG_100; }
            set { m_FLG_100 = value; }
        }

    }
}
