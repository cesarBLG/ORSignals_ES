using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    /*public class PN : CsSignalScript
    {
        public override void Initialize()
        {
        }
        public override void Update()
        {
            var next_state = NextSignalAspect("OLPN_T");
            var next_state_normal = NextSignalAspect("NORMAL");
            if (next_state == Aspect.Clear_2)
            {
                MstsSignalAspect = Aspect.Clear_2;
                
                if (next_state_normal == Aspect.Stop)
                {
                    MstsSignalAspect = Aspect.Approach_1; 
                }
            }
            else if (next_state == Aspect.Approach_2)
            {
                MstsSignalAspect = Aspect.Approach_2;
                
                if (next_state_normal == Aspect.Stop)
                {
                    MstsSignalAspect = Aspect.Approach_1; 
                }
            }	
            else if (next_state == Aspect.Approach_1)
            {
                MstsSignalAspect = Aspect.Approach_1;
            }
            else 
            {
                MstsSignalAspect = Aspect.Approach_3;
            }
            
            if (ApproachControlPosition(400, true) && next_state_normal == next_state_normal == Aspect.Stop)
            {
                MstsSignalAspect = Aspect.Approach_1;
            }
        }
    }*/
    public class OPEDALPN : CsSignalScript
    {
        Timer TemporizadorPedal;
        static Random rand = new Random();
        int id = -1;
        public override void Initialize()
        {
            TemporizadorPedal = new Timer(this);
            TemporizadorPedal.Setup(60);
        }
        public override void Update()
        {
            int nuevoId = NextSignalId("OLPN_T");
            if (nuevoId != -1) id = nuevoId;
            if (TemporizadorPedal.Triggered)
            {
                MstsSignalAspect = Aspect.Stop;
                if (id != -1) SendSignalMessage(id, "PEDAL_INACTIVO");
            }
            
            if (ApproachControlPosition(25, true) && MstsSignalAspect == Aspect.Stop)
            {
                TemporizadorPedal.Start();
                
                MstsSignalAspect = Aspect.Approach_1;
                
                bool falloPedal = rand.Next(50) == 1;
                if (!falloPedal)
                {
                    if (id != -1) SendSignalMessage(id, "PEDAL_ACTIVO");
                }
            }
            DrawState = DefaultDrawState(MstsSignalAspect);
        }
    }
    public class OLPN : CsSignalScript
    {
        static Random rand = new Random();
        bool PedalActivo;
        enum EstadoPN
        {
            Desarmado,
            Armandose,
            Armado,
            DesarmeTiempo
        }
        float TiempoArmado;
        EstadoPN Estado = EstadoPN.Desarmado;
        public override void Initialize()
        {
        }
        public override void Update()
        {
            if (PedalActivo && Estado == EstadoPN.Desarmado)
            {
                TiempoArmado = ClockTime();
                MstsSignalAspect = Aspect.Approach_1;
                Estado = EstadoPN.Armandose;
                PedalActivo = false;
            }
            if (Estado == EstadoPN.Armandose && ClockTime()-TiempoArmado > 5)
            {
                bool falloLeve = rand.Next(3) == 1;
                bool falloGrave = rand.Next(10) == 1;
                if (falloGrave)
                    MstsSignalAspect = Aspect.Approach_1; // Si hay un fallo grave el resultado de armarse en la SPN es desprotegido
                else if (falloLeve)
                    MstsSignalAspect = Aspect.Approach_2; // Si hay un fallo leve  el resultado de armarse en la SPN es protegido con fallo
                else
                    MstsSignalAspect = Aspect.Clear_2; // Si no hay fallo el resultado de armarse en la SPN es protegido
                    
                Estado = EstadoPN.Armado;
                PedalActivo = false;
            }
            if (Estado == EstadoPN.Armado && ClockTime()-TiempoArmado > 125)
            {
                MstsSignalAspect = Aspect.Approach_1; // Desprotegido en la SPN a los 120s de estar en posicion armada
                Estado = EstadoPN.DesarmeTiempo;
                PedalActivo = false;
            }
            if (Estado == EstadoPN.DesarmeTiempo && ClockTime()-TiempoArmado > 305)
            {
                MstsSignalAspect = Aspect.Approach_3; // Desarmado (apagado en SPN) a los 180s de estar en posicion desprotegida por desprotegido por tiempo
                Estado = EstadoPN.Desarmado;
                PedalActivo = false;
            }
            if (ApproachControlPosition(20, true))
            {
                MstsSignalAspect = Aspect.Approach_3; // Desarmado (apagado en SPN) al rebasar el tren el PN
                Estado = EstadoPN.Desarmado;
                PedalActivo = false;
            }
            SharedVariables[150] = NextSignalId("NORMAL");
            DrawState = DefaultDrawState(MstsSignalAspect);
        }
        public override void HandleSignalMessage(int id, string message)
        {
            if (message == "PEDAL_ACTIVO") PedalActivo = true;
            if (message == "PEDAL_INACTIVO") PedalActivo = false;
        }
    }
}
