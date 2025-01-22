using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomInstance : MonoBehaviour
{
    private int roomID;
    private int exitNumber;
    private int exitNumberAvailable;

    [SerializeField] private GameObject[] monsterSpawners;
 
    [SerializeField] private GameObject[] anchorPoints;

    [SerializeField] private GameObject floor;

    private RoomManager roomManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        roomManager = RoomManager.Instance();
        gameManager = GameManager.Instance();

        gameManager.AddSpawners(monsterSpawners);

        if (anchorPoints.Length > 0 )
        {
            foreach(GameObject ap in anchorPoints)
            {
                roomManager.CreateRoom(ap.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetFloor()
    {
        return floor;
    }
}
