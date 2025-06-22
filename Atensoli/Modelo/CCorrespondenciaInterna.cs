using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CCorrespondenciaInterna
	{
        public CCorrespondenciaInterna()
        {

        }

        public CCorrespondenciaInterna(int _correspondenciaID, int _tipoCorrespondenciaID, int _correspondenciaRemitenteID, int _estadoID, string _fechaCorrespondencia, string _contenidoCorrespondencia, int _correspondenciaPrioridadID, int _gerenciaID, int _correspondenciaEstatusID, int _seguridadUsuarioDatosID, string _nombreCorrespondenciaRemitente)
        {
            this._correspondenciaID = _correspondenciaID;
            this._tipoCorrespondenciaID = _tipoCorrespondenciaID;
            this._correspondenciaRemitenteID = _correspondenciaRemitenteID;
            this._estadoID = _estadoID;
            this._fechaCorrespondencia = _fechaCorrespondencia;
            this._contenidoCorrespondencia = _contenidoCorrespondencia;
            this._correspondenciaPrioridadID = _correspondenciaPrioridadID;
            this._gerenciaID = _gerenciaID;
            this._correspondenciaEstatusID = _correspondenciaEstatusID;
            this._seguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this._nombreCorrespondenciaRemitente = _nombreCorrespondenciaRemitente;

        }

        private int _correspondenciaID;
        private int _tipoCorrespondenciaID;
        private int _correspondenciaRemitenteID;
        private int _estadoID;
        private string _fechaCorrespondencia;
        private string _contenidoCorrespondencia;
        private int _correspondenciaPrioridadID;
        private int _gerenciaID;
        private int _correspondenciaEstatusID;
        private int _seguridadUsuarioDatosID;
        private string _nombreCorrespondenciaRemitente;

        public int CorrespondenciaID
        {
            get
            {
                return _correspondenciaID;
            }

            set
            {
                _correspondenciaID = value;
            }
        }

        public int TipoCorrespondenciaID
        {
            get
            {
                return _tipoCorrespondenciaID;
            }

            set
            {
                _tipoCorrespondenciaID = value;
            }
        }

        public int CorrespondenciaRemitenteID
        {
            get
            {
                return _correspondenciaRemitenteID;
            }

            set
            {
                _correspondenciaRemitenteID = value;
            }
        }

        public int EstadoID
        {
            get
            {
                return _estadoID;
            }

            set
            {
                _estadoID = value;
            }
        }

        public string FechaCorrespondencia
        {
            get
            {
                return _fechaCorrespondencia;
            }

            set
            {
                _fechaCorrespondencia = value;
            }
        }

        public string ContenidoCorrespondencia
        {
            get
            {
                return _contenidoCorrespondencia;
            }

            set
            {
                _contenidoCorrespondencia = value;
            }
        }

        public int CorrespondenciaPrioridadID
        {
            get
            {
                return _correspondenciaPrioridadID;
            }

            set
            {
                _correspondenciaPrioridadID = value;
            }
        }

        public int GerenciaID
        {
            get
            {
                return _gerenciaID;
            }

            set
            {
                _gerenciaID = value;
            }
        }

        public int CorrespondenciaEstatusID
        {
            get
            {
                return _correspondenciaEstatusID;
            }

            set
            {
                _correspondenciaEstatusID = value;
            }
        }

        public int SeguridadUsuarioDatosID
        {
            get
            {
                return _seguridadUsuarioDatosID;
            }

            set
            {
                _seguridadUsuarioDatosID = value;
            }
        }
        public string NombreCorrespondenciaRemitente
        {
            get
            {
                return _nombreCorrespondenciaRemitente;
            }

            set
            {
                _nombreCorrespondenciaRemitente = value;
            }
        }
    }
}