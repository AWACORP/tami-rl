using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Transform cameraTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer()
    {
        transform.LookAt(playerTransform.position);
    }
}
