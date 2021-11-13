using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QTETrap : Trap
{
    [SerializeField]
    private GameObject uiObj;
    [SerializeField]
    private TMP_Text timerTxt;
    [SerializeField]
    private float time = 1.0f;
    private float timer = 0.0f;
    // Update is called once per frame
    void Update(){
        if(_isPlayerInRange && !isCompleted){
            if(!isStarted){
                uiObj.SetActive(true);
                timerTxt.text = (time-timer).ToString("n2") + " s";
                isStarted = true;
            }
        }
        if(isStarted && !isCompleted){
            if(Input.GetKeyDown(KeyCode.Space)){
                isCompleted = true;
                uiObj.SetActive(false);
                gameObject.SetActive(false);
                TrapSuccess();
                return;
            }
            timer += Time.deltaTime;
            timerTxt.text = (time-timer).ToString("n2") + " s";
            if(timer >= time){
                TrapFail();
            }
        }
    }
}
