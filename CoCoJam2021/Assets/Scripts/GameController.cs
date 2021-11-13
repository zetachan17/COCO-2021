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
    private List<float> floorPositions;
    public PlayerController player;
    public Camera _camera;

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

        ChangeFloor(0);
    }

    public void ChangeFloor(int floor)
	{
        player.transform.position = new Vector3(floorPositions[floor], player.transform.position.y, 0);
        _camera.transform.position = new Vector3(floorPositions[floor], _camera.transform.position.y, -10);
    }

    public void RemoveObject(PickupableObj obj){
        objects.Remove(obj);
        if(objects.Count == 0)isGameEnded = true;
    }
}
