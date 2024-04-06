using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Http;
//using System.Text.Json;

public class DynamicDataRender : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //public WeatherDetails kobj;
     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   //     var client = new HttpClient();
   //     var request = new HttpRequestMessage
   //     {
   //         Method = HttpMethod.Get,
   //         RequestUri = new Uri("https://foreca-weather.p.rapidapi.com/current/102643743?alt=0&tempunit=C&windunit=MS&tz=Europe%2FLondon&lang=en"),
    //        Headers =
   // {
    //    { "X-RapidAPI-Key", "e49fa934d4mshcec452b01525876p1fa0e2jsn4dd373d7b056" },
   //     { "X-RapidAPI-Host", "foreca-weather.p.rapidapi.com" },
   // },
   //     };
    //    using (var response = await client.SendAsync(request))
    //    {
     //       response.EnsureSuccessStatusCode();
     //       var body = await response.Content.ReadAsStringAsync();
      //      Debug.Log(body);
      //      kobj = JsonUtility.FromJson<WeatherDetails>(body);
      //      animator.SetFloat("Speed", (animator.GetFloat("Speed")+kobj.current.windSpeed)/30);
      //      Debug.Log(kobj.current.windSpeed);

            //var dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(body); 
            
       // }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
//[System.Serializable]
//public class WeatherDetails
//{
 //   public DetailsWe current;
//}
//[System.Serializable]
//public class DetailsWe
//{
    //public string time;
   //public string symbolPhrase;
   // public float temperature;
   // public float feelsLikeTemp;
   // public float relHumidity;
   // public float windSpeed;
   // public string windDirString;
   // public float windGust;
    //public float thunderProb;
    //public float cloudiness;
    //public float pressure;
//}

