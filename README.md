# Camelot.Sharp

This is a maintained fork of [BobLd's camelot-sharp](https://github.com/BobLd/camelot-sharp) with bug fixes and improvements.

**Original author:** BobLd  
**Maintained by:** cmoski

## Recent Improvements

- **v0.0.3**: Fixed Lattice parser text splitting for multi-column tables
  - Improved vertical proximity detection for text grouping
  - Better handling of text elements with slight vertical offsets
  - Prevents incorrect text merging across columns

# Usage
## Stream mode 
```csharp
using (PdfDocument doc = PdfDocument.Open(@"Files\foo.pdf", new ParsingOptions() { ClipPaths = true }))
{
	Stream stream = new Stream();
	var tables = stream.ExtractTables(doc.GetPage(1));

	Assert.Single(tables);
	Assert.Equal((612, 792), stream.Dimensions);
	Assert.Equal(612, stream.PdfWidth);
	Assert.Equal(792, stream.PdfHeight);
	//Assert.Equal(84, stream.HorizontalText.Count);

	var parsingReport = tables[0].ParsingReport();
	//   parsing_report = {"accuracy": 99.02, "whitespace": 12.24, "order": 1, "page": 1}
	parsingReport["order"] = 1;
	parsingReport["page"] = 1;
}
```

## Lattice mode
```csharp
using (var doc = PdfDocument.Open(@"Files\column_span_2.pdf", new ParsingOptions() { ClipPaths = true }))
{
	var page = doc.GetPage(1);

	Lattice lattice = new Lattice(new OpenCvImageProcesser(), new BasicSystemDrawingProcessor(), line_scale: 40);
	var tables = lattice.ExtractTables(page,
		layout_kwargs: new DlaOptions[]
		{
			new DocstrumBoundingBoxes.DocstrumBoundingBoxesOptions()
			{
				WithinLineMultiplier = 2
			}
		});
	Assert.Single(tables);
	Assert.Equal(DataLatticeShiftTextLeftTop.Length, tables[0].Cells.Count);
	Assert.Equal(DataLatticeShiftTextLeftTop, tables[0].Data().Select(r => r.Select(c => c).ToArray()).ToArray());
}

```
