using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineAI : MonoBehaviour {
	public UnityEngine.UI.Text numberOfCards;
	float nextMove;
	// Use this for initialization
	void Start () {
		nextMove=Time.time+2.0f;
	}


	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<playerCards>().getTimes>=2){
			gameRuntime.grt.done=true;
			gameObject.GetComponent<playerCards>().getTimes=0;
		  }
		numberOfCards.text=gameObject.GetComponent<playerCards>().hand.Count.ToString();
		if(gameRuntime.grt.playerTurn==gameObject.name&&gameRuntime.grt.done==false){
			print("Done this");
			if(nextMove<Time.time){ 
				doMove(stackManager.stackM.topCard);
				nextMove=Time.time+0.1f;
			}
		}
	}

	private bool doMove(infoBaraja.cardContent c){
		List<infoBaraja.cardContent> myCards=gameObject.GetComponent<playerCards>().hand;
		for(int i=0;i<myCards.Count;++i){
			if(myCards[i].getColor()==c.getColor()||myCards[i].getNumber()==c.getNumber()){
				gameObject.GetComponent<playerCards>().currentCardNumber=i;
				gameObject.GetComponent<playerCards>().putCard();
				return true;
			}
		}
		gameObject.GetComponent<playerCards>().getCard(false);
		return false;
	}
}
