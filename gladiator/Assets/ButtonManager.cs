using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void Directioner()
    {
        string currentButton = EventSystem.current.currentSelectedGameObject.name;
        if (currentButton == "Play Button")
        {
            SceneManager.LoadScene("Arena");
        }
    }
}
