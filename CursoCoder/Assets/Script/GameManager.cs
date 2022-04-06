using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject GlobalPP;
    GameObject player;
    public int playerScore;
    public int score;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown("o"))
        {
            score = playerScore;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GlobalPpAddBloodEffect()
    {
        
        if (GlobalPP.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>().active == false)
        {
            GlobalPP.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>().active = true;
        }
        else
        {
            GlobalPP.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>().intensity.value += 0.1f;
            GlobalPP.GetComponent<PostProcessVolume>().profile.GetSetting<Vignette>().smoothness.value += 0.1f;
        }
    }
}
