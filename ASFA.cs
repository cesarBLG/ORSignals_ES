using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORTS.Scripting.Script
{
	public class ASFA : CsSignalScript
	{
        bool balizaSenalFocos;
        bool previa;
        bool avanzadaBLA;
        bool preavanzadaBLA;
        bool balizaLVI;
        bool balizaPN;
        bool balizaCambioSenalizacion;
        
        bool Anulada;
        
        bool Fase2 = false;
        
		int SenalAsociada = -1;
        
        readonly bool FondoSiNoPreparada = false;
        
        // Frecuencias
        enum Frecuencia
        {
            FP,
            L1,
            L2,
            L3,
            L4,
            L5,
            L6,
            L7,
            L8,
            L9,
            L10,
            L11
        }
        const Frecuencia FrecuenciaFondoDefecto = Frecuencia.L8;
        Frecuencia FrecuenciaFondo = Frecuencia.FP;
        Frecuencia FrecuenciaActual;

		// Compatibilidad MSTS

		Dictionary<Frecuencia, Aspect> compatibilidadAspectosMSTS = new Dictionary<Frecuencia, Aspect>();
		Dictionary<string, Aspecto> textoAAspecto;
		
		public override void Initialize()
		{
            if (SignalTypeName.Contains("pn")) balizaPN = true;
            else if (SignalTypeName.Contains("peprima")) balizaSenalFocos = preavanzadaBLA = true;
            else if (SignalTypeName.Contains("eprima")) balizaSenalFocos = avanzadaBLA = true;
            else if (SignalTypeName.Contains("previa")) balizaSenalFocos = previa = true;
            else if (SignalTypeName.Contains("senal")) balizaSenalFocos = true;
            else if (SignalTypeName.Contains("l4")) balizaCambioSenalizacion = true;
            else if (SignalTypeName.Contains("l1"))
            {
                balizaLVI = true;
                if (SignalTypeName.Contains("l10")) FrecuenciaFondo = Frecuencia.L10; // LVI fase 2
                else if (SignalTypeName.Contains("l11")) FrecuenciaFondo = Frecuencia.L11; // LVI fase 2
                else FrecuenciaFondo = Frecuencia.L1; // Anuncio CSV fase 1
            }
            else if (SignalTypeName.Contains("l9")) // Anuncio LTV fase 1
            {
                balizaLVI = true;
                FrecuenciaFondo = Frecuencia.L9;
            }
            else if (SignalTypeName.Contains("l2")) // Preanuncio de LTV/CSV fase 1
            {
                balizaLVI = true;
                FrecuenciaFondo = Frecuencia.L2;
            }
            if (SignalTypeName.Contains("fase_2")) Fase2 = true;
            
            if (balizaSenalFocos)
            {
                if (preavanzadaBLA) FrecuenciaFondo = Frecuencia.L2;
                else if (avanzadaBLA) FrecuenciaFondo = Frecuencia.L1;
                else if (previa) FrecuenciaFondo = Frecuencia.L7;
                else FrecuenciaFondo = Frecuencia.L8;
            }
            else if (balizaPN) FrecuenciaFondo = Fase2 ? Frecuencia.L9 : Frecuencia.L1;
            else if (balizaCambioSenalizacion) FrecuenciaFondo = Frecuencia.L4;
            
			compatibilidadAspectosMSTS[Frecuencia.L8] = Aspect.Stop;
			compatibilidadAspectosMSTS[Frecuencia.L7] = Aspect.StopAndProceed;
			compatibilidadAspectosMSTS[Frecuencia.L4] = Aspect.Restricting;
			compatibilidadAspectosMSTS[Frecuencia.L1] = Aspect.Approach_1;
			compatibilidadAspectosMSTS[Frecuencia.L5] = Aspect.Approach_2;
			compatibilidadAspectosMSTS[Frecuencia.L6] = Aspect.Approach_3;
			compatibilidadAspectosMSTS[Frecuencia.L2] = Aspect.Clear_1;
			compatibilidadAspectosMSTS[Frecuencia.L3] = Aspect.Clear_2;
            
            textoAAspecto = Enum.GetNames(typeof(Aspecto)).ToDictionary(x => x, x => (Aspecto)Enum.Parse(typeof(Aspecto), x), StringComparer.OrdinalIgnoreCase);
		}

		public override void Update()
		{
            DeterminarFrecuencia();
            
            // TODO: simular desviaciones de la frecuencia en Hz respecto a la nominal

            TextSignalAspect = FrecuenciaActual.ToString();
            //MstsSignalAspect = compatibilidadAspectosMSTS[FrecuenciaActual];
            //DrawState = DefaultDrawState(MstsSignalAspect);
		}

		void DeterminarFrecuencia()
        {
            if (Anulada)
            {
                FrecuenciaActual = Frecuencia.FP;
            }
            else if (!Enabled && FondoSiNoPreparada)
            {
                FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
            }
			else if (balizaSenalFocos)
            {
                if (SenalAsociada < 0)
                {
                    if (avanzadaBLA || preavanzadaBLA) SenalAsociada = NextSignalId("DISTANCE");
                    else SenalAsociada = NextSignalId("NORMAL");
                    SendSignalMessage(SenalAsociada, "ASFA");
                }
                if (SenalAsociada < 0)
                {
                    FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
                    return;
                }
                var aspecto = GetAspectoSiguienteSenal();
                if (preavanzadaBLA)
                {
                    if (aspecto == Aspecto.ViaLibre) FrecuenciaActual = Frecuencia.L3;
                    else FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
                }
                else if (avanzadaBLA)
                {
                    switch (aspecto)
                    {
                        case Aspecto.AnuncioPrecaucion:
                            FrecuenciaActual = Fase2 ? Frecuencia.L6 : Frecuencia.L1;
                            break;
                        case Aspecto.PreanuncioParada:
                            FrecuenciaActual = Fase2 ? Frecuencia.L5 : Frecuencia.L1;
                            break;
                        case Aspecto.ViaLibreCondicional:
                            FrecuenciaActual = Frecuencia.L2;
                            break;
                        case Aspecto.ViaLibre:
                            FrecuenciaActual = Frecuencia.L3;
                            break;
                        default:
                            FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
                            break;
                    }
                }
                else
                {
                    switch (aspecto)
                    {
                        case Aspecto.AnuncioParada:
                        case Aspecto.AnuncioParadaInmediata:
                            FrecuenciaActual = Frecuencia.L1;
                            break;
                        case Aspecto.AnuncioPrecaucion:
                            FrecuenciaActual = Fase2 ? Frecuencia.L6 : Frecuencia.L1;
                            break;
                        case Aspecto.PreanuncioParada:
                            FrecuenciaActual = Fase2 ? Frecuencia.L5 : Frecuencia.L1;
                            break;
                        case Aspecto.ViaLibreCondicional:
                            FrecuenciaActual = Frecuencia.L2;
                            break;
                        case Aspecto.ViaLibre:
                            FrecuenciaActual = Frecuencia.L3;
                            break;
                        default:
                            FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
                            break;
                    }
                }
            }
            else if (balizaPN)
            {
                if (SenalAsociada < 0) SenalAsociada = NextSignalId("PN_T");
                if (SenalAsociada < 0)
                {
                    FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
                    return;
                }
                switch (IdSignalAspect(SenalAsociada, "PN_T"))
                {
                    // TODO: Ajustar a los aspectos que da la SPN
					case Aspect.Approach_2:
					case Aspect.Clear_2:
						FrecuenciaActual = Fase2 ? Frecuencia.L4 : Frecuencia.L3;
                        break;
                    default:
                        FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;
                        break;
                }
            }
            else FrecuenciaActual = FrecuenciaFondo != Frecuencia.FP ? FrecuenciaFondo : FrecuenciaFondoDefecto;    
        }
		
		public override void HandleSignalMessage(int id, string message)
		{
		}
		
		Aspecto GetAspectoSiguienteSenal()
		{
			int id = SenalAsociada;
            string tipo = (preavanzadaBLA || avanzadaBLA) ? "DISTANCE" : "NORMAL";
			var aspectoSiguienteSenalTexto = IdTextSignalAspect(id, tipo);
			if (textoAAspecto.ContainsKey(aspectoSiguienteSenalTexto))
			{
				return textoAAspecto[aspectoSiguienteSenalTexto];
			}
			else
			{
				switch (IdSignalAspect(id, tipo))
				{
					case Aspect.Stop:
						return Aspecto.Parada;

					case Aspect.StopAndProceed:
						return Aspecto.RebaseAutorizado;

					case Aspect.Restricting:
						return Aspecto.RebaseAutorizadoDestellos;

					case Aspect.Approach_1:
						return Aspecto.AnuncioParada;

					case Aspect.Approach_2:
						return Aspecto.AnuncioPrecaucion;

					case Aspect.Approach_3:
						return Aspecto.PreanuncioParada;

					case Aspect.Clear_1:
						return Aspecto.ViaLibreCondicional;

					case Aspect.Clear_2:
						return Aspecto.ViaLibre;
				}
			}
			return Aspecto.Parada;
		}
    }
}
