using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargoPinkBoomSlime : SlimeBase
{
    //[SimeSize] 0: normal, 1: largo 2: gordo
    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public GameObject explosionParticle;
    public SphereCollider particleCollider;

    bool isSetExplosion;

    public override void Start()
    {
        base.Start();
        slimeSize = 1;
        slimeType1 = 1;
        slimeType1 = 5;

        defaultColor = slimeColor[5];

        defaultMaterial.color = slimeColor[5];
        defaultLod1Material.color = slimeColor[5];
        defaultLod2Material.color = slimeColor[5];
        defaultLod3Material.color = slimeColor[5];

        explosionParticle = transform.GetChild(2).gameObject;
        particleCollider = explosionParticle.GetComponent<SphereCollider>();
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
        if (frequency_ >= 0 && frequency_ < 3)
        {
            currentActionState = ActionState.Jump;
        }
        else
        {
            if (moodStateMachine.currentState == moodStateMachine.agitated | moodStateMachine.currentState == moodStateMachine.hungry)
            {
                currentActionState = ActionState.Boom;
            }
            else
            {
                currentActionState = ActionState.Jump;
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

        StartCoroutine(SetStun());
    }

}
