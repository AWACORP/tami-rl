using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private Weapon[] weapons;
    private Weapon selectedWeapon;

    private bool isAttacking;
    
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        selectedWeapon = weapons[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackPressed())
        {
            isAttacking = true;
            Attack();
        }

        if (isAttacking)
        {
            Attacking();
        }

        if (AttackReleased())
        {
            isAttacking = false;
            StopAttack();
        }
    }

    void Attack()
    {
        selectedWeapon.UsePrincipaleAttack();
    }

    void Attacking()
    {
        selectedWeapon.UsingPrincipaleAttack();
    }

    void StopAttack()
    {
        selectedWeapon.StopPrincipaleAttack();
    }

    bool AttackPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    bool AttackReleased()
    {
        return Input.GetMouseButtonUp(0);
    }
}
