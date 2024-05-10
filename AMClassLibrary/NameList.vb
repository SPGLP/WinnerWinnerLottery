Imports System.IO
Imports System.IO.Directory

Public Class NameList
    Public Property List As New LinkedList(Of String)
    Public Property ListLength As Integer = -1

    Public Sub New(List As LinkedList(Of String))
        Me.List = List
        ListLength = List.Count
        'Dim Reader As StreamReader = Nothing
        'Try
        '    Reader = New StreamReader(GetCurrentDirectory() + "\NameList\NameList.txt")   '此处写入名单文件路径
        '    Dim NamesTmp As String = Reader.ReadLine()
        '    If NamesTmp = "" Then
        '        ListLength = -1
        '        Reader.Close()
        '        Exit Sub
        '    End If
        '    Dim NamesSplited As String() = Split(NamesTmp, ",")
        '    For Each ListNode As String In NamesSplited
        '        List.AddLast(ListNode)
        '    Next
        '    ListLength = List.Count
        'Catch ex As Exception
        '    MsgBox("读取名单失败，因为：" + vbCrLf + ex.Message + "请截图该错误信息并在咨询开发者时提供，开发者联系方式请查看软件【关于】页面。")
        'Finally
        '    Reader?.Close()
        'End Try
    End Sub

    Public Function FindName(Index As Integer) As String
        Dim CurrentNode As LinkedListNode(Of String) = List.First
        For i As Integer = 0 To Index - 1
            CurrentNode = CurrentNode.Next
        Next
        Return CurrentNode.Value
    End Function

    Public Function ForEachNameListLogic() As String
        Dim ReturnText As String = ""
        For Each ListNode As String In List
            ReturnText += ListNode & " "
        Next
        Return ReturnText
    End Function

    Public Sub RemoveName(Index As Integer)
        Dim CurrentNode As LinkedListNode(Of String) = List.First
        For i As Integer = 0 To Index - 1
            CurrentNode = CurrentNode.Next
        Next
        List.Remove(CurrentNode)
        ListLength = List.Count
    End Sub

    Public Sub RemoveName(Name As String)
        List.Remove(Name)
        ListLength = List.Count
    End Sub

End Class

