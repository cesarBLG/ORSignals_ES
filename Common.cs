using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ORTS.Scripting.Script
{
    // Aspectos
    public enum Aspecto
    {
        Apagada,
        Parada,
        ParadaLZB,
        ParadaSelectiva,
        ParadaSelectivaDestellos,
        ParadaPermisiva,
        RebaseAutorizado,
        RebaseAutorizadoCortaDistancia,
        RebaseAutorizadoDestellos,
        MovimientoAutorizado,
        ParadaDiferida,
        AnuncioParadaInmediata,
        AnuncioParada,
        AnuncioPrecaucion,
        PreanuncioParada,
        ViaLibreCondicional,
        ViaLibre,

        // Indicadora de entrada
        IndicadoraDesviada,
        IndicadoraDirecta,
    }
    enum InfoRuta
    {
        NO_INSTALADO,
        AG_DIR_SENAL_A_PARA,
        AG_DIR_SENAL_A_PREC,
        AG_DIR_SENAL_PREA,
        AG_DES_SENAL_A_PARA,
        AG_DES_SENAL_A_PREC,
        AG_DES_SENAL_PREA,
        NO_PREPARADO
    }
    [Flags]
    public enum SistemaSeñalizacion
    {
        Ninguno=0,
        ETCS_N1=1,
        ETCS_N2=2,
        ASFA=4,
        LZB=8,
    }
    [Flags]
    public enum TipoSeñal
    {
        Ninguno=0,
        Entrada=1,
        Salida=2,
        Interior=4,
        Intermedia=8,
        Avanzada=16,
        Liberacion=32,
        Virtual=64,
        Retroceso=128,
        Topera=256,
        Maniobra=512,
    }
    public enum TipoBloqueo
    {
        BLA,
        BA,
    }
    public abstract class CommonSignalScript : CsSignalScript
    {
        public readonly int KEY_VARIABLE_COMPARTIDA_AGUJA = 100;
        public readonly int KEY_VARIABLE_COMPARTIDA_ASPECTO_EXTENDIDO = 101;
        public readonly int KEY_VARIABLE_COMPARTIDA_DESLIZAMIENTO = 121;
        public readonly int KEY_VARIABLE_COMPARTIDA_SIG_SENAL = 150;
        public readonly int KEY_VARIABLE_COMPARTIDA_SISTEMAS_SEÑALIZACION = 200;
        public readonly int KEY_VARIABLE_COMPARTIDA_TIPO_SEÑAL = 201;
        public readonly int KEY_VARIABLE_COMPARTIDA_TIPO_BLOQUEO = 202;
        public readonly int KEY_VARIABLE_COMPARTIDA_ESTADO_CANTON = 801;
        public readonly int KEY_VARIABLE_COMPARTIDA_INFO_RUTA = 802;
        public readonly int KEY_VARIABLE_COMPARTIDA_REBASE = 803;
        public readonly int KEY_VARIABLE_COMPARTIDA_SIG_INFO_RUTA = 804;
        public readonly int KEY_VARIABLE_COMPARTIDA_SNCA_DIFF = 900;
        public readonly int KEY_VARIABLE_COMPARTIDA_SNCA = 901;
        public readonly int KEY_VARIABLE_COMPARTIDA_PROXIMIDAD = 902;
        public readonly int KEY_VARIABLE_COMPARTIDA_PROXIMIDAD_ERTMS = 903;
        public readonly int KEY_VARIABLE_COMPARTIDA_SUCESION_AUTOMATICA = 904;
        public readonly int KEY_VARIABLE_COMPARTIDA_SNCA_REAL = 905;

        // Compatibilidad MSTS
        protected Dictionary<Aspecto, Aspect> compatibilidadAspectosMSTS = new Dictionary<Aspecto, Aspect>();
        protected Dictionary<Aspecto, string> drawStates = new Dictionary<Aspecto, string>();
        protected Dictionary<string, Aspecto> textoAAspecto = new Dictionary<string, Aspecto>();
        protected Dictionary<Aspecto, string> aspectoATexto = new Dictionary<Aspecto, string>();
        protected Dictionary<Aspecto, int> drawStates_fast = new Dictionary<Aspecto, int>();

        public CommonSignalScript()
        {
            compatibilidadAspectosMSTS[Aspecto.Apagada] = Aspect.Stop;
            compatibilidadAspectosMSTS[Aspecto.Parada] = Aspect.Stop;
            compatibilidadAspectosMSTS[Aspecto.ParadaLZB] = Aspect.StopAndProceed;
            compatibilidadAspectosMSTS[Aspecto.ParadaSelectiva] = Aspect.StopAndProceed;
            compatibilidadAspectosMSTS[Aspecto.ParadaSelectivaDestellos] = Aspect.StopAndProceed;
            compatibilidadAspectosMSTS[Aspecto.ParadaPermisiva] = Aspect.StopAndProceed;
            compatibilidadAspectosMSTS[Aspecto.RebaseAutorizado] = Aspect.StopAndProceed;
            compatibilidadAspectosMSTS[Aspecto.RebaseAutorizadoCortaDistancia] = Aspect.StopAndProceed;
            compatibilidadAspectosMSTS[Aspecto.RebaseAutorizadoDestellos] = Aspect.Restricting;
            compatibilidadAspectosMSTS[Aspecto.ParadaDiferida] = Aspect.Approach_1;
            compatibilidadAspectosMSTS[Aspecto.AnuncioParadaInmediata] = Aspect.Approach_1;
            compatibilidadAspectosMSTS[Aspecto.AnuncioParada] = Aspect.Approach_1;
            compatibilidadAspectosMSTS[Aspecto.AnuncioPrecaucion] = Aspect.Approach_2;
            compatibilidadAspectosMSTS[Aspecto.PreanuncioParada] = Aspect.Approach_3;
            compatibilidadAspectosMSTS[Aspecto.ViaLibreCondicional] = Aspect.Clear_1;
            compatibilidadAspectosMSTS[Aspecto.ViaLibre] = Aspect.Clear_2;
            compatibilidadAspectosMSTS[Aspecto.IndicadoraDesviada] = Aspect.Approach_2;
            compatibilidadAspectosMSTS[Aspecto.IndicadoraDirecta] = Aspect.Clear_2;
            compatibilidadAspectosMSTS[Aspecto.MovimientoAutorizado] = Aspect.Clear_2;

            drawStates[Aspecto.ViaLibre] = "FF1A";
            drawStates[Aspecto.ViaLibreCondicional] = "FF2";
            drawStates[Aspecto.AnuncioPrecaucion] = "FF3A";
            drawStates[Aspecto.PreanuncioParada] = "FF4";
            drawStates[Aspecto.AnuncioParada] = "FF5A";
            drawStates[Aspecto.AnuncioParadaInmediata] = "FF6";
            drawStates[Aspecto.Parada] = "FF7A";
            drawStates[Aspecto.ParadaPermisiva] = "FF7B";
            drawStates[Aspecto.ParadaSelectiva] = "FF7C";
            drawStates[Aspecto.ParadaSelectivaDestellos] = "FF7D";
            drawStates[Aspecto.ParadaLZB] = "FF7I";
            drawStates[Aspecto.RebaseAutorizadoDestellos] = "FF8A";
            drawStates[Aspecto.RebaseAutorizado] = "FF8B";
            drawStates[Aspecto.RebaseAutorizadoCortaDistancia] = "FF8C";
            drawStates[Aspecto.MovimientoAutorizado] = "FF9";
            drawStates[Aspecto.ParadaDiferida] = "FF12";
        }

        public override void Initialize()
        {
            foreach (Aspecto a in Enum.GetValues(typeof(Aspecto)))
            {
                string rcf;
                if (drawStates.TryGetValue(a, out rcf))
                {
                    int state = GetDrawState(rcf.ToLowerInvariant());
                    if (state > 0) drawStates_fast[a] = state;
                    else drawStates_fast[a] = DefaultDrawState(compatibilidadAspectosMSTS[a]);
                }
                else drawStates_fast[a] = -1;

                string name = a.ToString();
                textoAAspecto[name] = a;
                aspectoATexto[a] = name;
            }
        }

        protected Aspecto GetAspectoSenal(int id, string tipo)
        {
            if (id < 0) return Aspecto.Parada;
            var aspectoSiguienteSenalTexto = IdTextSignalAspect(id, tipo);
            if (textoAAspecto.TryGetValue(aspectoSiguienteSenalTexto, out Aspecto aspecto))
            {
                return aspecto;
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
        public virtual void SetSNCA()
        {
            int snca = SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA];
            // Extender SNCA si estamos en la proximidad de otra señal, pero no propagar a señales anteriores
            int proximidad = 1 - SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA_DIFF];
            for (int i = 0; i < snca; i++)
            {
                int id = NextSignalId("NORMAL", i);
                if (id < 0) break;
                if (IdSignalLocalVariable(id, KEY_VARIABLE_COMPARTIDA_PROXIMIDAD) >= proximidad)
                {
                    snca = Math.Max(IdSignalLocalVariable(id, KEY_VARIABLE_COMPARTIDA_SNCA) + i + 1, snca);
                }
                if (IdSignalLocalVariable(id, KEY_VARIABLE_COMPARTIDA_PROXIMIDAD_ERTMS) >= i + 1)
                {
                    snca = Math.Max(IdSignalLocalVariable(id, KEY_VARIABLE_COMPARTIDA_SNCA) + i + 1, snca);
                }
                proximidad += 1 - IdSignalLocalVariable(id, KEY_VARIABLE_COMPARTIDA_SNCA_DIFF);
            }
            SignalNumClearAhead = snca;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SNCA_REAL] = snca;
        }
    }
}
