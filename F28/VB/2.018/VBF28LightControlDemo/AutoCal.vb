' ***********************************************************
' 1.400 19/11/15 Add auto calibration functions 
' 1.501 05/01/16 if Abort Cal process -> Send F28_StopAutoCal see RunContinue(false)
' ***********************************************************

Imports VBF28LightControlDemo.F28LightControl


Public Class AutoCal

    ' Auto Cam mode
    Enum MODE_AUTO_CAL As Byte
        OFFSET
        OFFSET_VOLUME
    End Enum

    ' Calibration phase
    Enum CAL_AUTO_PHASES As Byte
        AUTO_IDDLE
        AUTO_START_OFFSET
        AUTO_WAIT_EOC_OFFSET
        AUTO_WAIT_MASTER_LEAK
        AUTO_START_VOLUME
        AUTO_WAIT_EOC_VOLUME
        AUTO_END
    End Enum


    Dim m_wNbCycles, m_wInterCycle As UShort
    Dim m_fOffsetMax As Single
    Dim m_fVolumeLeak, m_fVolumePressure, m_fVolumeMin, m_fVolumeMax As Single

    Dim m_wError As UShort
    Dim m_ucPhase As Byte
    Dim m_ucMode As Byte
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
        m_fOffsetMax = 0

        m_fVolumeLeak = 0
        m_fVolumePressure = 0
        m_fVolumeMin = 0
        m_fVolumeMax = 0

        m_wError = 0
        m_sModuleId = 0
        m_bRunning = False

        m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE
        m_ucMode = MODE_AUTO_CAL.OFFSET

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
    ' Is Waiting Master Leak
    ' *****************************************************
    '
    Public Function IsWaitingMasterLeak() As Boolean

        Return (m_ucPhase = AutoCal.CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK)

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
    ' Get Calibration mode
    ' *****************************************************
    '
    Public Function GetMode() As Byte

        Return m_ucMode

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

            Case CAL_AUTO_PHASES.AUTO_IDDLE
                strRet = "Ready"

            Case CAL_AUTO_PHASES.AUTO_START_OFFSET
                strRet = "Start Offset calculation"

            Case CAL_AUTO_PHASES.AUTO_WAIT_EOC_OFFSET
                strRet = "Wait end of Offset calculation"

            Case CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK
                strRet = "Wait Master"

            Case CAL_AUTO_PHASES.AUTO_START_VOLUME
                strRet = "Start Volume calculation"

            Case CAL_AUTO_PHASES.AUTO_WAIT_EOC_VOLUME
                strRet = "Wait end of volume calculation"

            Case CAL_AUTO_PHASES.AUTO_END
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
    Public Function StartCal(sModuleID As Short, ucMode As Byte, _
                           wNbCycles As UShort, _
                           wInterCycle As UShort, _
                           fOffsetMax As Single, _
                           Optional fVolumeLeak As Single = 0, _
                           Optional fVolumePressure As Single = 0, _
                           Optional fVolumeMin As Single = 0, _
                           Optional fVolumeMax As Single = 0) As Boolean
        Dim bRet As Boolean

        bRet = False

        If sModuleID > 0 Then

            m_wNbCycles = wNbCycles
            m_wInterCycle = wInterCycle
            m_fOffsetMax = fOffsetMax
            m_fVolumeLeak = fVolumeLeak
            m_fVolumePressure = fVolumePressure
            m_fVolumeMin = fVolumeMin
            m_fVolumeMax = fVolumeMax

            m_sModuleId = sModuleID
            m_ucMode = ucMode
            m_wError = 0
            m_ucPhase = CAL_AUTO_PHASES.AUTO_START_OFFSET           ' CAL_AUTO_PHASES.AUTO_INIT
            m_bRunning = True

            bRet = True

        End If

        Return bRet

    End Function

    '
    ' *****************************************************
    ' Stop Calibration
    ' *****************************************************
    '
    Public Function StopCal() As Short

        Dim sRet As Short

        sRet = F28_RETURN.F28_FAIL

        If (m_sModuleId > 0) And (m_ucPhase <> CAL_AUTO_PHASES.AUTO_IDDLE) Then

            sRet = F28_StopAutoCal(m_sModuleId)

        End If

        m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE
        m_bRunning = False

        Return sRet

    End Function
    '
    ' *****************************************************
    ' Continue calibration after validation -> Run Volume Calibration
    ' *****************************************************
    '
    Public Sub RunContinue(bForward As Boolean)

        If (bForward = True) Then
            m_ucPhase = CAL_AUTO_PHASES.AUTO_START_VOLUME
        Else

            m_wError = m_ucPhase

            ' 1.501 if Abort Cal process -> Send F28_StopAutoCal
            StopCal()

            m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE
            m_bRunning = False

            'StopCal()

        End If
    End Sub

    '
    ' *****************************************************
    ' Purpose   : Run Calibration
    ' Return    :
    '               - True  : EOC calibration
    '               - False : Running
    ' *****************************************************
    '
    Public Function RunCal() As Boolean
        Dim sRet As Short
        Dim bReturn As Boolean

        ' Not End of Run
        bReturn = False

        Select Case m_ucPhase

            Case CAL_AUTO_PHASES.AUTO_START_OFFSET              ' Start auto Cal     
                If (m_ucMode = MODE_AUTO_CAL.OFFSET) Then
                    sRet = F28_StartAutoCalOffsetOnly(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fOffsetMax)
                Else
                    sRet = F28_StartAutoCalOffset(m_sModuleId, m_wNbCycles, m_wInterCycle, m_fOffsetMax)
                End If

                If (sRet = F28_RETURN.F28_OK) Then
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_WAIT_EOC_OFFSET
                Else
                    m_wError = m_ucPhase
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_END
                End If

            Case CAL_AUTO_PHASES.AUTO_WAIT_EOC_OFFSET           ' Wait EOC Offset

                If (F28_GetEOCOffset(m_sModuleId) > 0) Then

                    If (m_ucMode = MODE_AUTO_CAL.OFFSET) Then
                        m_wError = 0        ' Pas d'erreur
                        m_ucPhase = CAL_AUTO_PHASES.AUTO_END
                    Else
                        m_wError = m_ucPhase
                        m_ucPhase = CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK
                    End If

                End If

            Case CAL_AUTO_PHASES.AUTO_WAIT_MASTER_LEAK          ' Waiting master leak

                ' Wait validation from user
                ' Do nothing

            Case CAL_AUTO_PHASES.AUTO_START_VOLUME              ' Start auto volume
                If (F28_StartAutoCalVolume(m_sModuleId, _
                                           m_wNbCycles, _
                                           m_wInterCycle, _
                                           m_fVolumeLeak, _
                                           m_fVolumePressure, _
                                           m_fVolumeMin, _
                                           m_fVolumeMax) = F28_RETURN.F28_OK) Then
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_WAIT_EOC_VOLUME
                Else
                    m_wError = m_ucPhase
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_END
                End If

            Case CAL_AUTO_PHASES.AUTO_WAIT_EOC_VOLUME           ' Wait EOC Auto volume
                If (F28_GetEOCVolume(m_sModuleId) > 0) Then
                    m_wError = 0        ' Pas d'erreur
                    m_ucPhase = CAL_AUTO_PHASES.AUTO_END
                End If

            Case CAL_AUTO_PHASES.AUTO_END                       ' End of auto calibration
                m_wError = m_ucPhase
                m_ucPhase = CAL_AUTO_PHASES.AUTO_IDDLE
                m_bRunning = False
                bReturn = True

            Case CAL_AUTO_PHASES.AUTO_IDDLE                     ' Ready do nothing

                ' do nothing

        End Select

        Return bReturn

    End Function

    '
    ' 1.403 :NEW:(4)
    '
    Public Function IsRunningVolumeCal() As Boolean

        Return m_bRunning And m_ucMode = MODE_AUTO_CAL.OFFSET_VOLUME

    End Function



End Class
