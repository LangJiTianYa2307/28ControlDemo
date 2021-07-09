' ****************************************************************************
' 15/07/15  1.000   Original version (CAN library) 
' ****************************************************************************
' ****************************************************************************
' 13/10/15  1.300   - Add support Ethernet (Library Ethernet)
' 02/11/15  1.302   - Delete CAN interface
' 17/11/15  1.404   - Add F28_ResetEthernetModule function
' 21/07/16  1.504   - Replace Ulong to Uinteger declaration
' ****************************************************************************
Imports System.Runtime.InteropServices

Public Class F28LightControl

    ' 1.404 Flag ucEndCycle in real time data 
    Enum F28_FLAG As Byte
        FLAG_END_OF_CYCLE = 1
        FLAG_NEW_RESULT_AVAILABLE = 2       ' Reserved
        FLAG_END_AUTOCALIB_OFFSET = 4       ' Reserved
        FLAG_END_AUTOCALIB_VOLUME = 8       ' Reserved
        FLAG_AUTOCALIB_ALARM = 16           ' Reserved
    End Enum

    ' -------------------------
    ' Function return code
    ' -------------------------
    Enum F28_RETURN As Short
        F28_FAIL = -1
        F28_OK = 0
    End Enum

    ' -------------------------
    ' Connection status
    ' -------------------------

    Enum F28_CONNECT As Short
        F28_OFFLINE = 0
        F28_CONNECTED = 1
    End Enum


    ' -------------------------
    ' Group ID
    ' -------------------------
    Enum F28_GROUP_ID As Byte
        GROUP_1 = 1
        GROUP_2
        GROUP_3
        GROUP_4
        GROUP_5
        GROUP_6
        GROUP_7
        GROUP_8
        GROUP_9
        GROUP_10
        GROUP_11
        GROUP_12
        GROUP_13
        GROUP_14
        GROUP_15
        GROUP_MAX
    End Enum

    ' -------------------------
    ' Module address
    ' -------------------------
    Enum F28_MODULE_ADDR As Byte
        MODULE_ADDR_0 = 0
        MODULE_ADDR_1
        MODULE_ADDR_2
        MODULE_ADDR_3
        MODULE_ADDR_4
        MODULE_ADDR_5
        MODULE_ADDR_6
        MODULE_ADDR_7
        MODULE_ADDR_8
        MODULE_ADDR_9
        MODULE_ADDR_10
        MODULE_ADDR_11
        MODULE_ADDR_12
        MODULE_ADDR_13
        MODULE_ADDR_14
        MODULE_ADDR_15
        MODULE_MAX
    End Enum

    ' -------------------------
    ' Boot/Run mode
    ' -------------------------
    Enum F28_MODE As Byte
        F28_MODE_BOOT = 1
        F28_MODE_APPLICATION = 2
    End Enum

    ' -------------------------
    ' Test type
    ' -------------------------
    Enum F28_TYPE_TEST              ' Uses with wTypeTest parameter
        UNDEFINED_TEST
        LEAK_TEST
        SEALED_COMPONENT_TEST
        MODE_D                      ' 1.500
        FLOW_TEST
    End Enum

    ' -------------------------
    ' Result status
    ' -------------------------
    Enum F28_RSLT_STATUS As Byte    ' Use with ucStatus of Result cycle
        STATUS_GOOD_PART
        STATUS_TEST_FAIL_PART
        STATUS_REF_FAIL_PART
        STATUS_ALARM_EEEE
        STATUS_ALARM_MMMM
        STATUS_ALARM_PPPP
        STATUS_ALARM_MPPP
        STATUS_ALARM_OFFD_FUITE
        STATUS_ALARM_OFFD_PRESSION
        STATUS_ALARM_PST
        STATUS_ALARM_MPST                               ' 10
        STATUS_ALARM_CS_VOLUME_PETIT
        STATUS_ALARM_CS_VOLUME_GRAND
        STATUS_ALARM_ERREUR_PRESS_CALIBRATION
        STATUS_ALARM_ERREUR_LEAK_CALIBRATION
        STATUS_ALARM_ERREUR_LINE_PRESS_CALIBRATION
        ' V2.0.0.4
        STATUS_ALARM_APPR_REG_ELEC_ERROR
        STATUS_ALARM_TEST_PART_LARGE_LEAK
        STATUS_ALARM_REF_SIDE_LARGE_LEAK
        STATUS_ALARM_P_TOO_LARGE_FILL
        STATUS_ALARM_P_TOO_LOW_FILL
        STATUS_ALARM_JET_CHECK_FAIL
        STATUS_ALARM_JET_CHECK_PASS
        STATUS_ALARM_INCOMPATIBLE_DEVICE
        NMAX_STATUS_CODE
    End Enum

    ' -------------------------
    ' Pressure unit
    ' -------------------------
    Enum F28_PRESS_UNITS As Byte
        PRESS_PA
        PRESS_KPA
        PRESS_MPA
        PRESS_BAR
        PRESS_mBAR
        PRESS_PSI                                       ' 5
        PRESS_POINTS
        NMAX_PRESS_UNITS
    End Enum

    ' -------------------------
    ' Leak unit
    ' -------------------------
    Enum F28_LEAK_UNITS As Byte ' Uses with wLeakUnit parameter
        LEAK_PA
        LEAK_PASEC
        LEAK_PA_HR
        LEAK_PASEC_HR
        LEAK_CAL_PA
        LEAK_CAL_PASEC
        LEAK_CCMIN
        LEAK_CCSEC
        LEAK_CCH
        LEAK_MM3SEC
        LEAK_CM3_SEC            ' 10
        LEAK_CM3_MIN
        LEAK_CM3_H
        LEAK_ML_SEC
        LEAK_ML_MIN
        LEAK_ML_H
        LEAK_INCH3_SEC
        LEAK_INCH3_MIN
        LEAK_INCH3_H
        LEAK_FT3_SEC
        LEAK_FT3_MIN            ' 20
        LEAK_FT3_H
        LEAK_MMCE
        LEAK_MMCE_SEC
        LEAK_SCCM
        LEAK_POINTS
        ' 1.500 Leak units
		LEAK_KPA
		LEAK_MPA
		LEAK_BAR
		LEAK_mBAR
		LEAK_PSI
		LEAK_L_MIN
        ' End 1.500
        ' V2.0.0.6
        LEAK_CM_H2O
        ' V2.0.0.6
        LEAK_UG_H2O
        NMAX_LEAK_UNITS
        ' V2.0.0.4
        LEAK_JET_CHECK = 255
    End Enum

    Enum F28_ENUM_VOLUME_UNIT As Byte  ' Uses with wVolumeUnit parameter
        VOLUME_CM3
        VOLUME_MM3
        VOLUME_ML
        VOLUME_LITRE
        VOLUME_INCH3
        VOLUME_FT3
        NMAX_VOLUME_UNITS       ' 6
    End Enum

    ' -------------------------
    ' Cycle step code
    ' -------------------------
    Enum F28_ENUM_STEP_CODE As Byte
        NO_STEP
        FILL_STEP
        STAB_STEP
        TEST_STEP
        DUMP_STEP               ' 4
        FILL_VOLUME_STEP
        TRANSFERT_STEP
    End Enum

    ' ===========================================================================================
    ' Structure declaration must be 1 byte packed
    ' The C++ DLL ver >= 1.100 is packed 1 byte
    ' ===========================================================================================

    ' -------------------------
    ' Parameter structure
    ' -------------------------
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Structure F28_PARAMETERS
        Dim wTypeTest As UShort             ' STANDARD or LARGE LEAK (Sealed) or LARGE LEAK TEST (sealed + test)
        Dim wTpsFillVol As UShort
        Dim wTpsTransfert As UShort
        Dim wTpsFill As UShort
        Dim wTpsStab As UShort
        Dim wTpsTest As UShort
        Dim wTpsDump As UShort
        Dim wPress1Unit As UShort           ' See F28_PRESS_UNITS
        Dim fPress1Min As Single
        Dim fPress1Max As Single
        Dim fSetFillP1 As Single            ' Setpoint auto-fill
        Dim fRatioMax As Single
        Dim fRatioMin As Single
        Dim wFillMode As UShort             ' STD_FILL_MODE / AUTOFILL_MODE
        Dim wLeakUnit As UShort             ' See F28_LEAK_UNITS
        Dim wRejectCalc As UShort           ' Pa or Pa/s
        Dim wVolumeUnit As UShort           ' See F28_ENUM_VOLUME_UNIT 
        Dim fVolume As Single
        Dim fRejectMin As Single
        Dim fRejectMax As Single
        Dim fCoeffAutoFill As Single
        Dim wOptions As UShort              ' SIGN(NO/YES)
        ' ------------------------------------
        ' 1.200 
        ' ------------------------------------
        Dim fPatmSTD As Single              ' Patm  standard condition (hPa)
        Dim fTempSTD As Single              ' Temperature standard condition (°C)
        Dim fFilterTime As Single           ' in (s)
        ' ------------------------------------
        ' 1.300
        ' ------------------------------------
        Dim fOffsetLeak As Single            ' Offset sur la fuite
        ' ------------------------------------
        ' 1.400
        ' ------------------------------------
        Dim fVolumeRef As Single
        Dim wTpsTestCompTemp As UShort
        Dim wPourcCompTemp As UShort
        Dim wTpsWaitingTime As UShort
        Dim wLastConsigneDacEasy As UShort
        Dim fNominalValue As Single
        Dim fCoeffMin As Single
        Dim fCoeffMax As Single
    End Structure

    ' -------------------------
    ' Date structure
    ' -------------------------
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Structure F28_DATE
        Dim wYear As UShort
        Dim wMonth As UShort
        Dim wDay As UShort
        Dim wHour As UShort
        Dim wMinute As UShort
        Dim wSecond As UShort
    End Structure

    ' -------------------------
    ' Result structure
    ' -------------------------
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Structure F28_RESULT
        Dim ucStatus As Byte
        Dim fPressureValue As Single
        Dim fLeakValue As Single
        Dim ucUnitPressure As Byte
        Dim ucUnitLeak As Byte
        Dim GroupID As Byte                     ' F28_GROUP_ID
        Dim ModuleAddr As Byte                  ' F28_MODULE_ADDR
        Dim dateReceived As F28_DATE
    End Structure

    ' -------------------------
    ' real time result structure
    ' -------------------------
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Structure F28_REALTIME_CYCLE
        Dim ucEndCycle As Byte
        Dim ucStatus As Byte
        Dim fPressureValue As Single
        Dim fLeakValue As Single
        Dim ucUnitPressure As Byte
        Dim ucUnitLeak As Byte
        Dim fInternalTemperature As Single      ' Temperature in °C
        Dim fPatm As Single                     ' Abs pressure in hPa

    End Structure

    ' -------------------------
    ' Statistic structure
    ' -------------------------
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Structure F28_CYCLE_STATISTICS
        Dim dwTotalCycles As UInteger
        Dim dwFailCycles As UInteger
        Dim dwSuccessCycles As UInteger
    End Structure

    ' -------------------------
    ' Communication counter structure
    ' -------------------------
    <StructLayout(LayoutKind.Sequential, Pack:=1)> _
    Structure F28_COMMUNICATION_STATISTICS
        Dim dwTransmited As UInteger
        Dim dwReceived As UInteger
        Dim dwErrors As UInteger
    End Structure


    REM ===========================================================================================
    REM   Available functions for Ethernet interface
    REM ===========================================================================================
    ' Ethernet Info
    Structure T_ETH_INFO
        Dim strIP As String
        Dim strVersion As String
        Dim strHardVersion As String
        Dim strSubnetMask As String
        Dim strGateway As String
        Dim strMACAddress As String
    End Structure

    Structure F28_VOLUME_LEARNING_TEST
        Dim wTempsRempTestVolumeLearn As UShort
        Dim wTempsTransfertTestVolumeLearn As UShort
        Dim fVolumePressCC As Single
        Dim fVolumeMin As Single
        Dim fVolumeMax As Single
    End Structure


    ' C++ DLL declaration
    ' unsigned short F28API	F28_GetDllMajorVersion(void);
    ' unsigned short F28API	F28_GetDllMinorVersion(void);
    ' short	F28API  F28_Init(void);
    ' short	F28API  F28_OpenChannel(BYTE ucChannelID);
    ' void	F28API  F28_Close(void);
    ' short	F28API  F28_AddModule(ULONG ulIP, BYTE ucModuleAddr, BYTE ucGroupID, BYTE ucTimeout);
    ' short	F28API	F28_ReconnectModule(short sModuleID);
    ' short F28API	F28_RemoveModule(short sModuleID);
    ' short F28API	F28_RemoveAllModules();
    ' short	F28API	F28_ResetEthernetModule(short sModuleID);
    ' short	F28API	F28_RefreshModuleInformations(short sModuleID);
    ' short	F28API	F28_GetSerialNumber(short sModuleID, LPSTR szSerialNumber, unsigned short wLength);
    ' short	F28API	F28_GetModuleSoftVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
    ' short	F28API	F28_GetModuleHardVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
    ' short	F28API	F28_GetModuleCANAddress(short sModuleID);
    ' short F28API	F28_IsModuleConnected(short sModuleID);
    ' short F28API	F28_JumpApplicationMode(short sModuleID);
    ' short F28API	F28_JumpBootMode(short sModuleID);
    ' short F28API	F28_GetMode(short sModuleID);
    ' short F28API	F28_StartCycle(short sModuleID);
    ' short F28API	F28_StopCycle(short sModuleID);
    ' short F28API	F28_StartAutoZeroPressure(short sModuleID, float fDumpTime);
    ' short	F28API	F28_StartRegulatorAdjust(short sModuleID);
    ' short	F28API	F28_StartLearningRegulator(short sModuleID, float fDumpTime);		// 1.500
    ' short	F28API	F28_GetModuleParameters(short sModuleID, F28_PARAMETERS* pPara);
    ' short	F28API	F28_SetModuleParameters(short sModuleID, F28_PARAMETERS* pPara);
    ' short F28API	F28_GetRealTimeData(short sModuleID, F28_REALTIME_CYCLE* pCycle);
    ' short F28API	F28_GetLastResult(short sModuleID, F28_RESULT* pResult);
    ' short F28API  F28_GetCycleStatistics(short sModuleID, F28_CYCLE_STATISTICS* pInfo);
    ' short F28API  F28_GetCommunicationStatistics(short sModuleID, F28_COMMUNICATION_STATISTICS* pInfo);
    ' short	F28API	F28_GetAddressIP(short sModuleID, ULONG* pAddressIP);
    ' short	F28API	F28_GetSubnetMask(short sModuleID, ULONG* pAddressIP);
    ' short	F28API	F28_GetGatewayAddressIP(short sModuleID, ULONG* pAddressIP);
    ' short	F28API	F28_GetMACAddress(short sModuleID, LPSTR szMAC, unsigned short wLength);
    ' short	F28API	F28_GetETHSoftVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
    ' short	F28API	F28_GetETHHardVersion(short sModuleID, LPSTR szVersion, unsigned short wLength);
    ' short F28API	F28_StartCycleByGroup(BYTE ucGroupID);
    ' short F28API	F28_StopCycleByGroup(BYTE ucGroupID);
    ' WORD	F28API	F28_F28_GetResultsCount(m_sModuleID)(short sModuleID);
    ' short	F28API	F28_GetNextResult(short sModuleID, F28_RESULT* pResult);
    ' short F28API	F28_ClearFIFOResults(short sModuleID);
    ' UCHAR	F28API	F28_GetEOCOffset(short sModuleID);
    ' UCHAR	F28API	F28_GetEOCVolume(short sModuleID);
    ' UCHAR	F28API	F28_GetAutoCalAlarm(short sModuleID);
    ' short F28API	F28_StartAutoCalOffsetOnly(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fOffsetMax);
    ' short F28API	F28_StartAutoCalOffset(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fOffsetMax);
    ' short F28API	F28_StartAutoCalVolume(short sModuleID, WORD wNbCycles, WORD wInterCycleTime, float fLeak, float fPressure, float fVolMin, float fVolMax);
    ' short F28API	F28_StopAutoCal(short sModuleID);

#If _64BITS Then
    Public Declare Function F28_GetDllMinorVersion Lib "F28LightControl_ETH64.dll" () As Short
    Public Declare Function F28_GetDllMajorVersion Lib "F28LightControl_ETH64.dll" () As Short

    ' -------------------------------------------------
    ' Connection
    ' -------------------------------------------------

    Public Declare Function F28_Init Lib "F28LightControl_ETH64.dll" () As Short
    Public Declare Function F28_OpenChannel Lib "F28LightControl_ETH64.dll" () As Short
    Public Declare Sub F28_Close Lib "F28LightControl_ETH64.dll" ()

    ' -------------------------------------------------
    ' Create/Search F28 modules 
    ' -------------------------------------------------
    ' 1.504
    Public Declare Function F28_AddModule Lib "F28LightControl_ETH64.dll" (ByVal ulIP As UInteger, ByVal ucModuleAddr As Byte, ByVal ucGroupID As Byte, ucTimeout As Byte) As Short
    Public Declare Function F28_ReconnectModule Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    Public Declare Function F28_RemoveModule Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_RemoveAllModules Lib "F28LightControl_ETH64.dll" () As Short

    ' DLL - 1.404
    Public Declare Function F28_ResetEthernetModule Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    ' -------------------------------------------------
    ' F28 Informations
    ' -------------------------------------------------

    Public Declare Function F28_RefreshModuleInformations Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_GetSerialNumber Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal szSerialNumber As String, ByVal Length As UShort) As Short
    Public Declare Function F28_GetModuleSoftVersion Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal szSoftVersion As String, ByVal Length As UShort) As Short
    Public Declare Function F28_GetModuleHardVersion Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal szHardVersion As String, ByVal Length As UShort) As Short

    ' -------------------------------------------------
    ' F28 Control
    ' -------------------------------------------------

    Public Declare Function F28_IsModuleConnected Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_JumpApplicationMode Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_JumpBootMode Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    Public Declare Function F28_GetMode Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StartCycle Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StopCycle Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    ' -------------------------------------------------
    ' Special cycles
    ' -------------------------------------------------

    Public Declare Function F28_StartAutoZeroPressure Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal fDumpTime As Single) As Short

    ' DLL 1.402 20/10/15
    Public Declare Function F28_StartRegulatorAdjust Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    ' DLL 1.500 23/12/15
    Public Declare Function F28_StartLearningRegulator Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal fDumpTime As Single) As Short

    ' V2.0.0.4
    Public Declare Function F28_StartJetCheck Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    ' V2.15 12/04/2019
    Public Declare Function X28_StartVolumeLearning Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Para As F28_VOLUME_LEARNING_TEST, ByVal bTest As Integer) As Short
    Public Declare Function X28_StartVidageInfini Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

    ' -------------------------------------------------
    ' Edit programs/Parameters
    ' -------------------------------------------------

    Public Declare Function F28_GetModuleParameters Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Para As F28_PARAMETERS) As Short
    Public Declare Function F28_SetModuleParameters Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Para As F28_PARAMETERS) As Short

    ' -------------------------------------------------
    ' Results FIFO
    ' -------------------------------------------------

    Public Declare Function F28_GetRealTimeData Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Cycle As F28_REALTIME_CYCLE) As Short
    Public Declare Function F28_GetLastResult Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Result As F28_RESULT) As Short

    ' -------------------------------------------------
    ' Statistics/Counters
    ' -------------------------------------------------

    Public Declare Function F28_GetCycleStatistics Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Info As F28_CYCLE_STATISTICS) As Short
    Public Declare Function F28_GetCommunicationStatistics Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Info As F28_COMMUNICATION_STATISTICS) As Short

    ' -------------------------------------------------
    ' Ethernet information
    ' -------------------------------------------------

    ' 1.504
    Public Declare Function F28_GetAddressIP Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef pAddressIP As UInteger) As Short
    Public Declare Function F28_GetSubnetMask Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef pAddressIP As UInteger) As Short
    Public Declare Function F28_GetGatewayAddressIP Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef pAddressIP As UInteger) As Short

    Public Declare Function F28_GetMACAddress Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal szMAC As String, ByVal wLength As Short) As Short
    Public Declare Function F28_GetETHSoftVersion Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal szVersion As String, ByVal wLength As Short) As Short
    Public Declare Function F28_GetETHHardVersion Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByVal szVersion As String, ByVal wLength As Short) As Short

    ' -------------------------------------------------
    ' Group Control
    ' -------------------------------------------------

    Public Declare Function F28_StartCycleByGroup Lib "F28LightControl_ETH64.dll" (ByVal ucGroupID As Byte) As Short
    Public Declare Function F28_StopCycleByGroup Lib "F28LightControl_ETH64.dll" (ByVal ucGroupID As Byte) As Short

    Public Declare Function F28_ClearFIFOResults Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_GetResultsCount Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As UShort
    Public Declare Function F28_GetNextResult Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, ByRef Result As F28_RESULT) As Short

    ' -------------------------------------------------
    ' Auto calibration 1.400
    ' -------------------------------------------------

    Public Declare Function F28_GetEOCOffset Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetEOCVolume Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetEOCRatio Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetEOCEasyAutoLearning Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetAutoCalAlarm Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_StartAutoCalOffsetOnly Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fOffsetMax As Single) As Short
    Public Declare Function F28_StartAutoCalOffset Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fOffsetMax As Single) As Short
    Public Declare Function F28_StartAutoCalVolume Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fLeak As Single, _
                                                                                      ByVal fPressure As Single, _
                                                                                      ByVal fVolMin As Single, _
                                                                                      ByVal fVolMax As Single) As Short
    Public Declare Function F28_StopAutoCal Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StartAutoRatio Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fRatiotMax As Single, _
                                                                                      ByVal fRatiotMin As Single) As Short
    Public Declare Function F28_StopAutoRatio Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StartEasyAutoLearning Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort) As Short
    Public Declare Function F28_StopEasyAutoLearning Lib "F28LightControl_ETH64.dll" (ByVal sModuleID As Short) As Short

#Else
    Public Declare Function F28_GetDllMinorVersion Lib "F28LightControl_ETH.dll" () As Short
    Public Declare Function F28_GetDllMajorVersion Lib "F28LightControl_ETH.dll" () As Short

    ' -------------------------------------------------
    ' Connection
    ' -------------------------------------------------

    Public Declare Function F28_Init Lib "F28LightControl_ETH.dll" () As Short
    Public Declare Function F28_OpenChannel Lib "F28LightControl_ETH.dll" () As Short
    Public Declare Sub F28_Close Lib "F28LightControl_ETH.dll" ()

    ' -------------------------------------------------
    ' Create/Search F28 modules 
    ' -------------------------------------------------
    ' 1.504
    Public Declare Function F28_AddModule Lib "F28LightControl_ETH.dll" (ByVal ulIP As UInteger, ByVal ucModuleAddr As Byte, ByVal ucGroupID As Byte, ucTimeout As Byte) As Short
    Public Declare Function F28_ReconnectModule Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    Public Declare Function F28_RemoveModule Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_RemoveAllModules Lib "F28LightControl_ETH.dll" () As Short

    ' DLL - 1.404
    Public Declare Function F28_ResetEthernetModule Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    ' -------------------------------------------------
    ' F28 Informations
    ' -------------------------------------------------

    Public Declare Function F28_RefreshModuleInformations Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_GetSerialNumber Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal szSerialNumber As String, ByVal Length As UShort) As Short
    Public Declare Function F28_GetModuleSoftVersion Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal szSoftVersion As String, ByVal Length As UShort) As Short
    Public Declare Function F28_GetModuleHardVersion Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal szHardVersion As String, ByVal Length As UShort) As Short

    ' -------------------------------------------------
    ' F28 Control
    ' -------------------------------------------------

    Public Declare Function F28_IsModuleConnected Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_JumpApplicationMode Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_JumpBootMode Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    Public Declare Function F28_GetMode Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StartCycle Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StopCycle Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    ' -------------------------------------------------
    ' Special cycles
    ' -------------------------------------------------

    Public Declare Function F28_StartAutoZeroPressure Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal fDumpTime As Single) As Short

    ' DLL 1.402 20/10/15
    Public Declare Function F28_StartRegulatorAdjust Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    ' DLL 1.500 23/12/15
    Public Declare Function F28_StartLearningRegulator Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal fDumpTime As Single) As Short

    ' V2.0.0.4
    Public Declare Function F28_StartJetCheck Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    ' V2.15 12/04/2019
    Public Declare Function X28_StartVolumeLearning Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Para As F28_VOLUME_LEARNING_TEST, ByVal bTest As Integer) As Short
    Public Declare Function X28_StartVidageInfini Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short

    ' -------------------------------------------------
    ' Edit programs/Parameters
    ' -------------------------------------------------

    Public Declare Function F28_GetModuleParameters Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Para As F28_PARAMETERS) As Short
    Public Declare Function F28_SetModuleParameters Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Para As F28_PARAMETERS) As Short

    ' -------------------------------------------------
    ' Results FIFO
    ' -------------------------------------------------

    Public Declare Function F28_GetRealTimeData Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Cycle As F28_REALTIME_CYCLE) As Short
    Public Declare Function F28_GetLastResult Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Result As F28_RESULT) As Short

    ' -------------------------------------------------
    ' Statistics/Counters
    ' -------------------------------------------------

    Public Declare Function F28_GetCycleStatistics Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Info As F28_CYCLE_STATISTICS) As Short
    Public Declare Function F28_GetCommunicationStatistics Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Info As F28_COMMUNICATION_STATISTICS) As Short

    ' -------------------------------------------------
    ' Ethernet information
    ' -------------------------------------------------

    ' 1.504
    Public Declare Function F28_GetAddressIP Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef pAddressIP As UInteger) As Short
    Public Declare Function F28_GetSubnetMask Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef pAddressIP As UInteger) As Short
    Public Declare Function F28_GetGatewayAddressIP Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef pAddressIP As UInteger) As Short

    Public Declare Function F28_GetMACAddress Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal szMAC As String, ByVal wLength As Short) As Short
    Public Declare Function F28_GetETHSoftVersion Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal szVersion As String, ByVal wLength As Short) As Short
    Public Declare Function F28_GetETHHardVersion Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByVal szVersion As String, ByVal wLength As Short) As Short

    ' -------------------------------------------------
    ' Group Control
    ' -------------------------------------------------

    Public Declare Function F28_StartCycleByGroup Lib "F28LightControl_ETH.dll" (ByVal ucGroupID As Byte) As Short
    Public Declare Function F28_StopCycleByGroup Lib "F28LightControl_ETH.dll" (ByVal ucGroupID As Byte) As Short

    Public Declare Function F28_ClearFIFOResults Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_GetResultsCount Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As UShort
    Public Declare Function F28_GetNextResult Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, ByRef Result As F28_RESULT) As Short

    ' -------------------------------------------------
    ' Auto calibration 1.400
    ' -------------------------------------------------

    Public Declare Function F28_GetEOCOffset Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetEOCVolume Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetEOCRatio Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetEOCEasyAutoLearning Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_GetAutoCalAlarm Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Byte
    Public Declare Function F28_StartAutoCalOffsetOnly Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fOffsetMax As Single) As Short
    Public Declare Function F28_StartAutoCalOffset Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fOffsetMax As Single) As Short
    Public Declare Function F28_StartAutoCalVolume Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fLeak As Single, _
                                                                                      ByVal fPressure As Single, _
                                                                                      ByVal fVolMin As Single, _
                                                                                      ByVal fVolMax As Single) As Short
    Public Declare Function F28_StopAutoCal Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StartAutoRatio Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort, _
                                                                                      ByVal fRatiotMax As Single, _
                                                                                      ByVal fRatiotMin As Single) As Short
    Public Declare Function F28_StopAutoRatio Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
    Public Declare Function F28_StartEasyAutoLearning Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short, _
                                                                                      ByVal wNbCycles As UShort, _
                                                                                      ByVal wInterCycleTime As UShort) As Short
    Public Declare Function F28_StopEasyAutoLearning Lib "F28LightControl_ETH.dll" (ByVal sModuleID As Short) As Short
#End If

End Class
