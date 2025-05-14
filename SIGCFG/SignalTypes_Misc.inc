
SignalType ( "PN"

	SignalFnType ( PN_T )
	SignalLightTex ( "iePNtex" )
	SigFlashDuration ( 1.0 1.0 )
	ORTSShowInDispatcher( 1 )
	SignalLights ( 1
		SignalLight ( 0 "Amber Light"
			Position ( 0 4.300 0.13 )
			Radius ( 0.25 )
		)
		
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Flashing Amber"
			DrawLights ( 1
				DrawLight ( 0 	SignalFlags ( FLASHING ) )				
			)
		)
		SignalDrawState ( 1
			"Unlit"
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1					"Flashing Amber"				 	)
		SignalAspect ( CLEAR_2				"Unlit"				      )
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "OPEDALPN"

	SignalFnType ( OPEDALPN_T )
	SignalLightTex ( "iePNtex" )
	SigFlashDuration ( 1.0 1.0 )
	comment (  )
	SignalLights ( 1
		SignalLight ( 0 "Amber Light"
			Position ( 0 -4.425 0.21 )
			Radius ( 0.39 )
		)
		
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Flashing Amber"
			DrawLights ( 1
				DrawLight ( 0 	SignalFlags ( FLASHING ) )				
			)
		)
		SignalDrawState ( 1
			"Unlit"
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1					"Flashing Amber"				 	)
		SignalAspect ( CLEAR_2				"Unlit"				      )
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "OPN"

	SignalFnType ( OPN_T )
	SignalLightTex ( "ieOPNtex" )
	SigFlashDuration ( 1.0 1.0 )
	comment (  )
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 4.300 0.13 )
			Radius ( 0.27 )
		)
		
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Flashing White"
			DrawLights ( 1
				DrawLight ( 0 	SignalFlags ( FLASHING ) )				
			)
		)
		SignalDrawState ( 1
			"White"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 2
			"Unlit"
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_1					"Unlit"				 	)
		SignalAspect ( APPROACH_2					"Flashing White"				 	)
		SignalAspect ( CLEAR_2				"White"				      )
	)
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "OLPN"

	SignalFnType ( OLPN_T )
	SignalLightTex ( "iePNtex" )
	SigFlashDuration ( 1.0 1.0 )
	comment (  )
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 4.300 0.13 )
			Radius ( 0.27 )
		)
		
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Flashing White"
			DrawLights ( 1
				DrawLight ( 0 	SignalFlags ( FLASHING ) )				
			)
		)
		SignalDrawState ( 1
			"White"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 2
			"Unlit"
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_1					"Unlit"				 	)
		SignalAspect ( APPROACH_2					"Flashing White"				 	)
		SignalAspect ( CLEAR_2				"White"				      )
	)
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "ESRNIndSal"
	SignalFnType ( INFO )
	SignalLightTex ( "indsaltex" )

	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 2.58 0.17 )
			Radius ( 0.28 )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Unlit"
		)
		SignalDrawState ( 1
			"Pass"
			DrawLights ( 1
				DrawLight ( 0 )
			)	
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1			"Unlit" )
		SignalAspect ( CLEAR_1				"Pass" )
	)
)

SignalType ( "ESRNIndSalPuntos"
	SignalFnType ( INFO )
	SignalLightTex ( "indsaltexPuntos" )
	SigFlashDuration ( 0.5 0.5 )
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 2.58 0.17 )
			Radius ( 0.3 )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Unlit"
		)
		SignalDrawState ( 1
			"Pass"
			DrawLights ( 1
				DrawLight ( 0 SignalFlags ( FLASHING ) )
			)	
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1			"Unlit" )
		SignalAspect ( CLEAR_1				"Pass" )
	)
)

	
SignalType ( "s_ESINDEAEC"

	SignalFnType ( ESINDEAEC )
	SignalLightTex ( "EAtex" )
	
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 2.200 0.11 )
			Radius ( 0.35 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"EA"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( CLEAR_2					"EA"				 	)
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "s_ESINDEAEC_aux"

	SignalFnType ( ESINDEAEC )
	SignalLightTex ( "ECtex" )
	
	SigFlashDuration ( 1.0 1.0 )
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 2.200 0.11 )
			Radius ( 0.35 )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"EC"
			DrawLights ( 1
				DrawLight ( 0 )				
			)
		)
		SignalDrawState ( 1
			"Unlit"
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_1					"EC"				 	)
		SignalAspect ( CLEAR_2						"Unlit"				 	)
	)	
	
	SignalNumClearAhead ( 5 )
	
)

SignalType ( "SPIEMT"

	SignalFnType ( NORMAL )
	SignalLightTex ( "ieMTtex" )

	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
		)
	)

	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Unlit"
			)
		SignalDrawState ( 1
			"Whitedes"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP				"Unlit"					   )
		SignalAspect ( CLEAR_2					"Whitedes"  				         )
	)
	
)

SignalType ( "SPDID"

	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )

	SignalLights ( 5
		SignalLight ( 0 "White Light"
			Position ( 0 5.470 0.135 )
			Radius ( 0.08 )
		)
		SignalLight ( 1 "White Light"
			Position ( 0.290 5.745 0.138 )
			Radius ( 0.08 )
		)
		SignalLight ( 2 "White Light"
			Position ( 0.550 5.995 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 3 "White Light"
			Position ( -0.550 5.995 0.138 )
			Radius ( 0.08 )
		)
		SignalLight ( 4 "White Light"
			Position ( -0.290 5.745 0.140 )
			Radius ( 0.08 )
		)

	)

	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Unlit"
			)
		SignalDrawState ( 1
			"Whitedes"
			DrawLights ( 3
				DrawLight ( 0 )
				DrawLight ( 3 )
				DrawLight ( 4 )
			)
		)
		SignalDrawState ( 2
			"Whitedir"
			DrawLights ( 3
				DrawLight ( 0 )
				DrawLight ( 1 )
				DrawLight ( 2 )
			)
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_1				"Unlit"					   )
		SignalAspect ( APPROACH_2				"Whitedes"					   )
		SignalAspect ( CLEAR_2					"Whitedir" 				         )
	)
	
)

SignalType ( "SPDIF"

	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )

	SignalLights ( 5
		SignalLight ( 0 "White Light"
			Position ( 0 5.470 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 1 "White Light"
			Position ( 0 5.858 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 2 "White Light"
			Position ( 0 6.243 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 3 "White Light"
			Position ( 0.550 5.995 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 4 "White Light"
			Position ( 0.290 5.745 0.140 )
			Radius ( 0.08 )
		)

	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Unlit"
			)
		SignalDrawState ( 1
			"Whitedes"
			DrawLights ( 3
				DrawLight ( 0 )
				DrawLight ( 1 )
				DrawLight ( 2 )
			)
		)
		SignalDrawState ( 2
			"Whitedir"
			DrawLights ( 3
				DrawLight ( 0 )
				DrawLight ( 3 )
				DrawLight ( 4 )
			)
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_1				"Unlit"					   )
		SignalAspect ( APPROACH_2				"Whitedes"					   )
		SignalAspect ( CLEAR_2					"Whitedir" 				         )
	)

	
)

SignalType ( "SPDDF"

	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )

	SignalLights ( 5
		SignalLight ( 0 "White Light"
			Position ( 0 5.470 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 1 "White Light"
			Position ( 0 5.858 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 2 "White Light"
			Position ( 0 6.243 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 3 "White Light"
			Position ( -0.550 5.995 0.140 )
			Radius ( 0.08 )
		)
		SignalLight ( 4 "White Light"
			Position ( -0.290 5.745 0.140 )
			Radius ( 0.08 )
		)

	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Unlit"
			)
		SignalDrawState ( 1
			"Whitedes"
			DrawLights ( 3
				DrawLight ( 0 )
				DrawLight ( 1 )
				DrawLight ( 2 )
			)
		)
		SignalDrawState ( 2
			"Whitedir"
			DrawLights ( 3
				DrawLight ( 0 )
				DrawLight ( 3 )
				DrawLight ( 4 )
			)
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_1				"Unlit"					   )
		SignalAspect ( APPROACH_2				"Whitedes"					   )
		SignalAspect ( CLEAR_2					"Whitedir" 				         )
	)

	
)
