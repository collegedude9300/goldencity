using System;
using System.Diagnostics;
using System.Collections.Generic;
using GoldenCities.ClassModels;
using Xamarin.Forms;
//using Auth0;
using SQLite;

namespace GoldenCities
{
    public partial class RegisterActivity : ContentPage
    {
        string temp_hold = "";
        bool password_accept = false, password_confrim = false, date_correct = false;
        string[] userInfo_hold = new string[6];


        public RegisterActivity()
        {
            InitializeComponent();
        }

        async void Handle_Errors(string mesg)
        {
            await DisplayAlert("Error", mesg, "OK");
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;

            if (entry.Text.Length <= 50)
            {
                temp_hold = entry.Text;
            }
            else
            {
                entry.Text = temp_hold;
                temp_hold = "";
            }

            Handle_Completed(entry, null);
        }

        void Handle_TextChanged_Dof(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;

            int i = entry.Text.Length;



            if (String.IsNullOrEmpty(entry.Text) || entry.Text[i - 1] == '/')
            {
                goto DONE;
            }

            else if (i <= 10 && char.IsNumber(entry.Text[i - 1]))
            {
                temp_hold = entry.Text;
            }

            else if (i > 10 || !char.IsNumber(entry.Text[i - 1]))
            {
                entry.Text = temp_hold;
                temp_hold = "";
            }

        DONE:
            Handle_Completed(entry, null);
        }

        void Handle_Completed_Dof(object sender, System.EventArgs e)
        {
            string date = DOF.Text;
            int dateSize = DOF.Text.Length;
            date_correct = false;

            if (dateSize != 10)
            {
                Handle_Errors("Invalid Date");
                DOF.Text = "";
                goto ERROR;
            }
            else
            {
                DateTime Temp;
                if (!DateTime.TryParse(date, out Temp))
                {
                    Handle_Errors("Invalid Date");
                    DOF.Text = "";
                    goto ERROR;
                }

                string year = "";
                year += date[6];
                year += date[7];
                year += date[8];
                year += date[9];
                int numVal = Int32.Parse(year);

                if (numVal < 1920 || numVal > 2018)
                {
                    Handle_Errors("Invalid Date");
                    DOF.Text = "";
                    goto ERROR;
                }
                else
                {
                    date_correct = true;
                }
            }

        ERROR:
            Handle_Completed(null, null);
        }

        void Handle_Completed(object sender, System.EventArgs e)
        {
            userInfo_hold[0] = Frist_Name_Entry.Text;
            userInfo_hold[1] = Last_Name_Entry.Text;
            userInfo_hold[2] = DOF.Text;
            userInfo_hold[3] = Email_Entry.Text;
            userInfo_hold[4] = Username_Entry.Text;
            userInfo_hold[5] = Password_Entry.Text;

            //userInfo_hold[5] = Address_Entry.Text;
        }

        void Handle_Completed_Password(object sender, System.EventArgs e)
        {
            string pass = Password_Entry.Text;
            password_accept = false;
            int i = 0;
            int upper = 0, num = 0;
            bool lower = false, special = false;



          
            if (pass.Length < 6)
            {
                Handle_Errors("Password must be at least 6 characters");
                return;
            }

            while (i < pass.Length)
            {
                if (Char.IsUpper(pass[i]))
                {
                    upper++;
                }
                else if (Char.IsLower(pass[i]))
                {
                    lower = true;
                }
                else if (Char.IsNumber(pass[i]))
                {
                    num++;
                }

                else if (!Char.IsLetter(pass[i]) && !Char.IsNumber(pass[i]))
                {
                    special = true;
                }

                if (upper >= 2 && num >= 2 && lower && special)
                {
                    password_accept = true;
                    break;
                }
                i++;
            }

            if (!password_accept)
            {
                Handle_Errors("Password must have at least 2 Uppercase, 2 Nummbers 1 lowercase and 1 special character");
                return;
            }
            else
            {
                Handle_Completed(null, null);
            }
        }

        void Handle_Completed_Confirm(object sender, System.EventArgs e)
        {
            string pass = Password_Entry.Text;
            string confirm = ConfirmPassword_Entry.Text;

            password_confrim = false;

            if (String.IsNullOrEmpty(confirm))
            {
                Handle_Errors("Password does not match");
            }
            else if (pass == confirm)
            {
                password_confrim = true;
                Handle_Completed(null, null);
            }
            else
            {
                Handle_Errors("Password does not match");
            }
        }

        void reset()
        {
            userInfo_hold[0] = Frist_Name_Entry.Text = "";
            userInfo_hold[1] = Last_Name_Entry.Text = "";
            userInfo_hold[2] = DOF.Text = "";
            userInfo_hold[3] = Email_Entry.Text = "";
            userInfo_hold[4] = Username_Entry.Text = "";
            userInfo_hold[5] = Password_Entry.Text = "";
            //userInfo_hold[5] = Address_Entry.Text = "";

            Password_Entry.Text = "";
            ConfirmPassword_Entry.Text = "";
            date_correct = false;
            password_accept = false;
            password_confrim = false;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Handle_Completed(null, null);

            bool filled_error = false;

            for (int i = 0; i < 5; i++)
            {
                if (String.IsNullOrEmpty(userInfo_hold[i]))
                {
                    filled_error = true;
                    break;
                }
            }

            if (filled_error)
            {
                Handle_Errors("One or more fields is blank");
            }
            else if (!filled_error)
            {
                Handle_Completed_Password(null, null);
                Handle_Completed_Confirm(null, null);
                if (password_accept == password_confrim)
                {
                    Handle_Completed_Dof(null, null);
                    if (date_correct)
                    {
                        
                        //Push data into database

                        //Console.WriteLine("Creating database, if it doesn't already exist");
                        //string dbPath = Path.Combine(
                            // Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                           //  "ormdemo.db3");
                        // var db = new SQLiteConnection(dbPath);


                        reset();
                        Debug.WriteLine($"**** {this.GetType().Name}.{nameof(Handle_Clicked)}");

                    }
                }
            }
        }
    }
}