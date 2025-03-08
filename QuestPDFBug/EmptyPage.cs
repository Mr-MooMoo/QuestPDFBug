using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDFBug;

public class EmptyPage : IDocument
{


    public DocumentSettings GetSettings() => new DocumentSettings()
    {
        PdfA = true
    };


    private DocumentMetadata DocumentMetadata() => new DocumentMetadata()
    {
        Title = $"Rechnung",
        Author = "Someone",
        Subject = $"Rechnung - Nr",
        CreationDate = DateTimeOffset.Now,
        ModifiedDate = DateTimeOffset.Now,
    };


    public void Compose(IDocumentContainer container)
    {
        container.Page(p =>
        {
            p.DefaultTextStyle(TextStyle.Default.DisableFontFeature(FontFeatures.StandardLigatures));
            p.Content().Text("Some Text...");
        });
    }
}