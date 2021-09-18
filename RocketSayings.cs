using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Events;

public class RocketSayings : MonoBehaviour
{
    string[] phrases = new string[] { "Seems Like It", "Sure, Whatever.", "Yup!", "Why Not?", "Who could stop you?", "You have known the answer all along", "The Friends We Made Along The Way!", "I feel unqualified to address that", "Who knows? Tim does, but who wants to ask him?"
,"I'm just a box!"
,"I wasn't really listening","Ask your mother, she knows things?","I'd love to answer that, but I'd rather do anything else", "42", "Eh?" ,"I think not!" ,"That would displease the gods.", "The suggestion is absurd!" ,"Nah!" ,"I love you, but just, no."};
    public UnityEvent ButtonEvents;
    public GameObject phraseBox;
    public GameObject knickknack_base;
    public Button myButton;
    public bool isTurn;


    // Start is called before the first frame update
    void Start()
    {
        
        isTurn = false;
    }




    // Update is called once per frame
    void Update()
    {
        if ((knickknack_base.transform.up.y < 0f) && (isTurn == false))
        {

            int phrase = Random.Range(0, phrases.Length);
            phraseBox.GetComponent<TextMeshPro>().text = phrases[phrase];
            Button btn = myButton.GetComponent<Button>();
            btn.onClick.Invoke();
            isTurn = true;
        }
        if (knickknack_base.transform.up.y > 0f)
        {

            isTurn = false;
        }
    }

}
