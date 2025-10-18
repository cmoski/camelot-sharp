using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;

namespace Camelot
{
    /// <summary>
    /// Represent an actual letter in the text as a Unicode string.
    /// Note that, while a LTChar object has actual boundaries, LTAnno objects does not, as these are
    /// "virtual" characters, inserted by a layout analyzer according to the relationship between two characters (e.g. a space).
    /// <para>https://euske.github.io/pdfminer/programming.html</para>
    /// </summary>
    internal class LTAnno : Letter
    {
        public LTAnno(string value)
            : base(
                value: value,
                glyphRectangle: new PdfRectangle(),
                startBaseLine: new PdfPoint(),
                endBaseLine: new PdfPoint(),
                width: 0,
                fontSize: 0,
                font: null,
                renderingMode: TextRenderingMode.Fill,
                strokeColor: GrayColor.Black,
                fillColor: GrayColor.Black,
                pointSize: 0,
                textSequence: -1)
        { }
    }
}