using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject name;
    public GameObject button;
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        button.SetActive(false);
        name.SetActive(true);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Area1")
        {
            Debug.Log("Daðru");
        }
    }
}
