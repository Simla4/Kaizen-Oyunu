using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreScript : MonoBehaviour
{
    private Transform entryCointainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private int entryScore;
    private string entryName;
    private string entryID;
    private string entryDate;
    private string entryTime;
    private float entryTimer;
    private string fileAdress;

    [SerializeField] private Text txt_score;
    [SerializeField] private Text txt_name;
    [SerializeField] private Text txt_time;
    [SerializeField] private Text txt_ID;
    [SerializeField] private Text txt_timer;
    //[SerializeField] private InputField check;
    [SerializeField] private GameObject activeted;
    [SerializeField] private GameObject deactiveted;

    // [SerializeField] private InputField inputName;

    private void Start()
    {
        entryScore = int.Parse(txt_score.text);
        entryName = txt_name.text;
        entryID = txt_ID.text;
        entryTime = txt_time.text;
        entryDate = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy");
        entryTimer = float.Parse(txt_timer.text);
        fileAdress = "C:\\data\\kaizen-oyunu-data.json";
        //    \\\fileserver\\PAYLASIM\\BT\\
        AddHighscoreEntry(entryDate, entryTimer, entryTime, entryScore, entryID, entryName);

        entryCointainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryCointainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        /*Veriyi PlayerPrefs olarak kayýt ettik*/
        string jsonString = PlayerPrefs.GetString("highscoresTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        /*Json dosyasýna yazma*/
        FileStream fs = new FileStream(fileAdress, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(jsonString);
        sw.Flush();
        sw.Close();
        fs.Close();

        /*Gerekli verilerin sýralý bir þekilde scereboard'a yazdýrýlmasý*/
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
                else if (highscores.highscoreEntryList[j].score == highscores.highscoreEntryList[i].score)
                {
                    if (highscores.highscoreEntryList[j].timer < highscores.highscoreEntryList[i].timer)
                    {
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }
        }

        /*Bilgilerin listeye aktarýlmasý*/
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryCointainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform conteiner, List<Transform> transformList)
    {
        float templateHeight = 50f;

        Transform entryTransform = Instantiate(entryTemplate, entryCointainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }

        /*Gerekli textbox'larý bulup içine bilgilerin yazdýrýlmasý*/
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        String date = highscoreEntry.date;
        entryTransform.Find("dateText").GetComponent<Text>().text = date;

        string time = highscoreEntry.time;
        entryTransform.Find("timeText").GetComponent<Text>().text = time;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string ID = highscoreEntry.ID;
        entryTransform.Find("IDText").GetComponent<Text>().text = ID;

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    /*Veri ekleme*/
    private void AddHighscoreEntry (String date, float timer, string time, int score, string ID, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { date = date, time = time, timer = timer, score = score, ID = ID, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoresTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoresTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public float timer;
        public String date;
        public String time;
        public int score;
        public string ID;
        public string name;
    }

    public void Check()
    {
        string jsonString = PlayerPrefs.GetString("highscoresTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for(int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            if (highscores.highscoreEntryList[i].ID == txt_ID.text)
            {
                //check.text = highscores.highscoreEntryList[i].name;
                txt_name.text = highscores.highscoreEntryList[i].name;

                deactiveted.SetActive(false);
                activeted.SetActive(true);
            }

        }
    }
}
