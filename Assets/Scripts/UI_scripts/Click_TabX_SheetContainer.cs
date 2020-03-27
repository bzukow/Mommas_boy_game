using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_TabX_SheetContainer : MonoBehaviour
{
    public Sheet_cotroller sheets;
    // Start is called before the first frame update
    public void ExitSheets()
    {
        sheets.ExitWithAButton();
    }
}
