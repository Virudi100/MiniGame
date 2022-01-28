using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    private float _delay = .2f;

    [Header("Difficulty")]
    private float cubeMass = 10f;
    private GameObject newCube;

    private float timer = 0f;
    [SerializeField] private Text timeText;
    [SerializeField] private Text highTimeText;

    [SerializeField] private Scores datas;
    
    private void Start()
    {
        InvokeRepeating("Spawn", _delay, _delay);

        StartCoroutine(DifficultyIncreaser());
    }

    private void Update()
    {
        timer += Time.deltaTime;

        Mathf.Floor(timer);

        timeText.text = timer.ToString();
        highTimeText.text = datas.highTime.ToString();

        if (timer > datas.highTime)
        {
            datas.highTime = timer;
            
        }
    }

    private void Spawn()
    {
        newCube = Instantiate(cube, new Vector3(Random.Range(-6, 6),10,0),Quaternion.identity);
        newCube.GetComponent<Rigidbody>().mass = cubeMass;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
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

