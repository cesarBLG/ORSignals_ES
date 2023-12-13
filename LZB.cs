using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
    public class LZBSTART : CsSignalScript
    {
        static public readonly int KeyNextSignalId=150;
        int id = -1;
        public override void Initialize()
        {
            
        }
        public override void Update()
        {
            if (id < 0)
            {
                id = NextSignalId("NORMAL");
                SharedVariables[KeyNextSignalId] = id;
            }
        }
    }
}
