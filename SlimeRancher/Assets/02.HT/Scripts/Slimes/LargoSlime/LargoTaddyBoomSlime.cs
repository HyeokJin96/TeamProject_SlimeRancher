using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoTabbyBoomSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public GameObject explosionParticle;
    public SphereCollider particleCollider;

    bool isSetExplosion;

    Texture2D tabbyBodyTexture;
    Texture2D tabbyEarNTailTexture1;
    Texture2D tabbyEarNTailTexture2;
    GameObject tabbyEarsAndTail;


    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 3;
        slimeType1 = 5;

        defaultMaterial.color = slimeColor[5];
        defaultLod1Material.color = slimeColor[5];
        defaultLod2Material.color = slimeColor[5];
        defaultLod3Material.color = slimeColor[5];

        explosionParticle = transform.GetChild(2).gameObject;
        particleCollider = explosionParticle.GetComponent<SphereCollider>();

        tabbyBodyTexture = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/TabbyBodyStripe");
        tabbyEarNTailTexture1 = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/tabbyEarNTailTexture1");
        tabbyEarNTailTexture2 = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/tabbyEarNTailTexture2");

        defaultMaterial.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod1Material.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod2Material.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod3Material.SetTexture("_MainTex", tabbyBodyTexture);

        tabbyEarsAndTail = shadow.GetChild(5).gameObject;
        tabbyEarsAndTail.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[5];

        tabbyEarsAndTail.SetActive(true);
        defaultColor = slimeColor[5];
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
    public override void Action()
    {
        int frequency_;
        frequency_ = Random.Range(0, 5);
        switch (frequency_)
        {
            case 0:
                currentActionState = ActionState.Jump;
                break;
            case 1:
            case 2:
                if (moodStateMachine.currentState != moodStateMachine.agitated && pounceTarget != null)
                {
                    currentActionState = ActionState.Pounce;
                }
                else
                {
                    currentActionState = ActionState.Jump;
                }
                break;
            case 3:
            case 4:
                if (moodStateMachine.currentState == moodStateMachine.agitated | moodStateMachine.currentState == moodStateMachine.hungry)
                {
                    currentActionState = ActionState.Boom;
                }
                else
                {
                    currentActionState = ActionState.Jump;
                }
                break;
            default:
                break;
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

        StartCoroutine(SetStun());
    }

    //public Transform pounceTarget;
    public float speed = 10f;
    public float gravity = 9.81f;

    protected override void Pounce()
    {
        base.Pounce();
        Debug.Log("pounce test");

        // { if(target to eat != null)
        Vector3 direction = pounceTarget.position - transform.position;
        float distance = direction.magnitude;
        if (distance <= 0f) return;
        float height = direction.y;
        float angle = 45f * Mathf.Deg2Rad; // 45도 각도로 발사
        float velocity = Mathf.Sqrt(distance * gravity / (Mathf.Sin(2 * angle)));
        Vector3 horizontalDirection = new Vector3(direction.x, 0f, direction.z);
        float horizontalDistance = horizontalDirection.magnitude;
        float time = horizontalDistance / (velocity * Mathf.Cos(angle));
        float verticalVelocity = gravity * time / 2f;
        Vector3 initialVelocity = (velocity * direction.normalized) + (Vector3.up * verticalVelocity);

        rigid.velocity = initialVelocity;
    }

    protected void AfterPounce()
    {
        Debug.Log("af test");
        if (pounceTarget.tag == "Player")
        {
            agitatedValue = 0;
            pounceTarget = null;
        }
        else if (pounceTarget.tag == "Food")
        {
            pounceTarget.gameObject.SetActive(false);
            hungerValue = 0;
            agitatedValue = 0;
            pounceTarget = null;
        }
    }

}
