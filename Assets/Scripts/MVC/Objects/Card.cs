using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    //1 - Hearts
    //2 - Diamonds
    //3 - Clubs
    //4 - Spades
    private int suite;

    //From 1 to 12
    private int number;

    //1 - Covered
    //2 - Uncovered
    //0 - Not instantiated
    private int state;


    public Card(int suite, int number, int state) {
        this.suite = suite;
        this.number = number;
        this.state = state;
    }

    public int getSuite() {
        return suite;
    }

    public void setSuite(int suite) {
        this.suite = suite;
    }

    public int getNumber() {
        return number;
    }

    public void setNumber(int number) {
        this.number = number;
    }

    public int getState() {
        return state;
    }

    public void setState(int state) {
        this.state = state;
    }

    public string toString(){
        string response = "";
        if(this.state == 1){
            response += "[COVERED]";
        }
        if(this.state == 2){
            response += "[VISIBLE]";
        }

        response += " " + this.number + " ";

        if (this.suite == 1){
            response += "Hearts";
        }
        if (this.suite == 2){
            response += "Diamonds";
        }
        if (this.suite == 3){
            response += "Clubs";
        }
        if (this.suite == 4){
            response += "Spades";
        }

        return response;
    }


}
