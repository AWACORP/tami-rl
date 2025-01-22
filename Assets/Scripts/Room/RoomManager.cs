using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private static RoomManager _singleton;

    public static RoomManager Instance()
    {
        return _singleton;
    }
    
    [SerializeField] private int roomNumber;
    private List<GameObject> roomsList;
    [SerializeField] private GameObject[] roomsPrefabs;

    bool m_Started;

    List<Vector3> center = new List<Vector3>();
    List<Vector3> scale = new List<Vector3>();
    
    private void Awake() {
        if (_singleton)
        {
            Destroy(this);
        }

        _singleton = this;
        roomsList = new List<GameObject>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
        m_Started = true;

        //CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRoom(Transform anchorPoint = null)
    {
        if(roomNumber == roomsList.Count) return;

        int roomIndex = Random.Range(0, roomsPrefabs.Length);

        GameObject prefabs = roomsPrefabs[roomIndex];

        //Postion
        Vector3 position = anchorPoint ? anchorPoint.position : new Vector3(0,0,0);

        //Rotation
        Quaternion rotation = anchorPoint ? anchorPoint.rotation : Quaternion.Euler(0,0,0);


        GameObject roomNewInstance = Instantiate(prefabs, position, rotation);

        if(!CheckIfRoomIsPlacable(roomNewInstance))
        {
            Destroy(roomNewInstance);
            return;
        }

        roomNewInstance.SetActive(true);

        roomsList.Add(roomNewInstance);
    }

    private bool CheckIfRoomIsPlacable(GameObject temporaryRoom)
    {

        temporaryRoom.SetActive(false);

        MeshRenderer floor = temporaryRoom.GetComponent<RoomInstance>().GetFloor().GetComponent<MeshRenderer>();

        Collider[] colliders = Physics.OverlapBox(floor.bounds.center, floor.bounds.extents / 1.1f);

        foreach(Collider collider in colliders)
        {
            center.Add(floor.transform.position);
            scale.Add(floor.transform.localScale);

            /*Debug.Log(floor.transform.position + " " + floor.transform.localScale + " " + temporaryRoom.transform.rotation);
            Debug.Log(collider.gameObject.name);*/

        }

        return colliders.Length <= 0;
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            for (int i = 0; i < center.Count ; i++)
            {
                Gizmos.DrawWireCube(center[i], scale[i]);
            }
            
    }*/
}
