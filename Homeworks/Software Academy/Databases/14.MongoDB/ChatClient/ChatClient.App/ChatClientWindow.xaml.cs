namespace ChatClient.App
{
    using ChatClient.Data;
    using ChatClient.Data.Models;
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class ChatClientWindow : Window
    {
        public ChatClientWindow()
        {
            InitializeComponent();
        }

        public StackPanel StackPanelChatBox
        { 
            get
            {
                return this.ChatStackPanel;
            }
        }

        public string LoggedUserText
        {
            get 
            { 
                return LoggedUserTextBox.Text; 
            }
            set 
            { 
                LoggedUserTextBox.Text = value; 
            }
        }

        public string SendMessageText 
        { 
            get 
            {
                return MessageText.Text;
            }
        }

        private void Send_Message_Button_Click(object sender, RoutedEventArgs e)
        {
            string text = this.SendMessageText;
            string date = DateTime.Now.ToString();
            string user = this.LoggedUserText.Split(',')[1];
            MongoDBClient.InsertMessage(MongoDBClient.GetMongoDatabase(), new Message(user, text, date));
            LoadStackPanel(this.StackPanelChatBox);
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStackPanel((sender as StackPanel));
        }

        private void LoadStackPanel(StackPanel stackPanel)
        {
            stackPanel.Children.RemoveRange(0, stackPanel.Children.Count);

            var db = MongoDBClient.GetMongoDatabase();
            var messages = MongoDBClient.GetAllMessages(db);

            foreach (var message in messages)
            {
                string user = message.User;
                string date = message.Date;
                string text = message.Text;

                TextBox txtBox = new TextBox();
                txtBox.Text += user + ": " + text;

                stackPanel.Children.Add(txtBox);
            }
        }
    }
}
