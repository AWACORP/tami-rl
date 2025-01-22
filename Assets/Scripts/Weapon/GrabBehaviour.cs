using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBehaviour : Weapon
{

    [SerializeField] private float grabLength;

    [SerializeField] private GameObject grabArea;
    

    [SerializeField] private float grabIncreasingScale;


    public static float GRAB_FORCE = 10f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void UsePrincipaleAttack()
    {

        if (grabArea.transform.localScale.z < grabLength)
            grabArea.transform.localScale += new Vector3(0,0,grabIncreasingScale);
        
    }

    public override void UsingPrincipaleAttack()
    {
        if (grabArea.transform.localScale.z < grabLength)
            grabArea.transform.localScale += new Vector3(0,0,grabIncreasingScale);
        
    }

    public override void StopPrincipaleAttack()
    {
        grabArea.transform.localScale = new Vector3(1,1,0);
        GetComponent<Collider>().isTrigger = true;
        weaponAnimator.SetBool("grabReleased", true);
        gameManager.SetPlayerMobility(false);
    
    }

    public override void SpecialInteraction(MonsterBehaviour monster)
    {
        Vector3 grabVector = (weaponEmplacement.transform.position - monster.transform.position) + Vector3.up * 2;

        grabVector = grabVector.normalized;

        Debug.DrawLine(monster.transform.position ,monster.transform.position + grabVector * GRAB_FORCE, Color.green, 10f);

        weaponAnimator.SetBool("EnemyHit", true);
        GetComponent<Collider>().isTrigger = false;

        //monster.transform.Translate(grabVector * GRAB_FORCE * Time.timeScale, Space.World);

        monster.GetComponent<Rigidbody>().AddForce(grabVector * GRAB_FORCE, ForceMode.VelocityChange);
    }
}
