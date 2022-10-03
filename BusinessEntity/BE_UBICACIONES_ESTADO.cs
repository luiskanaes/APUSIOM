using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public class BE_UBICACIONES_ESTADO
    {
        private int m_IDE_ESTADO;
        public int IDE_ESTADO
        {
            get { return m_IDE_ESTADO; }
            set { m_IDE_ESTADO = value; }
        }
        private string m_IDE_UBICACION;
        public string IDE_UBICACION
        {
            get { return m_IDE_UBICACION; }
            set { m_IDE_UBICACION = value; }
        }
        private string m_DESCRIPCION;
        public string DESCRIPCION
        {
            get { return m_DESCRIPCION; }
            set { m_DESCRIPCION = value; }
        }
        private string m_ABREVIATURA;
        public string ABREVIATURA
        {
            get { return m_ABREVIATURA; }
            set { m_ABREVIATURA = value; }
        }
        private string m_COLOR_FONDO;
        public string COLOR_FONDO
        {
            get { return m_COLOR_FONDO; }
            set { m_COLOR_FONDO = value; }
        }
        private int m_FLG_ESTADO;
        public int FLG_ESTADO
        {
            get { return m_FLG_ESTADO; }
            set { m_FLG_ESTADO = value; }
        }
        private int m_FLG_PRESENTE;
        public int FLG_PRESENTE
        {
            get { return m_FLG_PRESENTE; }
            set { m_FLG_PRESENTE = value; }
        }

    }
}
