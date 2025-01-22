using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _direction;
    private int _speed;

    private bool _canMove;

    private bool m_Started;
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_Started = true;
        _canMove = true;
        _transform = this.transform;
        _direction = Vector3.zero;
        _speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
            Move();
    }

    void Move()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(xMove,0, yMove).normalized;
        
        _transform.Translate(_direction * _speed * 0.1f);
    }

    public void SetMobility(bool canMove)
    {
        _canMove = canMove;
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireSphere(_transform.position, GameManager.THRESHOLD_NEARBY_PLAYER);
            
    }
}
