using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    Animator animator;

    int tutorialObjectGet = 0;

    int tutorialpart = 0;

    public int TutorialObjectGet { get => tutorialObjectGet; set => tutorialObjectGet = value; }



    public void Show_ok()
    {
        tutorialpart++;
    }

    public void Show_na()
    {

    }

    private void Update()
    {
          
    }
}

