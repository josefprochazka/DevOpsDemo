// Tento testovac� soubor ov��uje funk�nost endpointu /weatherforecast ve webov� aplikaci.
// Pou��v� xUnit a t��du WebApplicationFactory k vytvo�en� testovac� instance aplikace,
// d�ky �emu� nen� pot�eba spou�t�t aplikaci "na�ivo". 
// 
// T��da WeatherEndpointTests2 implementuje IClassFixture<WebApplicationFactory<Program>>,
// co� znamen�, �e pro ka�d� test se vytvo�� HttpClient napojen� na testovac� server.
// 
// Konkr�tn� test Get_WeatherForecast_ReturnsOk ode�le GET po�adavek na /weatherforecast
// a o�ek�v� odpov�� se stavov�m k�dem 200 OK. 
// T�m ov��uje, �e endpoint funguje a aplikace vrac� validn� odpov��.
//
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

public class WeatherEndpointTests2 : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly HttpClient _client;
	public WeatherEndpointTests2(WebApplicationFactory<Program> factory)
		=> _client = factory.CreateClient();

	[Fact]
	public async Task Get_WeatherForecast_ReturnsOk()
	{
		var resp = await _client.GetAsync("/weatherforecast");
		Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
	}
}
