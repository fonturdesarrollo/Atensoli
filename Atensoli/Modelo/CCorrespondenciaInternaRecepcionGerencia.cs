using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CCorrespondenciaInternaRecepcionGerencia
	{
        public CCorrespondenciaInternaRecepcionGerencia()
        {

        }

        public CCorrespondenciaInternaRecepcionGerencia(int _correspondenciaID, int _tipoInstruccionCorrespondenciaID, string _observacionesSeguimientoCorrespondencia, int _correspondenciaEstatusID, int _gerenciaID, int _seguridadUsuarioDatosID, int _gerenciaRemitenteID)
        {
            this._correspondenciaID = _correspondenciaID;
            this._tipoInstruccionCorrespondenciaID = _tipoInstruccionCorrespondenciaID;
            this._observacionesSeguimientoCorrespondencia = _observacionesSeguimientoCorrespondencia;
            this._correspondenciaEstatusID = _correspondenciaEstatusID;
            this._gerenciaID = _gerenciaID;
            this._seguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this._gerenciaRemitenteID = _gerenciaRemitenteID;
        }

        private int _correspondenciaID;
        private int _tipoInstruccionCorrespondenciaID;
        private string _observacionesSeguimientoCorrespondencia;
        private int _correspondenciaEstatusID;
        private int _gerenciaID;
        private int _seguridadUsuarioDatosID;
        private int _gerenciaRemitenteID;

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

        public int TipoInstruccionCorrespondenciaID
        {
            get
            {
                return _tipoInstruccionCorrespondenciaID;
            }

            set
            {
                _tipoInstruccionCorrespondenciaID = value;
            }
        }

        public string ObservacionesSeguimientoCorrespondencia
        {
            get
            {
                return _observacionesSeguimientoCorrespondencia;
            }

            set
            {
                _observacionesSeguimientoCorrespondencia = value;
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
        public int GerenciaRemitenteID
        {
            get
            {
                return _gerenciaRemitenteID;
            }

            set
            {
                _gerenciaRemitenteID = value;
            }
        }
    }
}