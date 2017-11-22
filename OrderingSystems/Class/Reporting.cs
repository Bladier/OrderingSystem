using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using Microsoft.VisualBasic;

namespace OrderingSystems
{
    class Reporting
    {
        public int m_currentPageIndex;
        public IList<Stream> m_streams;
        private string Fname;

        public Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {

            string tmpPath = System.IO.Path.GetTempPath();
            //Dim tmpFile As String = name + "." + fileNameExtension
            string tmpFile = GetRandomString(5) + "." + fileNameExtension;

            Fname = tmpPath + tmpFile;
            Console.WriteLine("Generating: " + Fname);

            Stream stream = new FileStream(Fname, FileMode.Create);
            //New FileStream("C:\" + name + "." + fileNameExtension, FileMode.Create)

            m_streams.Add(stream);
            return stream;
        }

        public void Export(LocalReport report, Dictionary<string, double> size = null)
        {
            string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>EMF</OutputFormat>" + "  <PageWidth>8.5in</PageWidth>" + "  <PageHeight>11in</PageHeight>" + "  <MarginTop>0.25in</MarginTop>" + "  <MarginLeft>0.25in</MarginLeft>" + "  <MarginRight>0.25in</MarginRight>" + "  <MarginBottom>0.25in</MarginBottom>" + "</DeviceInfo>";

            if ((size != null))
            {
                Console.WriteLine("Resizing Paper....");

                string paperWidth_in = size["width"].ToString("0.00");
                string paperHeight_in = size["height"].ToString("0.00");

                deviceInfo = "<DeviceInfo>" + "  <OutputFormat>EMF</OutputFormat>" + "  <PageWidth>" + paperWidth_in + "in</PageWidth>" + "  <PageHeight>" + paperHeight_in + "in</PageHeight>" + "  <MarginTop>0.25in</MarginTop>" + "  <MarginLeft>0.25in</MarginLeft>" + "  <MarginRight>0.25in</MarginRight>" + "  <MarginBottom>0.25in</MarginBottom>" + "</DeviceInfo>";
            }
            Console.WriteLine("Device Info:");
            Console.WriteLine(deviceInfo);

            Warning[] warnings = null;
            m_streams = new List<Stream>();
            report.Refresh();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            Console.WriteLine(report.GetDefaultPageSettings().PaperSize);
            Console.WriteLine(report.GetDefaultPageSettings().Margins);

            Stream stream = null;
            foreach (Stream stream_loopVariable in m_streams)
            {
                stream = stream_loopVariable;
                stream.Position = 0;
            }
        }


        public void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex += 1;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
            Console.WriteLine("Num of Pages: " + m_streams.Count);

        }

        public void Print(string printerName = null)
        {
            if (m_streams == null || m_streams.Count == 0)
            {
                return;
            }

            PrintDocument printDoc = new PrintDocument();

            if ((printerName != null))
                printDoc.PrinterSettings.PrinterName = printerName;

            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = string.Format("Can't find printer \"{0}\".", printerName);
                Console.WriteLine(msg);
                return;
            }

            printDoc.PrintPage += PrintPage;
            printDoc.PrinterSettings.Duplex = Duplex.Horizontal;
            printDoc.Print();

        }


        public void Dispose()
        {
            if ((m_streams != null))
            {
                Stream stream = null;
                foreach (Stream stream_loopVariable in m_streams)
                {
                    stream = stream_loopVariable;
                    stream.Close();
                }
                m_streams = null;
            }

        }

        private string GetRandomString(int max)
        {
            string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 8; i++)
            {
                int idx = r.Next(0, 35);
                sb.Append(s.Substring(idx, 1));
            }

            //Delay for next random value
            System.Threading.Thread.Sleep(1000);
            return sb.ToString();
        }
    }
}
