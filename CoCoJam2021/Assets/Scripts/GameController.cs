using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    [SerializeField]
    private List<PickupableObj> objects;
    private Room[] rooms;
    [SerializeField]
    private bool isGameEnded = false;

    [SerializeField] GameObject background;

    [SerializeField]
    private SpriteFader floorTransition;
    private int currentFloor = 2;

    public PlayerController player;
    public Camera _camera;
    public float transitionTime = 2.0f;
    private IEnumerator transition = null;

    private void Awake() {
        // Singleton
        if(instance == null)
		{
            instance = this;
		}
        else
		{
            Destroy(this.gameObject);
		}
    }
    // Start is called before the first frame update
    void Start()
    {
        rooms = FindObjectsOfType(typeof(Room)) as Room[];
        SetFloor(currentFloor, new Vector2(90, -1.5f));

        PlayerController.instance.StopFor(14);
        var dialog = new List<DialogLine>();
        dialog.Add(new DialogLine("We have arrived, Katy!", true));
        dialog.Add(new DialogLine("Move around using 'WASD' and...", true));
        dialog.Add(new DialogLine("remember to press 'E' to interact with doors and items!", true));
        dialog.Add(new DialogLine("I know, Kitty, I'm no pushover when it comes to ghost hunting!", false));
        DialogueController.instance.WriteDialog(dialog);
    }

    public void RemoveObject(PickupableObj obj){
        objects.Remove(obj);
        if (objects.Count == 0)
            isGameEnded = true;
    }

    public void Win()
	{
        if(isGameEnded)
		{
            background.SetActive(true);
        }
        else
		{
            var dialog = new List<DialogLine>();
            dialog.Add(new DialogLine("We're not done, Katy!", true));
            dialog.Add(new DialogLine("We still need items to banish Catsper.", true));
            DialogueController.instance.WriteDialog(dialog);
        }
    }

    public void KillPlayer(){
        player.Die();
        ChangeFloor(2,new Vector2(100, -1.5f));

        //Close all rooms
        foreach (Room room in rooms)
        {
            room.CloseRoom();
        }
    }

    public void ChangeFloor(int floor, Vector2 destination)
	{
        if (transition == null && floor != currentFloor)
        {
            Debug.Log("FadeTeleport");
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
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        _camera.transform.position = new Vector3(floor * 50, _camera.transform.position.y, -10);
        currentFloor = floor;
    }
}
