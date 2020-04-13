using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Sheet_cotroller : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isTabClicked;
    public Transform ListButton;
    public bool switchStart;

    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject TabX;

    public Character_controller hasPlayerStarted;
    public NumbersSheet numbers;

    public bool isLoaded;
    public bool readInput;
    void Update()
    {
        if (switchStart)
        {
            if (Time.timeScale == 1)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(true);
                }

                PauseGame();
                isTabClicked = true;
                ListButton.GetComponent<Button>().onClick.AddListener(delegate
                {
                    ButtonClicked();
                });
                ListButton.GetComponent<Button>().enabled = false;
                switchStart = false;
                readInput = true;
            }
        }
        else if (isLoaded)
        {
            
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

            PauseGame();
            isTabClicked = true;
            ListButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                ButtonClicked();
            });
            ListButton.GetComponent<Button>().enabled = false;
            isLoaded = false;
            readInput = true;
        }
        if (readInput)
        {
            if ((Input.GetKeyDown(KeyCode.Tab) && !hasPlayerStarted.started))
            {
                ExitWithAButton();
            }
        }
    }

    private void PauseGame()
    {
        if (!switchStart || isLoaded)
        {
            numbers.ActualiseSheet();
            
        }

        Time.timeScale = 0;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        LeftArrow.SetActive(true);
        RightArrow.SetActive(true);
        TabX.SetActive(true);
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        LeftArrow.SetActive(false);
        RightArrow.SetActive(false);
        TabX.SetActive(false);
    }

    public void ButtonClicked()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<RawImage>().enabled = true;
            child.gameObject.SetActive(true);
        }
        LeftArrow.GetComponent<RawImage>().enabled = true;
        RightArrow.GetComponent<RawImage>().enabled = true;
        TabX.GetComponent<RawImage>().enabled = true;
        
        PauseGame();
        isTabClicked = true;
        ListButton.GetComponent<Button>().enabled = false;
    }

    public void ExitWithAButton()
    {
        if (!isTabClicked && Time.timeScale == 1)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<RawImage>().enabled = true;
            }
            LeftArrow.GetComponent<RawImage>().enabled = true;
            RightArrow.GetComponent<RawImage>().enabled = true;
            TabX.GetComponent<RawImage>().enabled = true;
            isTabClicked = true;

            PauseGame();
            ListButton.GetComponent<Button>().enabled = false;
        }
        else if (isTabClicked && Time.timeScale == 0)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<RawImage>().enabled = false;

            }
            LeftArrow.GetComponent<RawImage>().enabled = false;
            RightArrow.GetComponent<RawImage>().enabled = false;
            TabX.GetComponent<RawImage>().enabled = false;
            isTabClicked = false;
            ContinueGame();
            ListButton.GetComponent<Button>().enabled = true;
        }
    }
}
