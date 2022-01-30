Fixen todo menos o parser
A function IsComposite usoa para determinar si se poden engadir elementos na coleccion de fillos, esa función está na clase abstracta eliminando duplicidades.
Poderia utilizala tamen no Acept para determinar si ten fillos q teñan q aceptar o Exporter(visitor), esto eliminaría o código duplicado que hay nos Acept de todos os diferentes tipos de DocumentElement
e tamén no Exporter, q tería un solo Export(DocumentElement), q á sua vez usaría IsComposite para determinar si ten q exportar o contido dos fillos.
No fixen esto ainda pq tería q facer as propiedades Content e Title parte d DocumentElement e non se usan en todos os tipos...


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




Pois xa ves, as 2 da mañan e aqui sigo...

O q hay ata agora, q diria q está bastante ben, é a parte das clases q representan o modelo documento e o exporter.
O patron composite está implementado en esas clases e tamén o visitor. O diagrama de clases enviocho por mail pq non son capaz d metelo no repo
O codigo de esto esta na carpeta FinsitHomeAssigment.Core, a estructura d carpetas debería ser facil d entender
Tamen está o Parser, xa me dirás q che parece, hay una parte sin acabar, a q parsea os textos q poden conter textos en negrita

Na carpeta FinsitHomeAssigment solo está a clase Program que é dnd se executaría a aplicación d consola, hay cádigo q utilicei para ir facendo
probas rápidas mentres programaba e unha boa parte está comentada, aquí non hay moito que ver a non ser que poidas e queiras executalo

Fixen alguns tests unitarios para a implementacion do HtmlVisitor, FinsitHomeAssigment.Core.UnitTests


