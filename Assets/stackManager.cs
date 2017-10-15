using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stackManager : MonoBehaviour {
	public List<infoBaraja.cardContent> stack;
	public UnityEngine.UI.Image stackCardColor;
	public UnityEngine.UI.Text stackCardNumber;
	public UnityEngine.UI.Text stackCardNumberBig;
	public infoBaraja.cardContent topCard;
	public static stackManager stackM;
	public bool done;

	public static stackManager st;
	// Use this for initialization
	void Start () {
		stack = new List<infoBaraja.cardContent>();
		stackM=this;
		done=false;

	}
	
	// Update is called once per frame
	void Update () {
		if(infoBaraja.gameBaraja.ready==true&&done==false){
			stack.Add(infoBaraja.gameBaraja.shareCard());
			done=true;
		}
		print("Top card: "+topCard.checkUsed());

		topCard=lastCard();
		stackCardColor.color=infoBaraja.setCardColor(topCard);
		stackCardNumber.text=topCard.getNumber().ToString();
		stackCardNumberBig.text=topCard.getNumber().ToString();
	}
	public void addCard(infoBaraja.cardContent c){
		stack.Add(c);
	}
	public infoBaraja.cardContent lastCard(){
		
		return stack[stack.Count-1];
	}
	public void setUsedComodin(){
		infoBaraja.cardContent tmp = new infoBaraja.cardContent(stack[stack.Count-1].getColor(),stack[stack.Count-1].getNumber(),true);
		stack.RemoveAt(stack.Count-1);
		stack.Add(tmp);
	}


}
