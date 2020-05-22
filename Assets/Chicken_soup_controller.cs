using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Chicken_soup_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/Won.dat"))
        {
            FileStream file = File.Create(Application.persistentDataPath + "/Won.dat");
            file.Close();
        }
    }
}
