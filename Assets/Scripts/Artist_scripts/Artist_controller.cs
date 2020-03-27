using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Artist_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Button toSwitchOff;
    public Button toSwitchOn;
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/Won.dat"))
        {
            transform.position = target.position;
            GetComponent<Animator>().SetBool("hadEverything", true);
            toSwitchOff.GetComponent<StartScreen_OnHover>().HideTheBubble();
            toSwitchOff.gameObject.SetActive(false);
            toSwitchOn.gameObject.SetActive(true);

        }
    }
}
