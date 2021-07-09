
Imports VBF28LightControlDemo.F28LightControl


Public Class AutoRatio


    ' Auto-Ratio phase
    Enum AUTO_RATIO_PHASES As Byte
        AUTO_RATIO_IDDLE
        AUTO_RATIO_START
        AUTO_RATIO_WAIT_EOC
        AUTO_RATIO_END
    End Enum


    Dim m_wNbCycles, m_wInterCycle As UShort
    Dim m_fRatioMax As Single
    Dim m_fRatioMin As Single

    Dim m_wError As UShort
    Dim m_ucPhase As Byte
    Dim m_sModuleId As Short
    Dim m_bRunning As Boolean

    ' *****************************************************

    '
    ' *****************************************************
    ' Iniialize
    ' *****************************************************
    '
    Public Sub Initialize()
        m_wNbCycles = 2
        m_wInterCycle = 3000          ' 3 sec
        m_fRatioMax = 0.2
        m_fRatioMin = 1.0

        m_wError = 0
        m_sModuleId = 0
        m_bRunning = False

        m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE

    End Sub
    '
    ' *****************************************************
    ' Is Running
    ' *****************************************************
    '
    Public Function IsRunning() As Boolean

        Return m_bRunning

    End Function

    '
    ' *****************************************************
    ' Get Error
    ' *****************************************************
    '
    Public Function GetError() As UShort

        Return m_wError

    End Function

    '
    ' *****************************************************
    ' Get phase
    ' *****************************************************
    '
    Public Function GetPhase() As Byte

        Return m_ucPhase

    End Function

    '
    ' *****************************************************
    ' Get Calibration phase 
    ' *****************************************************
    '
    Public Function GetPhaseStr(ucPhase As Byte) As String

        Dim strRet As String

        strRet = "????"
        Select Case ucPhase

            Case AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE
                strRet = "Ready"

            Case AUTO_RATIO_PHASES.AUTO_RATIO_START
                strRet = "Start Auto-Ratio"

            Case AUTO_RATIO_PHASES.AUTO_RATIO_WAIT_EOC
                strRet = "Wait end of Auto-Ratio calculation"

            Case AUTO_RATIO_PHASES.AUTO_RATIO_END
                strRet = "End"

        End Select

        Return strRet

    End Function
    '
    ' *****************************************************
    ' Read alarm code at the end of calibration
    ' *****************************************************
    '
    Public Function GetAlarm() As UShort
        Dim wAlarm As UShort

        wAlarm = 0

        If m_sModuleId > 0 Then

            wAlarm = F28_GetAutoCalAlarm(m_sModuleId)

        End If

        Return wAlarm

    End Function

    '
    ' *****************************************************
    ' Start Calibration
    ' *****************************************************
    '
    Public Function StartAutoRatio(sModuleID As Short, _
                           wNbCycles As UShort, _
                           wInterCycle As UShort, _
                           fRatioMax As Single, _
                           fRatioMin As Single) As Boolean
        Dim bRet As Boolean

        bRet = False

        If sModuleID > 0 Then

            m_wNbCycles = wNbCycles
            m_wInterCycle = wInterCycle
            m_fRatioMax = fRatioMax
            m_fRatioMin = fRatioMin

            m_sModuleId = sModuleID
            m_wError = 0
            m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_START
            m_bRunning = True

            bRet = True

        End If

        Return bRet

    End Function

    '
    ' *****************************************************
    ' Stop Auto-ration
    ' *****************************************************
    '
    Public Function StopAutoRatio() As Short

        Dim sRet As Short

        sRet = F28_RETURN.F28_FAIL

        If (m_sModuleId > 0) And (m_ucPhase <> AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE) Then

            sRet = F28_StopAutoRatio(m_sModuleId)

        End If

        m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE
        m_bRunning = False

        Return sRet

    End Function

    '
    ' *****************************************************
    ' Purpose   : Run Auto-Ration
    ' Return    :
    '               - True  : EOC calibration
    '               - False : Running
    ' *****************************************************
    '
    Public Function RunAutoRatio() As Boolean
        Dim sRet As Short
        Dim bReturn As Boolean

        ' Not End of Run
        bReturn = False

        Select Case m_ucPhase

            Case AUTO_RATIO_PHASES.AUTO_RATIO_START
                sRet = F28_StartAutoRatio(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fRatioMax, m_fRatioMin)

                If (sRet = F28_RETURN.F28_OK) Then
                    m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_WAIT_EOC
                Else
                    m_wError = m_ucPhase
                    m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_END
                End If

            Case AUTO_RATIO_PHASES.AUTO_RATIO_WAIT_EOC           ' Wait EOC 

                If (F28_GetEOCRatio(m_sModuleId) > 0) Then
                    m_wError = 0        ' Pas d'erreur
                    m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_END
                End If

            Case AUTO_RATIO_PHASES.AUTO_RATIO_END                       ' End of auto Auto-Ratio
                m_wError = m_ucPhase
                m_ucPhase = AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE
                m_bRunning = False
                bReturn = True

            Case AUTO_RATIO_PHASES.AUTO_RATIO_IDDLE                     ' Ready do nothing

                ' do nothing

        End Select

        Return bReturn

    End Function

End Class
