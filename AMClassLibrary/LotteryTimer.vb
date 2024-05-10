Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Threading

Public Class LotteryTimer
    Implements INotifyPropertyChanged

    Protected SumTime As Integer = 0
    Private WithEvents Timer As Timer
    Private LotteryLogic As LotteryLogic
    'Private TextBlockUpdate As Action
    Private LotteryFinishToastShow As Action
    Public Property BingoNameReturnTextBlock As String
    Public Property TimeSumReturnTextBlock As String
    Public Property ButtonAgain As Boolean
    'Private ButtonAgain As Button

    Private Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New(ByRef NL As NameList, LotteryFinishToastShow As Action)
        'Timer = New Timer(New TimerCallback(AddressOf Timer_Tick), Nothing, 0, 50)
        'Timer.Interval = TimeSpan.FromMilliseconds(50)
        LotteryLogic = New LotteryLogic(NL)
        Me.LotteryFinishToastShow = LotteryFinishToastShow
        'Me.TextBlockUpdate = TextBlockUpdate
        'BingoNameReturnTextBlock = "TEST"
        'TimeSumReturnTextBlock = "5"
        'ButtonAgain = True
        'Me.ButtonAgain = ButtonAgain
    End Sub

    'Public Sub New()
    '    Timer = Nothing
    '    LotteryLogic = Nothing
    '    BingoNameReturnTextBlock = Nothing
    '    TimeSumRetrunTextBlock = Nothing
    '    ButtonAgain = Nothing
    'End Sub

    Protected Overridable Sub Timer_Tick()
        SumTime += 1
        TimeSumReturnTextBlock = CStr(5 - CInt(SumTime / 20))
        If SumTime < 100 Then
            Call LotteryLogic.RandomBingoIndex()
            BingoNameReturnTextBlock = LotteryLogic.BingoName
        Else
            SumTime = 0
            Call StopLottery()
        End If
        'Call TextBlockUpdate()
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(BingoNameReturnTextBlock)))
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(TimeSumReturnTextBlock)))
    End Sub

    Public Overridable Sub StartLottery()
        ButtonAgain = False
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ButtonAgain)))
        Timer = New Timer(New TimerCallback(AddressOf Timer_Tick), Me, 0, 50)
    End Sub

    Protected Overridable Sub StopLottery()
        Timer.Dispose()
        Call LotteryLogic.LotteryFinishLogic()
        Call LotteryFinishToastShow()
        ButtonAgain = True
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(ButtonAgain)))
    End Sub

End Class
