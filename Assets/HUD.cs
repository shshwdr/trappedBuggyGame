using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image image;
    public Button nextLevelButton;
    public Image[] passLevelIcons;
    public GameObject passLevelPanel;
    // Start is called before the first frame update
    void Awake()
    {
        EventPool.OptIn("updateCharacter", updateCharacter);
        EventPool.OptIn("characterTargetChange", characterTargetChange);
        nextLevelButton.onClick.AddListener(delegate
        {
            finishLevel();
        });
    }
    void finishLevel()
    {
        Debug.Log("win");

        Physics2D.gravity = new Vector2(0, -25f);
        SFXManager.Instance.playLevelComplete();
        GameManager.Instance.nextLevel();
    }

    void updateCharacter()
    {
        image.sprite = CharacterManager.Instance.currentPlayer.GetComponent<Character>().icon;
    }

    void characterTargetChange()
    {
        for(int i = 0; i < passLevelIcons.Length; i++)
        {
            if (CharacterManager.Instance.finishedState[i])
            {
                passLevelIcons[i].color = Color.white;
            }
            else
            {

                passLevelIcons[i].color = Color.black;
            }
        }
        if (CharacterManager.Instance.passedIndex > 0)
        {
            passLevelPanel.SetActive(true);
        }else
        {
            passLevelPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
