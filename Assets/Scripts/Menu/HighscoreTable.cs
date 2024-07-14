using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList ;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //此处加new Entry
        AddHighscoreEntry(10000,"CMK");

       string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        
        //Sort entry list by Score
        for (int i=0; i< highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) { 
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    //Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j]  = tmp;
                }
        }
        }
        


        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
       
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(-10, -templateHeight * transformList.Count - 35);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "1ND"; break;
            case 3: rankString = "1RD"; break;

        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        //Set background visible odds and evens, easier to read
        entryTransform.Find("background").gameObject.SetActive(rank % 2 ==1);

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name) { 
        //Create HigscoreEntry
    HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name= name};

        //Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Sve updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList; 
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
