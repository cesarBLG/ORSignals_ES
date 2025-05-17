
SignalShape (
    "GIFMONO2FOCOS.s"
    "Señal luminosa GIF LED 2 focos MANIOBRA"
    SignalSubObjs ( 1
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SignalFlags ( JN_LINK )
            SigSubSType ( "LED2RBGIF" )
        )
    )
)

SignalShape (
    "GIF5FOCOS.s" 
    "Señal luminosa GIF LED 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZAGIF" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF4FOCOS.s" 
    "Señal luminosa GIF LED 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZGIF" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF2FOCOS.s" 
    "Señal luminosa GIF LED 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VAGIF" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)
SignalShape (
    "GIF5FOCOSIZ.s" 
    "Señal luminosa GIF IZ LED 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZAGIFIZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF4FOCOSIZ.s" 
    "Señal luminosa GIF IZ LED 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZGIFIZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF4FOCOSIZ2.s" 
    "Señal luminosa GIF IZ LED 4 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VAGIFIZ_APREC" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF2FOCOSIZ.s" 
    "Señal luminosa GIF IZ LED 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VAGIFIZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF5FOCOSDE.s" 
    "Señal luminosa GIF DE LED 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZAGIFDE" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF4FOCOSDE.s" 
    "Señal luminosa GIF DE LED 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZGIFDE" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF2FOCOSDE.s" 
    "Señal luminosa GIF DE LED 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VAGIFDE" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF5FOCOSRDE.s" 
    "Señal luminosa GIF R DE LED 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZAGIFRDE" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF4FOCOSRDE.s" 
    "Señal luminosa GIF R DE LED 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZGIFRDE" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF2FOCOSRDE.s" 
    "Señal luminosa GIF R DE LED 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VAGIFRDE" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF5FOCOSRIZ.s" 
    "Señal luminosa GIF R IZ LED 5 focos VRBZA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED5VRBZAGIFRIZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF4FOCOSRIZ.s" 
    "Señal luminosa GIF R IZ LED 4 focos VRBZ"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED4VRBZGIFRIZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)

SignalShape (
    "GIF2FOCOSRIZ.s" 
    "Señal luminosa GIF R IZ LED 2 focos Avanzada VA"
    SignalSubObjs ( 16
        SignalSubObj ( 0
            "HEAD1"
            "Signal Head 1"
            SigSubType ( SIGNAL_HEAD )
            SigSubSType ( "LED2VAGIFRIZ" )
            SignalFlags ( JN_LINK )
        )
        Include ( "sigcfg_head_caracteristicas.inc" )
    )
)
