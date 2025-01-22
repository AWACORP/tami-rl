using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected int weaponDamage;
    [SerializeField] protected GameObject weaponEmplacement;
    protected Animator weaponAnimator;
    protected bool hasAnimator;

    protected GameManager gameManager;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        hasAnimator = TryGetComponent<Animator>(out weaponAnimator);
        Debug.Log(hasAnimator);
        gameManager = GameManager.Instance();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void UsePrincipaleAttack()
    {
        if(hasAnimator)
        {
            weaponAnimator.SetBool("isAttacking", true);
            GetComponent<Collider>().isTrigger = true;
        }
        
    }

    public virtual void UsingPrincipaleAttack()
    {
        Debug.Log("Using");
        
    }

    public virtual void StopPrincipaleAttack()
    {
        Debug.Log("Stop");
    
    }
    
    public virtual void SpecialInteraction(MonsterBehaviour monster)
    {
        return;
    }
    

    public int GetDamage()
    {
        return weaponDamage;
    }
}
