using System;

using UIKit;
using Auth0.OidcClient;
using System.Text;

namespace GoldenCities.iOS
{
    public partial class MyViewController : UIViewController
    {
        private Auth0Client client;

        public MyViewController() : base("MyViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        
            UserDetailsTextView.Text = String.Empty;

            LoginButton.TouchUpInside += LoginButton_TouchUpInside;

        
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        private async void LoginButton_TouchUpInside(object sender, EventArgs e)
        {
            var client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "ash123.auth0.com",
                ClientId = "nwJxiC7ILZnVMabtAaGif9MNTagMpwXM",
                Controller = this
            });

            var loginResult = await client.LoginAsync();

            var sb = new StringBuilder();

            if (loginResult.IsError)
            {
                sb.AppendLine("An error occurred during login:");
                sb.AppendLine(loginResult.Error);
            }
            else
            {
                sb.AppendLine($"ID Token: {loginResult.IdentityToken}");
                sb.AppendLine($"Access Token: {loginResult.AccessToken}");
                sb.AppendLine($"Refresh Token: {loginResult.RefreshToken}");
                sb.AppendLine();
                sb.AppendLine("-- Claims --");
                foreach (var claim in loginResult.User.Claims)
                {
                    sb.AppendLine($"{claim.Type} = {claim.Value}");
                }
            }

            UserDetailsTextView.Text = sb.ToString();


        }


    }
}

