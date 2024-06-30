using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Card : ScriptableObject
{
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string leftQuote;
    public string rightQuote;
    public string dialogue;
    public int cardHumanLeft;
    public int cardReligionLeft;
    public int cardArmyLeft;
    public int cardMoneyLeft;
    public int cardHumanRight;
    public int cardReligionRight;
    public int cardArmyRight;
    public int cardMoneyRight;
    public void Left()
    {
        Debug.Log(cardName + "swiped left");
        GameManager.human += cardHumanLeft;
        GameManager.religion += cardReligionLeft;
        GameManager.army += cardArmyLeft;
        GameManager.money += cardMoneyLeft;

    }
    public void Right()
    {
        Debug.Log(cardName + "swiped right");
        GameManager.human += cardHumanRight;
        GameManager.religion += cardReligionRight;
        GameManager.army += cardArmyRight;
        GameManager.money += cardMoneyRight;
    }
}