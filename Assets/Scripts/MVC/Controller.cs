using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    private Model model;
    //private View view;

    public Controller (Model model){
        this.model = model;
        //View creation
    }


    //ORIGIN:
    //1 - Deck
    //21 - Column 1
    //22 - Column 2
    //...
    //31 - Foundation 1
    //32 - Foundation 2
    //...

    //DESTINATION
    //21 - Column 1
    //22 - Column 2
    //...
    //31 - Foundation 1
    //32 - Foundation 2
    //...
    public void moveCard (int numberOfCardsMoved, int origin, int destination){

        List<Card> cardsMoved = new List<Card>();

        //GET CARDS FROM ORIGIN
        //Card from deck
        if(origin == 1){
            cardsMoved.Add(this.model.getDeck().getCardUncovered());
        }
        //Card from columns
        if(origin > 20 && origin < 30){
            int column = origin - 20 - 1;
            for(int i = 1;i<=numberOfCardsMoved;i++){
                cardsMoved.Add(this.model.getColumns()[column].First.Value);
                this.model.getColumns()[column].RemoveFirst();
            }

        }
        //Card from foundation
        if(origin>=30){
            int column = origin - 30 - 1;
            for(int i = 1;i<=numberOfCardsMoved;i++) {
                cardsMoved.Add(this.model.getFoundations()[column].First.Value);
                this.model.getFoundations()[column].RemoveFirst();
            }
        }


        //MOVE CARDS TO DESTINATION
        //Cards to columns
        if(destination > 20 && destination < 30){
            int column = destination - 20 - 1;
            for(int i = 0;i<=numberOfCardsMoved-1;i++) {
                this.model.getColumns()[column].AddLast(cardsMoved[i]);
            }
        }

        //Cards to foundation
        if(destination >= 30){
            int column = destination - 30 - 1;
            for(int i = 0;i<=numberOfCardsMoved-1;i++) {
                this.model.getFoundations()[column].AddLast(cardsMoved[i]);
            }
        }

    }

    public void uncoverCardsDeck(){
        this.model.getDeck().setUncoveredCards();
    }

    public void uncoverCardColumn(int column){
        this.model.getColumns()[column].First.Value.setState(2);
    }

}
