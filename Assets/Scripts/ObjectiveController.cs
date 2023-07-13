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

    private void OnEnable()
    {
        EventManager.PanicSurvival += EscapeObjectiveToggle;
    }

    private void OnDisable()
    {
        EventManager.PanicSurvival -= EscapeObjectiveToggle;
    }

    public void UpdateObjective (string objectiveText)
    {
        GetComponent<TextMeshProUGUI>().text = objectiveText;
    }

    private void EscapeObjectiveToggle (bool active)
    {
        if (active == true) {
            UpdateObjective("- ESCAPE!");
        }
        else
        {
            UpdateObjective("- Survive");
        }
    }

}
