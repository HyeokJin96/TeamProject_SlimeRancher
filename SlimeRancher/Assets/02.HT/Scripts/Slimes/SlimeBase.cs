using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBase : MonoBehaviour
{
    protected Rigidbody rigid;

    protected bool isGrounded;
    protected bool isJumpDelay;

    int jumpDelay = 5;
    int jumpForce = 5;

    public float hungerValue;   // after test, delete public 
    public float agitatedValue; // after test, delete public
    float minHunger = 0;
    float maxHunger = 100;

    public GameObject targetToEat = null;
    Vector3 targetPosition;
    float targetDistance;

    protected float targetDistanceValue1;
    protected float targetDistanceValue2;

    //var for move

    float minRadius = 8;
    float maxRadius = 10;
    float angle;
    float posX;
    float posZ;
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

    Transform shadow;
    MeshRenderer defaultMeshRenderer;
    public Material defaultMaterial;
    MeshRenderer defaultLod1MeshRenderer;
    public Material defaultLod1Material;
    MeshRenderer defaultLod2MeshRenderer;
    public Material defaultLod2Material;
    MeshRenderer defaultLod3MeshRenderer;
    public Material defaultLod3Material;

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
        Wait
    }

    public ActionState currentActionState;

    private void Awake()
    {
        //slimeArray = Resources.LoadAll<GameObject>("02.HT/Prefabs/Slimes");
        normalSlimeArray = Resources.LoadAll<GameObject>("02.HT/Prefabs/Slimes/NormalSlimes");
        largoSlimeArray = Resources.LoadAll<GameObject>("02.HT/Prefabs/Slimes/LargoSlimes");
        tarrSlime = Resources.Load<GameObject>("02.HT/Prefabs/Slimes/TarrSlime/TarrSlime");

        slimeColor = new List<Color32>();
        slimeColor.Add(new Color32(255, 255, 255, 255));
        slimeColor.Add(new Color32(225, 60, 90, 255));
        slimeColor.Add(new Color32(30, 125, 200, 255));  //rock

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


        StartCoroutine(IncreaseHunger(1)); // test value 1: after test, change to 60
    }

    public virtual void Update()
    {
        SetHungerValue();
        SetMoodState();

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
                //Jump(jumpForce, jumpDelay); //move 메서드 안으로 이동?
                break;
            case ActionState.Eat:
                StartCoroutine(Eat());
                break;
            case ActionState.Jump:
                //Do Nothing
                break;
            case ActionState.Wait:
                //Do Nothing
                break;
            default:
                break;
        }
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

    protected void Jump(int jumpForce_, int delayTime_)
    {
        if (!isJumpDelay)
        {
            isJumpDelay = true;
            currentActionState = ActionState.Jump;
            rigid.AddForce(Vector3.up * jumpForce_, ForceMode.Impulse);
            StartCoroutine(JumpDelay(delayTime_));
        }
    }

    protected void Move(float targetDistanceValue1_, float targetDistanceValue2_)
    {
        Jump(jumpForce, jumpDelay); //move 메서드 안으로 이동?
        if (!isSetDestination)
        {
            StartCoroutine(SetDestination());
        }

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
                    StopCoroutine(Eat());
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
        yield return new WaitForSeconds(10);
        while (destinationDistance < minRadius)
        {
            angle = Random.Range(0f, 360f);
            posX = transform.position.x + maxRadius * Mathf.Cos(angle * Mathf.Deg2Rad);
            posZ = transform.position.z + maxRadius * Mathf.Sin(angle * Mathf.Deg2Rad);
            destinationDistance = Mathf.Sqrt(Mathf.Pow(posX - transform.position.x, 2f) + Mathf.Pow(posZ - transform.position.z, 2f));
        }
        destination = new Vector3(posX, transform.position.y, posZ);

        isSetDestination = false;
    }

    public virtual IEnumerator Eat()
    {
        //currentActionState = ActionState.Eat;
        currentActionState = ActionState.Wait;
        yield return new WaitForSeconds(3f);
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
    }

    IEnumerator JumpDelay(int delayTime_)
    {
        yield return new WaitForSeconds(delayTime_);
        isJumpDelay = false;
    }

    IEnumerator IncreaseHunger(int time_)
    {
        while (currentMoodState != MoodState.Agitated)
        {
            yield return new WaitForSeconds(time_);
            if (hungerValue != maxHunger)
            {
                hungerValue += 5.56f;
            }
            else
            {
                agitatedValue += 5.56f;
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
        if (other.gameObject.tag == "Terrain")
        {
            currentActionState = ActionState.Idle;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            currentActionState = ActionState.Jump;
        }
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
                    Instantiate(largoSlimeArray[largoSlimeIndex_], transform.position, transform.rotation);
                    gameObject.SetActive(false);

                }
                else if (slimeType1 < slimeType2 && i == slimeType1 && j == slimeType2)
                {
                    Instantiate(largoSlimeArray[largoSlimeIndex_], transform.position, transform.rotation);
                    gameObject.SetActive(false);
                }

            }
        }
    }
}
