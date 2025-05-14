
SignalShape (
	"lzb_marker.s"
	"Marcador línea lzb"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Signal Head 1"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "LZB" )
			SignalFlags ( JN_LINK )
		)
	)
)
SignalShape (
	"lzb_start_marker.s"
	"Marcador línea con lzb"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Signal Head 1"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "LZBSTART" )
			SignalFlags ( JN_LINK )
		)
	)
)
SignalShape (
	"lzb_end_marker.s"
	"Marcador línea fin de lzb"
	SignalSubObjs ( 1
		SignalSubObj ( 0
			"HEAD1"
			"Signal Head 1"
			SigSubType ( SIGNAL_HEAD )
			SigSubSType ( "LZBEND" )
			SignalFlags ( JN_LINK )
		)
	)
)
