
SignalType ( "LED5VRBZAGIFRIZ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 6
        SignalLight ( 0 "Red LED Light"
            Position ( 0 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.36 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "Amber LED Light"
            Position ( 0 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 5 "White LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
        )
    )
    SignalDrawStates ( 12
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
        SignalDrawState ( 11
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 5 )
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
SignalType ( "LED4VRBZGIFRIZ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 5
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "White LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
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
        SignalDrawState ( 8
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 4 )
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
SignalType ( "LED2VAGIFRIZ"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0 3.34 0.07 )
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

SignalType ( "LED5VRBZAGIFRDE"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 6
        SignalLight ( 0 "Red LED Light"
            Position ( 0 4.10 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.36 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "Amber LED Light"
            Position ( 0 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 5 "White LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
        )
    )
    SignalDrawStates ( 12
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
        SignalDrawState ( 11
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 5 )
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
SignalType ( "LED4VRBZGIFRDE"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 5
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "White LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
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
        SignalDrawState ( 8
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 4 )
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
SignalType ( "LED2VAGIFRDE"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0 3.34 0.07 )
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

SignalType ( "LED5VRBZAGIFDE"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 6
        SignalLight ( 0 "Red LED Light"
            Position ( 0.815 4.10 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0.815 4.36 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0.815 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0.815 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "Amber LED Light"
            Position ( 0.815 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 5 "White LED Light"
            Position ( 0.815 3.85 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
        )
    )
    SignalDrawStates ( 12
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
        SignalDrawState ( 11
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 5 )
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
SignalType ( "LED4VRBZGIFDE"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 5
        SignalLight ( 0 "Red LED Light"
            Position ( 0.815 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0.815 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0.815 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0.815 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "White LED Light"
            Position ( 0.815 3.59 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
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
        SignalDrawState ( 8
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 4 )
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
SignalType ( "LED2VAGIFDE"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0.815 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0.815 3.34 0.07 )
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

SignalType ( "LED5VRBZAGIFIZ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 6
        SignalLight ( 0 "Red LED Light"
            Position ( -0.81 4.10 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( -0.81 4.36 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( -0.81 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( -0.81 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "Amber LED Light"
            Position ( -0.81 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 5 "White LED Light"
            Position ( -0.81 3.85 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
        )
    )
    SignalDrawStates ( 12
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
        SignalDrawState ( 11
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 5 )
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
SignalType ( "LED4VRBZGIFIZ"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 5
        SignalLight ( 0 "Red LED Light"
            Position ( -0.81 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( -0.81 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( -0.81 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( -0.81 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "White LED Light"
            Position ( -0.81 3.59 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
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
        SignalDrawState ( 8
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 4 )
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
SignalType ( "LED2VAGIFIZ"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( -0.81 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( -0.81 3.34 0.07 )
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

SignalType ( "LED2VAGIFIZ_APREC"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( -0.81 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( -0.81 3.34 0.07 )
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

SignalType ( "LED5VRBZAGIF"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 6
        SignalLight ( 0 "Red LED Light"
            Position ( 0 4.10 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.36 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "Amber LED Light"
            Position ( 0 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 5 "White LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
        )
    )
    SignalDrawStates ( 12
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
        SignalDrawState ( 11
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 5 )
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
SignalType ( "LED4VRBZGIF"
    SignalFnType ( NORMAL )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 5
        SignalLight ( 0 "Red LED Light"
            Position ( 0 3.85 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Green LED Light"
            Position ( 0 4.1 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 3 "Blue LED Light"
            Position ( 0 3.34 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 4 "White LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
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
        SignalDrawState ( 8
            "FF8C"
            DrawLights ( 2
                DrawLight ( 0 )
                DrawLight ( 4 )
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
SignalType ( "LED2VAGIF"
    SignalFnType ( DISTANCE )
    ORTSScript ( GENERICO )
    SignalLightTex ( "ltexLED" )
    SigFlashDuration ( 0.5 0.5 )
    ORTSOnOffTimeS ( 0 )
    SignalLights ( 2
        SignalLight ( 0 "Green LED Light"
            Position ( 0 3.59 0.07 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "Amber LED Light"
            Position ( 0 3.34 0.07 )
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

SignalType ( "LED2RBGIF"
    ORTSScript (GENERICO)
    SignalFnType ( NORMAL )
    SignalLightTex ( "ltexLED" )
    SignalLights ( 3
        SignalLight ( 0 "Red LED Light"
            Position ( 0 0.7 0.1 )
            Radius ( 0.07 )
        )
        SignalLight ( 1 "White LED Light"
            Position ( 0 0.44 0.1 )
            Radius ( 0.07 )
        )
        SignalLight ( 2 "White LED Light"
            Position ( 0 0.44 0.1 )
            Radius ( 0.07 )
            ORTSSignalLightTex ( "ltexLEDraya" )
        )
    )
    SignalDrawStates ( 4
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
        SignalDrawState ( 3
            "FF8C"
            DrawLights ( 2
                Drawlight ( 0 )
                Drawlight ( 2 )
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
