using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance;
    public int points;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        points = 0;
    }
    public void CoinCounter(int coinsCollected)
    {
        points += coinsCollected;
    }
}
