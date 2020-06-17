using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using System.IO;
using Inspinia_MVC5_SeedProject.Models;
namespace Inspinia_MVC5_SeedProject.PdfReport
{
    public class IssuesReport
    {
        #region Declaration
        int _totalColum = 6;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfPTable = new PdfPTable(6);
        PdfPCell _pdfPCell;
        MemoryStream _MemoryStream = new MemoryStream();
        List<Issue> _issues = new List<Issue>();
        #endregion

        public byte[] PrepareReport(string desde, string hasta, List<Issue> issues)
        {
            _issues = issues;
            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _MemoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 100f, 100f, 120f, 50f, 70f, 30f });
            #endregion
            this.ReportHeader(desde, hasta);
            this.ReportBody();
            _pdfPTable.HeaderRows = 2;
            _document.Add(_pdfPTable);
            _document.Close();
            return _MemoryStream.ToArray();


        }
        private void ReportHeader(string desde, string hasta)
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Resumen de tareas desde: " + desde + " hasta " + hasta + ".", _fontStyle));
            _pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Tareas", _fontStyle));
            _pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);



            _pdfPTable.CompleteRow();


        }
        private void ReportBody()
        {
            #region Table header    
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Creó", _fontStyle));
            //_pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);


            _pdfPCell = new PdfPCell(new Phrase("Estado", _fontStyle));
            //_pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);



            _pdfPCell = new PdfPCell(new Phrase("Titulo", _fontStyle));
            //_pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cliente", _fontStyle));
            //_pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Asignado a", _fontStyle));
            //_pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Tiempo", _fontStyle));
            //_pdfPCell.Colspan = _totalColum;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            //_pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);





            _pdfPTable.CompleteRow();
            #endregion
            #region table body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            int Id = 1;
            foreach (Issue issue in _issues)
            {
                _pdfPCell = new PdfPCell(new Phrase(issue.CreadaPorId.ToString(), _fontStyle));
                //_pdfPCell.Colspan = _totalColum;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(issue.FechaCerradaString, _fontStyle));
                //_pdfPCell.Colspan = _totalColum;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);



                Anchor titulo = new iTextSharp.text.Anchor(issue.Titulo);
                titulo.Font.Size = 7;
                titulo.Reference = issue.FechaCreadaString;
                //_pdfPCell.Colspan = _totalColum;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(titulo);

                _pdfPCell = new PdfPCell(new Phrase(issue.Clientes.Nombre.ToString(), _fontStyle));
                //_pdfPCell.Colspan = _totalColum;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase(issue.TecnicoAsignadoId.ToString(), _fontStyle));
                //_pdfPCell.Colspan = _totalColum;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(_pdfPCell);

                Anchor tiempo = new iTextSharp.text.Anchor(issue.TiempoDedicado.ToString());
                tiempo.Font.Size = 7;
                tiempo.Reference = issue.FechaCreadaString;
                //_pdfPCell.Colspan = _totalColum;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //_pdfPCell.Border = 0;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                //_pdfPCell.ExtraParagraphSpace = 0;
                _pdfPTable.AddCell(tiempo);



                _pdfPTable.CompleteRow();
            }
            #endregion
        }
    }
}