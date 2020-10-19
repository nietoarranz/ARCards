using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private List<LinkedList<Card>> columns;
    private List<LinkedList<Card>>  foundations;
    private Deck deck;

    public Model(List<LinkedList<Card>> columns, List<LinkedList<Card>> foundations, Deck deck) {
        this.columns = columns;
        this.foundations = foundations;
        this.deck = deck;
    }

    public List<LinkedList<Card>> getColumns() {
        return columns;
    }

    public void setColumns(List<LinkedList<Card>> columns) {
        this.columns = columns;
    }

    public List<LinkedList<Card>> getFoundations() {
        return foundations;
    }

    public void setFoundations(List<LinkedList<Card>> foundations) {
        this.foundations = foundations;
    }

    public Deck getDeck() {
        return deck;
    }

    public void setDeck(Deck deck) {
        this.deck = deck;
    }
}
