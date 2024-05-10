Imports System.ComponentModel
Imports System.Collections

Public Module OtherLogic

    Public MultiLotteryTimerList As LinkedList(Of MultiLotteryTimer)
    Public LotteryTimerNode As LinkedListNode(Of MultiLotteryTimer)
    Private NLLinked As LinkedList(Of String)
    Public Property IsMultiLotteryFinish As Boolean = False
    Public Property Model2ButtonAgain As ButtonAgainStatus
    Public Property TotalPeopel As Integer = 0
    Public Property LotteryCount As Integer = 0
    Private HaveLotteryCount As Integer = 0
    Public Property ProgressPageCount As Integer = 0
    Public Property ProgressPageNow As Integer = 0
    Public Property Model2TextBoxBingoNamePreset As ArrayList = New ArrayList({
            "大", "吉", "大", "利", "今", "晚", "抽", "签"
        })
    Public Property Model2OriginNameList As LinkedList(Of String)
    'Public Property Model2TimeSumReturnTextBlock As String
    Public Property Model2ProgressPageTextBlock As String
    Public Property Model2MultiLotteryLogic As MultiLotteryLogic
    Public Property Model2NameList As NameList
    Public Property Model2BingoNameStack As Stack(Of String)
    Private Model2SetBinding As Action
    Public Model2LotteryFinishToastShow As Action

    Public Sub NextLotteryTimer()
        HaveLotteryCount += 1
        If LotteryTimerNode.Next IsNot Nothing Then
            LotteryTimerNode = LotteryTimerNode.Next
            LotteryTimerNode.Value.PreStopLottery()
        Else
            If HaveLotteryCount >= LotteryCount Then
                HaveLotteryCount = 0
                IsMultiLotteryFinish = True
                MultiLotteryTimerList.Clear()
                Model2ButtonAgain.ChangeMButtonAgain()
            Else
                MultiLotteryTimerList.Clear()
                Call NewMultiTimerList()
            End If
        End If
    End Sub

    Public Sub NewMultiTimerList()
        MultiLotteryTimerList = New LinkedList(Of MultiLotteryTimer)
        Dim ValueMax As Integer = LotteryCount - HaveLotteryCount
        If ValueMax >= 8 Then
            ValueMax = 7
        Else
            ValueMax -= 1
        End If
        For i As Short = 0 To ValueMax
            Dim TimerObject As New MultiLotteryTimer(Model2NameList, Model2MultiLotteryLogic, i, Model2LotteryFinishToastShow)
            MultiLotteryTimerList.AddLast(TimerObject)
            MultiLotteryTimerList.Last.Value.StartLottery()
        Next
        Call Model2SetBinding()
        LotteryTimerNode = MultiLotteryTimerList.First
        LotteryTimerNode.Value.PreStopLottery()
    End Sub

    Public Sub StartMultiLottery(NameList As LinkedList(Of String), LCount As Integer, SetBinding As Action, LotteryFinishToastShow As Action)
        Model2ButtonAgain = New ButtonAgainStatus(False)
        Model2OriginNameList = NameList
        NLLinked = New LinkedList(Of String)(NameList)
        Model2NameList = New NameList(NLLinked)
        LotteryCount = LCount
        Model2LotteryFinishToastShow = LotteryFinishToastShow
        Model2SetBinding = SetBinding
        IsMultiLotteryFinish = False
        Model2MultiLotteryLogic = New MultiLotteryLogic(Model2NameList)
        Call NewMultiTimerList()
        'Call SetBinding()
    End Sub

    Public Class ButtonAgainStatus
        Implements INotifyPropertyChanged

        Public Property MButtonAgain As Boolean

        Public Sub New(ButtonAgain As Boolean)
            MButtonAgain = ButtonAgain
            'RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(MButtonAgain)))
        End Sub

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public Sub ChangeMButtonAgain()
            MButtonAgain = Not MButtonAgain
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(MButtonAgain)))
        End Sub
    End Class
End Module
