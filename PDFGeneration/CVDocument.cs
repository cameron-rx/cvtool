namespace cvtool.PDFGeneration;

using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

public class CVDocument 
{

	public static void Build() {

		QuestPDF.Settings.License = LicenseType.Community;

		var document = Document.Create(container => 
		{
			container.Page(page => 
			{
				page.Size(PageSizes.A4);
				page.Margin(2, Unit.Centimetre);
				page.PageColor(Colors.White);
				page.DefaultTextStyle(x => x.FontSize(20));

				page.Header()
				.Text("Cameron Robinson").SemiBold().FontSize(16);


				page.Content()
				.PaddingVertical(1, Unit.Centimetre)
				.Column(x => 
				{
					x.Spacing(20);

					x.Item().Text(Placeholders.LoremIpsum());
					x.Item().Image(Placeholders.Image(200, 100));
				}
				);

				page.Footer()
				.AlignCenter()
				.Text(x =>
				{
					x.Span("Page ");
					x.CurrentPageNumber();
				});
			});
		});

		document.ShowInCompanion();

	}
}
