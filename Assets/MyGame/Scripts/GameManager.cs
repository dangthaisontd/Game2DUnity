using System;
using UnityEngine.Events;
using UnityEngine;
   
[AddComponentMenu("DangSon/GameManager")]
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance 
    { 
        get => _instance;   
    }
    [HideInInspector]
    public UnityEvent<int> onCoinChanged = new UnityEvent<int>();
    [HideInInspector]
    public UnityEvent<int, int> onHealthd = new UnityEvent<int, int>();
    [HideInInspector]
    public UnityEvent<int> onUpdateCoin = new UnityEvent<int>();

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private int coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coin = DataManager.DataCoin;
        onCoinChanged.AddListener(AddCoin);
        Invoke("UpdateCoin", 0.5f);
    }

    // Update is called once per frame
    void UpdateCoin()
    {
        onUpdateCoin.Invoke(coin);
    }
    public void AddCoin(int amount)
    {
        coin += amount;
        DataManager.DataCoin = coin;
        onUpdateCoin.Invoke(coin);
    }
     public int GetCoin()
    {
        return coin;
    }
}
