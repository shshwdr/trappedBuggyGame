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
    // Start is called before the first frame update
    void Awake()
    {
        EventPool.OptIn("updateCharacter", updateCharacter);
        EventPool.OptIn("finishCharacter", updateCharacter);
    }

    void updateCharacter()
    {
        image.sprite = CharacterManager.Instance.currentPlayer.GetComponent<Character>().icon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
