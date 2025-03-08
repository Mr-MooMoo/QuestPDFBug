using QuestPDF.Fluent;

namespace QuestPDFBug;

public static class PdfGenerator
{
    public static async Task<byte[]> GeneratePdf()
    {
        var document = new EmptyPage();

        var tmpPdfFileName = Path.GetTempFileName();
        document.GeneratePdf(tmpPdfFileName);

        var resultTmpFile = Path.GetTempFileName();

        var metadata = await File.ReadAllTextAsync("metadata.xml");

        DocumentOperation
            .LoadFile(tmpPdfFileName)
            .AddAttachment(new DocumentOperation.DocumentAttachment
            {
                Key = "factur-zugferd",
                FilePath = "factur-x.xml",
                AttachmentName = "factur-x.xml",
                MimeType = "text/xml",
                Description = "Factur-X Invoice",
                Relationship = DocumentOperation.DocumentAttachmentRelationship.Alternative,
                CreationDate = DateTime.UtcNow,
                ModificationDate = DateTime.UtcNow
            })
            .ExtendMetadata(metadata)
            .Save(resultTmpFile);


        var resultAsBytes = await File.ReadAllBytesAsync(resultTmpFile);


        File.Delete(tmpPdfFileName);
        File.Delete(resultTmpFile);

        return resultAsBytes;
    }
}