using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _transform;
    private int _health;
    private float _speed;
    private bool getHit;
    private Animator monsterAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = 100;
        _transform = this.transform;
        _speed = 0.05f;
        getHit = false;
        monsterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Move();
    }

    void Aim()
    {
        var lookUp = new Vector3(_target.position.x, 1, _target.position.z);
        
        _transform.LookAt(lookUp);
    }
    void Move()
    {
        var _direction = (_target.position - _transform.position).normalized;
        _direction = new Vector3(_direction.x, 0, _direction.z);
        
        _transform.position += _direction * _speed * 0.1f;
    }

    bool CheckDeath()
    {
        return _health <= 0; 
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    void Attack()
    {
        monsterAnimator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon") && !getHit)
        {
            getHit = true;
            Weapon w = other.GetComponentInParent<Weapon>();
            _health -= w.GetDamage();
            w.SpecialInteraction(this);
            
            Debug.Log($"Dégat pris : {w.GetDamage()}, PV Restant : {_health}");
            
            if (CheckDeath())
            {
                Die();
            }
        }

        if (other.tag.Equals("Player"))
        {
            Debug.Log("Touché");
            InvokeRepeating(nameof(Attack), 0f, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            getHit = false;
        }
        
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Coulé");
            CancelInvoke(nameof(Attack));
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    
}
