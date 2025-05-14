﻿using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class ETCS_BIFURCACION : PaqueteETCS
	{
        string Mensaje = "";
        public ETCS_BIFURCACION()
        {
        }
        Aspect aspect;
        int id;
        public override void Initialize()
        {
            string dir = "";
            float dist = 2300;
            string sub = SignalTypeName.Substring(17);
            if (sub == "alcobendas") dir = "Alcobendas - SS Reyes";
            else if (sub == "burgos") dir = "Burgos";
            else if (sub == "aranjuez") dir = "Aranjuez";
            else if (sub == "parla") dir = "Parla";
            else if (sub == "pitis") dir = "Pitis";
            float distHead = 0;
            for (int i=0; i<7; i++)
            {
                if (HasHead(i+1)) distHead += (1<<i)*50;
            }
            if (distHead > 0) dist = distHead;
            Mensaje = get_bifurcacion(dir, dist);
        }
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
}
