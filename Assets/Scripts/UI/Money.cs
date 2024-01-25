using TMPro;
using UnityEngine;
using static Player;

public class Money : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.OnMoneyChanged += Instance_OnMoneyChanged;
        if (PlayerPrefs.HasKey(SCORE_KEY))
        {
            moneyText.text = PlayerPrefs.GetFloat(SCORE_KEY).ToString() + "p";
        }
    }

    private void Instance_OnMoneyChanged(object sender, Player.OnMoneyChangedEventArgs e)
    {
        if (e.Money == 0)
        {
            Debug.Log("Money is 0");
        }
        else
        {
            moneyText.text = e.Money.ToString() + "p";
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
