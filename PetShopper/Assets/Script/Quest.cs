using UnityEngine;
using TMPro;
using Ink.Parsed;
using System.Collections.Generic;

public class Quest : MonoBehaviour
{
    //Customizable list for each quest. 
    [SerializeField] private List<string> quests = new List<string>();
    [SerializeField] private List<string> badEnding = new List<string>();
    [SerializeField] private List<string> goodEnding = new List<string>();
    [SerializeField] private TMP_Text _questText;
    private List<string> currentQuestLine = new List<string>();
    public int _questStep = 0;
    public bool _questComplete = false;
    public bool _playerHasWaterGun = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentQuestLine.AddRange(quests);
    }

    // Update is called once per frame
    void Update()
    {
        if(_questComplete == true)
        {
            QuestAdvance(currentQuestLine);
        }
        
        if(_questStep >= currentQuestLine.Count)
        {
            _questStep = 0;
            if (_playerHasWaterGun == false)
            {
                BadEnding();
            }
            else
            {
                GoodEnding();
            }
        }
    }

    public void QuestCompletion()
    {
        _questComplete = true;
    }

    void QuestAdvance(List <string> currentQuest)
    {
        _questText.text = currentQuest[_questStep];
        _questStep++;
        _questComplete = false; 
    }

    void BadEnding()
    {
        currentQuestLine.Clear();
        currentQuestLine.AddRange(badEnding);
    }
    void GoodEnding()
    {
        currentQuestLine.Clear();
        currentQuestLine.AddRange(goodEnding);
    }
    
    void SetInactive()
    {
        _questText.gameObject.SetActive(false);
    }
}
