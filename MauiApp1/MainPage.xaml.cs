namespace MauiApp1;

public partial class MainPage : ContentPage
{
    IdentityModel.OidcClient.OidcClient client;

	public MainPage()
	{
		InitializeComponent();

        client = new IdentityModel.OidcClient.OidcClient(new IdentityModel.OidcClient.OidcClientOptions()
        {
            Authority = "https://domain.auth0.com",
            ClientId = "client_id",
            Browser = new WebViewBrowser(),
            RedirectUri = "myapp://callback",
			Scope = "openid profile email",
        });
    }

	private async void OnLoginClicked(object sender, EventArgs e)
	{
		var result = await client.LoginAsync();
		
		IdToken.Text = $"Id Token {result.TokenResponse.IdentityToken}";
	}
}

