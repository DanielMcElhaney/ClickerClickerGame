using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clicker : MonoBehaviour
{    
    public Text coinsText;
    public Text clickerButtonText;
    public Text upgradeButtonText; 
    public Text upgradeText;
    public Text automationButtonText;  
    public Text powerButtonText;
    public Button UpgradeButton;
    public Button ClickerButton; 
    public Button AutomationButton;
    public Button PowerButton;
    public Data coinData;
    
   

    public void Start()
    {
        coinData = new Data();
        coinData.coins = 0;   
    }
  
    
    public void Update()
    {
        //Update Coin Text
        coinsText.text = "Coins: " + coinData.coins.ToString("F0");
        //Update Clicker Button Text
        if(coinData.coinMulti>1){clickerButtonText.text = "Click" + "\r\n" + "+" + coinData.coinMulti + " Coins";};
        //Update Upgrade Text
        if(coinData.powerClickCount>1){upgradeText.text = "+"+coinData.powerClickCount+" Coins per Click";};
        //Update Upgrade Button Text
        upgradeButtonText.text = coinData.upgradeAmt.ToString("F0") + " Coins";
        //Update Automation Button Text
        automationButtonText.text = coinData.automationAmt.ToString("F0") + " Coins";
        //Update Power Button Text
        powerButtonText.text = coinData.powerAmt.ToString("F0") + " Coins";
        

        //Activates Upgrade Button
        if(coinData.coins < coinData.upgradeAmt){UpgradeButton.interactable = false;}
        else{UpgradeButton.interactable = true;}

        //Activates Automation Button
        if(coinData.coins < coinData.automationAmt){AutomationButton.interactable = false;}
        else{AutomationButton.interactable = true;}

        //Activates Power Button
        if(coinData.coins < coinData.powerAmt){PowerButton.interactable = false;}
        else{PowerButton.interactable = true;}

        //Runs the clicks per second
        if(coinData.automationClickCount>0)
        {
        coinData.coins += (coinData.automationClickCount * Time.deltaTime);
        coinData.totalCoins += (coinData.automationClickCount * Time.deltaTime);
        }
    }

    public void Click()
    {
         coinData.coins += (1*coinData.coinMulti);
         coinData.totalCoins += (1*coinData.coinMulti);
    }

    public void UpgradeClick()
    {
        coinData.coinMulti += 1*coinData.powerClickCount;
        coinData.coins -= coinData.upgradeAmt;
        coinData.upgradeClickCount +=1;
        coinData.upgradeAmt*=Random.Range(1.07f,1.15f);
    }

    public void AutomationClick()
    {
        coinData.coins -= coinData.automationAmt;
        coinData.automationClickCount +=1;
        coinData.automationAmt *= Random.Range(1.07f,1.15f);
    }  
  
    public void ClickPower()
    {
        coinData.powerClickCount++;
        coinData.powerAmt *= Random.Range(1.07f,1.15f);
    }
   
}

