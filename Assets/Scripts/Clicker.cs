using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clicker : MonoBehaviour
{    
    public Text coinsText;
    public Text clickerButtonText;
    public Text upgradeButtonText; 
    public Text automationButtonText;  
    public Text powerButtonText;
    public Text upgradeText;
    public Text clicksPerSecond;

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
        //Update Clicks Per Second Text
        clicksPerSecond.text = "Clicks Per Second: " + coinData.automationClickCount;
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
        coinData.coins += (coinData.automationClickCount * coinData.coinMulti * Time.deltaTime);
        coinData.totalCoins += (coinData.automationClickCount * coinData.coinMulti * Time.deltaTime);
        }

    }

    public void Click()
    {
        //Adds one coin + the current multiplier
         coinData.coins += (1f*coinData.coinMulti);
         coinData.totalCoins += (1f*coinData.coinMulti);
    }

    public void UpgradeClick()
    {
        //Pays for upgrade
        coinData.coins -= coinData.upgradeAmt;

        //Increases power of the multiplier by 1 times the power modifier
        coinData.coinMulti += 1f*coinData.powerPower;
        
        //Adds 1 to the total upgrades
        coinData.upgradeClickCount +=1f;

        //Increases cost of next upgrade.
        coinData.upgradeAmt*=coinData.growthMulti;
    }

    public void AutomationClick()
    {
        //Pays for automator
        coinData.coins -= coinData.automationAmt;

        //Add 1 to count of automator purchases
        coinData.automationClickCount +=1f;

        //Increased cost of next automator
        coinData.automationAmt *= coinData.growthMulti;
    }  
  
    public void ClickPower()
    {   
        //Pays for power upgrade
        coinData.coins -= coinData.powerAmt;

        //Adds one to number of power upgrades
        coinData.powerClickCount++;

        //Increases cost of next power upgrade
        coinData.powerAmt *= coinData.growthMulti;

        //Increases the power of the upgrade
        coinData.powerPower++;
    }
   
}

