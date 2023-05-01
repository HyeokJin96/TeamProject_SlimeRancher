using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoRockTabbySlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...

    Texture2D tabbyBodyTexture;
    Texture2D tabbyEarNTailTexture1;
    Texture2D tabbyEarNTailTexture2;
    GameObject tabbyEarsAndTail;


    GameObject rockAttachment;
    GameObject rockSpineLod0;
    GameObject rockSpineLod1;

    Material rockSpineLod0Mat;
    Material rockSpineLod1Mat;

    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 2;
        slimeType2 = 3;
        targetDistanceValue1 = 7;
        targetDistanceValue2 = 5;

        defaultMaterial.color = slimeColor[2];
        defaultLod1Material.color = slimeColor[2];
        defaultLod2Material.color = slimeColor[2];
        defaultLod3Material.color = slimeColor[2];

        tabbyBodyTexture = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/TabbyBodyStripe");
        tabbyEarNTailTexture1 = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/tabbyEarNTailTexture1");
        tabbyEarNTailTexture2 = Resources.Load<Texture2D>("02.HT/Slimes/TabbySlime/tabbyEarNTailTexture2");

        defaultMaterial.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod1Material.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod2Material.SetTexture("_MainTex", tabbyBodyTexture);
        defaultLod3Material.SetTexture("_MainTex", tabbyBodyTexture);

        tabbyEarsAndTail = shadow.GetChild(6).gameObject;
        tabbyEarsAndTail.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[2];

        tabbyEarsAndTail.SetActive(true);

        rockAttachment = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        rockSpineLod0 = shadow.GetChild(4).gameObject;
        rockSpineLod1 = shadow.GetChild(5).gameObject;

        rockAttachment.SetActive(true);
        rockSpineLod0.SetActive(true);
        rockSpineLod1.SetActive(true);

        rockAttachment.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(125, 180, 245, 255);
        rockSpineLod0.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(125, 180, 245, 255);
        rockSpineLod1.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = new Color32(125, 180, 245, 255);

        anim = GetComponent<Animator>();
    }

    public override void Update()
    {
        base.Update();
    }
    protected override void Jump(int jumpForce_, int delayTime_)
    {
        //base.Jump(jumpForce_, delayTime_);
        if (!isJumpDelay)
        {
            int frequency_;
            frequency_ = Random.Range(0, 5);
            isJumpDelay = true;

            /* if (frequency_ >= 0 && frequency_ < 3)
            {
                currentActionState = ActionState.Jump;
                rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
                StartCoroutine(JumpDelay(delayTime_));
            }
            else
            {
                currentActionState = ActionState.RockFire;
            } */

            switch (frequency_)
            {
                case 0:
                case 1:
                    currentActionState = ActionState.Jump;
                    rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
                    StartCoroutine(JumpDelay(delayTime_));
                    break;
                case 2:
                    currentActionState = ActionState.RockFire;
                    break;
                case 3:
                case 4:
                    if (currentMoodState != MoodState.Agitated && pounceTarget != null)
                    {
                        currentActionState = ActionState.Pounce;
                    }
                    else
                    {
                        currentActionState = ActionState.RockFire;
                    }
                    break;
                default:
                    break;
            }
        }
    }
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
