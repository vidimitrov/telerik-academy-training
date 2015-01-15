namespace DocumentSystemEngine
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DocumentNamespace;

    public interface IDocument
    {
        string Name { get; }

        string Content { get; }

        void LoadProperty(string key, string value);

        void SaveAllProperties(IList<KeyValuePair<string, object>> output);

        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool IsEncrypted { get; }

        void Encrypt();

        void Decrypt();
    }

    public class DocumentSystem
    {
        private static IList<Document> Documents = new List<Document>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }
  
        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            foreach (var doc in Documents)
            {
                Console.WriteLine(doc);
            }
        }

        private static void EncryptDocument(string name)
        {
            bool isFound = false;
            
            foreach (var doc in Documents)
            {
                if (doc.Name == name)
                {
                    isFound = true;

                    if (doc is IEncryptable)
                    {
                        (doc as IEncryptable).Encrypt();
                        Console.WriteLine("Document encrypted: {0}", doc.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool isFound = false;
            
            foreach (var doc in Documents)
            {
                if (doc.Name == name)
                {
                    isFound = true;

                    if (doc is IEncryptable)
                    {
                        (doc as IEncryptable).Decrypt();
                        Console.WriteLine("Document decrypted: {0}", doc.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            int documentsCount = Documents.Count;
            bool isAtLeastOneEncrypted = false;

            for (int i = 0; i < documentsCount; i++)
            {
                if (Documents[i] is IEncryptable)
                {
                    isAtLeastOneEncrypted = true;
                    (Documents[i] as IEncryptable).Encrypt();
                }
            }

            if (isAtLeastOneEncrypted)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool isFound = false;
            
            foreach (var doc in Documents)
            {
                if (doc.Name == name)
                {
                    isFound = true;

                    if (doc is IEditable)
                    {
                        (doc as IEditable).ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", doc.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document is not editable: {0}", doc.Name);
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void AddDocument(Document doc, string[] attributes)
        {
            foreach (var attr in attributes)
            {
                var splittedAttributes = attr.Split('=');

                doc.LoadProperty(splittedAttributes[0], splittedAttributes[1]);
            }

            if (doc.Name != null)
            {
                Documents.Add(doc);
                Console.WriteLine("Document added: {0}", doc.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }
    }
}