	
	SignalLights ( 1
		SignalLight ( 0 "White Light"
			Position ( 0 2.200 0.10 )
			Radius ( 0.35 )
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
		SignalAspect ( APPROACH_1				"Unlit"					   )
		SignalAspect ( CLEAR_2					"Whitedes" 				         )
	)
	
