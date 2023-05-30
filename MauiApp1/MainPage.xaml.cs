namespace MauiApp1;

public partial class MainPage : ContentPage
{
    Auth0Client client;

	public MainPage()
	{
		InitializeComponent();

        client = new Auth0Client(new IdentityModel.OidcClient.OidcClientOptions()
        {
            Authority = "https://{AUTH0_DOMAIN}",
            ClientId = "{AUTH0_CLIENT_ID}",
            Browser = new WebAuthenticatorBrowser(),
            RedirectUri = "myapp://callback",
			Scope = "openid profile email",
        });

        LoginBtn.IsVisible = true;
        LogoutBtn.IsVisible = false;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var result = await client.LogInAsync();

        IdToken.Text = $"Id Token {result.TokenResponse.IdentityToken}";
        LoginBtn.IsVisible = false;
        LogoutBtn.IsVisible = true;
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        await client.LogOut();

        IdToken.Text = $"";
        LoginBtn.IsVisible = true;
        LogoutBtn.IsVisible = false;
    }
}

