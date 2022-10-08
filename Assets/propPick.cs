using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class propPick : MonoBehaviour
{
    public Transform pickPosition;

    public List<Slots> slots;

    public List<Slots> emptyslotts = new List<Slots>();

    public bool itemPickedUp = false;
    
    public GameObject inventory;

    public GameObject pickedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
            } else if (!inventory.activeSelf)
            {
                inventory.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!inventory.activeSelf)
            {
                return;
            }

            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            
            EventSystem. current.RaycastAll(m_PointerEventData, results);
            
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<Slots>() != null)
                {
                    Debug.Log("item placable");
                    Slots slot = result.gameObject.GetComponent<Slots>();
                    
                    if (!slot.doesItHoldSomething && itemPickedUp)
                    {
                        Debug.Log("Item placed");
                        itemPickedUp = false;
                        slot.doesItHoldSomething = true;
                        slot.gmitHolds = pickedItem;
                    } else if (slot.doesItHoldSomething && !itemPickedUp)
                    {
                        Debug.Log("Item taken");
                        itemPickedUp = true;
                        slot.doesItHoldSomething = false;
                        pickedItem = slot.gmitHolds;
                        slot.gmitHolds = null;
                    }
                }
            }
        }
        
        if (Input.GetKeyDown("f"))
        {
            Debug.Log(itemPickedUp);
            if (!CheckEmptySlot())
            {
                return;
            }
            
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool b = Physics.Raycast(ray, out hit);
            Debug.DrawLine(ray.origin, hit.point, Color.green, 5);
            
            if (b)
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.gameObject.GetComponent<prop>() != null)
                {
                    prop _prop = hit.transform.gameObject.GetComponent<prop>();

                    if (_prop.sellable & !itemPickedUp)
                    {
                        pickedItem = _prop.gameObject;
                        itemPickedUp = true;
                        
                        _prop.gameObject.SetActive(false);
                        
                        Debug.Log(itemPickedUp);
                    }
                }
            }
        }
    }

    public bool CheckEmptySlot()
    {
        emptyslotts = new List<Slots>();
        foreach (Slots slot in slots)
        {
            if(!slot.doesItHoldSomething)
            {
                emptyslotts.Add(slot);
                
            }
        }

        if (emptyslotts.Count > 0)
        {
            return true;
        }

        return false;
    }

    public void AddtoEmptySlot(GameObject item)
    {
        foreach (Slots emptyslot in emptyslotts)
        {
            ClearHolding();
            
            emptyslot.doesItHoldSomething = true;
            emptyslot.gmitHolds = item;

            emptyslot.gmitHolds.transform.position = emptyslot.slotPosition.position;
            return;
        }
    }

    public void ClearHolding()
    {
        itemPickedUp = false;
        pickedItem = null;
    }

    public void AddHolding(GameObject gameobj)
    {
        gameobj.transform.parent = transform;
        gameobj.transform.position = pickPosition.position;
        pickedItem = gameobj;
        itemPickedUp = true;

    }
}
