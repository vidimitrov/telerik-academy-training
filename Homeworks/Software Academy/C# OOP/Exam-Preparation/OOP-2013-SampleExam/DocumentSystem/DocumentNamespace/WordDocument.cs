namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public class WordDocument : OfficeDocument, IEditable
    {
        public long? NumberOfCharacters { get; private set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "chars":
                    this.NumberOfCharacters = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> numOfCharsProperty = new KeyValuePair<string, object>("chars", this.NumberOfCharacters);
            output.Add(numOfCharsProperty);
        }
    }
}