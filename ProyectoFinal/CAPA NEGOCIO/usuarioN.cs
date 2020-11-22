using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CAPA_NEGOCIO
{
    public class usuarioN
    {
        usuario USUARIO = new usuario();
        public bool LoginUsuario(string user, string pass)
        {
            return USUARIO.Login(user, pass);
        }
    }
}
