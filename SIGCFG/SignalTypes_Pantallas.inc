
SignalType ( "PAP"
	SignalFnType ( PPREANUNCIO )
	ORTSScript(PAPGENERICO)
	SignalLightTex ( "6PAP" )
	SignalLights ( 11
		SignalLight ( 0 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "5PAP" )
		)
		SignalLight ( 1 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "6PAP" )
		)
		SignalLight ( 2 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "7PAP" )
		)
		SignalLight ( 3 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "8PAP" )
		)
		SignalLight ( 4 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "9PAP" )
		)
		SignalLight ( 5 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "10PAP" )
		)
		SignalLight ( 6 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "11PAP" )
		)
		SignalLight ( 7 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "12PAP" )
		)
		SignalLight ( 8 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "13PAP" )
		)
		SignalLight ( 9 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "14PAP" )
		)
		SignalLight ( 10 "Amber Light"
			Position ( 0 2.200 0.47 )
			Radius ( 0.34 )
			ORTSSignalLightTex( "15PAP" )
		)
	)
	SignalDrawStates ( 12
		SignalDrawState ( 0
			"Unlit"
		)
		SignalDrawState ( 1
			"PAP50"
			DrawLights ( 1
				DrawLight ( 0 )
			)
		)
		SignalDrawState ( 2
			"PAP60"
			DrawLights ( 1
				DrawLight ( 1 )
			)
		)
		SignalDrawState ( 3
			"PAP70"
			DrawLights ( 1
				DrawLight ( 2 )
			)
		)
		SignalDrawState ( 4
			"PAP80"
			DrawLights ( 1
				DrawLight ( 3 )
			)
		)
		SignalDrawState ( 5
			"PAP90"
			DrawLights ( 1
				DrawLight ( 4 )
			)
		)
		SignalDrawState ( 6
			"PAP100"
			DrawLights ( 1
				DrawLight ( 5 )
			)
		)
		SignalDrawState ( 7
			"PAP110"
			DrawLights ( 1
				DrawLight ( 6 )
			)
		)
		SignalDrawState ( 8
			"PAP120"
			DrawLights ( 1
				DrawLight ( 7 )
			)
		)
		SignalDrawState ( 9
			"PAP130"
			DrawLights ( 1
				DrawLight ( 8 )
			)
		)
		SignalDrawState ( 10
			"PAP140"
			DrawLights ( 1
				DrawLight ( 9 )
			)
		)
		SignalDrawState ( 11
			"PAP150"
			DrawLights ( 1
				DrawLight ( 10 )
			)
		)
	)
	SignalAspects ( 2
		SignalAspect ( CLEAR_1			"Unlit"			)
		SignalAspect ( APPROACH_3		"PAP60"		)
	)
)

SignalType ( "SPIAD"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "iavdtex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA30I"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia3itex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA30D"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia3dtex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA40I"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia4itex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA40D"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia4dtex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA50I"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia5itex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA50D"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia5dtex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIAD60"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "iadtex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIAI60"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "iaitex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIA100I"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia10itex" )
	Include ( "sigcfg_vel_ia.inc" )	
)

SignalType ( "SPIA100D"
	SignalFnType ( SPEED )
	ORTSScript(SPIA)
	SignalLightTex ( "ia10dtex" )
	Include ( "sigcfg_vel_ia.inc" )
)

SignalType ( "SPIVAMASTILAVANZADA_40_D"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia4dtex" )
	Include ( "sigcfg_vel_aprec.inc" )
)

SignalType ( "SPIVAMASTILAVANZADA_40_I"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia4itex" )
	Include ( "sigcfg_vel_aprec.inc" )
)

SignalType ( "SPIVAMASTILAVANZADA_45_D"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia45dtex" )
	Include ( "sigcfg_vel_aprec.inc" )
)
SignalType ( "SPIVAMASTILAVANZADA_45_I"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia45itex" )
	Include ( "sigcfg_vel_aprec.inc" )
)

SignalType ( "SPIVAMASTILAVANZADA_50_D"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia5dtex" )
	Include ( "sigcfg_vel_aprec.inc" )
)
SignalType ( "SPIVAMASTILAVANZADA_50_I"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia5itex" )
	Include ( "sigcfg_vel_aprec.inc" )
)

SignalType ( "SPIVAMASTILAVANZADA_60_D"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia6dtex" )
	Include ( "sigcfg_vel_aprec.inc" )
)
SignalType ( "SPIVAMASTILAVANZADA_60_I"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia6itex" )
	Include ( "sigcfg_vel_aprec.inc" )
)

SignalType ( "SPIVAMASTILAVANZADA_100_D"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia10dtex" )
	Include ( "sigcfg_vel_aprec.inc" )
)
SignalType ( "SPIVAMASTILAVANZADA_100_I"
	SignalFnType ( INDAGUJAS )
	ORTSScript(MFIA)
	SignalLightTex ( "ia10itex" )
	Include ( "sigcfg_vel_aprec.inc" )
)
