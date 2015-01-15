namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public class PDFDocument : EncryptableDocuments, IEncryptable
    {
        private long? numberOfPages;

        public long? NumberOfPages 
        { 
            get
            {
                return this.numberOfPages;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Number of pages cannot be negative!");
                }

                this.numberOfPages = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "pages":
                    this.NumberOfPages = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> numOfPagesProperty = new KeyValuePair<string, object>("pages", this.NumberOfPages);
            output.Add(numOfPagesProperty);
        }
    }
}