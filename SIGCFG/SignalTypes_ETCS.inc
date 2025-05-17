
comment ( Eurobalizas ETCS )

SignalType ( "ETCS_GENERIC"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2					"Green" 				           )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "ETCS_DEFAULT_1_1"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2					"Green" 				           )
    )
    SignalNumClearAhead ( 5 )
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
SignalType ( "ETCS_MSG_SECCIONAMIENTO"

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
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 5
        SignalDrawState ( 0
            "Trip"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "Proceed1"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "Proceed2"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 3
            "Proceed3"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 4
            "Proceed4"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 5
        SignalAspect ( STOP							"Trip" )
        SignalAspect ( STOP_AND_PROCEED				"Proceed1" )
        SignalAspect ( RESTRICTING					"Proceed2" )
        SignalAspect ( APPROACH_1					"Proceed3" )
        SignalAspect ( APPROACH_2					"Proceed4" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "ETCS_INFILL_FIXED_2_2"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2						"Green" )
    )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_MAIN_N2"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 1
        SignalLight ( 0 "Green Light"
            Position ( 0 -8.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2						"Green" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "ETCS_MAIN_MA_1_2"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 5
        SignalDrawState ( 0
            "Trip"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "Proceed1"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "Proceed2"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 3
            "Proceed3"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 4
            "Proceed4"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 5
        SignalAspect ( STOP							"Trip" )
        SignalAspect ( STOP_AND_PROCEED				"Proceed1" )
        SignalAspect ( RESTRICTING					"Proceed2" )
        SignalAspect ( APPROACH_1					"Proceed3" )
        SignalAspect ( APPROACH_2					"Proceed4" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "ETCS_MAIN_FIXED_2_2"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2						"Green" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "ETCS_RETROCESO"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2						"Green" )
    )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_DEFAULT_2_2"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2					"Green" 				           )
    )
    SignalNumClearAhead ( 5 )
)

    SignalType ( "ETCS_LTV"
    SignalFnType ( ETCS )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 3
        SignalLight ( 0 "Red Light"
            Position ( 0 -4.601 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Amber Light"
            Position ( 0 -4.212 0.20 )
            Radius ( 0.13 )
        )
        SignalLight ( 2 "Green Light"
            Position ( 0 -4.978 0.20 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Green"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2					"Green" 				           )
    )
    SignalNumClearAhead ( 5 )
)
comment ( ETCS Markers )

SignalType ( "ETCS_LEVEL"
    ORTSScript (ETCS_LEVEL)
    SignalFnType ( ETCS_LEVEL )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 0 )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Default"
            DrawLights ( 0 )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2					"Default" 				           )
    )
    SignalNumClearAhead ( 5 )
)

SignalType ( "ETCS_LEVELTR"
    SignalFnType ( ETCS_PACKET )
    SignalLightTex ( "ltex" )
    SigFlashDuration ( 0.5 0.5 )
    SignalLights ( 0 )
    SignalDrawStates ( 1
        SignalDrawState ( 0
            "Default"
            DrawLights ( 0 )
        )
    )
    SignalAspects ( 1
        SignalAspect ( CLEAR_2					"Default" 				           )
    )
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
    SignalLightTex ( "ltex" )

    SignalLights ( 2
        SignalLight ( 0 "Red Light"
            Position ( 0 0.789 0.2 )
            Radius ( 0.13 )
        )
        SignalLight ( 1 "Blue Light"
            Position ( 0 0.387 0.2 )
            Radius ( 0.13 )
        )
    )
    SignalDrawStates ( 2
        SignalDrawState ( 0
            "Red"
            DrawLights ( 0 )
        )
        SignalDrawState ( 1
            "RedBlue"
            DrawLights ( 0 )
        )
    )
    SignalAspects ( 2
        SignalAspect ( STOP					"Red"				SpeedKPH ( 0 ) 	)
        SignalAspect ( CLEAR_2				"RedBlue"				      )
    )
    SignalNumClearAhead ( -1 )
) 
	