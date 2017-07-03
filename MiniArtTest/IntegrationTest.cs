using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using MiniArtLibrary;
using System.IO;
using System.Diagnostics;
using System;
using MiniArtLibrary.Filters;

namespace MiniArtTest
{
    [TestClass]
    public class IntegrationTest
    {
        [TestMethod]
        public void XmlToPng()
        {
            string outputFilename = Path.ChangeExtension(Path.GetTempFileName(), ".png");
            try
            {
                using (var input = new FileStream(@"TestData\Artwork.xml", FileMode.Open))
                {
                    using (var output = new FileStream(outputFilename, FileMode.OpenOrCreate))
                    {
                        input.Seek(0, SeekOrigin.Begin);
                        var serializer = new XmlSerializer(typeof(Artwork));
                        var artwork = (Artwork)serializer.Deserialize(input);
                        ArtworkUtility.CreatePng(artwork, output, new DefaultArtworkFilter());
                    }
                }
                using (var pngViewer = Process.Start(outputFilename))
                {
                    pngViewer.WaitForExit();
                }
            }
            finally
            {
                File.Delete(outputFilename);
            }
        }
    }
}
