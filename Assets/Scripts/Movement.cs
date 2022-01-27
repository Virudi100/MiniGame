using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody rb;

    private bool canUseBoost = true;
    private float speedBoost = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUseBoost)
        {
            canUseBoost = false;
            speed *= speedBoost;

            StartCoroutine(BoostReload());
        }

        
    }

    IEnumerator BoostReload()
    {
        yield return new WaitForSeconds(3f);
        canUseBoost = true;
        speed /= speedBoost;
    }
}
