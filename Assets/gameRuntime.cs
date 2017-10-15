using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameRuntime : MonoBehaviour {
	public playerCards[] players;
	public bool won;
	public bool done;
	public string playerTurn;
	int playerTurnNum;
	public static gameRuntime grt;
	public string winner;
	public GameObject wonImage;
	public UnityEngine.UI.Text winText;
	void Start () {
		grt=this;
		won=false;
		done=false;
		playerTurnNum=0;
		wonImage.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(stackManager.stackM.done==true){
			playerTurn=players[playerTurnNum].gameObject.name;
			print(playerTurn);
			if(won==false&&done==true){
				done=false;
				if(playerTurnNum==players.Length-1){
					playerTurnNum=0;
				}
				else{
					playerTurnNum+=1;
				}
			}else if(won==true&&winner=="Player") {
			print("Some player won!");
				winText.text="HAS GANADO!";
				wonImage.SetActive(true);
			}else if(won==true){
				winText.text="Has perdido...";
				wonImage.SetActive(true);
			}
		}
	}

	public void resetGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");

	}
}
