using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoPhosphorBoomSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public GameObject explosionParticle;
    public SphereCollider particleCollider;

    bool isSetExplosion;

    public Material antenLod0;
    public Material antenLod1;
    public Material antenLod2;

    public Material wingLeft;
    public Material wingRight;

    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 4;
        slimeType1 = 5;

        defaultMaterial.color = slimeColor[8];
        defaultLod1Material.color = slimeColor[8];
        defaultLod2Material.color = slimeColor[8];
        defaultLod3Material.color = slimeColor[8];
        defaultMaterial.SetFloat("_Mode", 3);
        defaultLod1Material.SetFloat("_Mode", 3);
        defaultLod2Material.SetFloat("_Mode", 3);
        defaultLod3Material.SetFloat("_Mode", 3);

        explosionParticle = transform.GetChild(2).gameObject;
        particleCollider = explosionParticle.GetComponent<SphereCollider>();

        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;

        antenLod0 = shadow.GetChild(5).GetComponent<MeshRenderer>().materials[0];
        antenLod1 = shadow.GetChild(6).GetComponent<MeshRenderer>().materials[0];
        antenLod2 = shadow.GetChild(7).GetComponent<MeshRenderer>().materials[0];

        antenLod0.color = slimeColor[8];
        antenLod1.color = slimeColor[8];
        antenLod2.color = slimeColor[8];

        wingLeft = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<MeshRenderer>().materials[0];
        wingRight = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetComponent<MeshRenderer>().materials[0];

        wingLeft.color = slimeColor[8];
        wingRight.color = slimeColor[8];
    }

    public override void Update()
    {
        base.Update();

        if (isSetExplosion)
        {
            if (particleCollider.radius <= 2)
            {
                particleCollider.radius += Time.deltaTime * 2f;
            }

            else
            {
                //isJumpDelay = false;
                isSetExplosion = false;
                particleCollider.radius = 0.1f;
                explosionParticle.SetActive(false);
                currentActionState = ActionState.Stunned;
            }
        }
    }
    protected override void Jump(int jumpForce_, int delayTime_)
    {
        //base.Jump(jumpForce_, delayTime_);
        if (!isJumpDelay)
        {
            int frequency_;
            frequency_ = Random.Range(0, 5);
            isJumpDelay = true;
            if (frequency_ >= 0 && frequency_ < 3)
            {
                currentActionState = ActionState.Jump;
                rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
                StartCoroutine(JumpDelay(delayTime_));
            }
            else
            {
                if (currentMoodState == MoodState.Agitated | currentMoodState == MoodState.Hungry)
                {
                    Debug.Log("boom1?");
                    currentActionState = ActionState.Boom;
                }
                else
                {
                    currentActionState = ActionState.Jump;
                    rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
                    StartCoroutine(JumpDelay(delayTime_));
                }
            }
        }
    }

    protected override void Boom()
    {
        Debug.Log("boom2?");
        explosionParticle.SetActive(true);
        currentActionState = ActionState.Stunned;
        isSetExplosion = true;
    }

    protected override void Stunned()
    {
        Debug.Log("stunned??");
        defaultMaterial.color = new Color32(95, 30, 30, 255);
        defaultLod1Material.color = new Color32(95, 30, 30, 255);
        defaultLod2Material.color = new Color32(95, 30, 30, 255);
        defaultLod3Material.color = new Color32(95, 30, 30, 255);

        antenLod0.color = new Color32(95, 30, 30, 255);
        antenLod1.color = new Color32(95, 30, 30, 255);
        antenLod2.color = new Color32(95, 30, 30, 255);

        wingLeft.color = new Color32(95, 30, 30, 255);
        wingRight.color = new Color32(95, 30, 30, 255);



        StartCoroutine(SetStun());
    }

    public override IEnumerator SetStun()
    {
        Debug.Log("start stun");
        anim.SetBool("isStunned", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("isStunned", false);
        Debug.Log("end stun");
        StartCoroutine(JumpDelay(jumpDelay));

        currentActionState = ActionState.Idle;

        defaultMaterial.color = slimeColor[8];
        defaultLod1Material.color = slimeColor[8];
        defaultLod2Material.color = slimeColor[8];
        defaultLod3Material.color = slimeColor[8];

        antenLod0.color = slimeColor[8];
        antenLod1.color = slimeColor[8];
        antenLod2.color = slimeColor[8];

        wingLeft.color = slimeColor[8];
        wingRight.color = slimeColor[8];
    }

}
