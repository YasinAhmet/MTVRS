using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialQuestFollower : MonoBehaviour
{
    public propPick userInv;

    public Text text;

    public List<string> questline;
    public cashUpdater cash;

    public bool itemBought = false;
    public bool itemTaken = false;
    public bool ItemSold = false;

    public int questlineNumb = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = questline[questlineNumb];

        if (Input.GetKeyDown("g") && questlineNumb != questline.Count-1)
        {
            questlineNumb++;
        } else if (Input.GetKeyDown("l") && questlineNumb != 0)
        {
            questlineNumb--;
        }

        if (userInv.itemPickedUp && !itemTaken)
        {
            itemTaken = true;
            questlineNumb = 2;
        }

        if (cash.getMoney() < 100 && !itemBought)
        {
            itemBought = true;
            questlineNumb = 3;
        }

        if (cash.getMoney() > 100 && itemBought)
        {
            questlineNumb = 4;
        }
        
        if (Input.GetKeyDown("f"))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<ItemInsert_QuestLineBuy>() != null && userInv.itemPickedUp)
                {
                    if (hit.transform.gameObject.GetComponent<ItemInsert_QuestLineBuy>().earnloss == -50 && itemBought)
                    {
                        return;
                    }
                    
                    cash.Earn(hit.transform.gameObject.GetComponent<ItemInsert_QuestLineBuy>().earnloss);
                    userInv.AddtoEmptySlot(userInv.pickedItem);
                }
            }
        }
    }
}
