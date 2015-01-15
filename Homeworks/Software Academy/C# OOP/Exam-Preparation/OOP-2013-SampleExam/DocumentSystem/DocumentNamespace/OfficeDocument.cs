namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public abstract class OfficeDocument : EncryptableDocuments, IEncryptable
    {
        private string version;
        
        public string Version 
        { 
            get
            {
                return this.version;
            }
            private set
            {
                this.version = value;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "version":
                    this.Version = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> versionProperty = new KeyValuePair<string, object>("version", this.Version);
            output.Add(versionProperty);
        }
    }
}