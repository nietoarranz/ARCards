using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    
    private Model model;
    private Controller controller;
    private int view;
    private int tableX;
    private int tableY;
    private System.Random ran = new System.Random();

    public init(){

        //Creation of the ordered deck
        List<Card> orderedCards = new List<Card>();

        for(int i = 1 ; i <= 4 ; i++){
            for(int j = 1 ; j <= 12 ; j++){
                orderedCards.Add(new Card(i,j,0));
            }
        }

        //Creation of columns
        List<LinkedList<Card>> columns = new List<LinkedList<Card>>();

        for (int i = 1 ; i <=7 ; i++){
            for(int j = 1 ; j <=i ; j++){
                int randomIndex = ran.Next(orderedCards.Count);
                Card card = orderedCards[randomIndex];
                orderedCards.RemoveAt(randomIndex);

                if(j==i){
                    card.setState(2);
                }else{
                    card.setState(1);
                }

                if(j == 1){
                    LinkedList<Card> column = new LinkedList<Card>();
                    column.AddLast(card);
                    columns.Add(column);
                } else {
                    columns[i-1].AddLast(card);
                }

            }
        }

        //Transfering the rest of the cards randomly to the deck
        LinkedList<Card> deckList = new LinkedList<Card>();
        for(int i = 0; i < orderedCards.Count; i++){

            int randomIndex = ran.Next(orderedCards.Count);
            Card card = orderedCards[randomIndex];
            orderedCards.RemoveAt(randomIndex);
            deckList.AddLast(card);

        }
        Deck deck = new Deck(deckList);

        //Creating the foundations
        List<LinkedList<Card>> foundations = new List<LinkedList<Card>>();

        for(int i = 1; i <=4 ; i++){
            foundations.Add(new LinkedList<Card>());
        }

        //Creation of the model and the controller
        this.model = new Model(columns,foundations,deck);
        this.controller = new Controller(this.model);

    }

    public string showTable (){

        string response = "";

        response += '\n' + "DECK" + '\n';
        response += "=======================================" + '\n' ;

        Deck deck = this.model.getDeck();
        foreach (Card c in deck.getCards()){
            response += c.toString() + '\n';
        }

        response += '\n' + "COLUMNS" + '\n';
        response += "=======================================" + '\n' ;

        for (int i = 1 ; i <= 7 ; i++){
            response += "Column " + i + " ->" + '\n';
            LinkedList<Card> f = model.getColumns()[i-1];

            foreach (Card c in f){
                response += c.toString() + '\n' ;
            }

        }

        return response;

    }


}
