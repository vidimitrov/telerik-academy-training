namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public abstract class MultimediaDocument : BinaryDocument
    {
        public long? Length { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "length":
                    this.Length = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> lengthProperty = new KeyValuePair<string, object>("length", this.Length);
            output.Add(lengthProperty);
        }
    }
}