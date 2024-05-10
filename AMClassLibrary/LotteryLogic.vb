Imports AMClassLibraryForSave

Public Class LotteryLogic
    Protected BingoIndex As Integer = 0
    Public Property BingoName As String
    Protected Random As New Random
    Protected NameList As NameList

    'Public Sub New(List As LinkedList(Of String))
    '    NameList = New NameList(List)
    'End Sub

    Public Sub New(ByRef NameList As NameList)
        Me.NameList = NameList

    End Sub

    Public Sub RandomBingoIndex()
        BingoIndex = Random.Next(0, NameList.ListLength)
        Call LotteryBingoName()
    End Sub

    Protected Sub LotteryBingoName()
        BingoName = NameList.FindName(BingoIndex)
    End Sub

    Public Overridable Sub LotteryFinishLogic()
        Dim SaveLotteryLog As New SaveLotteryLog(BingoName, NameList.List)
        Call SaveLotteryLog.SaveLogLogic()
    End Sub
End Class
