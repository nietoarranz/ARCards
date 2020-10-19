using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private LinkedList<Card> cards;
    private Card cardU1;
    private Card cardU2;
    private Card cardU3;

    public Deck(LinkedList<Card> cards) {
        this.cards = cards;
        this.cardU1 = null;//most external one
        this.cardU2 = null;
        this.cardU3 = null;//least external one
    }

    public LinkedList<Card> getCards() {
        return cards;
    }

    public void setCards(LinkedList<Card> cards) {
        this.cards = cards;
    }

    public Card getCardUncovered(){
        Card response = null;
        if(this.cardU1!=null){
            response = this.cardU1;
            this.cardU1 = null;
        }else if(this.cardU2!=null){
            response = this.cardU2;
            this.cardU2 = null;
        }else{
            response = this.cardU3;
            this.cardU3 = null;
        }
        return response;
    }

    public void setUncoveredCards(){

        if(this.cardU1!=null){
            this.cards.AddLast(this.cardU1);
            this.cardU1 = null;
        }
        if(this.cardU2!=null){
            this.cards.AddLast(this.cardU2);
            this.cardU2 = null;
        }
        if(this.cardU3!=null){
            this.cards.AddLast(this.cardU3);
            this.cardU3 = null;
        }

        this.cardU3 = this.cards.First.Value;
        this.cardU2 = this.cards.First.Value;
        this.cardU1 = this.cards.First.Value;

    }
}
