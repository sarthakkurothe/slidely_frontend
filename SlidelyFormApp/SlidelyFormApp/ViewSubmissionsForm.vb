Imports System.Net
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Dictionary(Of String, String))

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        LoadSubmissions()
        LoadSubmission(currentIndex)
    End Sub

    Private Sub LoadSubmissions()
        Dim url As String = "http://localhost:3000/submissions"
        Dim json As String = New WebClient().DownloadString(url)
        submissions = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, String)))(json)
    End Sub

    Private Sub LoadSubmission(index As Integer)
        Try
            If index >= 0 And index < submissions.Count Then
                Dim submission As Dictionary(Of String, String) = submissions(index)

                txtName.Text = submission("name")
                txtEmail.Text = submission("email")
                txtPhoneNum.Text = submission("phone")
                txtGithubLink.Text = submission("github_link")
                lblStopwatch.Text = submission("stopwatch_time")
            Else
                MessageBox.Show("No more submissions available.")
                If currentIndex > 0 Then
                    currentIndex -= 1
                End If
            End If
        Catch ex As WebException
            MessageBox.Show("No more submissions available.")
            If currentIndex > 0 Then
                currentIndex -= 1
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading the submission.")
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currentIndex += 1
        LoadSubmission(currentIndex)
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission(currentIndex)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim submission As Dictionary(Of String, String) = submissions(currentIndex)
            Dim email As String = submission("email")

            Using client As New WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/json"
                client.UploadString($"http://localhost:3000/delete?email={email}", "DELETE", "")
            End Using

            MessageBox.Show("Submission deleted successfully.")
            LoadSubmissions()
            If currentIndex >= submissions.Count Then
                currentIndex = submissions.Count - 1
            End If
            LoadSubmission(currentIndex)
        Catch ex As Exception
            MessageBox.Show("An error occurred while deleting the submission.")
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Dim submission As New Dictionary(Of String, String) From {
                {"name", txtName.Text},
                {"email", txtEmail.Text},
                {"phone", txtPhoneNum.Text},
                {"github_link", txtGithubLink.Text},
                {"stopwatch_time", lblStopwatch.Text}
            }

            Using client As New WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/json"
                Dim json As String = JsonConvert.SerializeObject(submission)
                client.UploadString("http://localhost:3000/edit", "PUT", json)
            End Using

            MessageBox.Show("Submission edited successfully.")
            LoadSubmissions()
            LoadSubmission(currentIndex)
        Catch ex As Exception
            MessageBox.Show("An error occurred while editing the submission.")
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim email As String = txtSearch.Text

            Using client As New WebClient()
                Dim json As String = client.DownloadString($"http://localhost:3000/search?email={email}")
                Dim searchResult As List(Of Dictionary(Of String, String)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, String)))(json)
                If searchResult.Count > 0 Then
                    submissions = searchResult
                    currentIndex = 0
                    LoadSubmission(currentIndex)
                Else
                    MessageBox.Show("No submissions found for the provided email.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while searching for the submission.")
        End Try
    End Sub

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        End If
    End Sub
End Class
