using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject name;
    public GameObject button;
    public GameObject exit;
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        button.SetActive(false);
        name.SetActive(true);
        exit.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Area1")
        {
            Debug.Log("Daðru");
        }
    }
}
