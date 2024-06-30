using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject card;
    public Image human;
    public Image religion;
    public Image army;
    public Image money;
    public Image humanImpact;
    public Image religionImpact;
    public Image armyImpact;
    public Image moneyImpact;

    void Update()
    {
        human.fillAmount = (float)GameManager.human / GameManager.maxValue;
        religion.fillAmount = (float)GameManager.religion / GameManager.maxValue;
        army.fillAmount = (float)GameManager.army / GameManager.maxValue;
        money.fillAmount = (float)GameManager.money / GameManager.maxValue;

        if (card.transform.position.x > 0)
        {
            if (gameManager.currentCard.cardHumanRight != 0)
            {
                humanImpact.transform.localScale = new Vector3(1, 1, 0);
            }
            if (gameManager.currentCard.cardReligionRight != 0)
            {
                religionImpact.transform.localScale = new Vector3(1, 1, 0);
            }
            if (gameManager.currentCard.cardArmyRight != 0)
            {
                armyImpact.transform.localScale = new Vector3(1, 1, 0);
            }
            if (gameManager.currentCard.cardMoneyRight != 0)
            {
                moneyImpact.transform.localScale = new Vector3(1, 1, 0);
            }
        }
        else if (card.transform.position.x < 0)
        {
            if (gameManager.currentCard.cardHumanLeft != 0)
            {
                humanImpact.transform.localScale = new Vector3(1, 1, 0);
            }
            if (gameManager.currentCard.cardReligionLeft != 0)
            {
                religionImpact.transform.localScale = new Vector3(1, 1, 0);
            }
            if (gameManager.currentCard.cardArmyLeft != 0)
            {
                armyImpact.transform.localScale = new Vector3(1, 1, 0);
            }
            if (gameManager.currentCard.cardMoneyLeft != 0)
            {
                moneyImpact.transform.localScale = new Vector3(1, 1, 0);
            }
        }
        else
        {
            humanImpact.transform.localScale = new Vector3(0, 0, 0);
            religionImpact.transform.localScale = new Vector3(0, 0, 0);
            armyImpact.transform.localScale = new Vector3(0, 0, 0);
            moneyImpact.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
