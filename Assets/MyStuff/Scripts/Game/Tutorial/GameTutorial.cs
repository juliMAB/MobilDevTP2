using System;

public static class GameTutorial
{
    static int tutorialObjectGet = 0;

    public static Action onEndTutorial;

    public static void AddTutorialItem()
    {
        tutorialObjectGet ++;
        if (tutorialObjectGet == 2)
        {
            onEndTutorial?.Invoke();
            tutorialObjectGet = 0;
        }
    }
}

