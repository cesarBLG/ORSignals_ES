using ORTS.Scripting.Api;
using Orts.Simulation.Signalling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
// ASPECTOS QUE PUEDE DAR LA OPREANUNCIO Y SIGNIFICADO

// SIGASP_STOP					NO ESTA INSTALADA
// SIGASP_STOP_AND_PROCEED		SENAL EN PREANUNCIO A VIA DIRECTA
// SIGASP_RESTRICTING			SENAL EN PREANUNCIO A VIA DESV

// SIGASP_APPROACH_1			SENAL EN APARADA A VIA DIRECTA
// SIGASP_APPROACH_2			SENAL EN APREC A VIA DIRECTA
// SIGASP_APPROACH_3			SENAL EN APARA A VIA DESV

// SIGASP_CLEAR_1				NO ESTA PREPARADA O NO COINCIDE NINGUN ASPECTO
// SIGASP_CLEAR_2				SENAL EN APREC A VIA DESV

// VARIABLE DE ESTADO DE AGUJA
// KEY AGUJA 		KEY_AG = 100

// KEYS EN USO

// 100
*/




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
        ViaLibre
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
    public class GENERICO : CsSignalScript
    {

        //Timer y constantes para retraso en actualizar estado de senal
        Timer actualizarAspectoTimer;
        bool estaComenzadoActualizarAspectoTimer;
        readonly int TIEMPO_ACTUALIZAR_ASPECTO = 1;

        // Timer y constantes para reconocimiento de anuncio de precaucion
        Timer anuncioPrecaucionTimer;
        readonly int TIEMPO_RECONOCIMIENTO_ANUNCIO_PRECAUCION = 10;
        readonly string ANUNCIO_PRECAUCION_RECONOCIDO = "ANUNCIO_PRECAUCION_RECONOCIDO";
        readonly string ANUNCIO_PRECAUCION_NO_RECONOCIDO = "ANUNCIO_PRECAUCION_NO_RECONOCIDO";

        // Averias
        bool averiaFocoVerde;
        bool averiaFocoRojo;
        bool averiaFocoBlanco;
        bool averiaFocoAzul;
        bool averiaFocoAmarillo;
        bool averiaPantallaAlfanumerica;
        bool averia = false;

        //Caracteristicas
        int idEstaSenal = -1;
        int idSiguienteSenal = -1;
        int previoIdSiguienteSenal = -1;

        Aspecto aspectoEstaSenal;
        Aspecto previoAspectoEstaSenal;
        Aspecto aspectoSiguienteSenal;
        Aspecto reservaAspectoEstaSenal;

        bool paradaTotal;
        
        InfoRuta informacionDeRuta;

        bool agujaEstaSenalDesviada = false;
        bool agujaSiguienteSenalDesviada = false;
        readonly int KEY_VARIABLE_COMPARTIDA_AGUJA = 100;
        readonly int KEY_VARIABLE_COMPARTIDA_DESLIZAMIENTO = 121;
        readonly int KEY_VARIABLE_COMPARTIDA_SIG_SENAL = 150;
        readonly int KEY_VARIABLE_COMPARTIDA_SISTEMAS_SEÑALIZACION = 200;
        
        Random rand = new Random();

        // Tipologia senal 
        protected bool esPermisiva = false;
        protected bool esIntermedia = false;
        protected bool esPreavanzada = false;
        protected bool esAvanzada = false;
        protected bool esEntrada = false;
        protected bool esSalida = false;
        protected bool esProteccion = false;
        protected bool esLiberacion = false;

        // Funciones 
        protected bool anuncioParadaInmediata = false;

        protected bool esBSL = false;
        protected bool esLZB = false;
        protected bool esBLA = false;
        public SistemaSeñalizacion Sistemas;

        // Estado del canton
        enum EstadoCanton
        {
            Libre,
            Ocupado,
            ObstruidoAguja
        }
        EstadoCanton estadoDelCanton = EstadoCanton.ObstruidoAguja;
        bool pantallaERTMScerrada = false;
        bool deslizamientoSiguienteSenalOcupado = false;

        // Senal activa
        bool estaPreparada = false;
        bool previoEstaPreparada = false;
        bool previoPrevioEstaPreparada = false;

        // Flags
        protected bool rebaseAutorizadoDestellos = false;

        bool anuncioPrecaucionAnteriorReconocido = false;
        bool anuncioPrecaucionAnteriorNoReconocido = false;
        bool anuncioPrecaucionPropioReconocido = false;

        protected bool forzarAnuncioParada = false;
        protected bool forzarViaLibreCondicional = false;
        protected bool forzarViaLibre = false;
        protected bool forzarParada = false;
        protected bool forzarRebase = false;
        protected bool itinerarioERTMS = false;

        protected bool reposoViaLibre = false;
        protected bool reposoAnuncioParada = false;

        protected bool forzarAnuncioPrecaucion = false;
        protected bool forzarPreanuncioParada = false;

        protected bool inhibirPreanuncioParadaAViaLibreSiSigAnuncioParada = false;
        protected bool inhibirPreanuncioParadaAViaLibreSiSigAnuncioPrecaucion = false;

        protected bool inhibirViaLibreAAnuncioPrecaucion = false;
        protected bool inhibirViaLibreAViaLibreCondicional = false;

        protected bool tipoDeSenalizacionDoscientos = false;
        protected bool siguienteSenalEsDeLiberacion = false;
        protected bool siguienteEsRetroceso = false;
        protected bool siguienteEsPantallaERTMS = false;
        protected bool siguienteSenalEsAvanzadaBLA = false; // Para casos concretos donde el aspecto de la avanzada influye en la señal de salida

        protected bool rutaADesviadaObligatoria = false;

        // Elementos fisicos
        protected bool focoVerde = false;
        protected bool focoRojo = false;
        protected bool focoBlanco = false;
        protected bool focoAzul = false;
        protected bool focoAmarillo = false;

        protected bool pantallaAnuncioPrecaucion = false;
        protected bool pantallaPreanuncioParada = false;
        protected bool pajaritaAnuncioPrecaucion = false;

        bool pantallaID = false;
        bool cuernosID = false;

        bool placaP = false;
        
        Aspecto AspectoParada;
        List<Aspecto> aspectosDisponibles = new List<Aspecto>();

        // Informacion de ruta
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

        // Compatibilidad MSTS
        Dictionary<Aspecto, Aspect> compatibilidadAspectosMSTS = new Dictionary<Aspecto, Aspect>();
        Dictionary<Aspecto, string> drawStates = new Dictionary<Aspecto, string>();
        Dictionary<Aspecto, int> drawStates_fast = new Dictionary<Aspecto, int>();
        Dictionary<string, Aspecto> textoAAspecto = new Dictionary<string, Aspecto>();
        Dictionary<Aspecto, string> aspectoATexto = new Dictionary<Aspecto, string>();

        //Implementacion
        public override void Initialize()
        {
            InicializarTimers();
            InicializarCompatibilidadMSTS();

            aspectoEstaSenal = Aspecto.Apagada;
            
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
            
            DeterminarTipologia();
            ActualizarAspectos();
        }

        public override void Update()
        {
            previoAspectoEstaSenal = aspectoEstaSenal;
            if (idSiguienteSenal >= 0) previoIdSiguienteSenal = idSiguienteSenal;
            reservaAspectoEstaSenal = aspectoEstaSenal;
            previoPrevioEstaPreparada = previoEstaPreparada;
            previoEstaPreparada = estaPreparada;

            idSiguienteSenal = GetIdSiguienteSenal();
            aspectoSiguienteSenal = GetAspectoSiguienteSenal();

            agujaEstaSenalDesviada = GetAgujaDeEstaSenalDesviada();
            agujaSiguienteSenalDesviada = GetAgujaDeSiguienteSenalDesviada();
            estadoDelCanton = GetEstadoDelCanton();
            estaPreparada = IsPreparada();

            // Informacion adicional de ruta con oculto de preanuncio
            informacionDeRuta = getInformacionDeRuta();

            // Flags
            if (previoIdSiguienteSenal != idSiguienteSenal || (estaPreparada && (!previoEstaPreparada || !previoPrevioEstaPreparada)))
            {
                ActualizarInformacionFlags();
            }

            deslizamientoSiguienteSenalOcupado = IdSignalLocalVariable(idSiguienteSenal, KEY_VARIABLE_COMPARTIDA_DESLIZAMIENTO) == 1;
            bool deslizamientoOcupado = false;
            if (esSalida || esIntermedia)
            {
                int id = NextSignalId("NORMAL");
                if (id >= 0 && IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS") && estadoDelCanton == EstadoCanton.Ocupado) deslizamientoOcupado = true;
            }
            SharedVariables[KEY_VARIABLE_COMPARTIDA_DESLIZAMIENTO] = deslizamientoOcupado ? 1 : 0;
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SIG_SENAL] = NextSignalId("NORMAL");
            SharedVariables[KEY_VARIABLE_COMPARTIDA_SISTEMAS_SEÑALIZACION] = (int)Sistemas;
            
            SharedVariables[801] = (int)BlockState.Clear;
            SharedVariables[802] = (int)Aspect.Stop;
            
            CalcularAspecto();
            SetSNCA();
            
            ProducirFusion();
            GestionarFusionLamparas();
            GestionarReconocimientoAnuncioPrecaucion();
            if (!PreUpdate()) RetardarCambioDeAspecto();
            // ProducirAveria();
            ActualizarEstado();
        }
        void ItinerarioERTMS()
        {
            if (focoAzul)
            {
                itinerarioERTMS = true;
                for (int i=0; i<20; i++)
                {
                    int id = NextSignalId("NORMAL", i);
                    if (id < 0) break;
                    if (IdSignalHasNormalSubtype(id, "RETROCESO") || IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS")) continue;
                    SendSignalMessage(id, "ITINERARIO_ERTMS");
                    break;
                }
            }
        }

        public override void HandleSignalMessage(int id, string message)
        {
            if (message == ANUNCIO_PRECAUCION_RECONOCIDO)
            {
                anuncioPrecaucionAnteriorReconocido = true;
                anuncioPrecaucionAnteriorNoReconocido = false;
            }
            else if (message == ANUNCIO_PRECAUCION_NO_RECONOCIDO) anuncioPrecaucionAnteriorNoReconocido = true;
            else if (message.StartsWith("FLAG:"))
            {
                consultaFlag = message.Substring(5) == "true";
            }
            else if (message == "ITINERARIO_ERTMS" || message == "ERTMS_ROUTE") ItinerarioERTMS();
            else if (message == "ITINERARIO_ASFA") itinerarioERTMS = false;
            else if (message == "ETCS_N1") Sistemas |= SistemaSeñalizacion.ETCS_N1;
            else if (message == "ETCS_N2") Sistemas |= SistemaSeñalizacion.ETCS_N2;
            else if (message == "ASFA") Sistemas |= SistemaSeñalizacion.ASFA;
        }
        public override void HandleEvent(SignalEvent evt, string message = "") 
        {
            itinerarioERTMS = false;
            switch(evt)
            {
                case SignalEvent.RequestMostRestrictiveAspect:
                    break;
                case SignalEvent.RequestApproachAspect:
                    ItinerarioERTMS();
                    break;
                case SignalEvent.RequestLeastRestrictiveAspect:
                    break;
            }
        }




























        // Funciones propias


        void InicializarTimers()
        {
            anuncioPrecaucionTimer = new Timer(this);
            anuncioPrecaucionTimer.Setup(TIEMPO_RECONOCIMIENTO_ANUNCIO_PRECAUCION);

            actualizarAspectoTimer = new Timer(this);
            actualizarAspectoTimer.Setup(TIEMPO_ACTUALIZAR_ASPECTO);
            estaComenzadoActualizarAspectoTimer = false;
        }


        void InicializarCompatibilidadMSTS()
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
            compatibilidadAspectosMSTS[Aspecto.MovimientoAutorizado] = Aspect.Restricting;
            compatibilidadAspectosMSTS[Aspecto.ParadaDiferida] = Aspect.Approach_1;
            compatibilidadAspectosMSTS[Aspecto.AnuncioParadaInmediata] = Aspect.Approach_1;
            compatibilidadAspectosMSTS[Aspecto.AnuncioParada] = Aspect.Approach_1;
            compatibilidadAspectosMSTS[Aspecto.AnuncioPrecaucion] = Aspect.Approach_2;
            compatibilidadAspectosMSTS[Aspecto.PreanuncioParada] = Aspect.Approach_3;
            compatibilidadAspectosMSTS[Aspecto.ViaLibreCondicional] = Aspect.Clear_1;
            compatibilidadAspectosMSTS[Aspecto.ViaLibre] = Aspect.Clear_2;

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

        void ProducirAveria()
        {
            if (estaPreparada ^ previoEstaPreparada)
            {
                Console.WriteLine(SignalId + " cambio de estado de preparacion");
                var rn = 1;
                Console.WriteLine(SignalId + " random " + rn);
                if (rn == 1)
                {

                    MstsSignalAspect = compatibilidadAspectosMSTS[Aspecto.Parada];
                    TextSignalAspect = aspectoATexto[Aspecto.Parada];
                    DrawState = -1;
                    averia = true;
                }
                else
                {
                    averia = false;
                    ActualizarEstado();
                }
            }
            else
            {
                ActualizarEstado();
            }
            if (averia)
            {
                MstsSignalAspect = compatibilidadAspectosMSTS[Aspecto.Parada];
                TextSignalAspect = aspectoATexto[Aspecto.Parada];
                DrawState = -1;
            }
        }
        
        void ProducirFusion()
        {
            /*if (rand.Next(1000000)==1) averiaFocoAmarillo = !averiaFocoAmarillo;
            if (rand.Next(1000000)==1) averiaFocoAzul = !averiaFocoAzul;
            if (rand.Next(1000000)==1) averiaFocoBlanco = !averiaFocoBlanco;
            if (rand.Next(1000000)==1) averiaFocoRojo = !averiaFocoRojo;
            if (rand.Next(1000000)==1) averiaFocoVerde = !averiaFocoVerde;
            if (rand.Next(1000000)==1) averiaPantallaAlfanumerica = !averiaPantallaAlfanumerica;*/
        }
        
        void GestionarFusionLamparas()
        {
            while (!aspectosDisponibles.Contains(aspectoEstaSenal) && aspectoEstaSenal != Aspecto.Apagada)
            {
                if (aspectoEstaSenal == Aspecto.ViaLibre) aspectoEstaSenal = Aspecto.ViaLibreCondicional;
                else if (aspectoEstaSenal == Aspecto.ViaLibreCondicional)
                {
                    if (informacionDeRuta != InfoRuta.NO_INSTALADO) aspectoEstaSenal = Aspecto.PreanuncioParada;
                    else aspectoEstaSenal = Aspecto.AnuncioParada;
                }
                else if (aspectoEstaSenal == Aspecto.PreanuncioParada || aspectoEstaSenal == Aspecto.AnuncioPrecaucion) aspectoEstaSenal = Aspecto.AnuncioParada;
                else if (aspectoEstaSenal == Aspecto.AnuncioParada) aspectoEstaSenal = Aspecto.ParadaSelectivaDestellos;
                else if (aspectoEstaSenal == Aspecto.ParadaSelectivaDestellos) aspectoEstaSenal = Aspecto.ParadaSelectiva;
                else if (aspectoEstaSenal == Aspecto.ParadaSelectiva) aspectoEstaSenal = AspectoParada;
                else aspectoEstaSenal = Aspecto.Apagada;
            }
            var aspectoSinFusion = aspectoEstaSenal;
            if ((aspectoEstaSenal == Aspecto.ViaLibre || aspectoEstaSenal == Aspecto.ViaLibreCondicional) && averiaFocoVerde) aspectoEstaSenal = Aspecto.PreanuncioParada;
            if ((aspectoEstaSenal == Aspecto.AnuncioPrecaucion) && averiaFocoVerde) aspectoEstaSenal = Aspecto.AnuncioParada;
            if ((aspectoEstaSenal == Aspecto.AnuncioPrecaucion) && averiaFocoAmarillo) aspectoEstaSenal = Aspecto.ParadaSelectivaDestellos;
            if (aspectoEstaSenal == Aspecto.PreanuncioParada && averiaPantallaAlfanumerica) aspectoEstaSenal = Aspecto.AnuncioParada;
            if ((aspectoEstaSenal == Aspecto.PreanuncioParada || aspectoEstaSenal == Aspecto.AnuncioParada) && averiaFocoAmarillo) aspectoEstaSenal = Aspecto.ParadaSelectiva;
            if ((aspectoEstaSenal == Aspecto.ParadaSelectiva || aspectoEstaSenal == Aspecto.ParadaSelectivaDestellos) && averiaFocoAzul) aspectoEstaSenal = AspectoParada;
            if ((aspectoEstaSenal == Aspecto.ParadaSelectiva || aspectoEstaSenal == Aspecto.ParadaSelectivaDestellos || aspectoEstaSenal == AspectoParada) && averiaFocoRojo) aspectoEstaSenal = Aspecto.Apagada;
            if ((aspectoEstaSenal == Aspecto.RebaseAutorizado || aspectoEstaSenal == Aspecto.RebaseAutorizadoCortaDistancia || aspectoEstaSenal == Aspecto.RebaseAutorizadoDestellos) && averiaFocoBlanco) aspectoEstaSenal = AspectoParada;
            if ((aspectoEstaSenal == Aspecto.RebaseAutorizado || aspectoEstaSenal == Aspecto.RebaseAutorizadoCortaDistancia || aspectoEstaSenal == Aspecto.RebaseAutorizadoDestellos) && averiaFocoRojo) aspectoEstaSenal = Aspecto.Apagada;
            
            if (aspectoSinFusion != aspectoEstaSenal) GestionarFusionLamparas();
        }

        void RetardarCambioDeAspecto()
        {
            reservaAspectoEstaSenal = aspectoEstaSenal;

            if (estaPreparada || (previoAspectoEstaSenal != AspectoParada && aspectoEstaSenal == AspectoParada))
            {
                if (previoAspectoEstaSenal != aspectoEstaSenal && !estaComenzadoActualizarAspectoTimer)
                {
                    // Console.WriteLine(SignalId + ", nuevo aspecto: " + aspectoEstaSenal.ToString());
                    actualizarAspectoTimer.Start();
                    estaComenzadoActualizarAspectoTimer = true;
                    // Console.WriteLine(SignalId + " comenzado timer");
                }

                if (estaComenzadoActualizarAspectoTimer)
                {
                    aspectoEstaSenal = previoAspectoEstaSenal;
                }

                if (actualizarAspectoTimer.Triggered && estaComenzadoActualizarAspectoTimer)
                {
                    estaComenzadoActualizarAspectoTimer = false;
                    aspectoEstaSenal = reservaAspectoEstaSenal;
                    // Console.WriteLine(SignalId + " terminado timer");
                }
            }
        }








        bool GetAgujaDeEstaSenalDesviada()
        {
            if (FlagPresente("M_V_DESV") || !RouteSet)
            {
                SharedVariables[KEY_VARIABLE_COMPARTIDA_AGUJA] = 1;
                return true;
            }
            else
            {
                SharedVariables[KEY_VARIABLE_COMPARTIDA_AGUJA] = 0;
                return false;
            }
        }

        bool GetAgujaDeSiguienteSenalDesviada()
        {
            return IdSignalLocalVariable(idSiguienteSenal, KEY_VARIABLE_COMPARTIDA_AGUJA) == 1;
        }

        void EnviarMensaje(int idSenal, string mensaje)
        {
            if (idSenal >= 0) SendSignalMessage(idSenal, mensaje);
        }

        void ActualizarEstado()
        {
            MstsSignalAspect = compatibilidadAspectosMSTS[aspectoEstaSenal];
            TextSignalAspect = aspectoATexto[aspectoEstaSenal];
            DrawState = drawStates_fast[aspectoEstaSenal];
            if (aspectoEstaSenal == Aspecto.Parada && !paradaTotal) MstsSignalAspect = Aspect.StopAndProceed; // Truco para permitir que el itinerario se establezca mas alla de la señal
            if (aspectoEstaSenal == Aspecto.ParadaSelectiva || aspectoEstaSenal == Aspecto.ParadaSelectivaDestellos || aspectoEstaSenal == Aspecto.ParadaLZB)
            {
                if (!SpeedLimitSetByScript)
                {
                    SetSpeedLimit(float.MaxValue, float.MaxValue, false, false, true, false);
                    SpeedLimitSetByScript = true;
                }
            }
            else
            {
                SpeedLimitSetByScript = false;
            }
        }

        void CalcularAspecto()
        {
            paradaTotal = false;
            bool avanzadaSinParada = ((esAvanzada || esPreavanzada) && (esBLA || esBSL)) || !aspectosDisponibles.Contains(AspectoParada);
            if ((HoldState == HoldState.StationStop || HoldState == HoldState.ManualLock || estadoDelCanton == EstadoCanton.ObstruidoAguja) 
                && !avanzadaSinParada)
            {
                aspectoEstaSenal = AspectoParada;
                paradaTotal = true;
            }
            else if (!estaPreparada && !reposoAnuncioParada && !reposoViaLibre && !avanzadaSinParada)
            {
                aspectoEstaSenal = AspectoParada;
                paradaTotal = !esIntermedia; // Permite que se establezca el bloqueo pasando a estar preparadas
            }
            else if (siguienteEsRetroceso && (IdSignalAspect(NextSignalId("NORMAL"), "NORMAL") == Aspect.Stop || IdTextSignalAspect(NextSignalId("NORMAL"), "NORMAL") == "Parada"))
            {
                aspectoEstaSenal = AspectoParada;
            }
            else if (aspectosDisponibles.Contains(Aspecto.RebaseAutorizado) && TrainHasCallOn(false, true))
            {
                if (rebaseAutorizadoDestellos)
                {
                    aspectoEstaSenal = Aspecto.RebaseAutorizadoDestellos;
                }
                else
                {
                    aspectoEstaSenal = Aspecto.RebaseAutorizado;
                }
            }
            else if (siguienteEsRetroceso && IdTextSignalAspect(NextSignalId("NORMAL"), "NORMAL") == "RebaseAutorizado")
            {
                aspectoEstaSenal = Aspecto.RebaseAutorizado;
            }
            else if (estadoDelCanton == EstadoCanton.Ocupado && !avanzadaSinParada)
            {
                aspectoEstaSenal = AspectoParada;
                paradaTotal = true;
            }
            else if (forzarRebase)
            {
                aspectoEstaSenal = Aspecto.RebaseAutorizado;
            }
            else if (forzarParada)
            {
                aspectoEstaSenal = AspectoParada;
            }
            else if (!avanzadaSinParada && (estaPreparada || !reposoAnuncioParada) && pantallaERTMScerrada)
            {
                aspectoEstaSenal = esLZB ? Aspecto.ParadaLZB : Aspecto.ParadaSelectiva;
            }
            else if (!avanzadaSinParada && (itinerarioERTMS || (deslizamientoSiguienteSenalOcupado && aspectoSiguienteSenal == Aspecto.Parada)))
            {
                aspectoEstaSenal = Aspecto.ParadaSelectivaDestellos;
            }
            else if (aspectoSiguienteSenal == Aspecto.Apagada)
            {
                if (esPreavanzada) aspectoEstaSenal = Aspecto.ViaLibreCondicional;
                else aspectoEstaSenal = anuncioParadaInmediata ? Aspecto.AnuncioParadaInmediata : Aspecto.AnuncioParada;
            }
            else if (aspectoSiguienteSenal == Aspecto.Parada ||
                aspectoSiguienteSenal == Aspecto.ParadaPermisiva || aspectoSiguienteSenal == Aspecto.RebaseAutorizado ||
                aspectoSiguienteSenal == Aspecto.RebaseAutorizadoDestellos || aspectoSiguienteSenal == Aspecto.ParadaSelectiva || 
                aspectoSiguienteSenal == Aspecto.ParadaSelectivaDestellos || aspectoSiguienteSenal == Aspecto.ParadaLZB || aspectoSiguienteSenal == Aspecto.AnuncioParadaInmediata || idSiguienteSenal < 0 || HoldState == HoldState.ManualApproach)
            {
                aspectoEstaSenal = anuncioParadaInmediata ? Aspecto.AnuncioParadaInmediata : Aspecto.AnuncioParada;
            }
            else if (aspectoSiguienteSenal == Aspecto.AnuncioParada && forzarAnuncioParada)
            {
                aspectoEstaSenal = Aspecto.AnuncioParada;
            }
            else
            {
                if (agujaEstaSenalDesviada)
                {
                    CalcularAspectoConAgujaADesviada();
                }
                else
                {
                    CalcularAspectoConAgujaADirecta();
                }
            }
            GestionarSenalDeLiberacionPosterior();
        }

        void CalcularAspectoConAgujaADesviada()
        {
            if (rutaADesviadaObligatoria && ApproachControlSpeed(500, 1))
            {
                CalcularAspectoConAgujaADirecta();
            }
            else if (rutaADesviadaObligatoria && (anuncioPrecaucionAnteriorReconocido /* || agujaAnteriorSenalDesviada*/ || siguienteSenalEsAvanzadaBLA) && !anuncioPrecaucionAnteriorNoReconocido)
            {
                CalcularAspectoConAgujaADirecta();
            }
            /*else if () TODO: Itinerario de via general a via de apartado y vuelta a via general
            {
                aspectoEstaSenal = Aspecto.AnuncioParada;
            }*/
            else if (aspectoSiguienteSenal == Aspecto.AnuncioParada && forzarAnuncioPrecaucion && anuncioPrecaucionAnteriorReconocido)
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else if (agujaSiguienteSenalDesviada && ApproachControlSpeed(500, 1)) // 
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else if (agujaSiguienteSenalDesviada && anuncioPrecaucionAnteriorReconocido)
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else if (aspectoSiguienteSenal == Aspecto.AnuncioParada && informacionDeRuta == InfoRuta.AG_DIR_SENAL_A_PARA && !inhibirPreanuncioParadaAViaLibreSiSigAnuncioParada && anuncioPrecaucionAnteriorReconocido)
            {
                aspectoEstaSenal = Aspecto.PreanuncioParada;
            }
            else if (aspectoSiguienteSenal == Aspecto.AnuncioPrecaucion && informacionDeRuta == InfoRuta.AG_DIR_SENAL_A_PREC && !inhibirPreanuncioParadaAViaLibreSiSigAnuncioPrecaucion && anuncioPrecaucionAnteriorReconocido)
            {
                aspectoEstaSenal = Aspecto.PreanuncioParada;
            }
            else if (aspectoSiguienteSenal == Aspecto.PreanuncioParada && informacionDeRuta == InfoRuta.AG_DIR_SENAL_PREA && forzarPreanuncioParada && anuncioPrecaucionAnteriorReconocido)
            {
                aspectoEstaSenal = Aspecto.PreanuncioParada;
            }
            else if (inhibirViaLibreAAnuncioPrecaucion && anuncioPrecaucionAnteriorReconocido)
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else
            {
                aspectoEstaSenal = Aspecto.AnuncioParada;
            }
        }

        void CalcularAspectoConAgujaADirecta()
        {
            if (agujaSiguienteSenalDesviada)
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else if (aspectoSiguienteSenal == Aspecto.AnuncioParada && forzarAnuncioPrecaucion)
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else if (aspectoSiguienteSenal == Aspecto.AnuncioParada && informacionDeRuta == InfoRuta.AG_DIR_SENAL_A_PARA && !inhibirPreanuncioParadaAViaLibreSiSigAnuncioParada)
            {
                aspectoEstaSenal = Aspecto.PreanuncioParada;
            }
            else if (aspectoSiguienteSenal == Aspecto.AnuncioPrecaucion && informacionDeRuta == InfoRuta.AG_DIR_SENAL_A_PREC && !inhibirPreanuncioParadaAViaLibreSiSigAnuncioPrecaucion)
            {
                aspectoEstaSenal = Aspecto.PreanuncioParada;
            }
            else if (aspectoSiguienteSenal == Aspecto.PreanuncioParada && informacionDeRuta == InfoRuta.AG_DIR_SENAL_PREA && forzarPreanuncioParada)
            {
                aspectoEstaSenal = Aspecto.PreanuncioParada;
            }
            else if (inhibirViaLibreAAnuncioPrecaucion)
            {
                aspectoEstaSenal = Aspecto.AnuncioPrecaucion;
            }
            else if (inhibirViaLibreAViaLibreCondicional)
            {
                aspectoEstaSenal = Aspecto.ViaLibreCondicional;
            }
            else if (aspectoSiguienteSenal == Aspecto.ViaLibreCondicional && forzarViaLibreCondicional)
            {
                aspectoEstaSenal = Aspecto.ViaLibreCondicional;
            }
            else if (tipoDeSenalizacionDoscientos && (aspectoSiguienteSenal == Aspecto.AnuncioParada || aspectoSiguienteSenal == Aspecto.AnuncioPrecaucion || aspectoSiguienteSenal == Aspecto.PreanuncioParada))
            {
                aspectoEstaSenal = Aspecto.ViaLibreCondicional;
            }
            else
            {
                aspectoEstaSenal = Aspecto.ViaLibre;
            }
        }

        void GestionarReconocimientoAnuncioPrecaucion()
        {
            if (aspectoEstaSenal < previoAspectoEstaSenal) // El reconocimiento se pierde si la señal siguiente cambia a un aspecto más restrictivo
            {
                anuncioPrecaucionAnteriorReconocido = false;
            }
            if (previoEstaPreparada != estaPreparada/* || (aspectoEstaSenal != previoAspectoEstaSenal && aspectoEstaSenal == AspectoParada)*/) 
            {
                anuncioPrecaucionAnteriorNoReconocido = false; // Reset cuando la señal queda en reposo
            }
            if (!anuncioPrecaucionPropioReconocido && (aspectoEstaSenal == Aspecto.AnuncioPrecaucion || previoAspectoEstaSenal == Aspecto.AnuncioPrecaucion) && estadoDelCanton != EstadoCanton.Libre) 
            {
                // Si se ocupa el CV de la señal sin reconocer el aprec, notificar a la siguiente señal
                // Necesario si la señal siguiente no puede indicar anuncio de parada y abre directamente en vía libre
                EnviarMensaje(idSiguienteSenal >= 0 ? idSiguienteSenal : previoIdSiguienteSenal, ANUNCIO_PRECAUCION_NO_RECONOCIDO);
            }
            if (aspectoEstaSenal == Aspecto.AnuncioPrecaucion)
            {
                if (previoAspectoEstaSenal != aspectoEstaSenal) // Empezamos a contar el tiempo desde que la señal cambia a anuncio de precaucion
                { 
                    if (esAvanzada && (esBLA || esBSL))
                    {
                        anuncioPrecaucionTimer.Stop();
                        if (estadoDelCanton == EstadoCanton.Libre)
                        {
                            // Anuncio de precaucion reconocido
                            anuncioPrecaucionPropioReconocido = true;
                            EnviarMensaje(idSiguienteSenal, ANUNCIO_PRECAUCION_RECONOCIDO);
                        }
                        else
                        {
                            anuncioPrecaucionPropioReconocido = false;
                            EnviarMensaje(idSiguienteSenal, ANUNCIO_PRECAUCION_NO_RECONOCIDO);
                        }
                    }
                    else anuncioPrecaucionTimer.Start(); 
                }
                if (anuncioPrecaucionTimer.Triggered && !anuncioPrecaucionPropioReconocido)
                {
                    // Anuncio de precaucion reconocido
                    anuncioPrecaucionPropioReconocido = true;
                    EnviarMensaje(idSiguienteSenal, ANUNCIO_PRECAUCION_RECONOCIDO);
                }
            }
            else
            {
                anuncioPrecaucionPropioReconocido = false; // Reset si no muestra anuncio de precaucion
            }
        }

        void GestionarSenalDeLiberacionPosterior()
        {
            if (siguienteSenalEsDeLiberacion)
            {
                if (aspectoSiguienteSenal == Aspecto.Parada || aspectoSiguienteSenal == Aspecto.ParadaPermisiva || aspectoSiguienteSenal == Aspecto.RebaseAutorizado || aspectoSiguienteSenal == Aspecto.RebaseAutorizadoDestellos)
                {
                    aspectoEstaSenal = AspectoParada;
                }
                if ((aspectoSiguienteSenal == Aspecto.ParadaSelectiva || aspectoSiguienteSenal == Aspecto.ParadaSelectivaDestellos) &&
                    aspectoEstaSenal != AspectoParada)
                {
                    aspectoEstaSenal = aspectoSiguienteSenal;
                }
            }
        }

        EstadoCanton GetEstadoDelCanton()
        {
            var estadoDelCantonMSTS = (BlockState)Math.Max((int)CurrentBlockState, IdSignalLocalVariable(NextSignalId("NORMAL"), 801));
            pantallaERTMScerrada = false;
            for (int i=0; !pantallaERTMScerrada; i++)
            {
                int id = NextSignalId("NORMAL", i);
                if (id < 0) break;
                if (IdSignalHasNormalSubtype(id, "RETROCESO")) continue;
                else if (IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS"))
                {
                    if (IdSignalAspect(id, "NORMAL") == Aspect.Stop) pantallaERTMScerrada = true;
                }
                else break;
            }
            if (estadoDelCantonMSTS == BlockState.Occupied)
            {
                return EstadoCanton.Ocupado;
            }
            else if (estadoDelCantonMSTS == BlockState.Obstructed)
            {
                return EstadoCanton.ObstruidoAguja;
            }
            else
            {
                return EstadoCanton.Libre;
            }
        }
        InfoRuta getInformacionDeRuta()
        {
            var informacionDeRutaMSTS = DistMultiSigMR("OPREANUNCIO", "NORMAL", false);
            if (informacionDeRutaMSTS == Aspect.Stop) informacionDeRutaMSTS = (Aspect)IdSignalLocalVariable(NextSignalId("NORMAL"), 802);
            switch (informacionDeRutaMSTS)
            {
                case Aspect.Stop:
                    return InfoRuta.NO_INSTALADO;

                case Aspect.StopAndProceed:
                    return InfoRuta.AG_DIR_SENAL_PREA;

                case Aspect.Restricting:
                    return InfoRuta.AG_DES_SENAL_PREA;

                case Aspect.Approach_1:
                    return InfoRuta.AG_DIR_SENAL_A_PARA;

                case Aspect.Approach_2:
                    return InfoRuta.AG_DIR_SENAL_A_PREC;

                case Aspect.Approach_3:
                    return InfoRuta.AG_DES_SENAL_A_PARA;

                case Aspect.Clear_1:
                    return InfoRuta.NO_PREPARADO;

                case Aspect.Clear_2:
                    return InfoRuta.AG_DES_SENAL_A_PREC;
            }
            return InfoRuta.NO_INSTALADO;
        }

        bool IsPreparada()
        {
            return Enabled;
        }

        int GetIdSiguienteSenal()
        {
            if (siguienteSenalEsAvanzadaBLA) return NextSignalId("DISTANCE");
            for (int i=0; i<20; i++)
            {
                int id = NextSignalId("NORMAL", i);
                if (id < 0) break;
                if (!IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS") && !IdSignalHasNormalSubtype(id, "RETROCESO")) return id;
            }
            return -1;
        }

        Aspecto GetAspectoSiguienteSenal()
        {
            int id = idSiguienteSenal;
            if (id < 0) return Aspecto.Parada;
            string tipo = siguienteSenalEsAvanzadaBLA ? "DISTANCE" : "NORMAL";
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
        bool consultaFlag;
        bool FlagPresente(string tipo)
        {
            consultaFlag = false;
            if (siguienteEsRetroceso) EnviarMensaje(NextSignalId("NORMAL"), "FLAG:"+tipo);
            return DistMultiSigMR(tipo, siguienteSenalEsAvanzadaBLA ? "DISTANCE" : "NORMAL", false) == Aspect.Clear_2 || consultaFlag;
        }
        void ActualizarInformacionFlags()
        {
            
            DeterminarTipologia(); // Evitamos tener que modificar señales ya existentes
            
            siguienteEsRetroceso = NextSignalId("NORMAL") > 0 && IdSignalHasNormalSubtype(NextSignalId("NORMAL"),"RETROCESO");
            siguienteEsPantallaERTMS = NextSignalId("NORMAL") > 0 && IdSignalHasNormalSubtype(NextSignalId("NORMAL"),"PANTALLA_ERTMS");

            siguienteSenalEsAvanzadaBLA = DistMultiSigMR("DISTANCE", "NORMAL", false) != Aspect.Stop;
            siguienteSenalEsAvanzadaBLA |= FlagPresente("F_VL");
            siguienteSenalEsAvanzadaBLA |= (esSalida || esIntermedia) && (esBLA || esBSL);
            /*siguienteSenalEsAvanzadaBLA = false;
            if (DistMultiSigMR("DISTANCE", "NORMAL", false) != Aspect.Stop) siguienteSenalEsAvanzadaBLA = true;
            else
            {
                int av = NextSignalId("DISTANCE");
                int nxt = av >= 0 ? IdSignalLocalVariable(av, KEY_VARIABLE_COMPARTIDA_SIG_SENAL) : -1;
                for (int i=0; i<20 && !siguienteSenalEsAvanzadaBLA && nxt >= 0; i++)
                {
                    int id = NextSignalId("NORMAL", i);
                    if (id < 0) break;
                    if (id == nxt) siguienteSenalEsAvanzadaBLA = true;
                    if (!IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS") && !IdSignalHasNormalSubtype(id, "RETROCESO")) break;
                }
            }*/
            
            inhibirPreanuncioParadaAViaLibreSiSigAnuncioPrecaucion = FlagPresente("I_PREA_SIG_APREC_A_VL");
            inhibirPreanuncioParadaAViaLibreSiSigAnuncioParada = FlagPresente("I_PREA_SIG_APARA_A_VL");

            forzarPreanuncioParada = FlagPresente("F_PREA_SIG_PREA");
            forzarViaLibreCondicional = FlagPresente("F_VLC_SIG_VLC");
            forzarAnuncioParada = FlagPresente("F_APARA_SIG_APARA");
            forzarAnuncioPrecaucion = FlagPresente("F_APREC_SIG_APARA");
            forzarParada = FlagPresente("F_PARADA");
            forzarRebase = FlagPresente("F_REBASE");

            tipoDeSenalizacionDoscientos |= FlagPresente("B_DOSCIENTOS");
            rebaseAutorizadoDestellos = FlagPresente("R_DESTELLOS");

            inhibirViaLibreAAnuncioPrecaucion = FlagPresente("I_VL_A_APREC");
            inhibirViaLibreAViaLibreCondicional = FlagPresente("I_VL_A_VLC");
            
            //anuncioParadaInmediata = FlagPresente("APARADA_INMEDIATA");

            siguienteSenalEsDeLiberacion = FlagPresente("OLIBERACION");
            siguienteSenalEsAvanzadaBLA &= !siguienteSenalEsDeLiberacion;
            
            ActualizarAspectos();
        }
        void ActualizarAspectos()
        {
            aspectosDisponibles.Clear();
            if (focoVerde) aspectosDisponibles.Add(Aspecto.ViaLibre);
            if (focoVerde && (tipoDeSenalizacionDoscientos || inhibirViaLibreAViaLibreCondicional)) aspectosDisponibles.Add(Aspecto.ViaLibreCondicional);
            if (focoAmarillo && focoVerde) aspectosDisponibles.Add(Aspecto.AnuncioPrecaucion);
            if (focoAmarillo && !siguienteSenalEsAvanzadaBLA) aspectosDisponibles.Add(Aspecto.AnuncioParada);
            if (focoAmarillo) aspectosDisponibles.Add(Aspecto.PreanuncioParada);
            if (focoAzul && focoRojo) aspectosDisponibles.Add(Aspecto.ParadaSelectiva);
            if (focoAzul && focoRojo) aspectosDisponibles.Add(Aspecto.ParadaSelectivaDestellos);
            if (focoRojo && focoBlanco) aspectosDisponibles.Add(Aspecto.RebaseAutorizado);
            if (focoRojo && focoBlanco) aspectosDisponibles.Add(Aspecto.RebaseAutorizadoDestellos);
            if (focoRojo) aspectosDisponibles.Add(AspectoParada);
            if (focoBlanco) aspectosDisponibles.Add(Aspecto.ParadaLZB);
        }
        int SNCA_orig = -1;
        int SNCAcount = 0;
        public void SetSNCA()
        {
            if (SNCAcount++ < 10) return;
            SNCAcount = 0;
            if (SNCA_orig == -1)
            {
                SNCA_orig = SignalNumClearAhead;
                if (SNCA_orig < 0) SNCA_orig = 2;
            }
            int nsig = 0;
            for (int i=0; i<20; i++)
            {
                int id = NextSignalId("NORMAL", i);
                if (id < 0 || i == 19)
                {
                    SignalNumClearAhead = Math.Max(i+2, SNCA_orig);
                    return;
                }
                if (!IdSignalHasNormalSubtype(id, "PANTALLA_ERTMS") && !IdSignalHasNormalSubtype(id, "RETROCESO"))
                {
                    nsig++;
                    if (nsig >= SNCA_orig)
                    {
                        SignalNumClearAhead = i+1;
                        break;
                    }
                }
            }
        }


        protected virtual void DeterminarTipologia()
        {

            var nombreDeSenal = SignalTypeName;
            
            // Configuracion dinamica para señales polivalentes
            reposoAnuncioParada = HasHead(1);
            reposoViaLibre = HasHead(2);
            tipoDeSenalizacionDoscientos = HasHead(3);
            esPermisiva = HasHead(5);
            esIntermedia = HasHead(6);
            esPreavanzada = HasHead(7);
            esAvanzada = HasHead(8);
            esEntrada = HasHead(9);
            esSalida = HasHead(10);
            esProteccion = HasHead(11);
            esLiberacion = HasHead(12);
            esBSL = HasHead(13);
            esLZB = HasHead(14);
            esBLA = HasHead(15);

            if (nombreDeSenal.StartsWith("lav")) esBSL = true;
            if (nombreDeSenal.Equals("lav2av")) esBSL = esAvanzada = reposoAnuncioParada = true;
            
            if (nombreDeSenal.Equals("sp3ptunizq"))	esPermisiva = esIntermedia = true;
            if (nombreDeSenal.Equals("sp3ptunder"))	esPermisiva = esIntermedia = true;
            if (nombreDeSenal.Equals("sp2vrp"))		esPermisiva = esIntermedia = true;
            if (nombreDeSenal.Equals("sp3p"))		esPermisiva = esIntermedia = true;
            if (nombreDeSenal.Equals("sp3pr"))		esPermisiva = esIntermedia = true;
            if (nombreDeSenal.Equals("sp3p200"))		esPermisiva = esIntermedia = tipoDeSenalizacionDoscientos = true;

            if (nombreDeSenal.Equals("ep_3_ap_pap_p_ba"))			esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("ep_3_ap_bif_p_ba"))			esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("sp3aptunder"))					esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("sp3aptunizq"))					esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("ep_3_ap_bif_p_ba_tun_izq"))	esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("sp3aptundernar"))				esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("sp3ap"))						esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("sp3apr"))						esPermisiva = esAvanzada = true;
            if (nombreDeSenal.Equals("sp3ap200"))					esPermisiva = esAvanzada = tipoDeSenalizacionDoscientos = true;

            if (nombreDeSenal.Equals("sp5ebab"))			esEntrada = true;
            if (nombreDeSenal.Equals("sp4ebab"))			esEntrada = true;
            if (nombreDeSenal.Equals("sp4ebabap"))		esEntrada = true;
            if (nombreDeSenal.Equals("sp4ebabapap"))		esEntrada = true;
            if (nombreDeSenal.Equals("sp4ebabapvl"))		esEntrada = true;
            if (nombreDeSenal.Equals("sp4ebad"))			esEntrada = true;
            if (nombreDeSenal.Equals("sp4ebad200"))		esEntrada = tipoDeSenalizacionDoscientos = true;
            if (nombreDeSenal.Equals("sp4ebabap200"))	esEntrada = tipoDeSenalizacionDoscientos= true;

            if (nombreDeSenal.Equals("sp4sbad"))			esSalida = true;
            if (nombreDeSenal.Equals("sp4msbad"))		esSalida = true;
            if (nombreDeSenal.Equals("sp4msbad_izq"))	esSalida = true;
            if (nombreDeSenal.Equals("sp4sbabsp"))		esSalida = true;
            if (nombreDeSenal.Equals("sp4sbab"))			esSalida = true;
            if (nombreDeSenal.Equals("sp4msbab"))		esSalida = true;
            if (nombreDeSenal.Equals("sp4msbab_izq"))	esSalida = true;
            if (nombreDeSenal.Equals("sp4sbabl"))		esSalida = true;
            if (nombreDeSenal.Equals("sp4sbad200"))			esSalida = tipoDeSenalizacionDoscientos = true;
            if (nombreDeSenal.Equals("sp4sbad200mb"))		esSalida = tipoDeSenalizacionDoscientos = true;
            if (nombreDeSenal.Equals("sp4sbad200mb_izq"))	esSalida = tipoDeSenalizacionDoscientos = true;
            if (nombreDeSenal.Equals("sp4sbab200"))			esSalida = tipoDeSenalizacionDoscientos = true;
            if (nombreDeSenal.Equals("sp4sbab200mb"))		esSalida = tipoDeSenalizacionDoscientos = true;
            if (nombreDeSenal.Equals("sp4sbab200mb_izq"))	esSalida = tipoDeSenalizacionDoscientos = true;

            if (nombreDeSenal.Equals("sp3apd"))			esAvanzada		= esBLA = true;
            if (nombreDeSenal.Equals("sp1v"))			esPreavanzada	= esBLA = reposoAnuncioParada = true;
            if (nombreDeSenal.Equals("sp2av"))			esAvanzada		= esBLA = reposoAnuncioParada = true;
            if (nombreDeSenal.Equals("sp3sbem"))		esSalida       	= esBLA = true;
            if (nombreDeSenal.Equals("sp3sbeml"))		esSalida		= esBLA = true;
            if (nombreDeSenal.Equals("sp3sbemsp"))	    esSalida		= esBLA = true;
            if (nombreDeSenal.Equals("sp3msbeml"))		esSalida		= esBLA = true;
            if (nombreDeSenal.Equals("sp3msbeml_izq"))	esSalida		= esBLA = true;
            if (nombreDeSenal.Equals("sp3msbem"))		esSalida		= esBLA = true;
            if (nombreDeSenal.Equals("sp3msbem_izq"))	esSalida		= esBLA = true;
            
            /*if (nombreDeSenal.Equals("sp2vr"))
            if (nombreDeSenal.Equals("sp3tundersinp"))
            if (nombreDeSenal.Equals("sp3tunizqsinp"))
            if (nombreDeSenal.Equals("sp3"))
            if (nombreDeSenal.Equals("sp3200")) tipoDeSenalizacionDoscientos = true;*/
            
            AspectoParada = esPermisiva ? Aspecto.ParadaPermisiva : Aspecto.Parada;
            
            if (nombreDeSenal.StartsWith("led"))
            {
                int nfocos = int.Parse(nombreDeSenal.Substring(3,1));
                for (int i = 0; i < nfocos; i++)
                {
                    if (i + 4 >= nombreDeSenal.Length) break;
                    switch (nombreDeSenal[i+4])
                    {
                        case 'v':
                            focoVerde = true;
                            break;
                        case 'r':
                            focoRojo = true;
                            break;
                        case 'a':
                            focoAmarillo = true;
                            break;
                        case 'z':
                            focoAzul = true;
                            break;
                        case 'b':
                            focoBlanco = true;
                            break;
                    }
                }
            }
            else
            {
                focoRojo = !esAvanzada || (!esBLA && !esBSL);
                focoBlanco = nombreDeSenal.StartsWith("sp4") || nombreDeSenal.StartsWith("sp3msbem") || nombreDeSenal.StartsWith("sp3sbem") || nombreDeSenal.StartsWith("sp3e");
                focoVerde = nombreDeSenal != "sp2ra" && !nombreDeSenal.StartsWith("sp3e");
                focoAzul = (esBSL && !esAvanzada) || nombreDeSenal.StartsWith("sp5") || nombreDeSenal.StartsWith("sp4i");
                focoAmarillo = !(esSalida && (esBSL || esBLA)) && nombreDeSenal != "sp1v";
                if ((esSalida || esIntermedia) && (esBSL || esBLA)) focoAmarillo = false;
            }
        }
    }
}
