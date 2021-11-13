using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<PickupableObj> objects;
    [SerializeField]
    private bool isGameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PickupableObj obj in objects){
            obj.AssignGame(this);
        }
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void RemoveObject(PickupableObj obj){
        objects.Remove(obj);
        if(objects.Count == 0)isGameEnded = true;
    }
}
