using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CanvasAnim : MonoBehaviourSingleton<CanvasAnim>
{
    public GameObject buttons, balance, gameCanvas;

    public Image gamename;

    private RectTransform rect;

    public Text balancetext;

    public Text score, yourscore, bestscore;
    

    private bool endAnim = false;

    void Start()
    {
        StateController.Get().OnGoGame += () => { score.gameObject.SetActive(true); };
        StateController.Get().OnGoGame += () => { balance.SetActive(true); };
        StateController.Get().OnGoGame += () => { gameCanvas.SetActive(true); };
        
        rect = buttons.GetComponent<RectTransform>();
        UpdateBalance();
        StateController.Get().OnEndGame += UpdateEndScore;
    }

    void Update()
    {
        if (!StateController.Get().InGame()) return;

        if(endAnim) return;
        endAnim = !(gamename.rectTransform.offsetMax.y < 200 && gamename.rectTransform.offsetMin.y > -200);

        gamename.rectTransform.offsetMin = new Vector2(gamename.rectTransform.offsetMin.x, gamename.rectTransform.offsetMin.y + 200f * Time.deltaTime);
        gamename.rectTransform.offsetMax = new Vector2(gamename.rectTransform.offsetMax.x, gamename.rectTransform.offsetMax.y + 200f * Time.deltaTime);
        rect.offsetMin = new Vector2(rect.offsetMin.x, rect.offsetMin.y - 300f * Time.deltaTime);
        rect.offsetMax = new Vector2(rect.offsetMax.x, rect.offsetMax.y - 300f * Time.deltaTime);
    }
    public void UpdateScore()
    {
        score.text = DataController.Get().CurrentScore.ToString();
    }
    public void UpdateBalance()
    {
        balancetext.text = DataController.Get().Balance.ToString();
    }
    public void UpdateEndScore()
    {
        yourscore.text = "your score: " + DataController.Get().CurrentScore--;
        bestscore.text = "your best: " + DataController.Get().MaxScore;
    }
}
