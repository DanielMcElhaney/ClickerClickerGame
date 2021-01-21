using System.Collections;
using System.Collections.Generic;


public class Data 
{
    public double coins;
    public double totalCoins;
    public double upgradeAmt;
    public double coinMulti;
    public double upgradeClickCount;
    public double automationClickCount;
    public double automationAmt;
    public double powerAmt;
    public double powerPower;
    public double powerClickCount;
    public double growthMulti;

    public Data()
    {
        //Current Coins
        coins = 0f;
        //Lifetime Total Coins
        totalCoins = 0f;
        //Upgrade Cost
        upgradeAmt = 10f;
        //Coins per Click
        coinMulti = 1f;
        //Number of Upgrades
        upgradeClickCount = 1f;
        //Number of Automators
        automationClickCount = 0f;
        //Cost of Automators
        automationAmt = 250f;
        //Number of Power Upgrades
        powerClickCount = 1f;
        //Cost of Power Upgrade
        powerAmt = 5000f;
        //Power of Power Upgrade
        powerPower = 1f;
        //Growth Rate of Costs
        growthMulti = 1.2f;
    }
}
