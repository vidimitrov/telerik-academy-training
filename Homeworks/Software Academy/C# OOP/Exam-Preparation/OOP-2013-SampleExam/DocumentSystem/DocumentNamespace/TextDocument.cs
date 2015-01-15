namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TextDocument : Document, IEditable
    {
        private string charset;
        
        public string Charset
        {
            get 
            {
                return this.charset;
            }
            private set
            {
                this.charset = value;
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "charset":
                    this.Charset = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> charsetProperty = new KeyValuePair<string, object>("charset", this.Charset);
            output.Add(charsetProperty);
        }
    }
}