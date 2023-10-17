using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GESTCRM.Clases
{
    public class RegaloEspecial
    {
        private string m_codCamp;
        private List<string> m_matsRegalo;
        private List<string> m_matsEsp;

        public string codCamp
        {
            set { m_codCamp = value; }
            get { return m_codCamp; }
        }

        public List<string> matsRegalo
        {
            set { m_matsRegalo = value; }
            get { return m_matsRegalo; }
        }

        public List<string> matsEsp
        {
            set { m_matsEsp = value; }
            get { return m_matsEsp; }
        }

        public RegaloEspecial()
        {
            codCamp = null;
            matsRegalo = new List<string>();
            matsEsp = new List<string>();
        }

        public RegaloEspecial(string camp, List<string> regalos, List<string> especiales)
        {
            codCamp = camp;
            matsRegalo = regalos;
            matsEsp = especiales;
        }

        public bool EsEspecial(string mat)
        {
            bool ret = false;

            foreach (string s in matsEsp)
            {
                if (s == mat)
                    return true;
            }

            return ret;
        }

        public bool EsRegalo(string mat)
        {
            bool ret = false;

            foreach (string s in matsRegalo)
            {
                if (s == mat)
                    return true;
            }

            return ret;
        }
    }
}
