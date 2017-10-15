using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCards : MonoBehaviour {
	public infoBaraja baraja;
	public GameObject stack;
	public int currentCardNumber;
	public UnityEngine.UI.Image cardColor;
	public UnityEngine.UI.Text cardNumber;
	public UnityEngine.UI.Text cardNumberBig;
	public UnityEngine.UI.Text cardsInHand;
	public List<infoBaraja.cardContent> hand;
	private infoBaraja.cardContent currentCard;
	bool done;
	public int getTimes;
	public int cardsForEach;
	// Use this for initialization
	void Start () {
		done=false;
		hand=new List<infoBaraja.cardContent>();
		getTimes=0;
	}
	
	// Update is called once per frame
	void Update () {
		if(infoBaraja.gameBaraja.ready==true){
			if(done==false){
				for(int i=1;i<=cardsForEach;++i){
					getCard(true);
				}
				done=true;
				currentCardNumber=0;
				printCards();
			}
		if(hand.Count>0){
			currentCard=hand[currentCardNumber];
		}else{
			if(cardColor!=null) Destroy(cardColor.gameObject);
			gameRuntime.grt.won=true;
		}
		print(currentCard.getColor());
		cardColor.color=infoBaraja.setCardColor(currentCard);
		cardNumber.text=currentCard.getNumber().ToString();
		cardNumberBig.text=currentCard.getNumber().ToString();
		if(getTimes>=2){
		  gameRuntime.grt.done=true;
		  getTimes=0;
		  }
		if(gameRuntime.grt.playerTurn==gameObject.name){
			cardColor.gameObject.SetActive(true);	
		}else{
			cardColor.gameObject.SetActive(false);
		}
		}
		print("Es un comodin?: "+checkComodin(stackManager.stackM.topCard));
		print("Es positivo?: "+(stackManager.stackM.topCard.getNumber()>=0).ToString());
		cardsInHand.text=(hand.Count).ToString();
		if(hand.Count==0){
			gameRuntime.grt.winner=gameObject.name;
		}
	}

	void printCards(){
		foreach(infoBaraja.cardContent b in hand){
			print(b.getColor()+" - "+ b.getNumber());
		}
	}

	public void showNextCard(){
		if(hand.Count-1>currentCardNumber) currentCardNumber+=1;
	}

	public void showPreviousCard(){
		if(0<currentCardNumber) currentCardNumber-=1;
	}

	public void putCard(){
		
		if(gameRules(currentCard,stackManager.stackM.topCard)&&!checkComodin(stackManager.stackM.topCard)){
			if(hand.Count>1||(hand.Count==1&&currentCard.getColor().Equals(stackManager.stackM.topCard.getColor()))){
				stackManager.stackM.addCard(currentCard);
				hand.RemoveAt(currentCardNumber);
				if(currentCardNumber>hand.Count-1) showPreviousCard();
				gameRuntime.grt.done=true; 
				getTimes=0;
			}
			currentCardNumber=hand.Count-1;
		}else if(checkComodin(stackManager.stackM.topCard)){
			print("ESTO ES UN PUTO COMODIN VALE?");
			stackManager.stackM.setUsedComodin();
			forceGetCard();
		 }
	}

	public void getCard(bool init){
		if(stackManager.stackM.topCard.getNumber()>=0 || !checkComodin(stackManager.stackM.topCard)){
			hand.Add(infoBaraja.gameBaraja.shareCard());
			currentCardNumber=hand.Count-1;
			if(init==false)getTimes+=1;
			}else{
			print("ESTO ES UN PUTO COMODIN VALE?");
			stackManager.stackM.setUsedComodin();
				forceGetCard();
			}
	}

	public bool gameRules(infoBaraja.cardContent toPut,infoBaraja.cardContent current){
		bool res=toPut.getColor()==current.getColor();
		res=res||toPut.getNumber()==current.getNumber();
		res=res||toPut.getColor()==infoBaraja.color.white;
		return res;
	}
	public bool checkComodin(infoBaraja.cardContent card){
		if(card.getNumber()<0 && !card.checkUsed())return true;
		return false;
	}
	public void forceGetCard(){
		for(int i=stackManager.stackM.topCard.getNumber();i<0;++i){
					hand.Add(infoBaraja.gameBaraja.shareCard());
					currentCardNumber=hand.Count-1;					 
				}
		getTimes=0;
		gameRuntime.grt.done=true;
	}
}
