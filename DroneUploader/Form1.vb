Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports MetadataExtractor
Imports MetadataExtractor.Formats.Xmp
Imports System.Net.Http
Imports System.Net.Http.Handlers

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            My.Settings.src_ordner = FolderBrowserDialog1.SelectedPath
            My.Settings.Save()
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
        Button2.Enabled = True
        ListBox1.Items.Clear()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.src_ordner
        If Not File.Exists("uploaded_files.txt") Then
            ' Die Datei erstellen
            File.Create("uploaded_files.txt").Close()
        End If

        ComboBox1.SelectedIndex = My.Settings.orto_src
        ComboBox2.SelectedIndex = My.Settings.view_src
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
        classify_files.RunWorkerAsync(TextBox1.Text)
        Button2.Enabled = False
    End Sub
    Private Sub classify_files_DoWork(sender As Object, e As DoWorkEventArgs) Handles classify_files.DoWork

        Dim return_files As New List(Of DroneImage)
        Dim anz_orto As Integer = 0
        Dim anz_view As Integer = 0
        Dim anz_sum As Integer = 0

        Dim myfiles = System.IO.Directory.GetFiles(e.Argument, "*.JPG", System.IO.SearchOption.AllDirectories)
        For Each file In myfiles
            If CheckIfLineExists(Path.GetFileName(file)) Then
                classify_files.ReportProgress(0, file + " - bereits hochgeladen.")
            Else
                Dim image As DroneImage = GetExifData(file)

                If image.ImageSource = ComboBox2.Items.Item(My.Settings.view_src) Then
                    classify_files.ReportProgress(0, file + " - G.Roll " + image.GimbalRollDegree.ToString + " G.Yaw: " + image.GimbalYawDegree.ToString + " G.Pitch: " + image.GimbalPitchDegree.ToString + "SRC: " + image.ImageSource)
                    return_files.Add(image)
                    anz_view = anz_view + 1
                End If

                If image.ImageSource = ComboBox1.Items.Item(My.Settings.orto_src) Then
                    If image.isOrtogonal Then
                        classify_files.ReportProgress(0, file + " - G.Roll " + image.GimbalRollDegree.ToString + " G.Yaw: " + image.GimbalYawDegree.ToString + " G.Pitch: " + image.GimbalPitchDegree.ToString + "SRC: " + image.ImageSource + " ortogonal")
                        anz_orto = anz_orto + 1
                        return_files.Add(image)
                    End If
                End If
            End If
        Next
        e.Result = return_files
        classify_files.ReportProgress(0, "Bildersuche abgeschlossen. Bilder im Ordner: " + myfiles.Count.ToString + " davon Ortogonal: " + anz_orto.ToString + " davon View: " + anz_view.ToString)
    End Sub

    Private Sub classify_files_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles classify_files.ProgressChanged
        ListBox1.Items.Insert(0, e.UserState)
    End Sub

    Dim uploadFiles As List(Of DroneImage)

    Private Sub classify_files_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles classify_files.RunWorkerCompleted
        uploadFiles = e.Result
        Button3.Enabled = True
    End Sub

    Function GetExifData(imagePath As String) As DroneImage
        Dim xmpDirectory = ImageMetadataReader.ReadMetadata(imagePath).OfType(Of XmpDirectory)().FirstOrDefault()
        Dim retImage As New DroneImage
        For Each [property] In xmpDirectory.XmpMeta.Properties
            Select Case [property].Path
                Case "xmp:CreateDate"
                    retImage.CreateDate = [property].Value
                Case "drone-dji:ImageSource"
                    retImage.ImageSource = [property].Value
                Case "drone-dji:GpsLatitude"
                    retImage.GpsLatitude = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:GpsLongitude"
                    retImage.GpsLongitude = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:AbsoluteAltitude"
                    retImage.AbsoluteAltitude = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:RelativeAltitude"
                    retImage.RelativeAltitude = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:GimbalRollDegree"
                    retImage.GimbalRollDegree = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:GimbalYawDegree"
                    retImage.GimbalYawDegree = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:GimbalPitchDegree"
                    retImage.GimbalPitchDegree = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:FlightRollDegree"
                    retImage.FlightRollDegree = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:FlightYawDegree"
                    retImage.FlightYawDegree = Double.Parse([property].Value, NumberStyles.Float, CultureInfo.InvariantCulture)
                Case "drone-dji:CameraSerialNumber"
                    retImage.CameraSerialNumber = [property].Value
                Case "drone-dji:DroneSerialNumber"
                    retImage.DroneSerialNumber = [property].Value
            End Select
        Next
        retImage.filePath = imagePath
        retImage.FileHash = GenerateFileHash(imagePath)

        If retImage.GimbalPitchDegree < -87 Then
            retImage.isOrtogonal = True
        End If
        Return retImage
    End Function

    Function GenerateFileHash(filePath As String) As String
        Try
            Using fileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)
                Using md5 As MD5 = MD5.Create()
                    ' Hash-Wert berechnen
                    Dim hashBytes As Byte() = md5.ComputeHash(fileStream)

                    ' Byte-Array in eine Zeichenfolge umwandeln
                    Dim sb As StringBuilder = New StringBuilder()
                    For i As Integer = 0 To hashBytes.Length - 1
                        sb.Append(hashBytes(i).ToString("x2"))
                    Next

                    Return sb.ToString()
                End Using
            End Using
        Catch ex As Exception
            ' Fehler behandeln
            Console.WriteLine("Fehler beim Generieren des Hash-Werts: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        upload_files.RunWorkerAsync(uploadFiles)
        Button3.Enabled = False
        ProgressBar1.Enabled = True
        ProgressBar1.Maximum = uploadFiles.Count
        ProgressBar2.Enabled = True
        ProgressBar2.Maximum = 100
    End Sub

    Private Sub upload_files_DoWork(sender As Object, e As DoWorkEventArgs) Handles upload_files.DoWork
        Dim uploadImages As List(Of DroneImage) = e.Argument
        Dim pos As Integer = 1

        For Each image In uploadImages
            uploadFile(image)
            Dim retdata As New bgw_upload_status
            retdata.pos = pos
            retdata.action = "progress"
            upload_files.ReportProgress(0, retdata)
            pos = pos + 1
        Next

        If uploadImages.Count() > 0 Then
            '     Dim responseText As String = PerformHttpGetRequest("https://api.h2com.eu/api/feuerwehr/droneupload/" + formattedDate)
        End If

    End Sub
    Private WithEvents progressMessageHandler As New ProgressMessageHandler(New HttpClientHandler())
    Private httpClient As New HttpClient(progressMessageHandler)

    Async Sub uploadFile(image As DroneImage)
        Dim retdata As New bgw_upload_status

        Using content As New MultipartFormDataContent()

            content.Add(New StringContent(image.FileHash), "FileHash")
            content.Add(New StringContent(image.CreateDate.ToString("yyyy-MM-dd H:mm:ss")), "CreateDate")
            content.Add(New StringContent(image.ImageSource), "ImageSource")
            content.Add(New StringContent(image.GpsLatitude), "GpsLatitude")
            content.Add(New StringContent(image.GpsLongitude), "GpsLongitude")
            content.Add(New StringContent(image.AbsoluteAltitude), "AbsoluteAltitude")
            content.Add(New StringContent(image.RelativeAltitude), "RelativeAltitude")
            content.Add(New StringContent(image.GimbalRollDegree), "GimbalRollDegree")
            content.Add(New StringContent(image.GimbalYawDegree), "GimbalYawDegree")
            content.Add(New StringContent(image.GimbalPitchDegree), "GimbalPitchDegree")
            content.Add(New StringContent(image.FlightRollDegree), "FlightRollDegree")
            content.Add(New StringContent(image.FlightYawDegree), "FlightYawDegree")
            content.Add(New StringContent(image.CameraSerialNumber), "CameraSerialNumber")
            content.Add(New StringContent(image.DroneSerialNumber), "DroneSerialNumber")

            Dim fileContent As New ByteArrayContent(System.IO.File.ReadAllBytes(image.filePath))
            fileContent.Headers.ContentDisposition = New System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") With {
                .Name = "image",
                .FileName = System.IO.Path.GetFileName(image.filePath)
                }
            content.Add(fileContent)

            Dim url As String = My.Settings.server_url & "/api/drone/image"
            Dim response = httpClient.PostAsync(url, content)

            If response.Result.IsSuccessStatusCode Then
                retdata.msg = "POST-Request erfolgreich. (" + response.Result.Content.ReadAsStringAsync.Result + ")"
                '    AppendLineToFile(Path.GetFileName(image.filePath))
            Else
                retdata.msg = "Fehler beim POST-Request. Statuscode: (" + response.Result.Content.ReadAsStringAsync.Result + ") URL: " & url
            End If
            retdata.action = "log"
            upload_files.ReportProgress(0, retdata)
        End Using
        '   
    End Sub

    Private Sub HttpClient_SendProgress(sender As Object, e As HttpProgressEventArgs) Handles progressMessageHandler.HttpSendProgress
        Dim retdata As New bgw_upload_status
        retdata.action = "progress1"
        retdata.pos = e.ProgressPercentage
        upload_files.ReportProgress(0, retdata)
    End Sub

    Private Sub upload_files_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles upload_files.ProgressChanged

        Dim retdata As bgw_upload_status = e.UserState

        If retdata.action = "progress" Then
            Label7.Text = retdata.pos.ToString + "/" + ProgressBar1.Maximum.ToString
            ProgressBar1.Value = retdata.pos
        End If
        If retdata.action = "progress1" Then
            ProgressBar2.Value = retdata.pos
            Label8.Text = retdata.pos.ToString + "/" + ProgressBar2.Maximum.ToString
        End If
        If retdata.action = "log" Then
            ListBox1.Items.Insert(0, retdata.msg)
        End If


    End Sub




    Private Sub upload_files_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles upload_files.RunWorkerCompleted
        ListBox1.Items.Insert(0, "Upload abgeschlossen!")
    End Sub

    Sub AppendLineToFile(ByVal line As String)
        ' Verwenden von StreamWriter mit Append-Option zum Anhängen einer Zeile an eine Datei
        Using writer As New StreamWriter("uploaded_files.txt", True)
            writer.WriteLine(line)
        End Using
    End Sub
    Function CheckIfLineExists(ByVal lineToCheck As String) As Boolean
        ' Überprüfen, ob die Zeile in der Datei vorhanden ist
        Using reader As New StreamReader("uploaded_files.txt")
            While Not reader.EndOfStream
                Dim currentLine As String = reader.ReadLine()
                If currentLine = lineToCheck Then
                    ' Die Zeile wurde gefunden
                    Return True
                End If
            End While
        End Using

        ' Die Zeile wurde nicht gefunden
        Return False
    End Function



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        My.Settings.orto_src = ComboBox1.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        My.Settings.view_src = ComboBox2.SelectedIndex
        My.Settings.Save()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class


Class bgw_upload_status
    Property action As String
    Property msg As String
    Property pos As Integer
End Class

Public Class DroneImage
    Property filePath As String
    Property FileHash As String
    Property CreateDate As DateTime
    Property ImageSource As String
    Property GpsLatitude As Double
    Property GpsLongitude As Double
    Property AbsoluteAltitude As Double
    Property RelativeAltitude As Double
    Property GimbalRollDegree As Double
    Property GimbalYawDegree As Double
    Property GimbalPitchDegree As Double
    Property FlightRollDegree As Double
    Property FlightYawDegree As Double
    Property CameraSerialNumber As String
    Property DroneSerialNumber As String
    Property isOrtogonal As Boolean = False

End Class