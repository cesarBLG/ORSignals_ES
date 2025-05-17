
SignalShape (
    "eurobaliza_fija.s"
    "ETCS Baliza de relocalizacion"
    SignalSubObjs ( 2
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_DEFAULT_1_1" )
        )
        SignalSubObj ( 1
            "DECOR1"
            "Defecto baliza"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
    "eurobaliza_conmutable.s"
    "ETCS Baliza conmutable generica"
    SignalSubObjs ( 2
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_GENERIC" )
        )
        SignalSubObj ( 1
            "DECOR1"
            "Primera baliza de grupo"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
    "etcs_pn.s"
    "Paquete informacion paso a nivel ETCS"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_PN" )
        )
    )
)
SignalShape (
    "etcs_stopsr.s"
    "Paquete Parar en SR"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_STOPSR" )
        )
    )
)
SignalShape (
    "etcs_aproxpn.s"
    "Mensaje Aproximacion PN ETCS"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MSG_PN" )
        )
    )
)
SignalShape (
    "etcs_rbc.s"
    "Conexion RBC ETCS"
    SignalSubObjs ( 2
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "ETCS_CONEXION_RBC" )
        )
        SignalSubObj ( 1
            "DECOR1"
            "Desconexión"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
    "etcs_aproxtunnel.s"
    "Mensaje Aproximacion Túnel"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MSG_TUNNEL" )
            SignalFlags ( JN_LINK )
        )
    )
)
SignalShape (
    "etcs_aproxviaducto.s"
    "Mensaje Aproximacion Viaducto"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MSG_VIADUCTO" )
            SignalFlags ( JN_LINK )
        )
    )
)
SignalShape (
    "etcs_aproxbridge.s"
    "Mensaje Aproximacion Puente"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MSG_BRIDGE" )
            SignalFlags ( JN_LINK )
        )
    )
)
SignalShape (
    "etcs_aproxsecc.s"
    "Mensaje Aproximacion Seccionamiento ETCS"
    SignalSubObjs ( 8
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MSG_SECCIONAMIENTO" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_etcs_distance.inc" )
    )
)
SignalShape (
    "etcs_ltv_desvios.s"
    "ETCS restriccion de velocidad por desvio para señal en rojo"
    SignalSubObjs ( 8
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_LTV_DESVIOS" )
        )
        Include ( "sigcfg_head_etcs_distance.inc" )
    )
)

SignalShape (
    "etcs_inicioviaducto.s"
    "Mensaje Inicio Viaducto"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "inicioviaducto" )
        )
    )
)
SignalShape (
    "etcs_finviaducto.s"
    "Mensaje Fin Viaducto"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "finviaducto" )
        )
    )
)
    SignalShape (
    "etcs_iniciopuente.s"
    "Mensaje Inicio puente"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "iniciopuente" )
        )
    )
)
SignalShape (
    "etcs_finpuente.s"
    "Mensaje Fin puente"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "finpuente" )
        )
    )
)
SignalShape (
    "etcs_aproxzn.s"
    "Mensaje Aproximacion ZN ETCS"
    SignalSubObjs ( 6
    SignalSubObj ( 0
        "HEAD1"
        "Signal Head 1"
        SigSubType ( SIGNAL_HEAD )
        SigSubSType ( "ETCS_MSG_APROXIMACIONZN" )
            )
            SignalSubObj ( 1
                "DECOR1"
                "Sumar 50m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 2
                "DECOR2"
                "Sumar 100m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 3
                "DECOR3"
                "Sumar 200m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 4
                "DECOR4"
                "Sumar 400m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 5
                "DECOR5"
                "Sumar 800m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
        )
    )
	SignalShape (
        "etcs_llegadazn.s"
        "Mensaje Llegada ZN ETCS"
        SignalSubObjs ( 6
            SignalSubObj ( 0
                "HEAD1"
                "Signal Head 1"
                SigSubType ( SIGNAL_HEAD )
                SigSubSType ( "ETCS_MSG_LLEGADAZN" )
            )
            SignalSubObj ( 1
                "DECOR1"
                "Sumar 50m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 2
                "DECOR2"
                "Sumar 100m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 3
                "DECOR3"
                "Sumar 200m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
            )
            SignalSubObj ( 4
                "DECOR4"
                "Sumar 400m"
                SigSubType ( DECOR )
                SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 5
            "DECOR5"
            "Sumar 800m"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
	"inicio_azul_zona_neutra.s"
	"Cartel para indicar inicio de Zona Neutra F.Azul"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Signal Head 1"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "iniciozonaneutra" )
		)
	)
)
SignalShape (
	"inicio_blanco_zona_neutra.s"
	"Cartel para indicar inicio de Zona Neutra F.Blanco"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Signal Head 1"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "iniciozonaneutra" )
		)
	)
)
SignalShape (
	"fin_zona_neutra.s"
	"Cartel para indicar fin de Zona Neutra"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Signal Head 1"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "finzonaneutra" )
		)
	)
)
SignalShape (
    "eurobaliza_ltv.s"
    "ETCS baliza LTV, para limitaciones temporales de velocidad. Baliza 1/3"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_LTV" )
        )
    )
)
SignalShape (
    "eurobaliza_infill_ma.s"
    "ETCS Informacion via infill. Baliza 1/2"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_INFILL_MA_1_2" )
        )
    )
)
SignalShape (
    "eurobaliza_infill_fija.s"
    "ETCS Datos fijos infill. Baliza 2/2"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_INFILL_FIXED_2_2" )
        )
    )
)
SignalShape (
    "eurobaliza_pie_ma.s"
    "ETCS Informacion via pie de señal. Baliza 2/3"
    SignalSubObjs ( 2
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MAIN_MA_1_2" )
        )
        SignalSubObj ( 1
            "DECOR1"
            "Sin nivel 2"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
    "eurobaliza_pie_n2.s"
    "ETCS Informacion via N2. Baliza 1/2"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MAIN_N2" )
        )
    )
)
SignalShape (
    "eurobaliza_pie_fija.s"
    "ETCS Datos fijos pie de señal. Baliza 3/3"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_MAIN_FIXED_2_2" )
        )
    )
)
SignalShape (
    "eurobaliza_retroceso.s"
    "ETCS Datos señal retroceso. Baliza 2/2"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_RETROCESO" )
        )
    )
)
SignalShape (
    "eurobaliza_default.s"
    "ETCS baliza sin informacion, para determinar sentido de paso. Baliza 2/2"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_DEFAULT_2_2" )
        )
    )
)
SignalShape (
    "etcs_level_marker.s"
    "ETCS marcador de nivel"
    SignalSubObjs ( 7
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_LEVEL" )
            SignalFlags ( JN_LINK )
        )
        SignalSubObj ( 1
            "DECOR1"
            "N0"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 2
            "DECOR2"
            "N1"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 3
            "DECOR3"
            "N2"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 4
            "DECOR4"
            "ASFA"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 5
            "DECOR5"
            "LZB"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 6
            "DECOR6"
            "EBICAB"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
    "etcs_leveltr.s"
    "ETCS paquete de transicion"
    SignalSubObjs ( 8
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_LEVELTR" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_etcs_distance.inc" )
    )
)


SignalShape (
    "ESRNindagu_VELOCIDADLINK.s"
    "Velocidad configurable activada por link para ETCS"
    SignalSubObjs ( 7
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "VELOCIDADLINK" )
            SignalFlags ( JN_LINK )
        )
        SignalSubObj ( 1
            "DECOR1"
            "Sumar 5 km/h"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 2
            "DECOR2"
            "Sumar 10 km/h"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 3
            "DECOR3"
            "Sumar 20 km/h"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 4
            "DECOR4"
            "Sumar 40 km/h"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 5
            "DECOR5"
            "Sumar 80 km/h"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
        SignalSubObj ( 6
            "DECOR6"
            "Sumar 160 km/h"
            SigSubType ( DECOR )
            SignalFlags ( OPTIONAL )
        )
    )
)
SignalShape (
    "ETCS_NV.s"
    "Valores nacionales ETCS"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "ETCS_VALORES_NACIONALES" )
        )
    )
)

SignalShape (
    "pantallaERTMS.s"
    "Pantalla ERTMS Nivel 2"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "PANTALLA_ERTMS" )
        )
    )
)
	
