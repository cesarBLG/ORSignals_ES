using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ETCS_CFG : ETCS
    {
        public override void Initialize()
        {
            base.Initialize();
            NID_C = ETCS.DefaultNID_C;
            LoadParameter("NID_C", SignalTypeName.Substring(9), ref NID_C);
            SharedVariables[0] = NID_C;
            SharedVariables[1] = -2;
        }
        public override void Update()
        {
            if (SharedVariables[1] == -2) SharedVariables[1] = NextSignalId("NORMAL");
        }
    }
    public class ETCS_LEVEL : CsSignalScript
    {
        public override void Initialize()
        {
            SetLevels();
        }
        public void SetLevels()
        {
            var levels = new List<string>();
            var levelNames = new List<string>{"N0", "N1", "N2", "ASFA", "LZB", "EBICAB"};
            var levelPriorities = new List<string>{"N2", "N1", "LZB", "EBICAB", "ASFA", "N0"};
            for (int i=levelNames.Count-1; i>=0; i--)
            {
                if (HasHead(i+1)) levels.Add(levelNames[i]);
            }
            switch (SignalTypeName.ToLowerInvariant())
            {
                case "etcs_level0":
                    levels.Add("N0");
                    levels.Add("ASFA");
                    break;
                case "etcs_level1":
                    levels.Add("N0");
                    levels.Add("ASFA");
                    levels.Add("N1");
                    break;
            }
            var orderedLevels = levels.OrderBy(x => levelPriorities.IndexOf(x)).ToList();
            for (int i=0; i<orderedLevels.Count; i++)
            {
                int num = 0;
                switch (orderedLevels[i])
                {
                    case "N0":
                        num = 1;
                        break;
                    case "N1":
                        num = 2;
                        break;
                    case "N2":
                        num = 3;
                        break;
                    case "N3":
                        num = 4;
                        break;
                    case "ASFA":
                        num = 5;
                        break;
                    case "LZB":
                        num = 15;
                        break;
                    case "EBICAB":
                        num = 24;
                        break;
                }
                SharedVariables[602+i] = num;
            }
            SharedVariables[602+orderedLevels.Count] = 0;
        }
        public override void Update()
        {
            SharedVariables[601] = RouteSet ? NextSignalId("NORMAL") : -1;
        }
    }
}
