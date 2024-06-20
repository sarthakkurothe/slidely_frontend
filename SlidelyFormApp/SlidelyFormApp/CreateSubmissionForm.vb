Imports System.Diagnostics
Imports System.Net
Imports Newtonsoft.Json

Public Class CreateSubmissionForm
    Private stopwatch As New Stopwatch()
    Private WithEvents timer As New Timer()

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        txtStopwatch.ReadOnly = True
        txtStopwatch.Text = "00:00:00"
        timer.Interval = 1000
    End Sub

    Private Sub btnToggleStopwatch_Click(sender As Object, e As EventArgs) Handles btnToggleStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            timer.Stop()
        Else
            stopwatch.Start()
            timer.Start()
        End If
        UpdateStopwatchDisplay()
    End Sub

    Private Sub UpdateStopwatchDisplay() Handles timer.Tick
        txtStopwatch.Text = String.Format("{0:hh\:mm\:ss}", stopwatch.Elapsed)
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim submission As New Dictionary(Of String, String) From {
            {"name", txtName.Text},
            {"email", txtEmail.Text},
            {"phone", txtPhoneNum.Text},
            {"github_link", txtGithubLink.Text},
            {"stopwatch_time", txtStopwatch.Text}
        }

        Using client As New WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"
            Dim json As String = JsonConvert.SerializeObject(submission)
            client.UploadString("http://localhost:3000/submit", "POST", json)
        End Using
        MessageBox.Show("Submission successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.T Then
            btnToggleStopwatch.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class
