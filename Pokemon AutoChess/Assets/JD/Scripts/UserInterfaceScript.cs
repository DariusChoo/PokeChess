using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceScript : MonoBehaviour
{

        /* Player */

    //UI_Player Level
    private int LvNum; public Text LvNumUIText;
    private int HealthNum; public Text HealthNumUIText;

    //UI_Top
    //private string TopPlayerName; public Text TopPlayerNameUIText;
    private int TopRoundCount; public Text TopRoundCountUIText;


        /* Opponent */

    void Start()
    {
        LvNum = 3; HealthNum = 3; TopRoundCount = 3;
    }

    void Update()
    {
        LvNumUIText.text = LvNum.ToString();
        HealthNumUIText.text = HealthNum.ToString();
        TopRoundCountUIText.text = TopRoundCount.ToString();

    }


    /* public void GetPlayerName(string name){
        PlayerName = name;
    }

    public void GetOpponentName(string name){
        OpponentName = name;
    }
    */

    //Item Menu
    public void ItemMenu(){
        //Do something here
    }

    //Shop Menu
    public void ShopMenu(){
        //Do something here
    }
}
