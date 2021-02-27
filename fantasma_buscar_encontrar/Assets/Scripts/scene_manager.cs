using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    private bool aron_llego = false;
    private bool amelia_llego = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (aron_llego && amelia_llego) {
            NextScene();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Aron")) {
            aron_llego = true;
        }

        if (collision.transform.CompareTag("Amelia"))
        {
            amelia_llego = true;
        }
    }

    public void NextScene() {
        if (SceneManager.GetActiveScene().buildIndex + 1 == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    public void NextSceneChoice(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
