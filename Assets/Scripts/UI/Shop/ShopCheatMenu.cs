using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCheatMenu : ShopList
{
    static public Consumable.ConsumableType[] s_ConsumablesTypes = System.Enum.GetValues(typeof(Consumable.ConsumableType)) as Consumable.ConsumableType[];

    [SerializeField] private GameObject fishPrefabItem;
    [SerializeField] private GameObject premiumPrefabItem;
    [SerializeField] const int  cheatFishCount = 100;
    [SerializeField] const int cheatPremiumCount = 100;
	public override void Populate()
    {
		m_RefreshCallback = null;
        foreach (Transform t in listRoot)
        {
            Destroy(t.gameObject);
        }

        GameObject fishItem = Instantiate(fishPrefabItem);
        fishItem.transform.SetParent(listRoot, false);
        fishItem.GetComponent<ShopItemListItem>()
            .buyButton
            .onClick
            .AddListener(delegate () { 
                PlayerData.instance.coins += cheatFishCount;
                PlayerData.instance.Save();
             });

        GameObject premiumItem = Instantiate(premiumPrefabItem);
        premiumItem.transform.SetParent(listRoot, false);
        premiumItem.GetComponent<ShopItemListItem>()
            .buyButton
            .onClick
            .AddListener(delegate () { 
                PlayerData.instance.premium += cheatPremiumCount;
                PlayerData.instance.Save();
            });


        for(int i = 0; i < s_ConsumablesTypes.Length; ++i)
        {
            Consumable c = ConsumableDatabase.GetConsumbale(s_ConsumablesTypes[i]);
            if(c != null)
            {
                GameObject newEntry = Instantiate(prefabItem);
                newEntry.transform.SetParent(listRoot, false);

                ShopItemListItem itm = newEntry.GetComponent<ShopItemListItem>();

				itm.buyButton.image.sprite = itm.buyButtonSprite;

				itm.nameText.text = c.GetConsumableName();
				itm.icon.sprite = c.icon;

				itm.countText.gameObject.SetActive(true);
        
                itm.buyButton.onClick.AddListener(delegate () { Buy(c); });
				m_RefreshCallback += delegate () { RefreshButton(itm, c); };
				RefreshButton(itm, c);
			}
        }
    }

    


	protected void RefreshButton(ShopItemListItem itemList, Consumable c)
	{
		int count = 0;
        PlayerData.instance.consumables.TryGetValue(c.GetConsumableType(), out count);
        itemList.countText.text = count.ToString();		
	}

    public void Buy(Consumable c)
    {

		PlayerData.instance.Add(c.GetConsumableType());
        PlayerData.instance.Save();

#if UNITY_ANALYTICS // Using Analytics Standard Events v0.3.0
        var transactionId = System.Guid.NewGuid().ToString();
        var transactionContext = "store";
        var level = PlayerData.instance.rank.ToString();
        var itemId = c.GetConsumableName();
        var itemType = "consumable";
        var itemQty = 1;

        AnalyticsEvent.ItemAcquired(
            AcquisitionType.Soft,
            transactionContext,
            itemQty,
            itemId,
            itemType,
            level,
            transactionId
        );
        
        if (c.GetPrice() > 0)
        {
            AnalyticsEvent.ItemSpent(
                AcquisitionType.Soft, // Currency type
                transactionContext,
                c.GetPrice(),
                itemId,
                PlayerData.instance.coins, // Balance
                itemType,
                level,
                transactionId
            );
        }

        if (c.GetPremiumCost() > 0)
        {
            AnalyticsEvent.ItemSpent(
                AcquisitionType.Premium, // Currency type
                transactionContext,
                c.GetPremiumCost(),
                itemId,
                PlayerData.instance.premium, // Balance
                itemType,
                level,
                transactionId
            );
        }
#endif

        Refresh();
    }
}
