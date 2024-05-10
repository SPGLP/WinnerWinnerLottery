Imports System.IO.Directory
Imports AMClassLibraryForSave

Public Class MultiLotteryLogic
    Inherits LotteryLogic

    Private BingoNameStack As New Stack(Of String)
    'Private IsMultiLotteryFinish As Boolean
    Private Testi As Integer = 0

    Public Sub New(ByRef NameList As NameList)
        MyBase.New(NameList)
        'Me.IsMultiLotteryFinish = IsMultiLotteryFinish
    End Sub

    Public Sub BingoNameAdd(BingoName As String)
        BingoNameStack.Push(BingoName)
    End Sub

    Public Function GetBingoNames() As String
        Dim NameListString As String = ""
        Do While BingoNameStack.Count > 0
            NameListString += BingoNameStack.Pop() & " "
        Loop
        Return NameListString
    End Function

    Public Overloads Sub LotteryFinishLogic(TimerBingoName As String)
        'MyBase.LotteryFinishLogic()
        Call BingoNameAdd(TimerBingoName)
        Call NameList.RemoveName(TimerBingoName)
        Testi += 1
        If IsMultiLotteryFinish Then
            Testi += 1
            Dim SaveLotteryLog As New SaveMultiLotteryLog(BingoName, Model2OriginNameList, BingoNameStack)
            Call SaveLotteryLog.SaveLogLogic()
            Model2BingoNameStack = BingoNameStack
            Call Model2LotteryFinishToastShow()
        End If
    End Sub

End Class

