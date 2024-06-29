using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    public bool isMouseOver;
    public BoxCollider2D thisCard;
    private void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnMouseOver()
    {
        isMouseOver = true;
    }
    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}


public enum CardSprite
{
    Bigim,Zhanibek,Qobylandy,Mahmud,Burundyk,Turgai,Aruaq
}