namespace DocumentPrinter
{
    //By introducing IHPInterface with its method to print, we will not be breaking existing code
    //where this method is already being called. By introducing extra interfaces, we'tr adding extra
    //functionality to our class to be able to print to other printers. At the same time we're making sure our
    //class is following the open-closed principle of SOLID.
    public class DocumentPrinter : IHPInterface, IDellInterface, IAsusInterface
    {

        public DocumentPrinter()
        {

        }

        /// <summary>
        /// One public method that accept a document to print
        /// Assume this is used on several places of the code
        /// </summary>
        /// <param name="document"></param>
        public void PrintDocument(object document)
        {
            var formattedDoc = FormatDocument(document);
            PrintToHp(formattedDoc);
        }


        private object FormatDocument(object document)
        {
            // Does some formatting. E.g. Add page numbers
            object formattedDocument = document;
            return formattedDocument;
        }


        public void PrintToHp(object document)
        {
            // Some code written to print a document to an HP printer
            // Note: The exercise is not aimed at actually printing documents,
            // so please assume there is no standard api, so this method
            // cannot be reused to print on other printer models
        }

        //right now these methods are not used, but we could add some methods similar to 
        //PrintDocument to call the bellow two as needed. Another solution i was thinking about
        //is to 
        public void PrintToDell(object document)
        {
            //some code to print to dell
        }

        public void PrintToAsus(object document)
        {
            //some code to print to asus
        }
    }



    //We could have created a single interface which has all these methods inside,
    //but by doing so we would be forcing all the functionality of the interface and
    //this class may not necessarily need all of it. By doing interface segregation
    //we're giving more freedom as to what functionality this class needs to implement
    public interface IHPInterface
    {
        void PrintToHp(object document);
    }

    public interface IDellInterface
    {
        void PrintToDell(object document);
    }

    public interface IAsusInterface
    {
        void PrintToAsus(object document);
    }
}
