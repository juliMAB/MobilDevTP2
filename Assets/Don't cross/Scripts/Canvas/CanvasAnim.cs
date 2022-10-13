using UnityEngine;
using UnityEngine.UI;

public class CanvasAnim : MonoBehaviour
{
    public GameObject buttons;

    public Image gamename;

    private RectTransform rect;

    public Text balancetext;

    private bool endAnim = false;

    void Start()
    {
        rect = buttons.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (StateController.Get().InGame())
        {
            balancetext.text = PlayerPrefs.GetInt("balance") + "";

            if(endAnim) return;
            endAnim = !(gamename.rectTransform.offsetMax.y < 200 && gamename.rectTransform.offsetMin.y > -200);

            gamename.rectTransform.offsetMin = new Vector2(gamename.rectTransform.offsetMin.x, gamename.rectTransform.offsetMin.y + 200f * Time.deltaTime);
            gamename.rectTransform.offsetMax = new Vector2(gamename.rectTransform.offsetMax.x, gamename.rectTransform.offsetMax.y + 200f * Time.deltaTime);
            rect.offsetMin = new Vector2(rect.offsetMin.x, rect.offsetMin.y - 300f * Time.deltaTime);
            rect.offsetMax = new Vector2(rect.offsetMax.x, rect.offsetMax.y - 300f * Time.deltaTime);
        }
    }
}
