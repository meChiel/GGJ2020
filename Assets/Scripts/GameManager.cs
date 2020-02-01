using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public Canvas cameraCanvas;

    // Start is called before the first frame update
    void Start()
    {
        cameraCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public void GameOver()
    {
        
        canvas.transform.Find("SliderCrab").gameObject.SetActive(false);
        canvas.transform.Find("SliderCubes").gameObject.SetActive(false);

        cameraCanvas.gameObject.SetActive(true);
        //cameraCanvas.transform.Find("GameOver").gameObject.SetActive(true);
    }
}

