using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_switcher : MonoBehaviour
{
    public Transform bricksWithInfos;
    public List<GameObject> weaponList = new List<GameObject>();
    public Animator UI_animator;
    public int selectedWeapon;
    public GameObject selectedWeaponObject;
    // Start is called before the first frame update
    void Start()
    {
        weaponList.Add(GameObject.FindGameObjectWithTag("Machete"));
        weaponList.Add(GameObject.FindGameObjectWithTag("Throwing_machine"));
        selectedWeaponObject = weaponList[0];
        UI_animator = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Animator>();

        Invoke("SelectWeapon", 2);
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().canAttack)
        {
            if (Input.GetKeyDown(KeyCode.Period))
            {
                ChangeAnimation();
                if (selectedWeapon >= weaponList.Count - 1)
                {
                    
                    selectedWeapon = 0;
                    selectedWeaponObject = weaponList[selectedWeapon];
                }
                else
                {
                    selectedWeapon++;
                    selectedWeaponObject = weaponList[selectedWeapon];
                }
            }
            if (Input.GetKeyDown(KeyCode.Comma))
            {
                ChangeAnimation();
                if (selectedWeapon <= 0)
                {
                    selectedWeapon = weaponList.Count - 1;
                    selectedWeaponObject = weaponList[selectedWeapon];
                }
                else
                {
                    selectedWeapon--;
                    selectedWeaponObject = weaponList[selectedWeapon];
                }
            }
            if (previousSelectedWeapon != selectedWeapon)
            {
                SelectWeapon();
            }
        }
    }

    void ChangeAnimation()
    {
        if (UI_animator.GetBool("isCigaretteActive"))
        {
            bricksWithInfos.GetComponent<Hover_on_Bricks>().HideWhenThrowing();
            UI_animator.SetBool("isCigaretteActive", false);
        } else
        {
            bricksWithInfos.GetComponent<Hover_on_Bricks>().ShowWhenThrowing();
            UI_animator.SetBool("isCigaretteActive", true);
        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach (GameObject weapon in weaponList)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
