Imports System.ComponentModel
Imports System.Threading

Public Class MultiLotteryTimer
    Inherits LotteryTimer
    Implements INotifyPropertyChanged

    'WithEvents Timer As DispatcherTimer = Nothing
    Private OneLotteryLogic As MultiLotteryLogic
    Private IsPreStop As Boolean = False
    Private WithEvents MTimer As Timer
    'Private BingoNameReturnTextBlockArrayList As ArrayList
    Private ArrayIndex As Integer
    'Private NextLotteryTimer As Action

    Private Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub New(ByRef NameList As NameList, ByRef LotteryLogic As MultiLotteryLogic, ArrayIndex As Integer, LotteryFinishToastShow As Action)
        MyBase.New(NameList, LotteryFinishToastShow)
        OneLotteryLogic = LotteryLogic
        Me.ArrayIndex = ArrayIndex
        BingoNameReturnTextBlock = Model2TextBoxBingoNamePreset.Item(ArrayIndex)
        'Me.NextLotteryTimer = NextLotteryTimer
    End Sub

    Protected Overrides Sub Timer_Tick()
        If IsPreStop Then
            SumTime += 1
            TimeSumReturnTextBlock = CStr(2 - CInt(SumTime / 20))
            If SumTime < 40 Then                                        '2秒完成抽取
                Call OneLotteryLogic.RandomBingoIndex()
                BingoNameReturnTextBlock = OneLotteryLogic.BingoName
            Else
                SumTime = 0
                IsPreStop = False
                Call StopLottery()
            End If
        Else
            Call OneLotteryLogic.RandomBingoIndex()
            BingoNameReturnTextBlock = OneLotteryLogic.BingoName
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(BingoNameReturnTextBlock)))
    End Sub

    Public Overrides Sub StartLottery()
        MTimer = New Timer(New TimerCallback(AddressOf Timer_Tick), Me, 0, 50)
    End Sub

    Public Sub PreStopLottery()
        IsPreStop = True
    End Sub

    Protected Overrides Sub StopLottery()
        MTimer.Dispose()
        'Model2TextBoxBingoNameList.Item(ArrayIndex) = BingoNameReturnTextBlock
        Call NextLotteryTimer()
        Call OneLotteryLogic.LotteryFinishLogic(BingoNameReturnTextBlock)
    End Sub

End Class
