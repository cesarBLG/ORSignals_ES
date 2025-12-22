
comment ( Eurobalizas ETCS )

SignalType ( "ETCS_GENERIC"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_DEFAULT_1_1"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_BACKFACING"

    SignalFnType ( ETCS_BACKFACING )
    Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "ETCS_PN"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_STOPSR"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_CONEXION_RBC"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_PN"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_ENTRADA_ERTMS"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_SALIDA_ERTMS"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_SECCIONAMIENTO"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_SECCIONAMIENTO_LAMINA"
	ORTSScript(ETCS_MSG_SECCIONAMIENTO)
    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_SECCIONAMIENTO_AISLADOR"
	ORTSScript(ETCS_MSG_SECCIONAMIENTO)
    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_TUNNEL"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_VIADUCTO"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_MSG_BRIDGE"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_LTV_DESVIOS"

    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "ETCS_VALORES_NACIONALES"
    ORTSScript( ETCS_NV )
    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
SignalType ( "inicioviaducto"
    SignalFnType ( INFO )
    Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "finviaducto"
    SignalFnType ( INFO )
    Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "iniciopuente"
    SignalFnType ( INFO )
    Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "finpuente"
    SignalFnType ( INFO )
    Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "iniciozonaneutra"
	SignalFnType ( INFO )
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "finzonaneutra"
	SignalFnType ( INFO )
	Include ( "sigcfg_ocultas.inc" )
)
	
SignalType ( "avisozonaneutra"
	SignalFnType ( INFO )
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "ETCS_MSG_APROXIMACIONZN"
    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)
	
  SignalType ( "ETCS_MSG_LLEGADAZN"
    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
)



SignalType ( "ETCS_INFILL_MA_1_2"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_INFILL_FIXED_2_2"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)


SignalType ( "ETCS_MAIN_N2"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_MAIN_MA_1_2"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_MAIN_FIXED_2_2"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_LS_MAIN"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_LS_INFILL"
    SignalFnType ( ETCS )
    ORTSScript( ETCS_LS_MAIN )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_LS_DEFAULT"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_LS_ENTRY"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_RETROCESO"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_DEFAULT_2_2"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

    SignalType ( "ETCS_LTV"
    SignalFnType ( ETCS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)

comment ( ETCS Markers )

SignalType ( "ETCS_LEVEL"
    ORTSScript (ETCS_LEVEL)
    SignalFnType ( ETCS_LEVEL )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)


SignalType ( "ETCS_LEVELTR"
    SignalFnType ( ETCS_PACKET )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( 5 )
)



comment ( Velocidad de paso por agujas para ETCS )


SignalType ( "VELOCIDADLINK"
    SignalFnType ( SPEED )
    Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "PANTALLA_ERTMS"

    SignalFnType ( NORMAL )
    ORTSNormalSubtype ( PANTALLA_ERTMS )
    Include ( "sigcfg_ocultas.inc" )
    SignalNumClearAhead ( -1 )
) 
	