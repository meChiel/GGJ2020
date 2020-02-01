using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas canvas;
    public Canvas cameraCanvas;
    float timer;
    public Text timerText;
    bool timerCounting;
    float highscore;
    public GameObject GOtext;
    bool inMenu;



    public GameObject bucket;
    // Start is called before the first frame update
    void Start()
    {
        cameraCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        timer = 0;
        timerCounting = true;
        highscore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerCounting)
        {
        timer += Time.deltaTime;
        timerText.gameObject.GetComponent<Text>().text = "You've lasted " + Mathf.Round(timer).ToString() + " seconds.";
        }
        if(timer > 6f)
        {
            GetComponent<BirdSpawner>().enabled = true;
        }

        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) canvas.gameObject.SetActive(false);
            else canvas.gameObject.SetActive(true);
            inMenu = !inMenu;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
        {
            respawnBucket();
        }
    }

    public void respawnBucket()
    {
        bucket.transform.position = new Vector3(0.1f, 1f, 0);

    }
    public void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timerCounting = true;


    }

    public void GameOver()
    {
        timerCounting = false;
        if (timer > highscore)
        {
            highscore = timer;
            timerText.gameObject.GetComponent<Text>().text = "You have the new highscore of " + Mathf.Round(timer).ToString() + " seconds.";
        }
        else
        {
            timerText.gameObject.GetComponent<Text>().text = "You made it to " + Mathf.Round(timer).ToString() + " seconds. \n High score this session: " + Mathf.Round(highscore).ToString();
        }

        GOtext.SetActive(true);
        canvas.transform.Find("SliderCrab").gameObject.SetActive(false);
        canvas.transform.Find("SliderCubes").gameObject.SetActive(false);

        //cameraCanvas.gameObject.SetActive(true);
        //cameraCanvas.transform.Find("GameOver").gameObject.SetActive(true);
    }
}

