using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    [SerializeField] private Transform Player;


    public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
}
