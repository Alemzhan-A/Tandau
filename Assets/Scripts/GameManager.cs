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
    public float fMovingSpeed = 0f;
    public float fSideMargin;
    float alphaText;
    public float divideValue;
    public Color textColor;
    public float fSideTrigger;
    public ResourceManager resourceManager;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    private string rightQuote;
    private string leftQuote;
    public Card currentCard;
    public Card testCard;
    public SpriteRenderer actionBackground;
    public float fTransparency;
    public float backdivideValue;

    Vector3 pos;
    public int rollDice = 0;
    public Color actionBackgroundColor;
 

    void Start()
    {
      LoadCard(testCard);
    }
    void UpdateDialogue()
    {
        actionQuote.color = textColor;
        actionBackground.color = actionBackgroundColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuote.text = leftQuote;
        }
        else
        {
            actionQuote.text = rightQuote;
        }
    }
    void Update()
    {
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        actionBackgroundColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / backdivideValue, fTransparency);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Right();
                NewCard();
                
            }
        }
        else if (cardGameObject.transform.position.x > fSideMargin)
        {
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
        }
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        UpdateDialogue();
        if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
        {

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cardGameObject.transform.position = pos;
        }
        else{
            cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position,new Vector2(0,0),fMovingSpeed);
        }
    }

    public void LoadCard(Card card)
    {
        currentCard = card;
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        characterDialogue.text = card.dialogue;

    }

    public void NewCard()
    {
        LoadCard(resourceManager.cards[rollDice]);
        rollDice += 1;
    }


    

}
