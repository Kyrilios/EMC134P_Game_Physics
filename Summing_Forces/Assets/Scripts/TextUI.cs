﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{ 
    Text text;

    public GameObject movingCar;
    bool once;
    public bool startBlinking;
    void Start()
    {

        text =GetComponent<Text>();
        movingCar = GameObject.Find("Asteroid_4");
        
        
    }

    void Update(){
        Debug.Log(movingCar.GetComponent<PhysicsEngine>().netForceActive);
        if (!once)
        {
            FlashingText();
            once = true;
        }
    }
    


    void FlashingText(){
        startBlinking = movingCar.GetComponent<PhysicsEngine>().netForceActive;
        if (startBlinking)
        {
            StartCoroutine(BlinkingBad());
            startBlinking = false;
        }else{
            StartCoroutine(BlinkingGood());
        }
        
    }

    // Update is called once per frame
    IEnumerator BlinkingBad()
    {
        while(true){
           
            text.text= "";
            
            yield return new WaitForSeconds(1f);
            text = GetComponent<Text>();
            text.color = Color.red;
            text.text= "UNBALANCED FORCE DETECTED";
            text.fontSize = 30;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator BlinkingGood()
    {
        while(true){
           
            text.text= "";
            
            yield return new WaitForSeconds(1f);
            
            text = GetComponent<Text>();
            text.color = Color.green;
            text.text= "SUCCESS";
            
            yield return new WaitForSeconds(1f);
        }
    }
}
