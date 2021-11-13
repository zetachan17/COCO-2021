using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    [SerializeField]
    private List<PickupableObj> objects;
    [SerializeField]
    private bool isGameEnded = false;

    [SerializeField]
    private SpriteFader floorTransition;
    [SerializeField]
    private List<float> floorPositions;
    private int currentFloor = 0;
    public PlayerController player;
    public Camera _camera;
    public float transitionTime = 2.0f;
    private IEnumerator transition = null;

    // Start is called before the first frame update
    void Start()
    {
        // Singleton
        if(instance == null)
		{
            instance = this;
		}
        else
		{
            Destroy(this.gameObject);
		}

        foreach (PickupableObj obj in objects){
            obj.AssignGame(this);
        }

        SetFloor(0);
    }

    public void RemoveObject(PickupableObj obj){
        objects.Remove(obj);
        if(objects.Count == 0)
            isGameEnded = true;
    }

    public void ChangeFloor(int floor)
	{
        if (transition == null && floor != currentFloor)
        {
            transition = changeFloor(floor);
            StartCoroutine(transition);
        }
    }
    private IEnumerator changeFloor(int floor)
	{
        // Fade to black
        floorTransition.FadeTo(1);
        while(floorTransition.currentFade != null)
		{
            yield return new WaitForFixedUpdate();
        }
        
        // Teleport the player
        SetFloor(floor);

        // Fade to normal
        floorTransition.FadeTo(0);
        while (floorTransition.currentFade != null)
        {
            yield return new WaitForFixedUpdate();
        }
        transition = null;
    }

    private void SetFloor(int floor)
	{
        player.transform.position = new Vector3(floorPositions[floor], player.transform.position.y, 0);
        _camera.transform.position = new Vector3(floorPositions[floor], _camera.transform.position.y, -10);
        currentFloor = floor;
    }
}
