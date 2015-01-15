namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BinaryDocument : Document
    {
        public long? Size { get; set; }
        
        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "size":
                    this.Size = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> sizeProperty = new KeyValuePair<string, object>("size", this.Size);
            output.Add(sizeProperty);
        }
    }
}