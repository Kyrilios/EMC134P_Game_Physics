using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    Text textUI;
    public GameObject Asteroid;
    public bool isTrue;
    private bool blink;

    void Start()
    {
        textUI = GetComponent<Text>();
        Asteroid = GameObject.Find("Asteroid_4");
        
    }

    void Update() {
        if (isTrue == false) {
            Text();
            isTrue = true;
        }
    }

    void Text()
    {
        blink = Asteroid.GetComponent<PhysicsEngine>().netForceActive;
        if (blink) {
            StartCoroutine(Unbalanced());
        } else {
            StartCoroutine(Balanced());
        }
    }


    IEnumerator Unbalanced() {

        while (true) {

            textUI.text = " ";
            yield return new WaitForSeconds(1f);
       textUI.color = Color.red;
            textUI.text = "Unbalanced Force Detected";
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Balanced() {

        while (true) {

            textUI.text = " ";
            yield return new WaitForSeconds(1f);
            textUI.color = Color.green;
            textUI.text = "Balanced Force Detected";
            yield return new WaitForSeconds(1f);
        }
    }
}