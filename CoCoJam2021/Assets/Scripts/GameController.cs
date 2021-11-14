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
    private int currentFloor = 2;

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

        SetFloor(currentFloor, new Vector2(100, -1.5f));
    }

    public void RemoveObject(PickupableObj obj){
        objects.Remove(obj);
        if(objects.Count == 0)
            isGameEnded = true;
    }

    public void ChangeFloor(int floor, Vector2 destination)
	{
        if (transition == null && floor != currentFloor)
        {
            transition = changeFloor(floor, destination);
            StartCoroutine(transition);
        }
    }
    private IEnumerator changeFloor(int floor, Vector2 destination)
	{
        // Fade to black
        floorTransition.FadeTo(1);
        while(floorTransition.currentFade != null)
		{
            yield return new WaitForFixedUpdate();
        }
        
        // Teleport the player
        SetFloor(floor, destination);

        // Fade to normal
        floorTransition.FadeTo(0);
        while (floorTransition.currentFade != null)
        {
            yield return new WaitForFixedUpdate();
        }
        transition = null;
    }

    private void SetFloor(int floor, Vector2 destination)
	{

        player.transform.position = new Vector3(destination.x, destination.y, 0);

        _camera.transform.position = new Vector3(floor * 50, _camera.transform.position.y, -10);
        currentFloor = floor;
    }
}
