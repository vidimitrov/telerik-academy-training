namespace ChatClient.Data.Models
{
    using System;

    public class Message
    {
        public Message(string user, string text, string date)
        {
            this.User = user;
            this.Text = text;
            this.Date = date;
        }

        public string Text { get; set; }

        public string Date { get; set; }

        public string User { get; set; }
    }
}
