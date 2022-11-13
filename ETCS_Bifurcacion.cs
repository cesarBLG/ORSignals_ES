using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class ETCS_Bifurcacion : PaqueteETCS
	{
        string Mensaje = "";
        public ETCS_Bifurcacion(string direccion, int distancia)
        {
            Mensaje = get_bifurcacion(direccion, distancia);
        }
        Aspect aspect;
        int id;
        public override void Update()
        {
            int next_id = NextSignalId ("NORMAL");
            var next_state = IdSignalAspect (id, "NORMAL");
            if (next_id != id || next_state != aspect) SharedVariables[KeyPacketNeedsUpdate] = 1;
            id = next_id;
            aspect = next_state;
            base.Update();
        }
        public override void UpdatePacket()
        {
            bool show = false;
            if (Enabled && CurrentBlockState == BlockState.Clear)
            {
                var route_block_state = RouteClearedToSignal(id);
                var next_state = IdSignalAspect (id, "NORMAL");
                
                if (route_block_state == BlockState.Clear && aspect != Aspect.Stop && aspect != Aspect.StopAndProceed && aspect != Aspect.Restricting && RouteSet)
                {
                    show = true;
                }
            }
            Packet = show ? Mensaje : "";
            base.UpdatePacket();
        }
		string get_bifurcacion(string nombre, float length)
        {
            string txt = "Dir. "+nombre;
            byte[] ascii = System.Text.Encoding.GetEncoding(28591).GetBytes(txt);
            string msg = "10" + format_binary(1,2) + "1" + format_binary(0, 15) + format_binary(0,4) + format_binary(5,3) + format_binary((int)(length/10),15) + format_binary(1023,10) + format_binary(15,4) + format_binary(5,3) + format_binary(0,2) + format_binary(ascii.Length, 8);
            for (int i=0; i<ascii.Length; i++)
            {
                msg += format_binary((int)ascii[i],8);
            }
            return create_packet(72, msg, 1);
        }
    }
	public class ETCS_BIFURCACION_ARANDA : ETCS_Bifurcacion
    {
        public ETCS_BIFURCACION_ARANDA() : base("Aranda", 2300) {}
    }
	public class ETCS_BIFURCACION_OROBON : ETCS_Bifurcacion
    {
        public ETCS_BIFURCACION_OROBON() : base("Orobón", 2300) {}
    }
}
