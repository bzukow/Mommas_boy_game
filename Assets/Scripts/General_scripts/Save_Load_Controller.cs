using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_Load_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    Character_controller player;
    Grandma_controller[] grandmas;
    Employee_controller[] employees;
    Teleporter_alcoholic_controller[] teleporters;
    Normal_alcoholic_controller[] alcoholics;
    GameObject[] thingsFromList;

    GameObject[] coins;
    public GameObject[] checks;
    public void SaveGame()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();

        grandmas = FindObjectsOfType<Grandma_controller>();
        employees = FindObjectsOfType<Employee_controller>();
        teleporters = FindObjectsOfType<Teleporter_alcoholic_controller>();
        alcoholics = FindObjectsOfType<Normal_alcoholic_controller>();
        thingsFromList = GameObject.FindGameObjectsWithTag("StuffFromList");

        coins = GameObject.FindGameObjectsWithTag("Coin");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        PlayerData data = new PlayerData();

        data.playersPosition = new float[3];
        data.playersPosition[0] = player.checkpoint.x;
        data.playersPosition[1] = player.checkpoint.y;
        data.playersPosition[2] = player.checkpoint.z;
        
        data.checks = new float[8];
        for(int i = 0; i < checks.Length; i++)
        {
            if (checks[i].activeSelf)
            {
                data.checks[i] = 1;
            }
            else
            {
                data.checks[i] = 0;
            }
        }

        data.playerscoins = player.coins;
        data.playerslives = (int)player.lives;
        data.playerscigarettes = player.cigarettes;
        data.playersshrimps = player.shrimps;
        data.playerschilli = player.chilli;
        data.playerschicken = player.chicken;
        data.playersonions = player.onions;
        data.playerslimes = player.limes;
        data.playersmushrooms = player.mushrooms;
        data.playerscoconut_milk = player.coconut_milk;
        data.playerstoilet_paper = player.toilet_paper;

        data.playerstripoloski_trousers = player.tri_poloski_trousers;
        data.playerstripoloski_sweatshirt = player.tri_poloski_sweatshirt;
        data.playerstripoloski_shoes = player.tri_poloski_shoes;

        data.grandmasPositions = new float[grandmas.Length, 3];
        for (int i = 0; i < grandmas.Length; i++)
        {
            data.grandmasPositions[i, 0] = grandmas[i].transform.parent.position.x;
            data.grandmasPositions[i, 1] = grandmas[i].transform.parent.position.y;
            data.grandmasPositions[i, 2] = grandmas[i].transform.parent.position.z;
            print("zapisalo:" + grandmas[i].transform.parent.position);
        }
        data.employeesPositions = new float[employees.Length, 3];
        for (int i = 0; i < employees.Length; i++)
        {
            data.employeesPositions[i, 0] = employees[i].transform.parent.position.x;
            data.employeesPositions[i, 1] = employees[i].transform.parent.position.y;
            data.employeesPositions[i, 2] = employees[i].transform.parent.position.z;
        }
        data.alcoholicsPositions = new float[alcoholics.Length, 4];
        for (int i = 0; i < alcoholics.Length; i++)
        {
            data.alcoholicsPositions[i, 0] = alcoholics[i].transform.parent.position.x;
            data.alcoholicsPositions[i, 1] = alcoholics[i].transform.parent.position.y;
            data.alcoholicsPositions[i, 2] = alcoholics[i].transform.parent.position.z;
            if (!alcoholics[i].transform.GetComponent<BoxCollider>().enabled)
            {
                data.alcoholicsPositions[i, 3] = 1;
            }
            else
            {
                data.alcoholicsPositions[i, 3] = 0;
            }
        }
        data.teleportersPositions = new float[teleporters.Length, 5];
        for (int i = 0; i < teleporters.Length; i++)
        {
            data.teleportersPositions[i, 0] = teleporters[i].transform.parent.position.x;
            data.teleportersPositions[i, 1] = teleporters[i].transform.parent.position.y;
            data.teleportersPositions[i, 2] = teleporters[i].transform.parent.position.z;
            data.teleportersPositions[i, 3] = teleporters[i].alreadyUsed;
            data.teleportersPositions[i, 4] = teleporters[i].firstTime;
        }
        data.thingsFromListPositions = new float[thingsFromList.Length, 3];
        for (int i = 0; i < thingsFromList.Length; i++)
        {
            data.thingsFromListPositions[i, 0] = thingsFromList[i].transform.position.x;
            data.thingsFromListPositions[i, 1] = thingsFromList[i].transform.position.y;
            data.thingsFromListPositions[i, 2] = thingsFromList[i].transform.position.z;
        }
        data.coinsPositions = new float[coins.Length, 3];
        for (int i = 0; i < coins.Length; i++)
        {
            data.coinsPositions[i, 0] = coins[i].transform.parent.position.x;
            data.coinsPositions[i, 1] = coins[i].transform.parent.position.y;
            data.coinsPositions[i, 2] = coins[i].transform.parent.position.z;
        }

        bf.Serialize(file, data);
        file.Close();
    }
    PlayerData data;
    public void LoadGame()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();

        grandmas = FindObjectsOfType<Grandma_controller>();
        employees = FindObjectsOfType<Employee_controller>();
        teleporters = FindObjectsOfType<Teleporter_alcoholic_controller>();
        alcoholics = FindObjectsOfType<Normal_alcoholic_controller>();
        thingsFromList = GameObject.FindGameObjectsWithTag("StuffFromList");
        coins = GameObject.FindGameObjectsWithTag("Coin");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
        data = (PlayerData)bf.Deserialize(file);

        file.Close();

        PlayerPrefs.DeleteAll();

        for(int i = 0; i < checks.Length; i++)
        {
            if(data.checks[i] == 1)
            {
                checks[i].SetActive(true);
            }
        }
        List<Vector3> thingsSavedPositions = new List<Vector3>();
        for (int i = 0; i < data.thingsFromListPositions.GetLength(0); i++)
        {
            thingsSavedPositions.Add(new Vector3(data.thingsFromListPositions[i, 0], data.thingsFromListPositions[i, 1], data.thingsFromListPositions[i, 2]));
        }

        foreach (GameObject thing in thingsFromList)
        {
            if (!thingsSavedPositions.Contains(thing.transform.position))
            {
                Destroy(thing.gameObject);
            }
        }
        Invoke("LoadCheckpoint", 0.00000000001f);

        List<Vector3> grandmasSavedPositions = new List<Vector3>();
        for(int i = 0; i < data.grandmasPositions.GetLength(0); i++)
        {
            grandmasSavedPositions.Add(new Vector3(data.grandmasPositions[i, 0], data.grandmasPositions[i, 1], data.grandmasPositions[i, 2]));
        }

        foreach (Grandma_controller gc in grandmas)
        {
            if (!grandmasSavedPositions.Contains(gc.transform.parent.position))
            {
                Destroy(gc.transform.parent.gameObject);
            }
        }

        List<Vector3> employeesSavedPositions = new List<Vector3>();
        for (int i = 0; i < data.employeesPositions.GetLength(0); i++)
        {
            employeesSavedPositions.Add(new Vector3(data.employeesPositions[i, 0], data.employeesPositions[i, 1], data.employeesPositions[i, 2]));
        }

        foreach (Employee_controller ec in employees)
        {
            if (!employeesSavedPositions.Contains(ec.transform.parent.position))
            {
                Destroy(ec.transform.parent.gameObject);
            }
        }

        List<Vector3> teleporterSavedPositions = new List<Vector3>();
        for (int i = 0; i < data.teleportersPositions.GetLength(0); i++)
        {
            teleporterSavedPositions.Add(new Vector3(data.teleportersPositions[i, 0], data.teleportersPositions[i, 1], data.teleportersPositions[i, 2]));
        }

        foreach (Teleporter_alcoholic_controller tac in teleporters)
        {
            if (!teleporterSavedPositions.Contains(tac.transform.parent.position))
            {
                Destroy(tac.transform.parent.gameObject);
            } else
            {
                tac.alreadyUsed = data.teleportersPositions[teleporterSavedPositions.IndexOf(tac.transform.parent.position), 3];
                tac.firstTime = data.teleportersPositions[teleporterSavedPositions.IndexOf(tac.transform.parent.position), 4];
            }
        }

        foreach (Normal_alcoholic_controller nac in alcoholics)
        {
            for (int i = 0; i < data.alcoholicsPositions.GetLength(0); i++)
            {
                if (nac.transform.parent.position.Equals(new Vector3(data.alcoholicsPositions[i, 0], data.alcoholicsPositions[i, 1], data.alcoholicsPositions[i, 2])))
                {
                    if (data.alcoholicsPositions[i, 3] == 1)
                    {
                        nac.LoadSleeping();
                    }
                }
            }
        }

       List<Vector3> coinsSavedPositions = new List<Vector3>();
        for (int i = 0; i < data.coinsPositions.GetLength(0); i++)
        {
            coinsSavedPositions.Add(new Vector3(data.coinsPositions[i, 0], data.coinsPositions[i, 1], data.coinsPositions[i, 2]));
        }

        foreach (GameObject coin in coins)
        {
            if (!coinsSavedPositions.Contains(coin.transform.parent.position))
            {
                Destroy(coin.transform.parent.gameObject);
            }
        }

        //player.checkpoint = new Vector3(data.playersPosition[0], data.playersPosition[1], data.playersPosition[2]);
        player.transform.position = player.checkpoint;
        player.coins = data.playerscoins;
        player.lives = data.playerslives;
        player.cigarettes = data.playerscigarettes;
        player.shrimps = data.playersshrimps;
        player.chilli = data.playerschilli;
        player.chicken = data.playerschicken;
        player.onions = data.playersonions;
        player.limes = data.playerslimes;
        player.mushrooms = data.playersmushrooms;
        player.coconut_milk = data.playerscoconut_milk;
        player.toilet_paper = data.playerstoilet_paper;


        player.tri_poloski_trousers = data.playerstripoloski_trousers;
        player.tri_poloski_sweatshirt = data.playerstripoloski_sweatshirt;
        player.tri_poloski_shoes = data.playerstripoloski_shoes;

        
        Invoke("LoadThis", 1f);
    }
    void LoadCheckpoint()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>();
        player.checkpoint = new Vector3(data.playersPosition[0], data.playersPosition[1], data.playersPosition[2]);
        player.transform.position = player.checkpoint;
    }
    void LoadThis()
    {
        GameObject.FindGameObjectWithTag("ProductList").GetComponent<Sheet_cotroller>().isLoaded = true;

    }
    
}

[Serializable]
class PlayerData
{
    public float[] playersPosition;
    public float[,] grandmasPositions;
    public float[,] employeesPositions;
    public float[,] teleportersPositions;
    public float[,] alcoholicsPositions;
    public float[,] thingsFromListPositions;
    public float[,] coinsPositions;

    public float[] checks;

    public float playerscoins;
    public float playerslives;
    public float playerscigarettes;
    public float playersshrimps;
    public float playerschilli;
    public float playerschicken;
    public float playersonions;
    public float playersmushrooms;
    public float playerslimes;
    public float playerscoconut_milk;
    public float playerstoilet_paper;

    public float playerstripoloski_trousers;
    public float playerstripoloski_sweatshirt;
    public float playerstripoloski_shoes;
}
