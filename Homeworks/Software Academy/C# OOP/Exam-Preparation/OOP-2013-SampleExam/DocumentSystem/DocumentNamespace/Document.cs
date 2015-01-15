namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }
        
        public virtual void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "name":
                    this.Name = value;
                    break;
                case "content":
                    this.Content = value;
                    break;
                default:
                    break;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            KeyValuePair<string, object> nameProperty = new KeyValuePair<string, object>("name", this.Name);
            output.Add(nameProperty);
            KeyValuePair<string, object> contentProperty = new KeyValuePair<string, object>("content", this.Content);
            output.Add(contentProperty);
        }

        public override string ToString()
        {
            StringBuilder docAsString = new StringBuilder();

            docAsString.Append(this.GetType().Name + "[");

            List<KeyValuePair<string, object>> keyValuePairs = new List<KeyValuePair<string, object>>();
            SaveAllProperties(keyValuePairs);
            var sortedPairs = keyValuePairs.OrderBy(kv => kv.Key);

            List<string> properties = new List<string>();
            foreach (var prop in sortedPairs)
            {
                if (prop.Value != null)
                {
                    properties.Add(prop.Key + "=" + prop.Value);
                }
            }

            docAsString.Append(String.Join(";", properties));
            docAsString.Append("]");

            return docAsString.ToString();
        }
    }
}