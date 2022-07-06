using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PathofExile2.Model
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginSignupPage : TabbedPage
    {
        MockDB users;
        private SQLiteAsyncConnection connection;
        public class DBUsers
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [MaxLength(255)]
            public string username { get; set; }
            [MaxLength(255)]
            public string password { get; set; }
        }
        public LoginSignupPage()
        {
            InitializeComponent();
            users = new MockDB();
            connection = DependencyService.Get<ISQLiteDB>().GetConnection();
            connection.CreateTableAsync<DBUsers>();

        }

       
        

        public async void HandleDB_Login(object sender, System.EventArgs e)
        {
            //user inputs empty string
            if (string.IsNullOrEmpty(user.Text) || string.IsNullOrEmpty(pass.Text))
            {
                DisplayAlert("Login Failed - Username or password not provided", "Please re-enter login credentials", "Ok");
            }
            //check user input against db entries
            var query = connection.Table<DBUsers>().Where(i => i.username == user.Text).Where(i => i.password == pass.Text).FirstOrDefaultAsync();  
            
            //null check for no match vs match 
            if (query.Result == null)
            {
                DisplayAlert("Login unsucessful", "Please try again", "Ok");
            }
            else if (query.Result.username == user.Text && query.Result.password == pass.Text)
            {
                DisplayAlert(query.Result.username, "welcome " , "Ok");
            }
            
        }
       
        

        public async void Handle_Creation(object sender, System.EventArgs e)
        {
            var dbUser = username.Text;
            var dbPass = password.Text;

            DBUsers person = new DBUsers();
            person.username = dbUser;
            person.password = dbPass;

            int x = 0;

            try
            {
                x = await connection.InsertAsync(person);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (x == 1)
            {
                DisplayAlert("Registration Successful", "", "Ok");
            }
            else
            {
                DisplayAlert("Registration Failed", "Try again", "Ok");
            }
        }
    }
}