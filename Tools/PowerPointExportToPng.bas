Attribute VB_Name = "ExportToPng"
Option OnExplicitOn


Const ReadyFolder = "...\Mini Art\Ready\"
Const PublishedFolder = "...\Mini Art\Published\"
Const TitleShapeName = "Title"
Const UnpublishedSectionIndex = 2


Sub ExportSelectedSlidesToPng()
   
    If ActiveWindow.Selection.Type <> ppSelectionSlides Then
        MsgBox "No slides selected"
        
    Else
   
        Dim slide As slide
        For Each slide In ActiveWindow.Selection.SlideRange
            Dim title As String
            title = GetTitle(slide)
            
            If Not SlideIsNew(title) Then
                MsgBox ("Slide '" + title + "' has already been exported. Skipping to next selected slide.")
            Else
                ExportSlideAsPng slide, title
            End If
        Next
        
    End If
End Sub


Function GetTitle(slide As slide) As String
    Dim rawTitle As String
    rawTitle = slide.Shapes(TitleShapeName).TextFrame.TextRange.Text
    GetTitle = UCase(Left(rawTitle, 1)) & Mid(rawTitle, 2)
End Function


Function SlideIsNew(title As String) As Boolean
   SlideIsNew = (Dir(ReadyFolder + "*" + title + "*") = "") And _
                (Dir(PublishedFolder + "*" + title + "*") = "")
End Function


Sub ExportSlideAsPng(slide As slide, title As String)
    Dim fileName As String
    fileName = GetNextAvailableFileName(title)
    slide.Export fileName, FilterName:="PNG"
    slide.MoveTo (ActivePresentation.SectionProperties.FirstSlide(UnpublishedSectionIndex))
    MsgBox ("Slide '" + title + "' exported as " + fileName)
End Sub


Function GetNextAvailableFileName(title As String)
    Dim fileName As String
    Dim dateOffset As Integer
    dateOffset = -1
    Do
        dateOffset = dateOffset + 1
        fileName = ReadyFolder + Format(DateAdd("d", dateOffset, Date), "YYYY-MM-DD") + "*"
    Loop Until Dir(fileName) = ""
    GetNextAvailableFileName = ReadyFolder + Format(DateAdd("d", dateOffset, Date), "YYYY-MM-DD") + " " + title + ".png"
End Function

