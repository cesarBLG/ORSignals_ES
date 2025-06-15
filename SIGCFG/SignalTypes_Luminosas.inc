
SignalType ( "SP4MSBAB_PQ"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_DerV2.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4MSBAB_PQ_izq"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_IzqV2.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

comment (fijas fundamentales BA)

SignalType ( "SP2VRP"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	ORTSScript(GENERICO)
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP2VR"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	ORTSScript(GENERICO)
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP2RA"
	SignalFnType ( NORMAL )
	ORTSScript(GENERICO)
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	
	Include ( "SignalLights_Alta.inc" )
	
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)
		)
		SignalDrawState ( 2
			"Flashing Yellow"
			DrawLights ( 1
				DrawLight ( 1   SignalFlags ( FLASHING )  )
			)
		)
	)
	
	SignalAspects ( 4
		SignalAspect ( STOP					"Red"				)
		SignalAspect ( APPROACH_1			"Yellow"			)
		SignalAspect ( APPROACH_2			"Flashing Yellow"	)
		SignalAspect ( APPROACH_3			"Yellow"			)
	)

	SignalNumClearAhead ( 5 )
)



SignalType ( "SP3E"
	SignalFnType ( NORMAL )
	ORTSScript(GENERICO)
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	
	Include ( "SignalLights_Alta.inc" )
	
	SignalDrawStates ( 5
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)
		)
		SignalDrawState ( 2
			"Flashing Yellow"
			DrawLights ( 1
				DrawLight ( 1   SignalFlags ( FLASHING )  )
			)
		)
		SignalDrawState ( 3
			"RedWhite"
			DrawLights ( 2
				DrawLight ( 0 )
				DrawLight ( 3 )
			)
		)
		SignalDrawState ( 4
			"RedWhiteFlashing"
			DrawLights ( 2
				DrawLight ( 0 )
				DrawLight ( 3 SignalFlags ( FLASHING ) )
			)
		)
	)
	
	SignalAspects ( 6
		SignalAspect ( STOP					"Red"				)
		SignalAspect ( APPROACH_1			"Yellow"			)
		SignalAspect ( APPROACH_2			"Flashing Yellow"	)
		SignalAspect ( APPROACH_3			"Yellow"			)
		SignalAspect ( STOP_AND_PROCEED		"RedWhite"			)
		SignalAspect ( RESTRICTING			"RedWhiteFlashing"	)
	)

	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3P"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	ORTSScript(GENERICO)
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4EBAB"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	ORTSScript(GENERICO)
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP5EBAB"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	ORTSScript(GENERICO)
		
			SignalLights ( 5
		SignalLight ( 0 "Red Light"
			Position ( -0.005 5.094 0.118 )
			Radius ( 0.13 )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.005 4.27 0.118 )
			Radius ( 0.13 )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.005 5.51 0.118 )
			Radius ( 0.13 )
		)
		SignalLight ( 3 "White Light"
			Position ( -0.005 3.070 0.45 )
			Radius ( 0.11 )
		)
		SignalLight ( 4 "Blue Light"
			Position ( -0.005 4.68 0.118 )
			Radius ( 0.13 )
		)
			)
		
		SignalDrawStates ( 13
			SignalDrawState ( 0
		"FF7A"
		DrawLights ( 1
			DrawLight ( 0 )
		)
			)
			SignalDrawState ( 1
		"FF5A"
		DrawLights ( 1
			DrawLight ( 1 )
		)
			)
			SignalDrawState ( 2
		"FF2"
		DrawLights ( 1
			DrawLight ( 2   SignalFlags ( FLASHING )  )
		)
			)
			SignalDrawState ( 3
		"FF3A"
		DrawLights ( 2
			DrawLight ( 1 )
			DrawLight ( 2 )
		)
			)
			SignalDrawState ( 4
		"FF1A"
		DrawLights ( 1
			DrawLight ( 2 )
		)
			)
			SignalDrawState ( 5
		"FF8B"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 3 )
		)
			)
			SignalDrawState ( 6
		"FF8A"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 3 SignalFlags ( FLASHING ) )
		)
			)
			SignalDrawState ( 7
		"FF9"
		DrawLights ( 1
			DrawLight ( 3 )
		)
			)
			SignalDrawState ( 8
		"FF6"
		DrawLights ( 1
			DrawLight ( 1 SignalFlags ( FLASHING ) )
		)
			)
			SignalDrawState ( 9
		"FF4"
		DrawLights ( 1
			DrawLight ( 1 )
		)
			)
			SignalDrawState ( 10
		"FF7B"
		DrawLights ( 1
			DrawLight ( 0 )
		)
			)
			SignalDrawState ( 11
		"FF7C"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 4 )
		)
			)
			SignalDrawState ( 12
		"FF7D"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 4 SignalFlags ( FLASHING ) )
		)
			)
		)
		
		SignalAspects ( 8
			SignalAspect ( STOP					"FF7A"	)
			SignalAspect ( APPROACH_1			"FF5A"	)
			SignalAspect ( APPROACH_2			"FF3A"	)
			SignalAspect ( APPROACH_3			"FF4"	)
			SignalAspect ( CLEAR_1				"FF2"	)
			SignalAspect ( CLEAR_2				"FF1A"  )
			SignalAspect ( STOP_AND_PROCEED		"FF8B"  )
			SignalAspect ( RESTRICTING			"FF8A"	)
		)
	SignalNumClearAhead ( 5 )
	)

SignalType ( "SP4IBAB"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	ORTSScript(GENERICO)
		
			SignalLights ( 5
		SignalLight ( 0 "Red Light"
			Position ( -0.005 5.094 0.118 )
			Radius ( 0.13 )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.005 4.27 0.118 )
			Radius ( 0.13 )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.005 5.51 0.118 )
			Radius ( 0.13 )
		)
		SignalLight ( 3 "White Light"
			Position ( -0.005 3.070 0.45 )
			Radius ( 0.11 )
		)
		SignalLight ( 4 "Blue Light"
			Position ( -0.005 4.68 0.118 )
			Radius ( 0.13 )
		)
			)
		
		SignalDrawStates ( 13
			SignalDrawState ( 0
		"FF7A"
		DrawLights ( 1
			DrawLight ( 0 )
		)
			)
			SignalDrawState ( 1
		"FF5A"
		DrawLights ( 1
			DrawLight ( 1 )
		)
			)
			SignalDrawState ( 2
		"FF2"
		DrawLights ( 1
			DrawLight ( 2   SignalFlags ( FLASHING )  )
		)
			)
			SignalDrawState ( 3
		"FF3A"
		DrawLights ( 2
			DrawLight ( 1 )
			DrawLight ( 2 )
		)
			)
			SignalDrawState ( 4
		"FF1A"
		DrawLights ( 1
			DrawLight ( 2 )
		)
			)
			SignalDrawState ( 5
		"FF8B"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 3 )
		)
			)
			SignalDrawState ( 6
		"FF8A"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 3 SignalFlags ( FLASHING ) )
		)
			)
			SignalDrawState ( 7
		"FF9"
		DrawLights ( 1
			DrawLight ( 3 )
		)
			)
			SignalDrawState ( 8
		"FF6"
		DrawLights ( 1
			DrawLight ( 1 SignalFlags ( FLASHING ) )
		)
			)
			SignalDrawState ( 9
		"FF4"
		DrawLights ( 1
			DrawLight ( 1 )
		)
			)
			SignalDrawState ( 10
		"FF7B"
		DrawLights ( 1
			DrawLight ( 0 )
		)
			)
			SignalDrawState ( 11
		"FF7C"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 4 )
		)
			)
			SignalDrawState ( 12
		"FF7D"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 4 SignalFlags ( FLASHING ) )
		)
			)
		)
		
		SignalAspects ( 8
			SignalAspect ( STOP					"FF7A"	)
			SignalAspect ( APPROACH_1			"FF5A"	)
			SignalAspect ( APPROACH_2			"FF3A"	)
			SignalAspect ( APPROACH_3			"FF4"	)
			SignalAspect ( CLEAR_1				"FF2"	)
			SignalAspect ( CLEAR_2				"FF1A"  )
			SignalAspect ( STOP_AND_PROCEED		"FF8B"  )
			SignalAspect ( RESTRICTING			"FF8A"	)
		)
	SignalNumClearAhead ( 5 )
	)

SignalType ( "SELU2MONOTOPERA"
	ORTSScript (TOPERA)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( 0 0.789 0.2 )
			Radius ( 0.13 )
		)
		SignalLight ( 1 "Red Light"
			Position ( 0 0.387 0.2 )
			Radius ( 0.13 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"Red"
			DrawLights ( 2
				DrawLight ( 0 )					
				DrawLight ( 1 )					
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "SELU2MONOTOPERA_PQ"
	ORTSScript (TOPERA)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( -0.01 0.67 0.2 )
			Radius ( 0.1 )
		)
		SignalLight ( 1 "Red Light"
			Position ( -0.01 0.37 0.2 )
			Radius ( 0.1 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"Red"
			DrawLights ( 2
				DrawLight ( 0 )					
				DrawLight ( 1 )					
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "CARTELPARADA"
	ORTSScript (TOPERA)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( 0 -6 0 )
			Radius ( 0.01 )
		)
		SignalLight ( 1 "Red Light"
			Position ( 0 -6 0 )
			Radius ( 0.01 )
		)
	)
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"Red"
			DrawLights ( 2
				DrawLight ( 0 )					
				DrawLight ( 1 )					
			)
		)
	)
	SignalAspects ( 1
		SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4SBAB"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4MSBAB"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_Der.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4MSBAB_izq"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_Izq.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

comment(BLA BT BEM)

SignalType ( "SP2AV"

	SignalFnType ( DISTANCE )
	ORTSScript(GENERICO)
	ORTSShowInDispatcher( 1 )
	SignalLightTex ( "ltex" )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP1V"
	SignalFnType ( DISTANCE )
	ORTSScript(GENERICO)
	ORTSShowInDispatcher( 1 )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3SBEM"

	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	Include ( "SignalLights_Alta.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3MSBEM"

	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_Der.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3MSBEM_izq"

	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_Izq.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3MSBEML_PQ"

	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_DerV2.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3MSBEML_PQ_izq"

	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Mono_IzqV2.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4MD_pq"

	SignalFnType ( NORMAL )
	ORTSNormalSubtype( RETROCESO )
	ORTSScript(SP4MD)
	SignalLightTex ( "ltex" )
	ORTSShowInDispatcher( 1 )
	SignalLights ( 4
		SignalLight ( 0 "Red Light"
			Position ( 0.22 0.67 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.21 0.37 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 2 "White Light"
			Position ( -0.21 0.67 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 3 "White Light"
			Position ( 0.22 0.37 0.14 )
			Radius ( 0.11 )
		)

	)
	SignalDrawStates ( 4
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 1
			"Whitedir"
			DrawLights ( 2
				DrawLight ( 1 )
				DrawLight ( 2 )
			)
		)
		SignalDrawState ( 2
			"Whitedes"
			DrawLights ( 2
				DrawLight ( 1 )
				DrawLight ( 3 )
			)
		)
		SignalDrawState ( 3
			"RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 3 )
			)
		)
	)
	SignalAspects ( 4
		SignalAspect ( STOP				"Red"						   )
		SignalAspect ( APPROACH_2				"Whitedes"					   )
		SignalAspect ( CLEAR_2					"Whitedir" 				         )
		SignalAspect ( STOP_AND_PROCEED				"RedWhite"				      )
	)
	SignalNumClearAhead ( -1 )
)

SignalType ( "SP4MD_pq_izq"

	SignalFnType ( NORMAL )
	ORTSNormalSubtype( RETROCESO )
	ORTSScript(SP4MD)
	SignalLightTex ( "ltex" )
	ORTSShowInDispatcher( 1 )
	ORTSScript(SP4MD)
	SignalLights ( 4
		SignalLight ( 0 "White Light"
			Position ( 0.22 0.37 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.21 0.37 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 2 "White Light"
			Position ( 0.22 0.67 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 3 "Red Light"
			Position ( -0.21 0.67 0.14 )
			Radius ( 0.11 )
		)

	)
	SignalDrawStates ( 4
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 3 )
			)
		)
		SignalDrawState ( 1
			"Whitedir"
			DrawLights ( 2
				DrawLight ( 0 )
				DrawLight ( 2 )
			)
		)
		SignalDrawState ( 2
			"Whitedes"
			DrawLights ( 2
				DrawLight ( 1 )
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 3
			"RedWhite"
			DrawLights ( 2
				Drawlight ( 1 )
				DrawLight ( 3 )
			)
		)
	)
	SignalAspects ( 4
		SignalAspect ( STOP				"Red"						   )
		SignalAspect ( APPROACH_2				"Whitedes"					   )
		SignalAspect ( CLEAR_2					"Whitedir" 				         )
		SignalAspect ( STOP_AND_PROCEED				"RedWhite"				      )
	)
	SignalNumClearAhead ( -1 )
)

SignalType ( "SP2M"

	SignalFnType ( NORMAL )
	ORTSScript ( GENERICO )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )

	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( -0.005 4.675 0.118 )
			Radius ( 0.11 )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.005 3.066 0.453 )
			Radius ( 0.11 )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )					
			)
		)
		SignalDrawState ( 1
			"RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 1 )
			)
		)
		SignalDrawState ( 2
			"Flashing RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 1 	SignalFlags ( FLASHING ) )
			)
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
		SignalAspect ( STOP_AND_PROCEED				"RedWhite"				      )
		SignalAspect ( RESTRICTING				"Flashing RedWhite"				      )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP2MB"

	SignalFnType ( NORMAL )
	ORTSScript ( GENERICO )
	SignalLightTex ( "ltex" )

	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( 0 0.789 0.2 )
			Radius ( 0.13 )
		)
		SignalLight ( 1 "White Light"
			Position ( 0 0.387 0.2 )
			Radius ( 0.13 )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )					
			)
		)
		SignalDrawState ( 1
			"RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 1 )
			)
		)
		SignalDrawState ( 2
			"Flashing RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 1 	SignalFlags ( FLASHING ) )
			)
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
		SignalAspect ( STOP_AND_PROCEED				"RedWhite"				      )
		SignalAspect ( RESTRICTING				"Flashing RedWhite"				      )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP2MB_pq"

	SignalFnType ( NORMAL )
	ORTSScript ( GENERICO )
	SignalLightTex ( "ltex" )

	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( -0.012 0.67 0.14 )
			Radius ( 0.11 )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.012 0.37 0.14 )
			Radius ( 0.11 )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )					
			)
		)
		SignalDrawState ( 1
			"RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 1 )
			)
		)
		SignalDrawState ( 2
			"Flashing RedWhite"
			DrawLights ( 2
				Drawlight ( 0 )
				DrawLight ( 1 	SignalFlags ( FLASHING ) )
			)
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
		SignalAspect ( STOP_AND_PROCEED				"RedWhite"				      )
		SignalAspect ( RESTRICTING				"Flashing RedWhite"				      )
	)
	SignalNumClearAhead ( 5 )
)         
SignalType ( "SP4ETBADDER"

	SignalFnType ( NORMAL )
	ORTSScript(GENERICO)
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	SignalLights ( 4
		SignalLight ( 0 "Red Light"
			Position ( -0.01 2.950 -0.1 )
			Radius ( 0.05 )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.01 2.740 -0.1 )
			Radius ( 0.05 )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.01 3.150 -0.1 )
			Radius ( 0.05 )
		)
			SignalLight ( 3 "White Light"
			Position ( -0.01 2.49 0.10 )
			Radius ( 0.045 )
		)
	)
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4ETBADIZQ"

	SignalFnType ( NORMAL )
	ORTSScript(GENERICO)
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	SignalLights ( 4
		SignalLight ( 0 "Red Light"
			Position ( -0.01 2.950 -0.1 )
			Radius ( 0.05 )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.01 2.740 -0.1 )
			Radius ( 0.05 )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.01 3.150 -0.1 )
			Radius ( 0.05 )
		)
			SignalLight ( 3 "White Light"
			Position ( -0.01 2.49 0.10 )
			Radius ( 0.045 )
		)
	)
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)


SignalType ( "SP3TUNDERSINP"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	ORTSScript(GENERICO)
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Tunel.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3TUNIZQSINP"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	ORTSScript(GENERICO)
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_Tunel.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3SBEMSP"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_SP.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP4SBABSP"
	ORTSScript(GENERICO)
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_SP.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)

SignalType ( "SP3ESP"
	SignalFnType ( NORMAL )
	ORTSScript(GENERICO)
	SignalLightTex ( "ltex" )
	SigFlashDuration ( 0.5 0.5 )
	Include ( "SignalLights_SP.inc" )
	Include ( "SignalDrawStates.inc" )
	Include ( "SignalAspects.inc" )
	SignalNumClearAhead ( 5 )
)
