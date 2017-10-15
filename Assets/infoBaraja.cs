using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoBaraja : MonoBehaviour {
	public UnityEngine.UI.Image barajaCardColor;
	public UnityEngine.UI.Text barajaCardNumber;
	public UnityEngine.UI.Text cardsLeftInDeck;
    public enum color {red,blue,green,yellow,black,white};
    public static infoBaraja gameBaraja;
    public GameObject[] objectDeck;
	List<cardContent> deck;
    public bool ready;
    public int cardsLeft;
	// Use this for initialization
	void Start () {
		ready=false;
		deck = loadDeck();
		//objectDeck = createObjectDeck(deck);
		gameBaraja=this;


	}
	
	// Update is called once per frame
	void Update () {
		
		barajaCardColor.color=setCardColor(deck[0]);
		barajaCardNumber.text=deck[0].getNumber().ToString();
		ready=true;
		cardsLeft=deck.Count;
		cardsLeftInDeck.text=cardsLeft.ToString();
		if(cardsLeft<5) deck=loadDeck();
	}

	public struct cardContent
	{
		color cardColor;
		private int cardNumber;
		private bool usedC;
        public cardContent(color c, int n)
		{
            cardColor = c;
            cardNumber = n;
            usedC=false;
		}
		public cardContent(color c, int n,bool u)
		{
            cardColor = c;
            cardNumber = n;
            usedC=u;
		}
		public color getColor(){
			return cardColor;
		}
		public int getNumber(){
			return cardNumber;
		}
		public bool checkUsed(){
			return usedC;
		}
		public void setUsed(){
			usedC=true;
		}
	}

	public cardContent shareCard(){
		if(deck.Count>0){
		cardContent s = deck[0];
		deck.RemoveAt(0);
		return s;
		}
		return(new cardContent(color.green,-1));
	}


	private List<cardContent> loadDeck(){
		List<cardContent> deck = new List<cardContent>();
        deck.AddRange(loadDeckColor(deck,color.blue));
		deck.AddRange(loadDeckColor(deck,color.green));
		deck.AddRange(loadDeckColor(deck,color.red));
		deck.AddRange(loadDeckColor(deck,color.yellow));
		//deck.Add(new cardContent(color.white,-4));
		//deck.Add(new cardContent(color.white,-4));
		//deck.Add(new cardContent(color.white,-4));
		//deck.Add(new cardContent(color.white,-4));
		deck=randomizeList(deck);
        return deck;
	}
	private List<cardContent> loadDeckColor(List<cardContent> d,color c){
		List<cardContent> colorDeck = new List<cardContent>();
        int i = 0;
        while(i<10){
            colorDeck.Add(new cardContent(c,i));
            ++i;
        }
		colorDeck.Add(new cardContent(c,-2));
        return colorDeck;
	}

	List<cardContent> randomizeList(List<cardContent> l){
		cardContent tmp;
		for(int j=0;j<3;++j){
			int i=0;
			while(i<l.Count){
				int k=Random.Range(0,l.Count);
				tmp=l[k];
				l[k]=l[i];
				l[i]=tmp;
				++i;
			}
		}
		return l;
	}

	public static Color setCardColor(cardContent c){
		if(c.getColor()==infoBaraja.color.blue) return Color.blue;
		else if(c.getColor()==infoBaraja.color.red) return Color.red;
		else if(c.getColor()==infoBaraja.color.yellow) return Color.yellow;
		else if(c.getColor()==infoBaraja.color.black) return Color.black;
		else if(c.getColor()==infoBaraja.color.white) return Color.white;
		else return Color.green;	
	}
	/*
	public GameObject[] createObjectDeck(List<cardContent> l){
		GameObject[] r=new GameObject[l.Count];
		foreach(cardContent c in l){
			Instantiate
		}
	}*/
}
