using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoRockBoomSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public GameObject explosionParticle;
    public SphereCollider particleCollider;

    bool isSetExplosion;
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
        slimeType1 = 5;

        defaultMaterial.color = slimeColor[5];
        defaultLod1Material.color = slimeColor[5];
        defaultLod2Material.color = slimeColor[5];
        defaultLod3Material.color = slimeColor[5];

        explosionParticle = transform.GetChild(2).gameObject;
        particleCollider = explosionParticle.GetComponent<SphereCollider>();

        rockAttachment = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        rockSpineLod0 = shadow.GetChild(4).gameObject;
        rockSpineLod1 = shadow.GetChild(5).gameObject;

        rockAttachment.SetActive(true);
        rockSpineLod0.SetActive(true);
        rockSpineLod1.SetActive(true);

        rockAttachment.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[5];
        rockSpineLod0.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[5];
        rockSpineLod1.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].color = slimeColor[5];
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
                currentActionState = ActionState.RockFire;
                break;
            case 2:
            case 3:
            case 4:
                if (moodStateMachine.currentState == moodStateMachine.agitated | moodStateMachine.currentState == moodStateMachine.hungry)
                {
                    currentActionState = ActionState.Boom;
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

    protected override void Boom()
    {
        explosionParticle.SetActive(true);
        currentActionState = ActionState.Stunned;
        isSetExplosion = true;
    }

    protected override void Stunned()
    {
        defaultMaterial.color = new Color32(95, 30, 30, 255);
        defaultLod1Material.color = new Color32(95, 30, 30, 255);
        defaultLod2Material.color = new Color32(95, 30, 30, 255);
        defaultLod3Material.color = new Color32(95, 30, 30, 255);

        StartCoroutine(SetStun());
    }

}
