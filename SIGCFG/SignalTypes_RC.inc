

SignalType ( "s_MASTER_ECEAC"
	SignalFnType ( MASTER_ECEAC )
	ORTSShowInDispatcher( 1 )
	Include ( "sigcfg_ocultas.inc" )	
)

SignalType ( "s_ESRC_PASO"

	SignalFnType ( ESRC_PASO )
	SignalLightTex ( "RCPASOtex" )
	ORTSShowInDispatcher( 1 )
	SignalLights ( 1
		SignalLight ( 0 "RC Light"
			Position ( 0 1.400 0.00 )
			Radius ( 1.35 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"PASO"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( CLEAR_2					"PASO"				 	)
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "s_ESRC_PASO_aux"

	SignalFnType ( ESRC_PASO )
	SignalLightTex ( "RCPARADAtex" )
	
	SigFlashDuration ( 1.0 1.0 )
	SignalLights ( 1
		SignalLight ( 0 "RC Light"
			Position ( 0 1.400 0.00 )
			Radius ( 1.35 )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"PARADA"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
		SignalDrawState ( 1
			"Unlit"
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1					"PARADA"				 	)
		SignalAspect ( CLEAR_2						"Unlit"				 	)
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "s_ESRC_SALIDA"

	SignalFnType ( ESRC_SALIDA )
	SignalLightTex ( "RCSALIDAtex" )
	ORTSShowInDispatcher( 1 )
	SignalLights ( 1
		SignalLight ( 0 "RC Light"
			Position ( 0 1.400 0.00 )
			Radius ( 1.35 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"SALIDA"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( CLEAR_2					"SALIDA"				 	)
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "s_ESRC_SALIDA_aux"

	SignalFnType ( ESRC_SALIDA )
	SignalLightTex ( "RCPARADAtex" )
	
	SigFlashDuration ( 1.0 1.0 )
	SignalLights ( 1
		SignalLight ( 0 "RC Light"
			Position ( 0 1.400 0.00 )
			Radius ( 1.35 )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"PARADA"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
		SignalDrawState ( 1
			"Unlit"
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1					"PARADA"				 	)
		SignalAspect ( CLEAR_2						"Unlit"				 	)
	)	
	
	SignalNumClearAhead ( 5 )
	
)	

SignalType ( "s_ESCARTELONC"

	SignalFnType ( IND_C )
	SignalLightTex ( "Ctex" )
	
	SignalLights ( 1
		SignalLight ( 0 "White Light C"
			Position ( 0 3.800 0.03 )
			Radius ( 0.8 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"C"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( APPROACH_1				"C"				      )
	)
	SignalNumClearAhead ( 5 )
	
)
