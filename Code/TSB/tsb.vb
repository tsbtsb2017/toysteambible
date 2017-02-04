Option Strict Off
Option Explicit On
Friend Class TSB_Generator
	Inherits System.Windows.Forms.Form
	Private Declare Function ShellExecute Lib "shell32.dll"  Alias "ShellExecuteA"(ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
	
	Dim tyManufacturer As MANUFACTURER_DETAILS
    Dim iPagesProcessed As Integer
    Dim iPagesUpdated As Integer

	
	Private Sub cmdBuildManufacturerPage_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdBuildManufacturerPage.Click
		
		Dim oC As New ADODB.Connection
		Dim oRs As ADODB.Recordset
        Dim tyBlank As New MANUFACTURER_DETAILS
		Dim i As Short
		Dim sPage As String
		Dim sLinks As String
		Dim sManufacturer As String
		Dim sManufacturerDir As String
		Dim l As Integer
		Dim sDate As String
		Dim sFlag As String
		Dim aLinks(500) As String
		Dim iLinkCount As Short
		Dim sTable As String
		Dim iRows As Short

        iPagesProcessed = 0
        iPagesUpdated = 0

		cmdBuildManufacturerPage.Enabled = False
		oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

		oC.BeginTrans()
		' Find list of manufacturers
		oRs = oC.Execute("select distinct manufacturer from steam_engines order by manufacturer")
		
		
		oRs.MoveFirst()
		sLinks = ""
		' Build title page link
		For i = 0 To oRs.RecordCount - 1
			sManufacturer = Trim(oRs.Fields("manufacturer").Value)
			sManufacturerDir = Replace(sManufacturer, " ", "_")
			
			'UPGRADE_WARNING: Couldn't resolve default property of object tyManufacturer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			tyManufacturer = tyBlank
			FindManufacturerDetails(sManufacturer, tyManufacturer)
			
			If tyManufacturer.FlagCode <> "???" Then
				sFlag = "<img src='Flags/" & tyManufacturer.FlagCode & ".gif' alt='" & tyManufacturer.Country & " flag' title='" & tyManufacturer.Country & "'></img>"
			Else
				sFlag = "<img src='Flags/Unknown.gif' alt='unknown country flag' title='Unknown'></img>"
			End If
			
			
			sLinks = sFlag & "<a href='" & sManufacturerDir & "/index.htm'>" & sManufacturer & "</a>"
			
			' Store links in array
			aLinks(i + 1) = sLinks
			
			BuildManufacturerPage(sManufacturer, sManufacturerDir)
			
			oRs.MoveNext()
		Next i
		
		iLinkCount = oRs.RecordCount
		
		oC.CommitTrans()
		
		oC.Close()
		
		sPage = ReadTemplate(sRootPath & "\index_template.htm")
		
		' Build table of manufacturers
		
        iRows = CShort(Microsoft.VisualBasic.Format((iLinkCount / 4) - 0.5, "0"))
		
		If iLinkCount Mod 4 > 0 Then iRows = iRows + 1
		
		sTable = "<table width='100%'>"
		For i = 1 To iRows
			sTable = sTable & "<tr>"
			
			sTable = sTable & "<td>" & aLinks(i) & "</td>"
			sTable = sTable & "<td>" & aLinks(i + iRows) & "</td>"
			sTable = sTable & "<td>" & aLinks(i + (iRows * 2)) & "</td>"
			sTable = sTable & "<td>" & aLinks(i + (iRows * 3)) & "</td>"
			
			sTable = sTable & "</tr>"
			
		Next i
		sTable = sTable & "</table>"
		sPage = Replace(sPage, "%%%INSERT 1%%%", sTable)
		
		
		' Work out title page totals
		l = SelectValue("select count(*) as dvalue from steam_engines")
		sPage = Replace(sPage, "%%%SECOUNT%%%", CStr(l))
		
		l = SelectValue("select sum(number_of_images) as dvalue from steam_engines")
		sPage = Replace(sPage, "%%%PCOUNT%%%", CStr(l))
		
		sDate = FindLatestEngine()
		sPage = Replace(sPage, "%%%UDATE%%%", sDate)
		
		sPage = Replace(sPage, "%%%RND%%%", RandomDigits())
		
		WritePage(sPage, sRootPath & "\index.htm")
		
		
		BuildRecentEngines()

        sPage = ReadTemplate(sRootPath & "\links_template.htm")
        WritePage(sPage, sRootPath & "\links.htm")

		
		Me.Text = "Build is okay.   " & CStr(Now)
		
		cmdBuildManufacturerPage.Enabled = True
	End Sub
	
	Sub BuildManufacturerPage(ByRef sManufacturer As String, ByRef sManufacturerDir As String)
		
		Dim sPage As String
		
		Dim oC As New ADODB.Connection
		Dim oRs As ADODB.Recordset
		Dim i As Short
		Dim sLinks As String
		Dim sModel As String
		Dim sModelDir As String
		Dim sNoNotes As String
		
		oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)
		
		oC.BeginTrans()
		' Find list of manufacturers
		oRs = oC.Execute("select distinct engine_model from steam_engines where manufacturer='" & sManufacturer & "' order by engine_model")
		
		
		oRs.MoveFirst()
		sLinks = ""
		' Build title page link
		For i = 0 To oRs.RecordCount - 1
			sModel = Trim(oRs.Fields("engine_model").Value)
			sModelDir = Replace(sModel, " ", "_")
			sModelDir = Replace(sModelDir, "#", "")
			
			
			sLinks = sLinks & "<a href='" & sModelDir & ".htm'>" & sModel & "</a><br />" & vbCrLf
			
			BuildModelPage(sManufacturer, sManufacturerDir, sModel, sModelDir)
			
			oRs.MoveNext()
		Next i
		
		oC.CommitTrans()
		
		oC.Close()
		
		sPage = ReadTemplate(sRootPath & "\manufacturer_page_template.htm")
		
		If tyManufacturer.Notes = "TBA" Then
			sNoNotes = "Details about manufacturer %%%MAN%%% needed here.  Can anyone help?  Please email some text to subtsb@gmail.com."
			
			sPage = Replace(sPage, "%%%MDESC%%%", sNoNotes)
		Else
			sPage = Replace(sPage, "%%%MDESC%%%", tyManufacturer.Notes)
		End If
		
		
		sPage = Replace(sPage, "%%%MAN%%%", sManufacturer)
		
		sPage = Replace(sPage, "%%%LINKS%%%", sLinks)
		
		sPage = Replace(sPage, "%%%RND%%%", RandomDigits())
		
		WritePage(sPage, sRootPath & "\" & sManufacturerDir & "\index.htm")
		
		
	End Sub
	
	Sub BuildModelPage(ByRef sManufacturer As String, ByRef sManufacturerDir As String, ByRef sModel As String, ByRef sModelDir As String)
		
		Dim sPage As String
		
		Dim oC As New ADODB.Connection
		Dim oRs As ADODB.Recordset
		Dim i As Short
		Dim sDetails As String
		
		Dim sModelTemplate As String
		Dim sCurrentModel As String
		Dim sSEN As String
		Dim sEngineDate As String
		Dim sOwner As String
		Dim sOwnerURL As String
		Dim sEngineNotes As String
		Dim iNumberOfImages As Short
        'Dim sUpdateDate As String
		Dim iImage As Short
		Dim sImageLinks As String
		Dim sTitle As String
		Dim iCount As Short
        Dim sImageAltText As String
        Dim sVideoURL As String
		
		sModelTemplate = ReadTemplate(sRootPath & "\model_template.htm")
		
		oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)
		
		oC.BeginTrans()
		' Find list of manufacturers/models
        oRs = oC.Execute("select  steam_engine_id,engine_date,owner_name,owner_url,engine_notes,number_of_images,update_date,video_url from steam_engines where manufacturer='" & sManufacturer & "' and engine_model='" & sModel & "' order by sort_field asc")
		
		

        iCount = oRs.RecordCount
        If iCount > 0 Then oRs.MoveFirst()

		sDetails = ""
		' Build model details
		For i = 0 To oRs.RecordCount - 1
			
			sCurrentModel = sModelTemplate
			
			sSEN = Trim(oRs.Fields("steam_engine_id").Value)
			sEngineDate = Trim(oRs.Fields("engine_date").Value)
			sOwner = Trim(oRs.Fields("owner_name").Value)
			sOwnerURL = Trim(oRs.Fields("owner_url").Value)
			sEngineNotes = Trim(oRs.Fields("engine_notes").Value)
			iNumberOfImages = oRs.Fields("number_of_images").Value
			sImageAltText = "steam engine " & sManufacturer & " " & sModel & " " & sEngineDate
            sVideoURL = oRs.Fields("video_url").Value
			
			' Build Image Links
			sImageLinks = ""
			For iImage = 1 To iNumberOfImages
				
				sImageLinks = sImageLinks & "<a href='JavaScript://Click here to change image' onclick=" & Chr(34) & "ChangePicture('img_%%%SEN%%%','%%%SEN%%%_%%%IMGC%%%.jpg')" & Chr(34) & ">_%%%IMGC%%%_</a>     "
				sImageLinks = Replace(sImageLinks, "%%%SEN%%%", sSEN)
				sImageLinks = Replace(sImageLinks, "%%%IMGC%%%", CStr(iImage))
			Next iImage
			
			
			sCurrentModel = Replace(sCurrentModel, "%%%SEN%%%", sSEN)
			sCurrentModel = Replace(sCurrentModel, "%%%DATE%%%", sEngineDate)
			sCurrentModel = Replace(sCurrentModel, "%%%OWNER%%%", sOwner)
			sCurrentModel = Replace(sCurrentModel, "%%%WEBSITE%%%", sOwnerURL)
			sCurrentModel = Replace(sCurrentModel, "%%%NOTES%%%", sEngineNotes)
			sCurrentModel = Replace(sCurrentModel, "%%%IMAGE_LINKS%%%", sImageLinks)
			sCurrentModel = Replace(sCurrentModel, "%%%ALT%%%", sImageAltText)

            If sVideoURL.Trim <> "" Then
                sCurrentModel = Replace(sCurrentModel, "%%%VIDEO%%%", "<br />Video:    <a href='%%%VVVV%%%'>%%%VVVV%%%</a><br />")
                sCurrentModel = Replace(sCurrentModel, "%%%VVVV%%%", sVideoURL)
            Else
                sCurrentModel = Replace(sCurrentModel, "%%%VIDEO%%%", "")
            End If
			
			
			
			
			' Add this model to our details string
			sDetails = sDetails & sCurrentModel
			oRs.MoveNext()
		Next i
		
		oC.CommitTrans()
		
		oC.Close()
		
		sPage = ReadTemplate(sRootPath & "\model_page_template.htm")
		
		sPage = Replace(sPage, "%%%MAN%%%", sManufacturer)
		sPage = Replace(sPage, "%%%MODEL%%%", sModel)
		
		If sManufacturer <> "Jensen" Then
			If iCount = 1 Then
				sTitle = sManufacturer & " " & sModel & ""
			Else
				sTitle = CStr(iCount) & " " & sManufacturer & " " & sModel & ""
			End If
		Else
			' Jensen override!
			If iCount = 1 Then
				sTitle = sModel & ""
			Else
				sTitle = CStr(iCount) & " " & sModel & ""
			End If
			
		End If
		
		sPage = Replace(sPage, "%%%TITLE%%%", sTitle)
		sPage = Replace(sPage, "%%%MODEL_DETAILS%%%", sDetails)
		
		sPage = Replace(sPage, "%%%RND%%%", RandomDigits())
		
		WritePage(sPage, sRootPath & "\" & sManufacturerDir & "\" & sModelDir & ".htm")
		
		
	End Sub
	Function ReadTemplate(ByRef sFile As String) As String
		
		Dim iFile As Short
        Dim sOutput As String = ""
		Dim sData As String
		
		iFile = FreeFile
		FileOpen(iFile, sFile, OpenMode.Input)
		
		While Not EOF(iFile)
			sData = LineInput(iFile)
			sOutput = sOutput & sData & vbCrLf
		End While
		
		FileClose(iFile)
		ReadTemplate = sOutput
		
    End Function
    Function RemoveRandomBits(ByVal sData As String) As String

        Dim iStart As Integer, iEnd As Integer
        Dim sReturn As String = ""

        ' Remove Random Bits
        iStart = sData.IndexOf("<!-- Random Digit String:")
        If iStart > 0 Then
            sReturn = Microsoft.VisualBasic.Left(sData, iStart)
            iEnd = sData.IndexOf("-->", iStart + 1)
            sReturn += Microsoft.VisualBasic.Mid(sData, iEnd + 4)
        End If
        Return sReturn
    End Function
	Sub WritePage(ByRef sData As String, ByRef sFileName As String)
		
		Dim iFile As Short
        Dim sOldData As String = ""
        Dim sNewData As String

        iPagesProcessed += 1

        ' Remove Random Bits
        sNewData = RemoveRandomBits(sData)

        ' Read Old Page
        Try
            sOldData = ReadTemplate(sFileName)

            ' Remove Random Bits
            sOldData = RemoveRandomBits(sOldData)
        Catch ex As Exception

        End Try



        ' If different or old does not exist then write new page
        If sOldData.Trim <> sNewData.Trim Then

            iPagesUpdated += 1
            iFile = FreeFile()
            FileOpen(iFile, sFileName, OpenMode.Output)

            PrintLine(iFile, sData)

            FileClose(iFile)
        Else
            '  Stop
        End If

        lblUp1.Text = "Pages Processed:" + iPagesProcessed.ToString
        lblUp2.Text = "Pages Updated:" + iPagesUpdated.ToString
        Me.Refresh()
        Application.DoEvents()

    End Sub

    Private Sub cmdLoad_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLoad.Click
        cmdLoad.Enabled = False
        System.Windows.Forms.Application.DoEvents()

        LoadSteamData()
        LoadManufacturerData()
        cmdLoad.Enabled = True
        cmdBuildManufacturerPage.PerformClick()
    End Sub

    Private Sub cmdShow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShow.Click
        ShellExecute(0, "open", sRootPath & "\index.htm", "", "", 0)

    End Sub

    Private Sub cmdShow2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdShow2.Click

        ShellExecute(0, "open", "http://www.toysteambible.org", "", "", 0)

    End Sub

    Private Sub Command1_Click()
        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        Dim i As Short

        oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()
        'oC.Execute "create table mc(sname varchar(100))"
        oC.Execute("insert into mc values ('cressey')")
        oC.Execute("insert into mc values('jones')")
        oC.CommitTrans()

        oRs = oC.Execute("select * from mc")

        'MsgBox oRs.RecordCount

        oRs.MoveFirst()

        For i = 0 To oRs.RecordCount - 1
            Debug.Print(oRs.Fields("sname").Value)
            oRs.MoveNext()
        Next i

        oC.Close()



    End Sub
    Function SelectValue(ByRef sSql As String) As Integer

        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        Dim i As Integer

        oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()

        oRs = oC.Execute(sSql)

        i = oRs.Fields("dvalue").Value

        oC.CommitTrans()
        oC.Close()
        SelectValue = i
    End Function
    Function FindLatestEngine() As String

        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        'Dim i As Integer
        Dim s As String

        oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()

        oRs = oC.Execute("select max(update_date) as udate from steam_engines")

        s = Microsoft.VisualBasic.Format(CDate(oRs.Fields("udate").Value), "dd-MMM-yyyy HH:mm:ss")


        oC.CommitTrans()
        oC.Close()
        FindLatestEngine = s

    End Function

    Sub BuildRecentEngines()


        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        'Dim i As Integer
        'Dim s As String
        Dim sPage As String
        Dim sLinks As String
        Dim sSEN As String
        Dim sEngineDate As String
        Dim sOwner As String
        Dim sOwnerURL As String
        Dim sEngineNotes As String
        Dim iNumberOfImages As Short
        '	Dim sUpdateDate As String
        Dim sEngineModel As String
        Dim sDate As String
        Dim sManufacturer As String
        Dim sManufacturerDir As String
        Dim sModelDir As String

        oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        ' oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()


        oRs = oC.Execute("select manufacturer, engine_model,steam_engine_id,engine_date,owner_name,owner_url,engine_notes,number_of_images,update_date from steam_engines order by update_date desc, manufacturer,engine_model") '  limit 200")

        oRs.MoveFirst()

        sLinks = ""
        While Not oRs.EOF

            sManufacturer = Trim(oRs.Fields("manufacturer").Value)
            sManufacturerDir = Replace(sManufacturer, " ", "_")
            sEngineModel = Trim(oRs.Fields("engine_model").Value)
            sSEN = Trim(oRs.Fields("steam_engine_id").Value)
            sEngineDate = Trim(oRs.Fields("engine_date").Value)
            sOwner = Trim(oRs.Fields("owner_name").Value)
            sOwnerURL = Trim(oRs.Fields("owner_url").Value)
            sEngineNotes = Trim(oRs.Fields("engine_notes").Value)
            iNumberOfImages = oRs.Fields("number_of_images").Value
            sDate = Microsoft.VisualBasic.Format(oRs.Fields("update_date").Value, "dd-MMM-yyyy HH:mm")
            sModelDir = Replace(sEngineModel, " ", "_")
            sModelDir = Replace(sModelDir, "#", "")

            sLinks = sLinks & "<tr>"
            sLinks = sLinks & "<td width='25%'><a href='" & sManufacturerDir & "/" & sModelDir & ".htm'>" & sDate & "</a></td>"
            sLinks = sLinks & "<td width='25%'>" & sManufacturer & "</td>"
            sLinks = sLinks & "<td width='25%'>" & sEngineModel & "</td>"
            sLinks = sLinks & "<td width='25%'>" & sOwner & "</td>"
            sLinks = sLinks & "</tr>"

            oRs.MoveNext()

        End While

        oC.CommitTrans()
        oC.Close()

        sPage = ReadTemplate(sRootPath & "\recent_page_template.htm")

        sPage = Replace(sPage, "%%%INSERT 1%%%", sLinks)

        WritePage(sPage, sRootPath & "\recent_additions.htm")


    End Sub

    Private Sub cmdUpload_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpload.Click

        Shell(sRootPath & "\code\updatesite.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub TSB_Generator_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Randomize()

        oMainForm = Me

        sRootPath = "D:\projects\tsbgit"  ' Change this to point at the root directory where the files are

    End Sub
    Function RandomDigits() As String

        Dim i As Short
        Dim r As Short
        Dim l As Short
        Dim sOutput As String

        i = CShort(Rnd() * 50) + 15
        sOutput = ""
        For l = 1 To i

            r = CShort(Rnd() * 24) + 1
            sOutput = sOutput & Chr(r + 65)

        Next l

        RandomDigits = sOutput
    End Function

 
    Private Sub cmdValidate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidate.Click

        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        Dim tyBlank As New MANUFACTURER_DETAILS
        Dim i As Short

        Dim sLinks As String
        Dim sManufacturer As String
        Dim sManufacturerDir As String
      
        Dim iLinkCount As Short
        Dim aDirs() As String
        Dim oDirList As New List(Of String)
        Dim sErr As String = ""


        ' Get directories

        aDirs = System.IO.Directory.GetDirectories(sRootPath)

        For Each sDir As String In aDirs
            If sDir.ToLower.Contains("\code") Or sDir.ToLower.Contains("\flags") Then
                ' Do nothing
            Else
                oDirList.Add(sDir.ToLower)
            End If

        Next
        iPagesProcessed = 0
        iPagesUpdated = 0

        cmdValidate.Enabled = False

        oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()
        ' Find list of manufacturers
        oRs = oC.Execute("select distinct manufacturer from steam_engines order by manufacturer")


        oRs.MoveFirst()
        sLinks = ""
        ' Build title page link
        For i = 0 To oRs.RecordCount - 1
            sManufacturer = Trim(oRs.Fields("manufacturer").Value)
            ' Console.WriteLine(i.ToString + ":" + sManufacturer)
            sManufacturerDir = sRootPath + "\" + Replace(sManufacturer, " ", "_")
            sManufacturerDir = sManufacturerDir.ToLower

            tyManufacturer = tyBlank
            FindManufacturerDetails(sManufacturer, tyManufacturer)

            ' Check directory exists
            If oDirList.Contains(sManufacturerDir) Then
                sErr += ValidateManufacturer(sManufacturer, sManufacturerDir)

                ' Remove directory as it's been checked
                oDirList.Remove(sManufacturerDir)
            Else
                sErr += "Directory:" + sManufacturerDir + " is not found."
            End If
            ' Check flag exists
            oRs.MoveNext()
        Next i
        If oDirList.Count > 0 Then
            sErr += "Found " + oDirList.Count.ToString + " directories that shouldn't exist."
        End If

        iLinkCount = oRs.RecordCount

        oC.CommitTrans()

        oC.Close()

        If sErr <> "" Then
            MsgBox(sErr)
        Else
            lblValidation.Text = "Validation Result:  OK!"
        End If
       
        cmdValidate.Enabled = True
    End Sub

    Function ValidateManufacturer(ByVal sManufacturer As String, ByVal sManufacturerDir As String) As String
        Dim sErr As String = ""
        Dim oC As New ADODB.Connection
        Dim oRs As ADODB.Recordset
        Dim i As Short
        Dim sLinks As String
        Dim sModel As String
        Dim sModelFile As String
        Dim aFiles() As String
        Dim oFiles As New List(Of String)
        Dim iPics As Integer
        Dim sPicFile As String
        Dim iEngine As Integer


        aFiles = System.IO.Directory.GetFiles(sManufacturerDir)

        For Each sFile As String In aFiles
            If Not sFile.ToLower.Contains("thumbs.db") And Not sFile.ToLower.Contains("index.htm") Then
                oFiles.Add(sFile.ToLower)
            End If

        Next



   
        oC.CursorLocation = ADODB.CursorLocationEnum.adUseClient

        'oC.Open("dsn=tsbdb")
        ConnectToDb(oC)

        oC.BeginTrans()
        ' Find list of manufacturers
        oRs = oC.Execute("select distinct engine_model from steam_engines where manufacturer='" & sManufacturer & "' order by engine_model")


        oRs.MoveFirst()

        ' Build title page link
        For i = 0 To oRs.RecordCount - 1
            sModel = Trim(oRs.Fields("engine_model").Value)
            sModelFile = Replace(sModel, " ", "_")
            sModelFile = sManufacturerDir + "\" + Replace(sModelFile, "#", "") + ".htm"
            sModelFile = sModelFile.ToLower

            If Not oFiles.Contains(sModelFile) Then
                sErr += "Missing File:" + sModelFile + vbCrLf
            Else
                oFiles.Remove(sModelFile)
            End If

            oRs.MoveNext()
        Next i


        ' Check entry an pictures exist
        oRs = oC.Execute("select  steam_engine_id,number_of_images from steam_engines where manufacturer='" & sManufacturer & "' order by steam_engine_id asc")

        oRs.MoveFirst()
        For i = 0 To oRs.RecordCount - 1
            iPics = CInt(Val(oRs.Fields("number_of_images").Value))
            iEngine = CInt(Val(oRs.Fields("steam_engine_id").Value))
            For ipic As Integer = 1 To iPics
                sPicFile = sManufacturerDir + "\" + iEngine.ToString + "_" + ipic.ToString + ".jpg"
                sPicFile = sPicFile.ToLower

                If Not oFiles.Contains(sPicFile) Then
                    sErr += "Missing picture:" + sPicFile + vbCrLf
                Else
                    oFiles.Remove(sPicFile)
                End If

            Next

            oRs.MoveNext()

        Next i


        If oFiles.Count > 0 Then
            For Each sF As String In oFiles
                sErr += "Extra File:" + sF + vbCrLf
                '   IO.File.Copy(sF, "d:\photos\tsb\code\old_files\" + IO.Path.GetFileName(sF), True)
            Next


        End If


        oC.CommitTrans()



        oC.Close()


        Return sErr
    End Function
End Class