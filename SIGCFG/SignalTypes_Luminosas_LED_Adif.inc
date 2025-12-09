
SignalType ( "LED2RB"
    ORTSScript (GENERICO)
    SignalFnType ( NORMAL )
    SignalLightTex ( "ltexLED" )
    SignalLights ( 2
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.72 0.1 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 3.47 0.1 )
                Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 3
        SignalDrawState ( 0
            "FF7"
            DrawLights ( 1
                DrawLight ( 0 )					
            )
        )
        SignalDrawState ( 1
            "FF8B"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF8A"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 	SignalFlags ( FLASHING ) )
            )
        )
    )
    SignalAspects ( 3
        SignalAspect ( STOP					"FF7"				SpeedKPH ( 0 ) 	)
        SignalAspect ( STOP_AND_PROCEED				"FF8B"				      )
        SignalAspect ( RESTRICTING				"FF8A"				      )
    )
    SignalNumClearAhead ( 5 )
)

SignalType ( "SELU4MONOMBRA"

    SignalFnType ( NORMAL )
    ORTSNormalSubtype( RETROCESO )
    SignalLightTex ( "ltexLED" )
    ORTSShowInDispatcher( 1 )
    ORTSScript( SP4MD )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( 0.19 0.68 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( -0.19 0.42 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( -0.19 0.68 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 3 "White LED Light"
            Position ( 0.19 0.42 0.04 )
                Radius ( 0.07 )
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
SignalType ( "SELU4MONOMBRAIZQ"

    SignalFnType ( NORMAL )
    ORTSNormalSubtype( RETROCESO )
    SignalLightTex ( "ltexLED" )
    ORTSShowInDispatcher( 1 )
    ORTSScript( SP4MD )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( -0.19 0.68 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( -0.19 0.42 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0.19 0.42 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 3 "White LED Light"
            Position ( 0.19 0.68 0.04 )
                Radius ( 0.07 )
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
                DrawLight ( 2 )
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 2
            "Whitedes"
            DrawLights ( 2
                DrawLight ( 1 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 3
            "RedWhite"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 2 )
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
SignalType ( "LED2RBMONO"
    ORTSScript(GENERICO)
    SignalFnType ( NORMAL )
    SignalLightTex ( "ltexLED" )
    SignalLights ( 2
        SignalLight ( 0 "Red LED Light"
            Position ( 0 0.68 0.04 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 0.43 0.04 )
                Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 3
        SignalDrawState ( 0
            "FF7"
            DrawLights ( 1
                DrawLight ( 0 )					
            )
        )
        SignalDrawState ( 1
            "FF8B"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF8A"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 	SignalFlags ( FLASHING ) )
            )
        )
    )
    SignalAspects ( 3
        SignalAspect ( STOP					"FF7"				SpeedKPH ( 0 ) 	)
        SignalAspect ( STOP_AND_PROCEED				"FF8B"				      )
        SignalAspect ( RESTRICTING				"FF8A"				      )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED2RBMEDIANA"
    ORTSScript(GENERICO)
    SignalFnType ( NORMAL )
    SignalLightTex ( "ltexLED" )
    SignalLights ( 2
        SignalLight ( 0 "Red LED Light"
            Position ( 0 2.19 0.1 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 1.94 0.1 )
                Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 3
        SignalDrawState ( 0
            "FF7"
            DrawLights ( 1
                DrawLight ( 0 )					
            )
        )
        SignalDrawState ( 1
            "FF8B"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF8A"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 	SignalFlags ( FLASHING ) )
            )
        )
    )
    SignalAspects ( 3
        SignalAspect ( STOP					"FF7"				SpeedKPH ( 0 ) 	)
        SignalAspect ( STOP_AND_PROCEED				"FF8B"				      )
        SignalAspect ( RESTRICTING				"FF8A"				      )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED2RBV2"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )

    SignalLights ( 2
        SignalLight ( 0 "Red LED Light"
            Position ( 0 2.19 0.1 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 1.94 0.1 )
                Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 8
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 2
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 3
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 4
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 5
            "FF3A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 6
            "FF5A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 7
            "FF4"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
    )
    SignalAspects ( 8
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )
        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( STOP_AND_PROCEED				"FF8B"				      )
        SignalAspect ( RESTRICTING                               "FF8A" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED2RBBAJA"
    ORTSScript(GENERICO)
    SignalFnType ( NORMAL )
    SignalLightTex ( "ltexLED" )

    SignalLights ( 2
        SignalLight ( 0 "Red LED Light"
            Position ( 0 1.95 0.1 )
                Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 1.69 0.1 )
                Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 3
        SignalDrawState ( 0
            "FF7"
            DrawLights ( 1
                DrawLight ( 0 )					
            )
        )
        SignalDrawState ( 1
            "FF8B"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF8A"
            DrawLights ( 2
                Drawlight ( 0 )
                DrawLight ( 1 	SignalFlags ( FLASHING ) )
            )
        )
    )
    SignalAspects ( 3
        SignalAspect ( STOP					"FF7"				SpeedKPH ( 0 ) 	)
        SignalAspect ( STOP_AND_PROCEED				"FF8B"				      )
        SignalAspect ( RESTRICTING				"FF8A"				      )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED2VA_APREC"
    SignalFnType ( Distance )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0 4.24 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 5
        SignalDrawState ( 0
            "FF1A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF2"
            DrawLights ( 1
                DrawLight ( 0 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 2
            "FF3A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 3
            "FF5A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 4
            "FF4"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
    )
    SignalAspects ( 5
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED4VRBAMONO"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( 0.19 0.68 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( -0.19 0.68 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0.19 0.42 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Amber LED Light"
            Position ( -0.19 0.42 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 9
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 2
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 3
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 4
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 5
            "FF3A"
            DrawLights ( 2
                DrawLight ( 1 )
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 6
            "FF5A"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 7
            "FF4"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 8
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 7
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )
        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( RESTRICTING                               "FF8A" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED4VRBAMONOIZQ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( -0.19 0.68 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( -0.19 0.42 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0.19 0.68 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Amber LED Light"
            Position ( 0.19 0.42 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 9
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 2
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 3
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 4
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 5
            "FF3A"
            DrawLights ( 2
                DrawLight ( 1 )
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 6
            "FF5A"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 7
            "FF4"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 8
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 7
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )
        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( RESTRICTING                               "FF8A" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED5VRBZA"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 5
        SignalLight ( 0 "Red LED Light"
            Position ( 0 4.24 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.48 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 11
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF7C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 2
            "FF7D"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 3 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 3
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 4
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 5
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 6
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 7
            "FF3A"
            DrawLights ( 2
                DrawLight ( 1 )
                DrawLight ( 4 )
            )
        )
            SignalDrawState ( 8
            "FF5A"
            DrawLights ( 1
                DrawLight ( 4 )
            )
        )
            SignalDrawState ( 9
            "FF4"
            DrawLights ( 1
                DrawLight ( 4 )
            )
        )
        SignalDrawState ( 10
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 7
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        
        SignalAspect ( CLEAR_2                        "FF1A"                            )
        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( RESTRICTING                               "FF8A" )
        
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED4VRBZ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.23 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 8
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF7C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 2
            "FF7D"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 3 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 3
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 4
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 5
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 6
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 7
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 4
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( RESTRICTING                               "FF8A" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED4VRBA"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.24 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 9
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 2
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 3
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 4
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 5
            "FF3A"
            DrawLights ( 2
                DrawLight ( 1 )
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 6
            "FF5A"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 7
            "FF4"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 8
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 7
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( RESTRICTING                               "FF8A" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED4VRZA"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 4
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.24 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "Blue LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 9
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 3
            "FF3A"
            DrawLights ( 2
                DrawLight ( 1 )
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 4
            "FF5A"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
            SignalDrawState ( 5
            "FF4"
            DrawLights ( 1
                DrawLight ( 3 )
            )
        )
        SignalDrawState ( 6
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 7
            "FF7C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 8
            "FF7D"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
    )
    SignalAspects ( 6
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
    )
    SignalNumClearAhead ( 5 )
)

SignalType ( "LED3VRA"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 3
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 7
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
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
            "FF5A"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
            SignalDrawState ( 5
            "FF4"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 6
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 6
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
    )
    SignalNumClearAhead ( 5 )
)

SignalType ( "LED3VRZ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 3
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "Blue LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 6
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 3
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 4
            "FF7C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 5
            "FF7D"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
    )
    SignalAspects ( 3
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( CLEAR_1                                 "FF2" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED3RBA"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 3
        SignalLight ( 0 "Red LED Light"
            Position ( 0 4.24 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 5
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 2
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 3
            "FF5A"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 4
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
    )
    SignalAspects ( 3
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( RESTRICTING                               "FF8A" )
        
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED2VA_APREC2"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 5
        SignalDrawState ( 0
            "FF1A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF2"
            DrawLights ( 1
                DrawLight ( 0 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 2
            "FF3A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 3
            "FF5A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 4
            "FF4"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
    )
    SignalAspects ( 5
        SignalAspect ( CLEAR_2                        "FF1A"                            )

        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )
        SignalAspect ( CLEAR_1                                 "FF2" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED3VRB"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 3
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 3.98 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 7
        SignalDrawState ( 0
            "FF7A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 1
            "FF1A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
        SignalDrawState ( 2
            "FF2"
            DrawLights ( 1
                DrawLight ( 1 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 3
            "FF7B"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 4
            "FF8A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 SignalFlags(FLASHING) )
            )
        )
        SignalDrawState ( 5
            "FF8B"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 2 )
            )
        )
        SignalDrawState ( 6
            "FF9"
            DrawLights ( 1
                DrawLight ( 2 )
            )
        )
    )
    SignalAspects ( 5
        SignalAspect ( STOP                        "FF7A"                    SpeedMPH ( 0 )  )
        SignalAspect ( CLEAR_2                        "FF1A"                            )
        SignalAspect ( STOP_AND_PROCEED				"FF8B"				      )
        SignalAspect ( RESTRICTING                               "FF8A" )
        SignalAspect ( CLEAR_1                                 "FF2" )
    )
    SignalNumClearAhead ( 5 )
)
SignalType ( "LED2VA"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0 3.72 0.09 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0 3.47 0.09 )
            Radius ( 0.07 )
        )
    )
    SignalDrawStates ( 5
        SignalDrawState ( 1
            "FF1A"
            DrawLights ( 1
                DrawLight ( 0 )
            )
        )
        SignalDrawState ( 2
            "FF2"
            DrawLights ( 1
                DrawLight ( 0 SignalFlags(FLASHING) )
            )
        )
            SignalDrawState ( 3
            "FF3A"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 4
            "FF5A"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
            SignalDrawState ( 5
            "FF4"
            DrawLights ( 1
                DrawLight ( 1 )
            )
        )
    )
    SignalAspects ( 5
        SignalAspect ( CLEAR_2                        "FF1A"                            )
        SignalAspect ( CLEAR_1                                 "FF2" )
        SignalAspect ( APPROACH_1                                 "FF5A" )
        SignalAspect ( APPROACH_2                              "FF3A" )
        SignalAspect ( APPROACH_3                              "FF4" )			
    )
    SignalNumClearAhead ( 5 )
)
