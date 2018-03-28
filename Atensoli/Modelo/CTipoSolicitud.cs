using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoSolicitud
    {
       public CTipoSolicitud()
        {
        }
        private int _tipoSolicitudID;
        private string _nombreTipoSolicitud;
        public CTipoSolicitud(int _tipoSolicitudID, string _nombreTipoSolicitud)
        {
            this.TipoSolicitudID = _tipoSolicitudID;
            this.NombreTipoSolicitud = _nombreTipoSolicitud;
        }

        public int TipoSolicitudID
        {
            get
            {
                return _tipoSolicitudID;
            }

            set
            {
                _tipoSolicitudID = value;
            }
        }

        public string NombreTipoSolicitud
        {
            get
            {
                return _nombreTipoSolicitud;
            }

            set
            {
                _nombreTipoSolicitud = value;
            }
        }
    }
}