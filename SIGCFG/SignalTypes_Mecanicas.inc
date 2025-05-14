
SignalType ( "ESRNSemHome"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 2 )
			)	
			SemaphorePos ( 2 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP			"Red" )
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)


SignalType ( "ESRNSemHome2"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 2 )
			)	
			SemaphorePos ( 2 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP			"Red" )
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)


SignalType ( "ESRNSemEntr"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 2 )
			)	
			SemaphorePos ( 2 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP			"Red" )
		SignalAspect ( APPROACH_2		"Yellow" SpeedKPH ( 30 ) )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNSemHome4"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 2 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 2 )
			)	
			SemaphorePos ( 3 )
		)
	)
	SignalAspects ( 4
		SignalAspect ( STOP			"Red" )
		SignalAspect ( STOP_AND_PROCEED		"Red" 	SpeedKPH ( 30 ) )
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNSemHome3"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.148 -0.050 0.02 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 2 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 2 )
			)	
			SemaphorePos ( 3 )
		)
	)
	SignalAspects ( 4
		SignalAspect ( STOP			"Red" )
		SignalAspect ( STOP_AND_PROCEED		"Red" 	SpeedKPH ( 30 ) )
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)


SignalType ( "ESRNSemAux4"
	SignalFnType ( REPEATER )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( -0.08 0.08 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Unlit"
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Permitted"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 4
		SignalAspect ( STOP			"Unlit" )
		SignalAspect ( STOP_AND_PROCEED		"Permitted" )
		SignalAspect ( APPROACH_2		"Unlit" )
		SignalAspect ( CLEAR_2			"Unlit" )
	)
)

SignalType ( "ESRNSemMan"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Violet Light"
			Position ( -0.08 0.08 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.08 0.08 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP			"Red" )
		SignalAspect ( CLEAR_2			"Green" )
	)
)

SignalType ( "ESRNSemDir"
	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Violet Light"
			Position ( -0.08 0.08 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.08 0.08 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"NoRuta"
			DrawLights ( 1
				DrawLight ( 0 )
			)	
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"EnRuta"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_2		"NoRuta" )
		SignalAspect ( CLEAR_2			"EnRuta" )
	)
)

SignalType ( "ESRNPanHome"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( -0.34 2.8 0.2 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.34 2.8 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP		"Red" )
		SignalAspect ( CLEAR_2		"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNPanEnt"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( -0.34 2.8 0.2 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.34 2.8 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Yellow"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP		"Red" )
		SignalAspect ( APPROACH_2	"Yellow"	SpeedKPH ( 30 ) )
		SignalAspect ( CLEAR_2		"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNPanMani"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Violet Light"
			Position ( -0.2 2.82 0.2 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( -0.2 2.82 0.11 )
			Radius( 0.10 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP			"Red" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNMonoRojo"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex2" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( 0 -0.097 0.205 )
			Radius ( 0.07 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( 0 -0.054 0.205 )
			Radius ( 0.07 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 0 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP		"Red" )
		SignalAspect ( CLEAR_2		"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNMonoMani"
	SignalFnType ( NORMAL )
	SignalLightTex ( "ltex2" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Violet Light"
			Position ( 0 -0.097 0.205 )
			Radius ( 0.07 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "White Light"
			Position ( 0 -0.054 0.205 )
			Radius ( 0.07 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Red"
			DrawLights ( 1
				DrawLight ( 0 )
			)
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 0 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP_AND_PROCEED	"Red" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNDAmDist"
	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Amber Light"
			Position ( -0.21 -10.07 0.11 )
			Radius( 0.09 )
		)
		SignalLight ( 1 "Green Light"
			Position ( -0.21 -10.74 0.11 )
			Radius( 0.09 )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"Yellow"
			DrawLights ( 1
				DrawLight ( 0 )
			)	
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"YellowGreen"
			DrawLights ( 2
				DrawLight ( 0 )
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_2	"Yellow" )
		SignalAspect ( APPROACH_3	"YellowGreen" )
		SignalAspect ( CLEAR_2		"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNDAmAux"
	SignalFnType ( REPEATER )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Yellow"
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"Green"
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( APPROACH_3		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
)

SignalType ( "ESRNDRoDist"
	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( -0.21 -10.74 0.11 )
			Radius( 0.09 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( -0.21 -10.07 0.11 )
			Radius( 0.09 )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.21 -10.74 0.11 )
			Radius( 0.09 )
		)
	)
	SignalDrawStates ( 3
		SignalDrawState ( 0
			"YellowRed"
			DrawLights ( 2
				DrawLight ( 0 )
				DrawLight ( 1 )
			)	
			SemaphorePos ( 0 )
		)
		SignalDrawState ( 1
			"YellowGreen"
			DrawLights ( 2
				DrawLight ( 1 )
				DrawLight ( 2 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 2
			"Green"
			DrawLights ( 1
				DrawLight ( 2 )
			)	
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 3
		SignalAspect ( APPROACH_2	"YellowRed" )
		SignalAspect ( APPROACH_3	"YellowGreen" )
		SignalAspect ( CLEAR_2		"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNDRoDist1"
	SignalFnType ( INFO )
	SignalLightTex ( "ltex2" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 2
		SignalLight ( 0 "Red Light"
			Position ( 2.26 -10.92 -0.03 )
			Radius( 0.08 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Green Light"
			Position ( -0.091 -10.023 0.093 )
			Radius ( 0.06 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Yellow"
			DrawLights ( 1
				DrawLight ( 0 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 1
				DrawLight ( 1 )
			)	
			SemaphorePos ( 0 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNDRoDist2"
	SignalFnType ( INFO )
	SignalLightTex ( "ltex2" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )
	SignalLights ( 3
		SignalLight ( 0 "Red Light"
			Position ( 2.26 -10 -0.03 )
			Radius( 0.08 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
		SignalLight ( 1 "Amber Light"
			Position ( 2.26 -10 -0.81 )
			Radius ( 0.06 )
		)
		SignalLight ( 2 "Green Light"
			Position ( -0.091 -10.023 0.093 )
			Radius ( 0.06 )
			SignalFlags ( SEMAPHORE_CHANGE )
		)
	)
	SignalDrawStates ( 2
		SignalDrawState ( 0
			"Yellow"
			DrawLights ( 2
				DrawLight ( 0 )
				DrawLight ( 1 )
			)	
			SemaphorePos ( 1 )
		)
		SignalDrawState ( 1
			"Green"
			DrawLights ( 2
				DrawLight ( 1 )
				DrawLight ( 2 )
			)	
			SemaphorePos ( 0 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_2		"Yellow" )
		SignalAspect ( CLEAR_2			"Green" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNPuntProt"
	SignalFnType ( NORMAL )
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"Sinluz"
		)
	)
	SignalAspects ( 2
		SignalAspect ( STOP			"Sinluz" )
		SignalAspect ( APPROACH_2		"Sinluz" )
	)
	SignalNumClearAhead ( 5 )
)

SignalType ( "ESRNPuntEntr"
	SignalFnType ( NORMAL )
	SignalDrawStates ( 1
		SignalDrawState ( 0
			"Sinluz"
		)
	)
	SignalAspects ( 3
		SignalAspect ( STOP			"Sinluz" )
		SignalAspect ( APPROACH_2		"Sinluz" SpeedKPH ( 30 ) )
		SignalAspect ( CLEAR_2			"Sinluz" )
	)
	SignalNumClearAhead ( 5 )
)


SignalType ( "ESRNIndDirec"
	SignalFnType ( INFO )
	SignalLightTex ( "ltex" )
	SemaphoreInfo ( 0.5 )
	SignalFlags ( SEMAPHORE )

	SignalDrawStates ( 2
		SignalDrawState ( 0
			"recto"
			SemaphorePos ( 2 )
		)
		SignalDrawState ( 1
			"desviado"
			SemaphorePos ( 1 )
		)
	)
	SignalAspects ( 2
		SignalAspect ( APPROACH_2		"desviado" )
		SignalAspect ( CLEAR_2			"recto" )
	)
	SignalNumClearAhead ( 5 )
)
