using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading_AG : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
    public MyBool_AG myBool;
    public bool isEnding;
    void Start()
    {
        myBool = MyBool_AG.Instance;
        SceneManager.sceneLoaded += this.OnLoadCallback;
        Invoke("StopMyBool", 1);
    }

    void OnGUI()
    {
        myBool = MyBool_AG.Instance;
        if (myBool.gameObject.activeInHierarchy)
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
            
        }
        if (isEnding)
        {
            GameObject sittingArtist = Artist_AdditionalGame_controller.Instance.gameObject;
            Destroy(sittingArtist);
            Destroy(myBool.gameObject);
        }
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        BeginFade(-1);
    }
    void StopMyBool()
    {
        myBool.gameObject.SetActive(false);
    }
}
