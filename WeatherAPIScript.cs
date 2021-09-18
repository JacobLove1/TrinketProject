﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeatherAPIScript : MonoBehaviour
{
    
    public GameObject weatherTextObject;
    public UnityEvent ButtonEvents;
    public Button myButton;
    // add your personal API key after APPID= and before &units=
    string url = "http://api.openweathermap.org/data/2.5/weather?lat=28.57&lon=80.65&APPID=c4b78713b2a9ae0630dffe7ad7a52620&units=imperial";
    string urlPyramid = "http://api.openweathermap.org/data/2.5/weather?lat=20.40&lon=8&APPID=c4b78713b2a9ae0630dffe7ad7a52620&units=imperial";
    



    void Start()
    {

        // wait a couple seconds to start and then refresh every 900 seconds
       
       InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {
        string thing = weatherTextObject.GetComponent<TextMeshPro>().text;
        if (thing == "Pyramid")
        {
            weatherTextObject.GetComponent<TextMeshPro>().text = "Yay";
            StartCoroutine(GetRequest(urlPyramid));
        }
        else { StartCoroutine(GetRequest(url));}     

   }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);


            	// grab the current temperature and simplify it if needed
            	int startTemp = webRequest.downloadHandler.text.IndexOf("temp",0);
            	int endTemp = webRequest.downloadHandler.text.IndexOf(",",startTemp);
				double tempF = float.Parse(webRequest.downloadHandler.text.Substring(startTemp+6, (endTemp-startTemp-6)));
				int easyTempF = Mathf.RoundToInt((float)tempF);
                //Debug.Log ("integer temperature is " + easyTempF.ToString());
                int startConditions = webRequest.downloadHandler.text.IndexOf("main",0);
                int endConditions = webRequest.downloadHandler.text.IndexOf(",",startConditions);
                string conditions = webRequest.downloadHandler.text.Substring(startConditions+7, (endConditions-startConditions-8));
                string FullText = webRequest.downloadHandler.text;
                /*int endRain = webRequest.downloadHandler.text.IndexOf(",", startRain);*/
                /*double isRain = float.Parse(webRequest.downloadHandler.text.Substring(endRain - 4, (endRain)));*/

                //Debug.Log(conditions);
                if (FullText.Contains("rain"))
                    {
                    Button btn = myButton.GetComponent<Button>();
                    btn.onClick.Invoke();

                }
                weatherTextObject.GetComponent<TextMeshPro>().text = "" + easyTempF.ToString() + "°F\n" + conditions;
            }
        }
    }
}

