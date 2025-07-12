
SignalShape (
    "SELULED2FOCOSMANIOBRA.s"
    "Señal luminosa LED 2 focos MANIOBRA"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "LED2RB" )
        )
    )
)

SignalShape (
    "SELULED4FOCOSMONO.s"
    "Señal luminosa LED MONO 4 focos RETROCESO"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "SELU4MONOMBRA" )
        )
    )
)

SignalShape (
    "SELULED4FOCOSMONO_IZQ.s"
    "Señal luminosa LED MONO 4 focos RETROCESO Izq"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "SELU4MONOMBRAIZQ" )
        )
    )
)

SignalShape (
    "SELULED2FOCOSMONO.s"
    "Señal luminosa LED MONO 2 focos MANIOBRA"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "LED2RBMONO" )
        )
    )
)


SignalShape (
    "SELULED2FOCOSMONOALTOS.s"
    "Señal luminosa LED Alta 2 focos MANIOBRA"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "LED2RBMEDIANA" )
        )
    )
)

SignalShape (
    "SELULED2FOCOSMONOALTOS2.s"
    "Señal luminosa LED Alta 2 focos RB"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "LED2RBV2" )
        )
    )
)

SignalShape (
    "SELULED2FOCOSMONOBAJOS.s"
    "Señal luminosa LED Baja 2 focos MANIOBRA"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "LED2RBBAJA" )
        )
    )
)

SignalShape (
    "SELULED4FOCOSMONO1.s"
    "Señal luminosa LED MONO 4 focos VRBA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBAMONO" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOSMONO1_IZQ.s"
    "Señal luminosa LED MONO 4 focos VRBA Izq"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBAMONOIZQ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED5FOCOS.s" 
    "Señal luminosa LED 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED5FOCOS2.s" 
    "Señal luminosa LED 5 focos RBA Entrada Estaciones Terminales"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3RBA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS.s" 
    "Señal luminosa LED 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS2.s" 
    "Señal luminosa LED 4 focos VRBA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS3.s" 
    "Señal luminosa LED 4 focos VRZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS4.s" 
    "Señal luminosa LED 4 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA_APREC" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)
SignalShape (
    "SELULED3FOCOS.s" 
    "Señal luminosa LED 3 focos VRA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED3FOCOS2.s" 
    "Señal luminosa LED 3 focos VRZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED3FOCOS3.s" 
    "Señal luminosa LED 3 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED3FOCOS4.s" 
    "Señal luminosa LED 3 focos VRB"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRB" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED2FOCOS.s" 
    "Señal luminosa LED 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM5FOCOSI.s" 
    "Señal luminosa LED SM IZQUIERDA 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSI.s" 
    "Señal luminosa LED SM IZQUIERDA 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSI2.s" 
    "Señal luminosa LED SM IZQUIERDA 5 focos VRBA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSI3.s" 
    "Señal luminosa LED SM IZQUIERDA 4 focos VRZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSI4.s" 
    "Señal luminosa LED SM IZQUIERDA 4 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA_APREC" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM3FOCOSI.s" 
    "Señal luminosa LED SM IZQUIERDA 3 focos VRA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM3FOCOSI2.s" 
    "Señal luminosa LED SM IZQUIERDA 3 focos VRZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM3FOCOSI3.s" 
    "Señal luminosa LED SM IZQUIERDA 3 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA_APREC2" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM2FOCOSI.s" 
    "Señal luminosa LED SM IZQUIERDA 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM5FOCOSD.s" 
    "Señal luminosa LED SM DERECHA 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSD.s" 
    "Señal luminosa LED SM DERECHA 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSD2.s" 
    "Señal luminosa LED SM DERECHA 5 focos VRBA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSD3.s" 
    "Señal luminosa LED SM DERECHA 4 focos VRZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM4FOCOSD4.s" 
    "Señal luminosa LED SM DERECHA 4 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA_APREC" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM3FOCOSD.s" 
    "Señal luminosa LED SM DERECHA 3 focos VRA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM3FOCOSD2.s" 
    "Señal luminosa LED SM DERECHA 3 focos VRZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM3FOCOSD3.s" 
    "Señal luminosa LED SM DERECHA 3 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA_APREC2" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULEDSM2FOCOSD.s" 
    "Señal luminosa LED SM DERECHA 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)


SignalShape (
    "SELULED5FOCOSSP.s" 
    "Señal luminosa LED 5 focos SIN POSTE VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED5FOCOS2SP.s" 
    "Señal luminosa LED 5 focos SIN POSTE RBA Entrada Estaciones Terminales"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3RBA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOSSP.s" 
    "Señal luminosa LED 4 focos SIN POSTE VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS2SP.s" 
    "Señal luminosa LED 4 focos SIN POSTE VRBA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS3SP.s" 
    "Señal luminosa LED 4 focos SIN POSTE VRZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRZA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED4FOCOS4SP.s" 
    "Señal luminosa LED 4 focos SIN POSTE Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA_APREC" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)
SignalShape (
    "SELULED3FOCOSSP.s" 
    "Señal luminosa LED 3 focos SIN POSTE VRA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED3FOCOS2SP.s" 
    "Señal luminosa LED 3 focos SIN POSTE VRZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED3FOCOS3SP.s" 
    "Señal luminosa LED 3 focos SIN POSTE Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED3FOCOS4SP.s" 
    "Señal luminosa LED 3 focos SIN POSTE VRB"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED3VRB" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "SELULED2FOCOSSP.s" 
    "Señal luminosa LED 2 focos SIN POSTE Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VA" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

