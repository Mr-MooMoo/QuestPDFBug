

using QuestPDF.Infrastructure;
using QuestPDFBug;

QuestPDF.Settings.License = LicenseType.Community;

Console.WriteLine("Generating PDF...");
var newFileName = Guid.NewGuid() + ".pdf";
var pdf = await PdfGenerator.GeneratePdf();
await File.WriteAllBytesAsync(newFileName, pdf);

Console.WriteLine("Saved PDF to " + newFileName);
