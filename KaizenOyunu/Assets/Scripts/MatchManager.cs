using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    public static MatchManager instance;

    private int score = 0;
    private int counter = 0;
    public Text score_t;
    public Text highScore_t;
    //public InputField name_t;
    private string name;

    public GameObject mainObject;
    public GameObject scoreObject;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore_t.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public bool GetMatch(int x, int y)
    {
        // bool _isMatchTrue = x == y;
        bool _isMatchTrue = true;
        if(x == y)
        {
            _isMatchTrue = true;
            score += 100;
            counter++;
            if(counter == 24)
            {
                mainObject.SetActive(false);
                scoreObject.SetActive(true);
            }
            score_t.text = "" + score;
        }
            
        else
        {
            _isMatchTrue = false;
            score -= 50;
            score_t.text = "" + score;
        }

        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore_t.text = score.ToString();
        }
        

        return _isMatchTrue;
        
    }
}
