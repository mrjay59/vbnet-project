Imports System.Windows.Automation

Public Class UiHelper

    ''' <summary>
    ''' Cari AutomationElement dengan multiple criteria
    ''' </summary>
    ''' <param name="root">Root element (misalnya mainWindow)</param>
    ''' <param name="scope">Scope pencarian (Children/Descendants)</param>
    ''' <param name="criteria">Dictionary Property → Value</param>
    ''' <returns>AutomationElement atau Nothing</returns>
    Public Shared Function FindElement(root As AutomationElement,
                                       scope As TreeScope,
                                       criteria As Dictionary(Of AutomationProperty, Object)) As AutomationElement
        If root Is Nothing Then Return Nothing
        If criteria Is Nothing OrElse criteria.Count = 0 Then Return Nothing

        ' Buat list kondisi dari dictionary
        Dim conds As New List(Of Condition)
        For Each kvp In criteria
            conds.Add(New PropertyCondition(kvp.Key, kvp.Value))
        Next

        ' Gabungkan jadi AndCondition
        Dim finalCond As Condition
        If conds.Count = 1 Then
            finalCond = conds(0)
        Else
            finalCond = New AndCondition(conds.ToArray())
        End If

        Return root.FindFirst(scope, finalCond)
    End Function

    Public Shared Function FindElementOr(root As AutomationElement,
                                         scope As TreeScope,
                                         criteria As List(Of KeyValuePair(Of AutomationProperty, Object))) As AutomationElement
        If root Is Nothing Then Return Nothing
        If criteria Is Nothing OrElse criteria.Count = 0 Then Return Nothing

        ' Buat list kondisi
        Dim conds As New List(Of Condition)
        For Each kvp In criteria
            conds.Add(New PropertyCondition(kvp.Key, kvp.Value))
        Next

        ' Gabungkan jadi OrCondition
        Dim finalCond As Condition
        If conds.Count = 1 Then
            finalCond = conds(0)
        Else
            finalCond = New OrCondition(conds.ToArray())
        End If

        Return root.FindFirst(scope, finalCond)
    End Function

End Class
