using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    //test
    public string slimeName;
    public List<string> slimeNameList;
    public Sprite[] slimeIconList;
    public Sprite slimeIcon;
    //test


    protected Rigidbody rigid;

    protected bool isGrounded;
    public bool isJumpDelay;

    int jumpDelay = 5;
    int jumpForce = 5;

    public float hungerValue;   // after test, delete public 
    public float agitatedValue; // after test, delete public
    float minHunger = 0;
    float maxHunger = 100;
    float increaseHungerValue = 5.56f;

    public GameObject targetToEat = null;
    Vector3 targetPosition;
    float targetDistance;

    protected float targetDistanceValue1;
    protected float targetDistanceValue2;

    public Transform pounceTarget;
    //var for move

    float minRadius = 8;
    float maxRadius = 10;
    float angle;
    float posX;
    float posZ;
    float radiusX;
    float radiusZ;
    public Vector3 destination = Vector3.zero;
    bool isSetDestination;


    //public GameObject[] slimeArray;

    GameObject[] normalSlimeArray;
    GameObject[] largoSlimeArray;
    public GameObject tarrSlime;

    public bool isTarrSlime;
    //[SimeSize] 0: normal, 1: largo 2: gordo
    public int slimeSize;

    //[SlimeType]  0: Default(White), 1: Pink, 2: Rock...
    public int slimeType1;
    public int slimeType2;


    //set color
    public List<Color32> slimeColor;

    protected Transform shadow;
    MeshRenderer defaultMeshRenderer;
    public Material defaultMaterial;
    protected MeshRenderer defaultLod1MeshRenderer;
    public Material defaultLod1Material;
    MeshRenderer defaultLod2MeshRenderer;
    public Material defaultLod2Material;
    MeshRenderer defaultLod3MeshRenderer;
    public Material defaultLod3Material;

    protected Animator anim;

    //var for LargoSlime
    bool isFeral;

    public enum MoodState   // after test, delete public
    {
        Elated,
        Happy,
        Hungry,
        Agitated
    }
    public MoodState currentMoodState;  // after test, delete public

    public enum ActionState
    {
        Idle,
        Eat,
        Jump,
        Wait,
        RockFire,
        Pounce,
        Boom,
        Stunned,
        VacuumTarget
    }
    public ActionState currentActionState;

    public enum CommonState
    {
        Idle,
        InCorral,
        Launched
    }


    private void Awake()
    {
        //slimeArray = Resources.LoadAll<GameObject>("02.HT/Prefabs/Slimes");
        normalSlimeArray = Resources.LoadAll<GameObject>("02.HT/Prefabs/Slimes/NormalSlimes");
        largoSlimeArray = Resources.LoadAll<GameObject>("02.HT/Prefabs/Slimes/LargoSlimes");
        tarrSlime = Resources.Load<GameObject>("02.HT/Prefabs/Slimes/TarrSlime/TarrSlime");

        slimeColor = new List<Color32>();
        slimeColor.Add(new Color32(255, 255, 255, 255));
        slimeColor.Add(new Color32(225, 60, 90, 255));  //pink
        slimeColor.Add(new Color32(30, 125, 200, 255));  //rock
        slimeColor.Add(new Color32(185, 185, 185, 255));  //tabby
        slimeColor.Add(new Color32(175, 175, 255, 200));  //phosphor
        slimeColor.Add(new Color32(255, 30, 0, 255));  //boom
        slimeColor.Add(new Color32(25, 125, 25, 255));  //Rad
        slimeColor.Add(new Color32(225, 60, 90, 200));  //pinkPhospor

        slimeNameList = new List<string>();
        slimeNameList.Add("Empty");
        slimeNameList.Add("Pink Slime");
        slimeNameList.Add("Rock Slime");
        slimeNameList.Add("Tabby Slime");
        slimeNameList.Add("Phosphor Slime");
        slimeNameList.Add("Boom Slime");
        slimeNameList.Add("Rad Slime");

        slimeIconList = Resources.LoadAll<Sprite>("02.HT/Slimes/SlimeIcon");


        //slimeColor.Add(new Color32(95, 95, 185, 200));  //phosphor_Legacy

        targetDistanceValue1 = 5;
        targetDistanceValue2 = 2.5f;
    }
    public virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();

        currentMoodState = MoodState.Elated;
        currentActionState = ActionState.Idle;

        shadow = transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(3);

        defaultMeshRenderer = shadow.GetChild(0).GetChild(0).GetComponent<MeshRenderer>();
        defaultMaterial = defaultMeshRenderer.materials[0];

        defaultLod1MeshRenderer = shadow.GetChild(1).GetChild(0).GetComponent<MeshRenderer>();
        defaultLod1Material = defaultLod1MeshRenderer.materials[0];

        defaultLod2MeshRenderer = shadow.GetChild(2).GetChild(0).GetComponent<MeshRenderer>();
        defaultLod2Material = defaultLod2MeshRenderer.materials[0];

        defaultLod3MeshRenderer = shadow.GetChild(3).GetChild(0).GetComponent<MeshRenderer>();
        defaultLod3Material = defaultLod3MeshRenderer.materials[0];

        anim = GetComponent<Animator>();

        StartCoroutine(IncreaseHunger(1, increaseHungerValue)); // test value 1: after test, change to 60
        StartCoroutine(DestOnOffTest());
    }

    private void OnEnable()
    {
        StartCoroutine(IncreaseHunger(1, increaseHungerValue)); // test value 1: after test, change to 60
        StartCoroutine(DestOnOffTest());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    //test
    public bool isDestOn;
    IEnumerator DestOnOffTest()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            isDestOn = true;
        }
    }

    void DestTestMethod()
    {
        isDestOn = false;
        angle = Random.Range(0f, 360f);
        radiusX = Random.Range(5, 10);
        radiusZ = Random.Range(5, 10);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        posX = transform.position.x + radiusX * Mathf.Cos(angle * Mathf.Deg2Rad);
        posZ = transform.position.z + radiusZ * Mathf.Sin(angle * Mathf.Deg2Rad);
        destination = new Vector3(posX, transform.position.y, posZ);
    }
    //

    public virtual void Update()
    {
        //test
        if (isDestOn)
        {
            DestTestMethod();
        }
        //test

        SetHungerValue();
        SetMoodState();

        //test
        //if (!isSetDestination)
        //{
        //    StartCoroutine(SetDestination());
        //}
        //test


        switch (currentMoodState)
        {
            case MoodState.Elated:
            case MoodState.Happy:
                jumpForce = 5;
                jumpDelay = 5;
                break;
            case MoodState.Hungry:
                jumpForce = 6;
                jumpDelay = 4;
                break;
            case MoodState.Agitated:
                jumpForce = 7;
                jumpDelay = 3;
                break;
            default:
                break;
        }

        switch (currentActionState)
        {
            case ActionState.Idle:
                Move(targetDistanceValue1, targetDistanceValue2);
                Jump(jumpForce, jumpDelay); //move 메서드 안으로 이동?
                StopCoroutine(SetStun());
                break;
            case ActionState.Eat:
                Debug.Log(anim);
                anim.SetBool("isBite", true);

                destination = Vector3.zero;
                isSetDestination = false;
                //StartCoroutine(Eat());
                break;
            case ActionState.Jump:
                //Do Nothing
                break;
            case ActionState.Wait:
                //Do Nothing
                break;
            case ActionState.RockFire:
                anim.SetBool("isWindup", true);
                break;
            case ActionState.Pounce:
                anim.SetBool("isPounce", true);
                break;
            case ActionState.Boom:
                Boom();
                break;
            case ActionState.Stunned:
                Debug.Log("stunned?!?!?!?");
                Stunned();
                break;
            case ActionState.VacuumTarget:
                Debug.Log("흡수중");
                break;
            default:
                break;
        }
    }

    protected void RockFire()
    {
        anim.SetBool("isWindup", false);
        anim.SetBool("isRockFire", true);
        //test
        rigid.AddForce(transform.forward * 20, ForceMode.Impulse);
    }

    protected void RockRecover()
    {
        anim.SetBool("isRockFire", false);
        anim.SetBool("isRockRecover", true);
    }

    protected void RecoverVelocityAndRotation()
    {
        rigid.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    protected void RockAnimationEnd()
    {
        StartCoroutine(JumpDelay(jumpDelay));
        anim.SetBool("isRockRecover", false);
        currentActionState = ActionState.Idle;
    }
    protected virtual void Pounce()
    {

    }

    protected virtual void Boom()
    {

    }

    protected virtual void Stunned()
    {

    }
    public IEnumerator SetStun()
    {
        Debug.Log("start stun");
        anim.SetBool("isStunned", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("isStunned", false);
        Debug.Log("end stun");
        StartCoroutine(JumpDelay(jumpDelay));

        currentActionState = ActionState.Idle;

        defaultMaterial.color = slimeColor[5];
        defaultLod1Material.color = slimeColor[5];
        defaultLod2Material.color = slimeColor[5];
        defaultLod3Material.color = slimeColor[5];
    }

    protected void PounceEnd()
    {
        StartCoroutine(JumpDelay(jumpDelay));
        anim.SetBool("isPounce", false);
        currentActionState = ActionState.Idle;
    }


    public IEnumerator DestroyTarr()
    {
        yield return new WaitForSeconds(10);
        StopAllCoroutines();
        Destroy(this.gameObject);
    }


    //목적지 설정 테스트용
    private void OnDrawGizmos()
    {
        if (destination != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, destination);
        }
    }

    void SetHungerValue()
    {
        if (hungerValue > maxHunger)
        {
            hungerValue = maxHunger;
        }
        else { }
    }



    protected virtual void Jump(int jumpForce_, int delayTime_)
    {
        if (!isJumpDelay)
        {
            isJumpDelay = true;
            currentActionState = ActionState.Jump;
            rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
            StartCoroutine(JumpDelay(delayTime_));
        }
    }

    // { jump method backup before modify
    /* protected void Jump(int jumpForce_, int delayTime_)
    {
        if (!isJumpDelay)
        {
            int frequency_;
            frequency_ = Random.Range(0, 5);
            isJumpDelay = true;
            if (slimeType1 == 2)
            {
                if (frequency_ >= 0 && frequency_ < 3)
                {
                    currentActionState = ActionState.Jump;
                    rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
                    StartCoroutine(JumpDelay(delayTime_));
                }
                else
                {
                    currentActionState = ActionState.RockFire;
                }
            }
            else
            {
                currentActionState = ActionState.Jump;
                rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
                StartCoroutine(JumpDelay(delayTime_));
            }
        }
    } */
    // } jump method backup before modify

    protected void Move(float targetDistanceValue1_, float targetDistanceValue2_)
    {
        if (currentMoodState == MoodState.Elated)
        {
            if (Vector3.Distance(transform.position, destination) > 0.3f && destination != Vector3.zero)
            {
                transform.LookAt(destination);
                transform.position += transform.forward * 3 * Time.deltaTime;
            }
            else
            {
                destination = Vector3.zero;
                StopCoroutine(SetDestination());

            }
        }
        else
        {
            if (targetToEat == null)
            {
                if (Vector3.Distance(transform.position, destination) > 0.3f && destination != Vector3.zero)
                {
                    transform.LookAt(destination);
                    transform.position += transform.forward * 3 * Time.deltaTime;
                }
                else
                {
                    destination = Vector3.zero;
                    StopCoroutine(SetDestination());
                }
            }
            else
            {
                targetPosition = new Vector3(targetToEat.transform.position.x, transform.position.y, targetToEat.transform.position.z);
                targetDistance = Vector3.Distance(transform.position, targetPosition);

                //Debug.Log(targetDistance);

                if (targetDistance > targetDistanceValue1_)
                {
                    currentActionState = ActionState.Idle;
                    //StopCoroutine(Eat());
                    transform.LookAt(targetPosition);
                    transform.position += transform.forward * 3 * Time.deltaTime;
                }
                else if (targetDistance <= targetDistanceValue1_ && targetDistance > targetDistanceValue2_)
                {
                    transform.LookAt(targetPosition);
                    transform.position += transform.forward * 3 * Time.deltaTime;
                }
                else
                {
                    //play animation bite
                    if (targetToEat != null && currentActionState != ActionState.Eat)
                    {
                        currentActionState = ActionState.Eat;
                    }
                }
            }
        }

        if (!isTarrSlime)
        {
            if (targetToEat != null && targetToEat.activeSelf == false)
            {
                targetToEat = null;
            }
        }
        else
        {
            if (targetToEat != null && targetToEat.transform.root.gameObject.activeSelf == false)
            {
                targetToEat = null;
            }
        }

    }

    float destinationDistance;
    IEnumerator SetDestination()
    {
        isSetDestination = true;
        yield return new WaitForSeconds(7);
        if (destination == Vector3.zero)
        {
            angle = Random.Range(0f, 360f);
            radiusX = Random.Range(5, 10);
            radiusZ = Random.Range(5, 10);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            posX = transform.position.x + radiusX * Mathf.Cos(angle * Mathf.Deg2Rad);
            posZ = transform.position.z + radiusZ * Mathf.Sin(angle * Mathf.Deg2Rad);
            destinationDistance = Mathf.Sqrt(Mathf.Pow(posX - transform.position.x, 2f) + Mathf.Pow(posZ - transform.position.z, 2f));
        }

        destination = new Vector3(posX, transform.position.y, posZ);

        isSetDestination = false;

        yield return new WaitForSeconds(7);
        destination = Vector3.zero;
        isSetDestination = false;

    }

    //Eat(): Legacy
    /* public virtual IEnumerator Eat()
    {
        //currentActionState = ActionState.Eat;
        currentActionState = ActionState.Wait;
        yield return new WaitForSeconds(1f);
        targetToEat.SetActive(false);
        hungerValue = 0;
        agitatedValue = 0;
        if (targetToEat.tag == "Plort")
        {
            Debug.Log("합체");
            if (slimeSize == 0)
            {
                slimeSize = 1;
                slimeType2 = targetToEat.GetComponent<PlortBase>().plortType;

                TransformSlime();
            }
            else if (slimeSize == 1)
            {
                //Transform into TarrSlime
                Instantiate(tarrSlime, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }
        else if (targetToEat.tag == "Food")
        {
            Debug.Log("플로트 생산");
            GameObject clone_ = Resources.Load<GameObject>("02.HT/Prefabs/Plort/Plort");
            if (slimeSize == 0)
            {
                clone_.GetComponent<PlortBase>().plortType = slimeType1;
                Instantiate(clone_, transform.position, transform.rotation);
            }
            else if (slimeSize == 1)
            {
                clone_.GetComponent<PlortBase>().plortType = slimeType1;
                Instantiate(clone_, transform.position, transform.rotation);
                clone_.GetComponent<PlortBase>().plortType = slimeType2;
                Instantiate(clone_, transform.position, transform.rotation);
            }
            else
            {

            }

            //색상부여 관련 수정예정
        }
        yield return new WaitForSeconds(1f);
        currentActionState = ActionState.Idle;
    } */

    protected virtual void Eat()
    {
        targetToEat.SetActive(false);
        hungerValue = 0;
        agitatedValue = 0;
        if (targetToEat.tag == "Plort")
        {
            Debug.Log("합체");
            if (slimeSize == 0)
            {
                slimeSize = 1;
                slimeType2 = targetToEat.GetComponent<PlortBase>().plortType;

                TransformSlime();
            }
            else if (slimeSize == 1)
            {
                //Transform into TarrSlime
                Instantiate(tarrSlime, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }
        else if (targetToEat.tag == "Food")
        {
            Debug.Log("플로트 생산");
            GameObject clone_ = Resources.Load<GameObject>("02.HT/Prefabs/Plort/Plort");
            if (slimeSize == 0)
            {
                clone_.GetComponent<PlortBase>().plortType = slimeType1;
                Instantiate(clone_, transform.position, transform.rotation);
            }
            else if (slimeSize == 1)
            {
                Debug.Log("?????????");
                clone_.GetComponent<PlortBase>().plortType = slimeType1;
                Instantiate(clone_, transform.position, transform.rotation);
                clone_.GetComponent<PlortBase>().plortType = slimeType2;
                Instantiate(clone_, transform.position, transform.rotation);
            }
            else
            {

            }

            //색상부여 관련 수정예정
        }
        currentActionState = ActionState.Idle;
        anim.SetBool("isBite", false);
    }

    protected IEnumerator JumpDelay(int delayTime_)
    {
        yield return new WaitForSeconds(delayTime_);
        Debug.Log("ResetJumpDelay!!!"); ;
        isJumpDelay = false;
    }

    protected IEnumerator IncreaseHunger(int time_, float increaseHungerValue_)
    {
        while (currentMoodState != MoodState.Agitated)
        {
            yield return new WaitForSeconds(time_);
            if (hungerValue != maxHunger)
            {
                hungerValue += increaseHungerValue_;
            }
            else
            {
                agitatedValue += increaseHungerValue_;
            }
        }
    }

    void SetMoodState()
    {
        if (hungerValue >= minHunger && hungerValue < 33)
        {
            currentMoodState = MoodState.Elated;
        }
        else if (hungerValue >= 33 && hungerValue < 100)
        {
            currentMoodState = MoodState.Happy;
        }
        else if (hungerValue == maxHunger)
        {
            currentMoodState = MoodState.Hungry;
        }
        else
        {

        }

        if (agitatedValue >= 100)
        {
            currentMoodState = MoodState.Agitated;
        }
        else
        {

        }
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain" && currentActionState != ActionState.Stunned)
        {
            currentActionState = ActionState.Idle;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        /* if (other.gameObject.tag == "Terrain")
        {
            currentActionState = ActionState.Jump;
        } */
    }
    void TransformSlime()
    {
        int largoSlimeIndex_ = 0;
        for (int i = 1; i < normalSlimeArray.Length - 1; i++)
        {
            for (int j = i + 1; j < normalSlimeArray.Length; j++)
            {
                largoSlimeIndex_++;

                if (slimeType1 > slimeType2 && i == slimeType2 && j == slimeType1)
                {
                    Debug.Log("t1>t2");
                    Debug.Log(slimeType1);
                    Debug.Log(slimeType2);
                    Debug.Log(largoSlimeIndex_);
                    Instantiate(largoSlimeArray[largoSlimeIndex_], transform.position, transform.rotation);
                    gameObject.SetActive(false);

                }
                else if (slimeType1 < slimeType2 && i == slimeType1 && j == slimeType2)
                {
                    Debug.Log("t2>t1");
                    Debug.Log(slimeType1);
                    Debug.Log(slimeType2);
                    Debug.Log(largoSlimeIndex_);
                    Instantiate(largoSlimeArray[largoSlimeIndex_], transform.position, transform.rotation);
                    gameObject.SetActive(false);
                }

            }
        }
    }
}
