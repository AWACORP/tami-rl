using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private Camera _camera;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 mousePosition = Input.mousePosition;

        float xMouse = mousePosition.x - (_camera.pixelWidth / 2);
        float yMouse = mousePosition.y - (_camera.pixelHeight / 2);
        
        
        Vector3 mouseWorldPosition = new Vector3(xMouse, 0 , yMouse);
        
        playerTransform.LookAt(playerTransform.position + mouseWorldPosition);

    }
}
