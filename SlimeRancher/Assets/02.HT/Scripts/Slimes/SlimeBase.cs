using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlimeBase : MonoBehaviour
{
    // variables for Info
    #region slimeInfo
    public string slimeName;
    public List<string> slimeNameList;
    public Sprite[] slimeIconList;
    public Sprite slimeIcon;
    #endregion



    public Rigidbody rigid;
    public bool isPickup;
    protected bool isGrounded;
    public bool isJumpDelay;

    public int jumpDelay = 10;
    public int jumpForce = 5;

    public float hungerValue;
    public float agitatedValue;
    float minHunger = 0;
    public float maxHunger = 100;
    float increaseHungerValue = 5.56f;

    public GameObject targetToEat = null;
    Vector3 targetPosition;
    float targetDistance;

    public float targetDistanceValue1;
    public float targetDistanceValue2;

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

    #region Apprearance

    protected Color defaultColor;
    public List<Color32> slimeColor;
    protected float colorAlphaValue = 0.5f;

    protected Transform shadow;
    MeshRenderer defaultMeshRenderer;
    public Material defaultMaterial;
    protected MeshRenderer defaultLod1MeshRenderer;
    public Material defaultLod1Material;
    MeshRenderer defaultLod2MeshRenderer;
    public Material defaultLod2Material;
    MeshRenderer defaultLod3MeshRenderer;
    public Material defaultLod3Material;
    #endregion

    public Animator anim;

    //var for LargoSlime
    bool isFeral;

    public MoodStateMachine moodStateMachine;
    public ActionStateMachine actionStateMachine;


    #region ActionState

    public bool canEat;
    public bool canAct;
    public bool isCoolCheckEnd = true;
    public int coolTime = 10;

    public Dictionary<string, IActionState> actionTable = new Dictionary<string, IActionState>();

    public string action1;
    public string action2;
    public int actionNumber;

    public bool isGround;
    public bool isReadyToEat;
    public bool isAbsorbed;
    #endregion




    public enum ActionState
    {
        Idle,
        Eat,
        Jump,
        //Wait,
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
        moodStateMachine = new MoodStateMachine(this);
        actionStateMachine = new ActionStateMachine(this);


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
        slimeColor.Add(new Color32(255, 30, 0, 200));  //phosporBoom

        slimeNameList = new List<string>();
        slimeNameList.Add("Empty");
        slimeNameList.Add("Pink Slime");
        slimeNameList.Add("Rock Slime");
        slimeNameList.Add("Tabby Slime");
        slimeNameList.Add("Phosphor Slime");
        slimeNameList.Add("Boom Slime");
        slimeNameList.Add("Rad Slime");

        slimeIconList = Resources.LoadAll<Sprite>("02.HT/Slimes/SlimeIcon");



        targetDistanceValue1 = 5;
        targetDistanceValue2 = 2.5f;

        plortPrefab = Resources.Load<GameObject>("02.HT/Prefabs/Plort/Plort");
    }
    public virtual void Start()
    {
        moodStateMachine.InitState(moodStateMachine.elated);
        actionStateMachine.InitState(actionStateMachine.idleState);

        rigid = GetComponent<Rigidbody>();

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
        StartCoroutine(DestinationReset());

        //currentMState = new MoodState_Elated();
        //currentMState.InitState(this);
    }

    private void OnEnable()
    {
        isJumpDelay = false;
        StartCoroutine(IncreaseHunger(1, increaseHungerValue)); // test value 1: after test, change to 60
        StartCoroutine(DestinationReset());
    }
    private void OnDisable()
    {
        isCoolCheckEnd = true;
        isAbsorbed = false;
        isJumpDelay = false;
        StopAllCoroutines();
    }

    //test
    public bool isDestOn;
    IEnumerator DestinationReset()
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
        moodStateMachine.Update();
        actionStateMachine.Act();
        AnyStateToAbsorbedState();
        SetHungerValue();


        /* if (isDestOn)
        {
            DestTestMethod();
        }

        //SetMoodState();
        if (slimeSize == 1)
        {
            SetAlphaVelue();
        }

        switch (currentActionState)
        {
            case ActionState.Idle:
                if (isJumpDelay)
                {
                    Move(targetDistanceValue1, targetDistanceValue2);
                }
                else
                {
                    Action();
                }
                StopCoroutine(SetStun());
                break;
            case ActionState.Eat:
                anim.SetBool("isBite", true);

                destination = Vector3.zero;
                isDestOn = true;
                //StartCoroutine(Eat());
                break;
            case ActionState.Jump:
                Jump(jumpForce, jumpDelay);
                break;
            //case ActionState.Wait:
            //Do Nothing
            //break;
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
        } */
    }

    void AnyStateToAbsorbedState()
    {
        if (isAbsorbed)
        {
            actionStateMachine.TransitionTo(actionStateMachine.absorbedState);
        }
    }

    void SetAlphaVelue()
    {
        if (isPickup)
        {
            Color newColor = defaultColor;
            newColor.a = colorAlphaValue;
            defaultMaterial.color = newColor;
            defaultLod1Material.color = newColor;
            defaultLod2Material.color = newColor;
            defaultLod3Material.color = newColor;

            defaultMaterial.SetFloat("_Mode", 3);
            defaultLod1Material.SetFloat("_Mode", 3);
            defaultLod2Material.SetFloat("_Mode", 3);
            defaultLod3Material.SetFloat("_Mode", 3);
        }
        else
        {
            defaultMaterial.color = defaultColor;
            defaultLod1Material.color = defaultColor;
            defaultLod2Material.color = defaultColor;
            defaultLod3Material.color = defaultColor;
            if (slimeType1 != 4 && slimeType2 != 4)
            {
                defaultMaterial.SetFloat("_Mode", 0);
                defaultLod1Material.SetFloat("_Mode", 0);
                defaultLod2Material.SetFloat("_Mode", 0);
                defaultLod3Material.SetFloat("_Mode", 0);
            }
        }
    }

    /* protected void RockFire()
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
    } */
    protected virtual void Pounce()
    {

    }

    protected virtual void Boom()
    {

    }

    protected virtual void Stunned()
    {

    }
    public virtual IEnumerator SetStun()
    {
        Debug.Log("start stun");
        anim.SetBool("isStunned", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("isStunned", false);
        StartCoroutine(JumpDelay(jumpDelay));

        currentActionState = ActionState.Idle;

        defaultMaterial.color = slimeColor[5];
        defaultLod1Material.color = slimeColor[5];
        defaultLod2Material.color = slimeColor[5];
        defaultLod3Material.color = slimeColor[5];
    }

    protected void PounceEnd()
    {
        isJumpDelay = false;
        StartCoroutine(JumpDelay(jumpDelay));
        anim.SetBool("isPounce", false);
        currentActionState = ActionState.Idle;
    }

    //tarr로 이동
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

    public abstract void Action();

    protected virtual void Jump(int jumpForce_, int delayTime_)
    {
        if (!isJumpDelay)
        {
            isJumpDelay = true;
            rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
            StartCoroutine(JumpDelay(delayTime_));
        }
    }

    public void Move(float targetDistanceValue1_, float targetDistanceValue2_)
    {
        if (moodStateMachine.currentState == moodStateMachine.elated)
        {
            if (Vector3.Distance(transform.position, destination) > 0.3f && destination != Vector3.zero)
            {
                transform.LookAt(destination);
                transform.position += transform.forward * 3 * Time.deltaTime;
            }
            else
            {
                destination = Vector3.zero;
                isDestOn = true;
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
                    isDestOn = true;
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

    /* protected virtual void Eat()
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
    } */

    protected IEnumerator JumpDelay(int delayTime_)
    {
        yield return new WaitForSeconds(delayTime_);
        isJumpDelay = false;
    }

    protected IEnumerator IncreaseHunger(int time_, float increaseValue_)
    {
        while (agitatedValue < 100)
        {
            yield return new WaitForSeconds(time_);
            if (hungerValue != maxHunger)
            {
                hungerValue += increaseValue_;
            }
            else
            {
                agitatedValue += increaseValue_;
            }
        }
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGround = true;
        }

        if (canEat && !isReadyToEat)
        {
            if (other.gameObject.tag == "Food" ||
            (other.gameObject.tag == "Plort" &&
            other.gameObject.GetComponent<PlortBase>().plortType != slimeType1 &&
            other.gameObject.GetComponent<PlortBase>().plortType != slimeType2))
            {
                isReadyToEat = true;
                targetToEat = other.gameObject;
            }
        }
    }

    public void TransformSlime()
    {
        if (slimeSize == 0)
        {
            slimeType2 = targetToEat.GetComponent<PlortBase>().plortType;

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
        else if (slimeSize == 1)
        {
            //Transform into TarrSlime
            Instantiate(tarrSlime, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    GameObject plortPrefab;
    public void MakePlort()
    {
        if (slimeSize == 0)
        {
            plortPrefab.GetComponent<PlortBase>().plortType = slimeType1;
            Instantiate(plortPrefab, transform.position, transform.rotation);
        }
        else if (slimeSize == 1)
        {
            plortPrefab.GetComponent<PlortBase>().plortType = slimeType1;
            Instantiate(plortPrefab, transform.position, transform.rotation);
            plortPrefab.GetComponent<PlortBase>().plortType = slimeType2;
            Instantiate(plortPrefab, transform.position, transform.rotation);
        }
        else
        {

        }
    }
}
