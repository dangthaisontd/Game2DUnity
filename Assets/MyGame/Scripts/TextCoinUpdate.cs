using System.Collections;
using TMPro;
using UnityEngine;
[AddComponentMenu("DangSon/TextCoinUpdate")]
public class TextCoinUpdate : MonoBehaviour
{
    public TextMeshProUGUI textCoin;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.onUpdateCoin.AddListener((coin) =>
        {
            textCoin.text = coin.ToString();
        });
    }
}
