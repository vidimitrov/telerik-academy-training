namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public class ExcelDocument : OfficeDocument
    {
        public long? NumberOfRows { get; private set; }

        public long? NumberOfCols { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "rows":
                    this.NumberOfRows = long.Parse(value);
                    break;
                case "cols":
                    this.NumberOfCols = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> numOfRowsProperty = new KeyValuePair<string, object>("rows", this.NumberOfRows);
            output.Add(numOfRowsProperty);
            
            KeyValuePair<string, object> numOfColsProperty = new KeyValuePair<string, object>("cols", this.NumberOfCols);
            output.Add(numOfColsProperty);
        }
    }
}