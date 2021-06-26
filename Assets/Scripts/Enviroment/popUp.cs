using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class popUp : MonoBehaviour
{   
    
    public GameObject popUpBox;
    public TMP_Text text;

    public void popup(string Text)
    {
        popUpBox.SetActive(true);
        text.text = Text;
        Time.timeScale = 0f;
    }
    public void closePopUp()
    {
        Time.timeScale = 1f;
        popUpBox.SetActive(false);
    }
}
