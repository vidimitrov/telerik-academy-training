namespace ChatClient.App
{
    using System.Windows;

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public string UsernameText
        {
            get { return Username.Text; }
            set { Username.Text = value; }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            var chatClient = new ChatClientWindow();
            string greetingsText = "Welcome, ";

            chatClient.Owner = this.Owner;
            chatClient.LoggedUserText = greetingsText + this.UsernameText;
            chatClient.Show();

            this.Close();
        }
    }
}
