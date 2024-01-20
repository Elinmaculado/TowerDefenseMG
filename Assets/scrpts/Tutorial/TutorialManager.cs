using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    [SerializeField] GResourceManager resourceManager;
    int tutorialStep = 0;

    private void Start()
    {
        dialogText.SetText("Press left click in a gray square tu build a turret");
    }

    private void Update()
    {
        switch(tutorialStep) { 
        
            case 0:
                if (resourceManager.CurrentResources() != 50f)
                {
                    dialogText.SetText("Right click on turret to sell it");
                    tutorialStep++;
                }
                break;
            case 1:
                if(resourceManager.CurrentResources() != 0)
                {
                    dialogText.SetText("Right click on turret to sell it");
                    tutorialStep++;
                }
                break;
            default:
                break;
        }
    }

}
