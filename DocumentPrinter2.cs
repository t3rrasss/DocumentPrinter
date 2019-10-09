namespace DocumentPrinter
{
    //This aproach is different than my previous one and would require us to change code
    //wherever this class is being used, therefor I think its the the optimal solution.
    // The idea here is that we used dependancy injection
    //to inject a class which implements an IPrinter interface. The place using this class,
    //would have to pass a desired printer object as parameter to the constructor.
    public class DocumentPrinter2
    {
        private IPrinter _iPrinter;

        public DocumentPrinter2(IPrinter iPrinter)
        {
            _iPrinter = iPrinter;
        }

        /// <summary>
        /// One public method that accept a document to print
        /// Assume this is used on several places of the code
        /// </summary>
        /// <param name="document"></param>
        public void PrintDocument(object document)
        {
            var formattedDoc = FormatDocument(document);
            _iPrinter.Print(formattedDoc); //this would call the print method of whichever printer object was passed
        }


        private object FormatDocument(object document)
        {
            // Does some formatting. E.g. Add page numbers
            object formattedDocument = document;
            return formattedDocument;
        }


        //The implementation of this method would be moved to HPPrinter class's print method
        public void PrintToHp(object document)
        {
            // Some code written to print a document to an HP printer
            // Note: The exercise is not aimed at actually printing documents,
            // so please assume there is no standard api, so this method
            // cannot be reused to print on other printer models
        }
    }

    //our interface with the print method
    public interface IPrinter
    {
        void Print(object document);
    }

    //Printer class which implement the interface
    public class AsusPrinter : IPrinter
    {
        public void Print(object document)
        {
            //code to print to asus printer
        }
    }

    //Printer class which implement the interface
    public class HPPrinter : IPrinter
    {
        public void Print(object document)
        {
            //code to print to HP printer
        }
    }

    //This is a class which would require to print a document
    public class PlaceWePrintFrom {

        private void DoSomething()
        {
            Object ourPrintObject = new object();

            //Print to Asus
            DocumentPrinter2 dp2 = new DocumentPrinter2(new AsusPrinter());
            dp2.PrintDocument(ourPrintObject);

            //Print to Asus
            DocumentPrinter2 dp2_2 = new DocumentPrinter2(new HPPrinter());
            dp2.PrintDocument(ourPrintObject);
        }
    }
}
