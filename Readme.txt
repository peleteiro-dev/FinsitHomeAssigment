Overview
The programming library should contain:

    a parser: this parser transforms a string (the text is supposed to be a simplified version of the Markdown format, see below) into a document model;
    classes representing the document model;
    exporters: an exporter transforms a document model into a string representing the document in a given format (e.g., HTML).

Parsing
We want you to implement a Markdown parser supporting (only) the document items below. An example of a document with 3 sections (one of them a sub-section), including 2 paragraphs and some bold text would be:

# Section 1

Some **(bold) introduction** to Section 1.

## Section 1.1

A text describing Section 1.1

Some conclusion to Section 1.

# Section 2

An introduction to Section 2.

Some conclusion to Section 2.


A section's content finishes when another section with the same or above level starts or when the end of file is reached.

If your parser can only parse texts that look like the above, it's probably good enough, no need to add features (e.g., you don't have to implement escaping for the case the user would like to have ** in its text).

Document Model
A document contains an ordered sequence of document items. We ask you to implement only these kinds of document items:

    paragraph: an ordered sequence of text items;
    section: a title followed by a sequence of document items (e.g., paragraphs and infinitely nested sub-sections).

We ask you to implement only these kinds of text items:

    text: a string;
    bold text: a text that is emphasized.


Exporting
We want to export a document into many output formats but we ask you to implement these exporters only:

    an HTML exporter : we want as output a string containing HTML5 tags (i.e., <section>, <h1>, <p> and <strong>);
    a Mediawiki exporter: we want as output a string containing Mediawiki markup (e.g., '''bold text''');
    a Markdown exporter: we want as output a string containing Markdown markup (e.g., **bold text**); The markdown exporter is expected to output a string that can be parsed: in principle, markdown(parse(string)) should equal to string (or close enough).


Evolution
We plan to implement around 15 document/text items (e.g., italic texts, pictures, links). After that, we believe that we won't add more, or really seldom.

On the contrary, the exporters mentioned above are just a glimpse of what we want. We plan to add many exporters depending on customer's requests.



