using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [Header("Movement")]

    private float speed = 1200f;
    private Rigidbody rb;

    [Header("Boost Management")]

    private bool canUseBoost = true;
    private float speedBoost = 3;
    private float cdBoost = 0f;

    [Header("BoostUI Picture")]

    [SerializeField] RawImage boostReady;
    [SerializeField] RawImage boost1Sec;
    [SerializeField] RawImage boost2Sec;
    [SerializeField] RawImage boost3Sec;

    private int i = 0;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        BoostIsReady();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {  

        if (cdBoost != 0)
        {
            if (cdBoost == 1)
            {
                Boost3SecLeft();
            }
            else if (cdBoost == 2)
            {
                Boost2SecLeft();
            }
            else if (cdBoost == 3)
            {
                Boost1SecLeft();
            }
        }
        else
            BoostIsReady();
    }

    void GetInput()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && canUseBoost)
        {
            boostReady.color = new Color32(104, 104, 104, 100);
            canUseBoost = false;
            speed *= speedBoost;

            StartCoroutine(Boost());
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(i == 0)
            {
                Time.timeScale = 0;
                i++;
            }
            else if (i == 1)
            {
                Time.timeScale = 1;
                i = 0;
            }
        }
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(3f);
        speed /= speedBoost;

        StartCoroutine(TimerBoost());
    }

    IEnumerator TimerBoost()
    {
        while (true)
        {
            cdBoost++;
            yield return new WaitForSeconds(1f);
            if (cdBoost == 4)
            {
                canUseBoost = true;
                cdBoost = 0f;
                boostReady.color = new Color32(255, 255, 255, 255);

                break;
            }
        }
    }

    private void BoostIsReady()
    {
        boostReady.gameObject.SetActive(true);
        boost1Sec.gameObject.SetActive(false);
        boost2Sec.gameObject.SetActive(false);
        boost3Sec.gameObject.SetActive(false);
    }

    private void Boost1SecLeft()
    {
        boostReady.gameObject.SetActive(false);
        boost1Sec.gameObject.SetActive(true);
        boost2Sec.gameObject.SetActive(false);
        boost3Sec.gameObject.SetActive(false);
    }

    private void Boost2SecLeft()
    {
        boostReady.gameObject.SetActive(false);
        boost1Sec.gameObject.SetActive(false);
        boost2Sec.gameObject.SetActive(true);
        boost3Sec.gameObject.SetActive(false);
    }

    private void Boost3SecLeft()
    {
        boostReady.gameObject.SetActive(false);
        boost1Sec.gameObject.SetActive(false);
        boost2Sec.gameObject.SetActive(false);
        boost3Sec.gameObject.SetActive(true);
    }
}
