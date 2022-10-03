using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
  public   class BE_TBPERFIL
    {
        private int m_IdPerfil;
        public int IdPerfil
        {
            get { return m_IdPerfil; }
            set { m_IdPerfil = value; }
        }
        private int m_IdSistema;
        public int IdSistema
        {
            get { return m_IdSistema; }
            set { m_IdSistema = value; }
        }
        private string m_Descripcion;
        public string Descripcion
        {
            get { return m_Descripcion; }
            set { m_Descripcion = value; }
        }
        private int m_Estado;
        public int Estado
        {
            get { return m_Estado; }
            set { m_Estado = value; }
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
        private string m_UpdatedBy;
        public string UpdatedBy
        {
            get { return m_UpdatedBy; }
            set { m_UpdatedBy = value; }
        }
        private DateTime m_UpdatedDate;
        public DateTime UpdatedDate
        {
            get { return m_UpdatedDate; }
            set { m_UpdatedDate = value; }
        }
        private string m_UrlDefault;
        public string UrlDefault
        {
            get { return m_UrlDefault; }
            set { m_UrlDefault = value; }
        }
    }
}
