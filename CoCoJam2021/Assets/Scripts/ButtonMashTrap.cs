using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMashTrap : Trap
{
    [SerializeField]
    private GameObject uiObj;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float reduceStep = 0.001f;
    [SerializeField]
    private float augmentStep = 0.1f;

    // Update is called once per frame
    void Update(){
        if(_isPlayerInRange && !isCompleted){
            if(!isStarted){
                uiObj.SetActive(true);
                isStarted = true;
            }
        }
        if(isStarted && !isCompleted){
            if(slider != null){
                slider.value -= reduceStep* Time.deltaTime;
                if(Input.GetKeyDown(KeyCode.Q)){
                    slider.value += augmentStep;
                }
                if(slider.value >= 1){
                    isCompleted = true;
                    uiObj.SetActive(false);
                    gameObject.SetActive(false);
                    TrapSuccess();
                }else if(slider.value <= 0){
                    isCompleted = true;
                    TrapFail();
                }
            }
        }
    }
}
