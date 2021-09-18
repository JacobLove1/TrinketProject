using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Events;


public class MagicBall : MonoBehaviour
{
    string[] phrases = new string[] { "It is Certain", "It is decidedly so", "Without a doubt", "Yes definitely", "You may rely on it", "As I see it, yes.", "Most likely", "Outlook good", "Yes"
,"Signs point to yes"
,"Reply hazy, try again","Ask again later","Better not tell you now", "Cannot predict now", "Concentrate and ask again"
,"Don't count on it" ,"My reply is no", "My sources say no" ,"Outlook not so good" ,"Very doubtful"};
    public UnityEvent ButtonEvents;
    public GameObject phraseBox;
    public GameObject knickknack_base;
    public Button myButton1;
    public bool isTurn;


    // Start is called before the first frame update
    void Start()
    {

        isTurn = false;
    }




    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if ((knickknack_base.transform.up.y < 0f) && (isTurn == false))
        {

            int phrase = Random.Range(0, phrases.Length);
            phraseBox.GetComponent<TextMeshPro>().text = phrases[phrase];
            Button b = myButton1.GetComponent<Button>();
            b.onClick.Invoke();
            isTurn = true;
        }
        if (knickknack_base.transform.up.y > 0f)
        {

            isTurn = false;
        }
    }

}

