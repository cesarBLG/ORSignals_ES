/*using Orts.Formats.Msts;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class PAPGENERICO : CsSignalScript
    {
		Dictionary<string, Aspecto> textoAAspecto;
        bool senalEsAvanzadaBLA;
        int idSenal;
        const int KEY_PREANUNCIO = 101;
        int VelocidadPantalla;
        public override void Initialize()
		{
            VelocidadPantalla = int.Parse(SignalTypeName.SubString(3));
            textoAAspecto = Enum.GetNames(typeof(Aspecto)).ToDictionary(x => x, x => (Aspecto)Enum.Parse(typeof(Aspecto), x), StringComparer.OrdinalIgnoreCase);
		}

		public override void Update()
		{
            if (DistMultiSigMR("DISTANCE", "NORMAL", false) != MstsSignalAspect.STOP) senalEsAvanzadaBLA = true;
            else senalEsAvanzadaBLA = false;
            idSenal = NextSignalId(senalEsAvanzadaBLA ? "DISTANCE" : "NORMAL");
            
            bool preanuncio = GetAspectoSiguienteSenal() == Aspecto.PreanuncioParada;
            int velocidadPreanuncio = IdLocalVariable(idSenal, KEY_PREANUNCIO);
            
            if (preanuncio && (velocidadPreanuncio == 0 || velocidadPreanuncio == VelocidadPantalla))
            {
                MstsSignalAspect = MstsSignalAspect.CLEAR_2;
            }
            else
            {
                MstsSignalAspect = MstsSignalAspect.STOP;
            }
            
            DrawState = DefaultDrawState(MstsSignalAspect);
        }
        Aspecto GetAspectoSiguienteSenal()
		{
            string tipo = senalEsAvanzadaBLA ? "DISTANCE" : "NORMAL";
			var aspectoSiguienteSenalTexto = IdTextSignalAspect(idSenal, tipo);
			if (textoAAspecto.ContainsKey(aspectoSiguienteSenalTexto))
			{
				return textoAAspecto[aspectoSiguienteSenalTexto];
			}
			else
			{
				switch (IdSignalAspect(id, tipo))
				{
					case MstsSignalAspect.STOP:
						return Aspecto.Parada;

					case MstsSignalAspect.STOP_AND_PROCEED:
						return Aspecto.RebaseAutorizado;

					case MstsSignalAspect.RESTRICTING:
						return Aspecto.RebaseAutorizadoDestellos;

					case MstsSignalAspect.APPROACH_1:
						return Aspecto.AnuncioParada;

					case MstsSignalAspect.APPROACH_2:
						return Aspecto.AnuncioPrecaucion;

					case MstsSignalAspect.APPROACH_3:
						return Aspecto.PreanuncioParada;

					case MstsSignalAspect.CLEAR_1:
						return Aspecto.ViaLibreCondicional;

					case MstsSignalAspect.CLEAR_2:
						return Aspecto.ViaLibre;
				}
			}
			return Aspecto.Parada;
		}
    }
}*/
