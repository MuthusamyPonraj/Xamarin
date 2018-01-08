#!/bin/sh
# Define directories.
ProjectPath=/Jenkins/workspace/ES/xamarinios-samplebrowser-schedulepublishing

if [ ! -d /Jenkins/workspace/ES/xamarinios-samplebrowser-schedulepublishing ]; then
  ProjectPath=/Jenkins/workspace/ES/xamarinios-samplebrowser
fi

mkdir $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates
mkdir $ProjectPath/xamarinios-samplebrowser/Samples/PDFViewer/Assets
mkdir $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets
mkdir $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates
mkdir $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template


cp $ProjectPath/essentialstudio-common/Data/DocIO/BkmkDocumentPart_Template.doc $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Data/DocIO/Bookmark_Template.doc $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Data/DocIO/Excel_Template.xlsx $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Data/DocIO/Products.xml $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Data/DocIO/Employees.xml $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp "$ProjectPath/essentialstudio-common/Data/DocIO/Letter Formatting.docx" $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp "$ProjectPath/essentialstudio-common/Data/DocIO/ContentControlTemplate.docx" $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp "$ProjectPath/essentialstudio-common/Data/DocIO/Doc to HTML.doc" $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp -R "$ProjectPath/essentialstudio-common/Data/DocIO/Doc to HTML.doc" $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/WordtoHTML.doc
cp $ProjectPath/essentialstudio-common/Images/DocIO/AdventureCycle.jpg $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Images/DocIO/Mountain-200.jpg $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Images/DocIO/Mountain-300.jpg $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Images/DocIO/Northwind.png $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/
cp $ProjectPath/essentialstudio-common/Images/DocIO/Road-550-W.jpg $ProjectPath/xamarinios-samplebrowser/Samples/DocIO/Templates/

cp "$ProjectPath/essentialstudio-common/Data/PDF/GIS Succinctly.pdf" $ProjectPath/xamarinios-samplebrowser/Samples/PDFViewer/Assets/
cp "$ProjectPath/essentialstudio-common/Data/PDF/F# Succinctly.pdf" $ProjectPath/xamarinios-samplebrowser/Samples/PDFViewer/Assets/
cp "$ProjectPath/essentialstudio-common/Data/PDF/HTTP Succinctly.pdf" $ProjectPath/xamarinios-samplebrowser/Samples/PDFViewer/Assets/
cp "$ProjectPath/essentialstudio-common/Data/PDF/JavaScript Succinctly.pdf" $ProjectPath/xamarinios-samplebrowser/Samples/PDFViewer/Assets/
cp "$ProjectPath/essentialstudio-common/Data/PDF/Product Catalog.pdf" $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Data/PDF/SalesOrderDetail.pdf $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Data/PDF/Products.xml $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Data/PDF/Report.xml $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Images/PDF/Xamarin_bannerEdit.jpg $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Images/PDF/Xamarin_JPEG.jpg $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Images/PDF/Xamarin_PNG.png $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp $ProjectPath/essentialstudio-common/Data/PDF/PDF.pfx $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/
cp "$ProjectPath/essentialstudio-common/Data/PDF/JavaScript Succinctly.pdf" $ProjectPath/xamarinios-samplebrowser/Samples/PDF/Assets/

cp $ProjectPath/essentialstudio-common/Data/Presentation/HelloWorld.pptx $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Data/Presentation/Images.pptx $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Data/Presentation/NewCharts.pptx $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Data/Presentation/Slides.pptx $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Images/Presentation/tablet.jpg $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Data/Presentation/Products.xml $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Data/Presentation/TableData.xml $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/
cp $ProjectPath/essentialstudio-common/Data/Presentation/SlideTableData.xml $ProjectPath/xamarinios-samplebrowser/Samples/Presentation/Templates/

cp $ProjectPath/essentialstudio-common/Data/XlsIO/FilterData.xlsx $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template/
cp $ProjectPath/essentialstudio-common/Data/XlsIO/ReplaceOptions.xlsx $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template/
cp $ProjectPath/essentialstudio-common/Data/XlsIO/AdvancedFilterData.xlsx $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template/
cp $ProjectPath/essentialstudio-common/Data/XlsIO/ChartData.xlsx $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template/
cp $ProjectPath/essentialstudio-common/Data/XlsIO/BusinessObjects.xml $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template/
cp $ProjectPath/essentialstudio-common/Data/XlsIO/customers.xml $ProjectPath/xamarinios-samplebrowser/Samples/XlsIO/Template/

