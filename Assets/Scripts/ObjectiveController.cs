using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveController : MonoBehaviour {

    private void Start()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1: // Survival Mode
                GetComponent<TextMeshProUGUI>().text = "- Survive";
                break;
        }
            

    }

    public void UpdateObjective (string objectiveText)
    {
        GetComponent<TextMeshProUGUI>().text = objectiveText;
    }

}
