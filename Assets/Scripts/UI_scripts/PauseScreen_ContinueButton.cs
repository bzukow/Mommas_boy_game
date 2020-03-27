using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen_ContinueButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ContinueGame()
    {
        transform.parent.parent.GetComponent<PauseScreen_controller>().HidePauseMenu();
    }
}
