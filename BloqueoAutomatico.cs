/*using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class BloqueoAutomatico
    {
        public List<BloqueoAutomatico> Bloqueos;
        public bool BloqueoEstablecido;
        public int SentidoEstablecimiento;
        public bool[] CierreSeñales = new bool[2];
        public bool[] ItinerarioSalida = new bool[2];
        public bool[] ProhibicionBloqueo = new bool[2];
        public List<GENERICO>[] SeñalesBloqueo = new List<GENERICO>[2];
        public bool Ocupado;
        bool[] OcupadoUltimo = new bool[2];
        public bool SinDatos;
        public void Actualizar()
        {
            ActualizarOcupacion();
            if (!Establecido && ItinerarioSalida[0]) Establecer(0);
            if (!Establecido && ItinerarioSalida[1]) Establecer(1);
        }
        public void ActualizarOcupacion()
        {
            Ocupado = false;
            foreach (var sig in SeñalesBloqueo[0])
            {
                Ocupado |= sig.estadoDelCanton != EstadoCanton.Libre;
            }
            foreach (var sig in SeñalesBloqueo[1])
            {
                Ocupado |= sig.estadoDelCanton != EstadoCanton.Libre;
            }
            if (Establecido && !Ocupado && OcupadoUltimo[SentidoEstablecimiento]) Anular();
            OcupadoUltimo[0] = SeñalesBloqueo[0][SeñalesBloqueo[0].Count-1].estadoDelCanton != EstadoCanton.Libre;
            OcupadoUltimo[1] = SeñalesBloqueo[1][SeñalesBloqueo[1].Count-1].estadoDelCanton != EstadoCanton.Libre;
        }
        public void Establecer(int sentido, bool reintentar = false)
        {
            if (sentido != 0 && sentido != 1) return;
            if (!BloqueoEstablecido && !Ocupado && !ItinerarioSalida[1-sentido] && !ProhibicionBloqueo[1-sentido] && !SinDatos)
            {
                SentidoEstablecimiento = sentido;
                BloqueoEstablecido = true;
            }
            else if (reintentar)
            {
            
            }
        }
        public void Anular()
        {
            if (BloqueoEstablecido && !Ocupado && !CierreSeñales[0] && !CierreSeñales[1] && !ItinerarioSalida[SentidoEstablecimiento])
            {
                BloqueoEstablecido = false;
            }
        }
    }
}*/
