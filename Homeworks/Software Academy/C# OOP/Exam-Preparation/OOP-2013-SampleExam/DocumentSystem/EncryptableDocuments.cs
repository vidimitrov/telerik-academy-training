using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentSystemEngine.DocumentNamespace;

namespace DocumentSystemEngine
{
    public abstract class EncryptableDocuments : BinaryDocument
    {
        public bool IsEncrypted { get; private set; }

        public void Encrypt()
        {
            if (!this.IsEncrypted)
            {
                this.IsEncrypted = !this.IsEncrypted;
            }
        }

        public void Decrypt()
        {
            if (this.IsEncrypted)
            {
                this.IsEncrypted = !this.IsEncrypted;
            }
        }

        public override string ToString()
        {
            if (this.IsEncrypted)
            {
                string encryptedDocAsString = this.GetType().Name + "[encrypted]";
                return encryptedDocAsString;
            }
            else
            {
                return base.ToString();
            }
        }
    }
}
