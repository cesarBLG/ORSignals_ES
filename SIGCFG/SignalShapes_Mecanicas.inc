
SignalShape (
	"ESRNSemUnif3.s"
	"ESRN Semaforo Principal"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemHome" )
		)
	)
)

SignalShape (
	"ESRNSemUnif3NAP.s"
	"ESRN Semaforo Principal no Anuncio Parada"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemHome2" )
		)
	)
)

SignalShape (
	"ESRNSemUnif3E.s"
	"ESRN Semaforo Entrada"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNSemEntr" )
		)
	)
)

SignalShape (
	"ESRNSemUnif3pt.s"
	"ESRN Semaforo Principal (Puente)"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemHome" )
		)
	)
)

SignalShape (
	"ESRNSemUnif4.s"
	"ESRN Semaforo Principal con autorización de rebase (Home)"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemHome4" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Repeater arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemAux4" )
		)
	)
)

SignalShape (
	"ESRNSemUnif4NAP.s"
	"ESRN Semaforo Principal NO AP con autorización de rebase (Home)"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemHome3" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Repeater arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemAux4" )
		)
	)
)

SignalShape (
	"ESRNSemUnif4pt.s"
	"ESRN Semaforo Principal con autorización de rebase (Puente)"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemHome4" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Repeater arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemAux4" )
		)
	)
)

SignalShape (
	"ESRNSemMan.s"
	"ESRN Semaforo Maniobras (Home)"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemMan" )
		)
	)
)

SignalShape (
	"ESRNSemManpt.s"
	"ESRN Semaforo Maniobras (Puente)"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNSemMan" )
		)
	)
)

SignalShape (
	"ESRNPantPrin.s"
	"ESRN Pantalla Principal"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNPanHome" )
		)
	)
)

SignalShape (
	"ESRNPantPrinE.s"
	"ESRN Pantalla Entrada"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNPanEnt" )
		)
	)
)

SignalShape (
	"ESRNPantMani.s"
	"ESRN Pantalla Maniobras"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNPanMani" )
		)
	)
)

SignalShape (
	"ESRNMonR.s"
	"ESRN Mono Rojo"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNMonoRojo" )
		)
	)
)

SignalShape (
	"ESRNMonV.s"
	"ESRN Mono Maniobras"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Home arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNMonoMani" )
		)
	)
)

SignalShape (
	"ESRNDiscAmar.s"
	"ESRN Disco Amarillo (Distance)"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Distance arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNDAmDist" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Repeater arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNDAmAux" )
		)
	)
)

SignalShape (
	"ESRNDiscRojo.s"
	"ESRN Disco Rojo"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Distance arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNDRoDist" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Repeater arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNDAmAux" )
		)
	)
)

SignalShape (
	"ESRNDiscRoj1.s"
	"ESRN Disco Rojo Andaluces"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Distance arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNDRoDist1" )
		)
	)
)

SignalShape (
	"ESRNDiscRoj2.s"
	"ESRN Disco Rojo Andaluces Triangulo"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Distance arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNDRoDist2" )
		)
	)
)

SignalShape (
	"ESRNPuntProt.s"
	"ESRN Punto Protegido"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Fixed arm"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "ESRNPuntProt" )
		)
	)
)

SignalShape (
	"ESRNPuntEntr.s"
	"ESRN Punto Protegido Entrada"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Fixed arm"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNPuntEntr" )
		)
	)
)

SignalShape (
	"ESRNMarmitaInt.s"
	"ESRN Marm. aguja Iz. Int."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNMarmitaExt.s"
	"ESRN Marm. aguja Iz. Ext."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNMarmitaIntD.s"
	"ESRN Marm. aguja De. Int."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNMarmitaExtD.s"
	"ESRN Marm. aguja De. Ext."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNIndicInt.s"
	"ESRN Ind. aguja Iz. Int."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNIndicExt.s"
	"ESRN Ind. aguja Iz. Ext."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNIndicIntD.s"
	"ESRN Ind. aguja De. Int."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNIndicExtD.s"
	"ESRN Ind. aguja De. Ext."
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Indicador Dirección"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNIndDirec" )
		)
	)
)

SignalShape (
	"ESRNSemDir3.s"
	"ESRN Indicador de Dirección 3 brazos"
	SignalSubObjs ( 3
		SignalSubObj ( 0
			"HEAD1"
			"Dirección 1"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNSemDir" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Dirección 2"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )
			SigSubSType ( "ESRNSemDir" )
		)
		SignalSubObj ( 2
			"HEAD3"
			"Dirección 3"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )
			SigSubSType ( "ESRNSemDir" )
		)
	)
)

SignalShape (
	"ESRNSemDir3pt.s"
	"ESRN Indicador de Dirección 3 brazos (Puente)"
	SignalSubObjs ( 3
		SignalSubObj ( 0
			"HEAD1"
			"Dirección 1"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNSemDir" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Dirección 2"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )
			SigSubSType ( "ESRNSemDir" )
		)
		SignalSubObj ( 2
			"HEAD3"
			"Dirección 3"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )
			SigSubSType ( "ESRNSemDir" )
		)
	)
)

SignalShape (
	"ESRNSemDir2.s"
	"ESRN Indicador de Dirección 2 brazos"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Dirección 1"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNSemDir" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Dirección 2"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )
			SigSubSType ( "ESRNSemDir" )
		)
	)
)

SignalShape (
	"ESRNSemDir2pt.s"
	"ESRN Indicador de Dirección 2 brazos (Puente)"
	SignalSubObjs ( 2
		SignalSubObj ( 0
			"HEAD1"
			"Dirección 1"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )				
			SigSubSType ( "ESRNSemDir" )
		)
		SignalSubObj ( 1
			"HEAD2"
			"Dirección 2"
			SigSubType ( SIGNAL_HEAD )
			SignalFlags ( JN_LINK )
			SigSubSType ( "ESRNSemDir" )
		)
	)
)
