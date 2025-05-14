
SignalDrawStates ( 9
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
		"Flashing Green"
		DrawLights ( 1
			DrawLight ( 2   SignalFlags ( FLASHING )  )
		)
	)
	SignalDrawState ( 3
		"YellowGreen"
		DrawLights ( 2
			DrawLight ( 1 )
			DrawLight ( 2 )
		)
	)
	SignalDrawState ( 4
		"Green"
		DrawLights ( 1
			DrawLight ( 2 )
		)
	)
	SignalDrawState ( 5
		"RedWhite"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 3 )
		)
	)
	SignalDrawState ( 6
		"RedWhiteFlashing"
		DrawLights ( 2
			DrawLight ( 0 )
			DrawLight ( 3 SignalFlags ( FLASHING ) )
		)
	)
	SignalDrawState ( 7
		"FF7I"
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
)
