namespace ChatClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MongoDB.Driver;
    using ChatClient.Data.Models;

    public static class MongoDBClient
    {
        public const string CONNECTION_STRING = @"mongodb://admin:admin@ds035260.mongolab.com:35260/chatclient";
        public const string DATABASE_NAME = "chatclient";
        public const string MESSAGES_COLLECTION_NAME = "messages";
        public const string USERS_COLLECTION_NAME = "users";

        public static MongoDatabase GetMongoDatabase()
        {
            var connectionString = CONNECTION_STRING;
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase(DATABASE_NAME);
            return database;
        }
        
        public static ICollection<Message> GetAllMessages(MongoDatabase db)
        {
            var messagesCollection = db.GetCollection(MESSAGES_COLLECTION_NAME);
            var messagesFromCollection = messagesCollection.FindAll();
            List<Message> messages = new List<Message>();

            foreach (var msg in messagesFromCollection)
            {
                string text = (string)msg["Text"];
                string date = (string)msg["Date"];
                string user = (string)msg["User"];

                Message message = new Message(user, text, date);

                messages.Add(message);
            }

            return messages;
        }

        public static void InsertMessage(MongoDatabase db, Message newMessage)
        {
            var messagesCollection = db.GetCollection(MESSAGES_COLLECTION_NAME);

            messagesCollection.Insert(newMessage);
        }
    }
}
