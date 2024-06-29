using System.Collections;
using System.Collections.Generic;
using TMPro;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject cardGameObject;
    public SpriteRenderer cardSpriteRenderer;
    public CardController mainCardController;
    public float fMovingSpeed = 100f;
    public float fSideMargin;
    float alphaText;
    public float divideValue;
    public Color textColor;
    public float fSideTrigger;
    public TMP_Text dialogue;
    public ResourceManager resourceManager;
    public TMP_Text characterName;
    private string rightQuote;
    private string leftQuote;
    public Card currentCard;
    public Card testCard;

    Vector3 pos;
 

    void Start()
    {
      LoadCard(testCard);
    }
    void Update()
    {
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        dialogue.color = textColor;
        if(Input.GetMouseButton(0) && mainCardController.isMouseOver){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
        }
        else{
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position,new Vector2(0,0),0);

        }
        if(cardGameObject.transform.position.x>fSideMargin){
            dialogue.text = rightQuote;
            if(!Input.GetMouseButton(0) && cardGameObject.transform.position.x>fSideMargin){
                currentCard.Right();
            }
        }
        else if(cardGameObject.transform.position.x< -fSideMargin){
            dialogue.text = leftQuote;
            if(!Input.GetMouseButton(0) && cardGameObject.transform.position.x< -fSideMargin){
                currentCard.Left();
            }
        }
        else{
            cardSpriteRenderer.color = Color.white;
        }
    }

    public void LoadCard(Card card)
    {
        currentCard = card;
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;

    }


    

}
