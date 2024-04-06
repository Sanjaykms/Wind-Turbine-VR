using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class demoscript : MonoBehaviour
{
    public DynamicWeather jobj;
    public WeatherDetails kobj;
    public Text text;
    public TMP_Text Loc;
    public TMP_Text Details;
    public ParticleSystem rain;
    public ParticleSystem fog;
    public GameObject cloudy;
    String location = "chennai";
    // Start is called before the first frame update
    async void Start()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://foreca-weather.p.rapidapi.com/location/search/" + location),
            Headers =
    {
        { "X-RapidAPI-Key", "e49fa934d4mshcec452b01525876p1fa0e2jsn4dd373d7b056" },
        { "X-RapidAPI-Host", "foreca-weather.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Debug.Log(body);
            jobj = JsonUtility.FromJson<DynamicWeather>(body);
            Debug.Log(jobj.locations[0].id);
            WeatherD();
        }
    }
    async void WeatherD()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://foreca-weather.p.rapidapi.com/current/" + jobj.locations[0].id),
            Headers =
    {
        { "X-RapidAPI-Key", "e49fa934d4mshcec452b01525876p1fa0e2jsn4dd373d7b056" },
            { "X-RapidAPI-Host", "foreca-weather.p.rapidapi.com" },
    },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Debug.Log(body);
            kobj = JsonUtility.FromJson<WeatherDetails>(body);
            //animator.SetFloat("Speed", (animator.GetFloat("Speed") + kobj.current.windSpeed) / 30);
            Debug.Log(kobj.current.windSpeed);
            Details.text = "Time: " + kobj.current.time + "\nSymbol Phrase: " + kobj.current.symbolPhrase + "\nTemperature: " + kobj.current.temperature + "\nFeels Like Temp: " + kobj.current.feelsLikeTemp + "\nRel Humidity: " + kobj.current.relHumidity + "\nWind Speed: " + kobj.current.windSpeed + "\nWind Dir String: " + kobj.current.windDirString + "\nWind Gust: " + kobj.current.windGust + "\nThunder Prob: " + kobj.current.thunderProb + "\nCloudiness: " + kobj.current.cloudiness + "\nPressure: " + kobj.current.pressure;

        }
        // Animations start
        //rain
        if (kobj.current.symbolPhrase.ToLower() == "showers" || kobj.current.symbolPhrase.ToLower() == "thunderstorms" || kobj.current.symbolPhrase.ToLower() == "light rain" || kobj.current.symbolPhrase.ToLower() == "heavy rain" || kobj.current.symbolPhrase.ToLower() == "rain" || kobj.current.symbolPhrase.ToLower() == "high rain")
        {
            Debug.Log("rain");
            rain.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("no rain");
            rain.gameObject.SetActive(false);
        }
        //fog
        if(kobj.current.symbolPhrase.ToLower() == "overcast")
        {
            Debug.Log("fog");
            fog.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("no fog");
            fog.gameObject.SetActive(false);
        }
        // cloudy
        if (kobj.current.symbolPhrase.ToLower() == "cloudy")
        {
            Debug.Log("cloudy");
            cloudy.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("no cloudy");
            cloudy.gameObject.SetActive(false);
        }
        //---------------
        foreach (Transform tr in transform)
        {
            foreach (Transform t in tr)
            {
                if (t.gameObject.name == "Loft01")
                {
                    Animator ani = t.gameObject.GetComponent<Animator>();
                    ani.SetFloat("Speed", (ani.GetFloat("Speed") + kobj.current.windSpeed) / 30);
                }
            }
            //tr.gameObject.GetComponent<Animator>().SetFloat("Speeed", 12f);
        }
        Loc.text = "Location: " + location + " \nID: " + jobj.locations[0].id;
        Debug.Log(jobj.locations[0].id);
    }


    [System.Serializable]
    public class DynamicWeather
    {
        public Class1[] locations;
    }
    [System.Serializable]
    public class Class1
    {
        public int id;
        public string name;
        public string country;
        public string timezone;
        public string language;
        public string adminArea;
        public string adminArea2;
        public string adminArea3;
        public float lon;
        public float lat;
    }

    [System.Serializable]
    public class WeatherDetails
    {
        public DetailsWe current;
    }
    [System.Serializable]
    public class DetailsWe
    {
        public string time;
        public string symbolPhrase;
        public float temperature;
        public float feelsLikeTemp;
        public float relHumidity;
        public float windSpeed;
        public string windDirString;
        public float windGust;
        public float thunderProb;
        public float cloudiness;
        public float pressure;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Entered()
    {
        if ((text.text != "" || location == text.text) && !Regex.IsMatch(text.text, @"^\d+$"))
        {
            location = text.text;
            Start();
        }
    }
}
