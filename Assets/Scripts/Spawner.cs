using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float _delay = .2f;

    [Header("Difficulty")]
    [SerializeField] private float cubeMass = 10f;
    
    

    private void Start()
    {
        InvokeRepeating("Spawn", _delay, _delay);

        StartCoroutine(DifficultyIncreaser());
    }
    
    private void Spawn()
    {
        Instantiate(cube, new Vector3(Random.Range(-6, 6),10,0),Quaternion.identity);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    IEnumerator DifficultyIncreaser()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            cubeMass += 0.1f;
        }
    }
}

