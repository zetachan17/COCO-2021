using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingTrap : Trap
{
    [SerializeField]
    private GameObject uiObj;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float sizeStep = 0.1f;
    [SerializeField]
    private float size = 1.0f;
    private float startValue;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private RectTransform stopArea;
    private bool forward = true;

    private void Start() {
        size = Mathf.Clamp(size, 0.1f, (1/sizeStep));
        startValue = Random.Range(0, 1-(sizeStep*size));
        
    }
    // Update is called once per frame
    void Update(){
        if(_isPlayerInRange && !isCompleted){
            if(!isStarted){
                uiObj.SetActive(true);
                setUI();
                isStarted = true;
            }
        }
        
        if(isStarted && !isCompleted){
            if(slider != null){
                if(slider.value <= 0){
                    forward = true;
                }else if(slider.value >= 1){
                    forward = false;
                }
                if(forward){
                    slider.value += speed * Time.deltaTime;
                }else{
                    slider.value -= speed * Time.deltaTime;
                }
                
                if(Input.GetKeyDown(KeyCode.Space)){
                    if(slider.value >= startValue && slider.value <= startValue + size*sizeStep){
                        isCompleted = true;
                        uiObj.SetActive(false);
                        gameObject.SetActive(false);
                        TrapSuccess();
                    }
                }
            }
        }
    }

    private void setUI(){
        Vector2 newPos = new Vector2(startValue * 792.4f, 0.0f); // 692 is the furthest the area can be
        stopArea.anchoredPosition = newPos; 
        Vector2 newDelta = new Vector2(792*sizeStep*size, stopArea.sizeDelta.y); // 792 is the max size
        stopArea.sizeDelta = newDelta;
        slider.value = 0;
    }
}
