Public Class Form1
    Private Sub EyebotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EyebotToolStripMenuItem.Click
        System.Diagnostics.Process.Start("C:\Users\Ud12ay\Desktop\Kinect2FaceBasicsVer1\Kinect2FaceBasics_NET\bin\Debug\Kinect2FaceBasics_NET.exe")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        System.Diagnostics.Process.Start("C:\Users\Ud12ay\Desktop\KinectHandTracking\KinectHandTracking\bin\Debug\KinectHandTracking.exe")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub WavebotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WavebotToolStripMenuItem.Click
        System.Diagnostics.Process.Start("C:\Users\Ud12ay\Desktop\KinectHandTracking\KinectHandTracking\bin\Debug\KinectHandTracking.exe")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        System.Diagnostics.Process.Start("C:\Users\Ud12ay\Desktop\Kinect2FaceBasicsVer1\Kinect2FaceBasics_NET\bin\Debug\Kinect2FaceBasics_NET.exe")
    End Sub

    Private Sub GithubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GithubToolStripMenuItem.Click
        System.Diagnostics.Process.Start("www.github.com/nddave/geslite")
    End Sub

    Private Sub ProjectReferencesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProjectReferencesToolStripMenuItem.Click
        form2.show()
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditsToolStripMenuItem.Click
        form3.show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("www.github.com/nddave/geslite")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Form2.Show()
    End Sub
End Class
