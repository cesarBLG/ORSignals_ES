
SignalType ( "OPAP"
	SignalFnType ( OPREANUNCIO )
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "OLIB"
	SignalFnType ( OLIBERACION )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_I_PREA_SIG_APREC_A_VL"
	SignalFnType ( I_PREA_SIG_APREC_A_VL )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_I_PREA_SIG_APARA_A_VL"
	SignalFnType ( I_PREA_SIG_APARA_A_VL )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_I_VL_A_APREC"
	SignalFnType ( I_VL_A_APREC )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_I_VL_A_VLC"
	SignalFnType ( I_VL_A_VLC )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)


SignalType ( "s_APARADA_INMEDIATA"
	SignalFnType ( APARADA_INMEDIATA )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_PREA_SIG_PREA"
	SignalFnType ( F_PREA_SIG_PREA )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_VLC_SIG_VLC"
	SignalFnType ( F_VLC_SIG_VLC )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_APARA_SIG_APARA"
	SignalFnType ( F_APARA_SIG_APARA )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_APREC_SIG_APARA"
	SignalFnType ( F_APREC_SIG_APARA )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_PARADA"
	SignalFnType ( F_PARADA )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_REBASE"
	SignalFnType ( F_REBASE )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_F_VL"
	SignalFnType ( F_VL )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_B_DOSCIENTOS"
	SignalFnType ( B_DOSCIENTOS )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_R_DESTELLOS"
	SignalFnType ( R_DESTELLOS )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )	
)

SignalType ( "s_R_CORTO"
	SignalFnType ( R_CORTO )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_R_APARADA"
	SignalFnType ( R_APARADA )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )	
)

SignalType ( "s_R_VL"
	SignalFnType ( R_VL )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "s_M_V_DESV"
	SignalFnType ( M_V_DESV )
	ORTSScript(FLAG)
	Include ( "sigcfg_ocultas.inc" )
)

SignalType ( "ESRNOcul"
	SignalFnType ( NORMAL )
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"Sinluz"
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP			"Sinluz" )
		SignalAspect ( CLEAR_2			"Sinluz" )
	)
	SignalNumClearAhead ( 5 )
)
