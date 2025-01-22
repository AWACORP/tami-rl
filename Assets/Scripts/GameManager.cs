using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _singleton;
    
    public static GameManager Instance()
    {
        return _singleton;
    }


    public static float THRESHOLD_NEARBY_PLAYER = 20f;

    [SerializeField] private List<GameObject> spawns;
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerStartPosition;

    void Awake(){
         if (_singleton)
        {
            Destroy(this);
        }

        _singleton = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
       
        spawns = new List<GameObject>();
        InvokeRepeating(nameof(SpawnMonster), 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerMobility(bool canMove = true)
    {
        player.GetComponent<PlayerMovement>().SetMobility(canMove);
    }

    public void AddSpawners(GameObject[] newSpawns){
        spawns.AddRange(newSpawns);
    }

    void SpawnMonster()
    {
        GameObject[] spawnerNearbyPlayer = spawns.Where(x => Vector3.Distance(x.transform.position, player.transform.position) <= THRESHOLD_NEARBY_PLAYER).ToArray<GameObject>();

        if (spawnerNearbyPlayer.Length == 0) return; 

        var index = Random.Range(0, spawnerNearbyPlayer.Length);

        var monster = Instantiate(monsterPrefab, spawnerNearbyPlayer[index].transform.position, Quaternion.Euler(0,0,0));

        monster.GetComponent<MonsterBehaviour>().SetTarget(player.transform);

    }

    public void TeleportToSpawn()
    {
        player.transform.position = playerStartPosition.position;
    }
}
