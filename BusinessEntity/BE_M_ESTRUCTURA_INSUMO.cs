using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class BE_M_ESTRUCTURA_INSUMO
    {
        private int m_ID_INSUMO;
        public int ID_INSUMO
        {
            get { return m_ID_INSUMO; }
            set { m_ID_INSUMO = value; }
        }
        private int m_ID_ESTRUCTURA;
        public int ID_ESTRUCTURA
        {
            get { return m_ID_ESTRUCTURA; }
            set { m_ID_ESTRUCTURA = value; }
        }
        private string m_DESCRIPCION;
        public string DESCRIPCION
        {
            get { return m_DESCRIPCION; }
            set { m_DESCRIPCION = value; }
        }
        private int m_EJECUTADO;
        public int EJECUTADO
        {
            get { return m_EJECUTADO; }
            set { m_EJECUTADO = value; }
        }
        private string m_CENTRO;
        public string CENTRO
        {
            get { return m_CENTRO; }
            set { m_CENTRO = value; }
        }
        private string m_FECHA_TAREO;
        public string FECHA_TAREO
        {
            get { return m_FECHA_TAREO; }
            set { m_FECHA_TAREO = value; }
        }
        private string m_IDE_TAREA;
        public string IDE_TAREA
        {
            get { return m_IDE_TAREA; }
            set { m_IDE_TAREA = value; }
        }
        private DateTime m_FECHA_REGISTRO;
        public DateTime FECHA_REGISTRO
        {
            get { return m_FECHA_REGISTRO; }
            set { m_FECHA_REGISTRO = value; }
        }
        private string m_USUARIO_REGISTRO;
        public string USUARIO_REGISTRO
        {
            get { return m_USUARIO_REGISTRO; }
            set { m_USUARIO_REGISTRO = value; }
        }
        private string  m_PK_TAREA;
        public string  PK_TAREA
        {
            get { return m_PK_TAREA; }
            set { m_PK_TAREA = value; }
        }
        private string m_IDE_INGENIERO;
        public string IDE_INGENIERO
        {
            get { return m_IDE_INGENIERO; }
            set { m_IDE_INGENIERO = value; }
        }

    }
}
