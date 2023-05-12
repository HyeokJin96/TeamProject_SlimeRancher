using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test_veggie : MonoBehaviour
{
    [SerializeField] private GameObject model_carrot;
    [SerializeField] private GameObject sprout_carrot;

    [SerializeField] private GameObject model_heartbeet;
    [SerializeField] private GameObject sprout_heartbeet;

    [SerializeField] private GameObject model_ocaoca;
    [SerializeField] private GameObject sprout_ocaoca;

    [SerializeField] private GameObject model_cuberry;
    [SerializeField] private GameObject sprout_cuberry;

    [SerializeField] private Rigidbody rigidbody = default;
    [SerializeField] private float growthRate = default;

    [SerializeField] public bool isGrowing = false;
    [SerializeField] float boundForce = default;

    private float startPosY = default;
    private float currentPosY = default;
    private float maxPosY = default;

    private Vector3 initialScale = default;
    private Vector3 currentScale = default;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        model_carrot.GetComponent<MeshCollider>().enabled = false;

        isGrowing = true;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;

        initialScale = sprout_carrot.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        startPosY = 28.29541f;
        maxPosY = 28.4f;

    }

    private void Update()
    {
        if (isGrowing)
        {
            currentScale = currentScale + new Vector3(growthRate, growthRate, growthRate);
            sprout_carrot.transform.localScale = currentScale;

            currentPosY = Mathf.Lerp(startPosY, maxPosY, currentScale.x);
            transform.position = new Vector3(transform.position.x, currentPosY, transform.position.z);

            if (currentScale.x >= 1f)
            {
                rigidbody.isKinematic = false;

                rigidbody.AddForce(Vector3.up * boundForce, ForceMode.Impulse);

                isGrowing = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            model_carrot.GetComponent<MeshCollider>().enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
