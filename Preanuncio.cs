using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ORTS.Scripting.Script
{
    public class PAPGENERICO : CommonSignalScript
    {
        bool senalEsAvanzadaBLA;
        int idSenal;
        int VelocidadPantalla;
        bool SigAnuncioParada;
        bool SigAnuncioPrecaucion;
        bool SigPreanuncioParada;
        Dictionary<int,int> VelocidadADrawState = new Dictionary<int, int>();
        public override void Initialize()
        {
            if (SignalTypeName.Contains("soloapara"))
            {
                SigAnuncioParada = true;
                SigAnuncioPrecaucion = SigPreanuncioParada = false;
            }
            else if (SignalTypeName.Contains("soloaprec"))
            {
                SigAnuncioPrecaucion = true;
                SigAnuncioParada = SigPreanuncioParada = false;
            }
            else if (SignalTypeName.Contains("soloprea"))
            {
                SigPreanuncioParada = true;
                SigAnuncioParada = SigAnuncioPrecaucion = false;
            }
            else
            {
                SigAnuncioParada = HasHead(1);
                SigAnuncioPrecaucion = HasHead(2);
                SigPreanuncioParada = HasHead(3);
                if (!SigAnuncioParada && !SigAnuncioPrecaucion && !SigPreanuncioParada) SigAnuncioParada = SigAnuncioPrecaucion = SigPreanuncioParada = true;
            }
            var match = Regex.Match(SignalTypeName, @"^pap(\d+)");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int num))
            {
                VelocidadPantalla = num * 10;
            }
            if (VelocidadPantalla == 0)
            {
                for (int i=0; i<4; i++)
                {
                    if (HasHead(4+i)) VelocidadPantalla += (1<<i)*10;
                }
            }
            if (VelocidadPantalla == 0) VelocidadPantalla = 60;
            for (int i=50; i<160; i+=10)
            {
                int index = GetDrawState(("PAP"+i).ToLowerInvariant());
                if (index >= 0) VelocidadADrawState[i] = index;
            }
        }

        public override void Update()
        {
            if (DistMultiSigMR("DISTANCE", "NORMAL", false) != Aspect.Stop) senalEsAvanzadaBLA = true;
            else senalEsAvanzadaBLA = false;
            idSenal = NextSignalId(senalEsAvanzadaBLA ? "DISTANCE" : "NORMAL");

            bool preanuncio = GetAspectoSenal(idSenal, senalEsAvanzadaBLA ? "DISTANCE" : "NORMAL") == Aspecto.PreanuncioParada;
            InfoRuta infoRuta = (InfoRuta)IdSignalLocalVariable(idSenal, KEY_VARIABLE_COMPARTIDA_SIG_INFO_RUTA);

            if (preanuncio &&
                (((infoRuta == InfoRuta.AG_DIR_SENAL_A_PARA || infoRuta == InfoRuta.NO_PREPARADO) && SigAnuncioParada) ||
                (infoRuta == InfoRuta.AG_DIR_SENAL_A_PREC && SigAnuncioPrecaucion) ||
                (infoRuta == InfoRuta.AG_DIR_SENAL_PREA && SigAnuncioPrecaucion)))
            {
                MstsSignalAspect = Aspect.Approach_3;
                if (VelocidadADrawState.TryGetValue(VelocidadPantalla, out int drawState)) DrawState = drawState;
                else DrawState = DefaultDrawState(MstsSignalAspect);
            }
            else
            {
                MstsSignalAspect = Aspect.Stop;
                DrawState = DefaultDrawState(MstsSignalAspect);
            }
        }
    }
}
