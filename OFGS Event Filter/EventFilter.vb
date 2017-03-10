Imports System.IO

Public Class EventFilter

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "iCal Calendar (*.ics)|*.ics|All files (*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = fd.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\"
        fd.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = fd.FileName
        End If
    End Sub

    Sub main()

        Dim ICSEvents As List(Of List(Of String))
        ICSEvents = readICS(TextBox1.Text)

        Dim csvEvents As List(Of String())
        csvEvents = readCSV(TextBox2.Text)




    End Sub

    Function readICS(filename As String)
        Dim ICSEvents As New List(Of List(Of String))
        ICSEvents.Add(New List(Of String))
        Try
            Using sr As New StreamReader(filename)
                Dim line As String
                While Not sr.EndOfStream
                    line = sr.ReadLine

                    If line.Contains("BEGIN:VEVENT") Then
                        ICSEvents.Add(New List(Of String))
                    End If
                    ICSEvents.Last.Add(line)
                End While
            End Using
        Catch e As Exception
            MsgBox(e.Message)
        End Try
        Return ICSEvents
    End Function

    Function readCSV(filename As String)
        Dim csvText As New List(Of String)
        Dim csvEvents As New List(Of String())

        Try
            Using sr As New StreamReader(filename)
                Dim line As String
                While Not sr.EndOfStream
                    line = sr.ReadLine
                    csvText.Add(line)
                End While
            End Using
        Catch e As Exception
            MsgBox(e.Message)
        End Try

        For Each eventLine In csvText
            csvEvents.Add(Split(eventLine, ","))
        Next
        Return csvEvents
    End Function

    Function filterEvents(ICSEvents As List(Of List(Of String)), csvEvents As List(Of String()))
        For Each ICSEvent In ICSEvents
            For Each eventLine In ICSEvent
                If eventLine.Contains("") Then

                End If
            Next
        Next


    End Function

    Function getEventsToPublish()

    End Function

End Class
