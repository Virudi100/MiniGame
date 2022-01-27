using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    [SerializeField] private GameObject loseTextGo;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource loseSound;

    private void Start()
    {
        Play();
        loseTextGo.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Pause();
            music.Pause();
            loseSound.Play();
            loseTextGo.SetActive(true);
        }
        Destroy(other.gameObject);
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Play()
    {
        Time.timeScale = 1;
    }
}
