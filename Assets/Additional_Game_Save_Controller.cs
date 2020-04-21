using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Additional_Game_Save_Controller : MonoBehaviour
{
    public SaveNickname input;
    public void SavefromInput()
    {
        input.SendNicknameToMainScript();
    }
}
