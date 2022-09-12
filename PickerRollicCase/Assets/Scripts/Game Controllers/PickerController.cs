using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerController : MonoBehaviour
{
    public BoxCollider _PickerCollider;
    List<GameObject> temp = new List<GameObject>();

    public int bN = 0;
    private void Start()
    {
        GameEvents.current.onBasketEnter += pushObjects;
    }

    void pushObjects (int bN) 
    {
        if (_PickerCollider == null) return;
        foreach (GameObject item in temp)
            {
            if (item != null)
            {
                if (_PickerCollider.bounds.Contains(item.transform.position) == true) //controlling if the object in the temp list are still in our bounds
                {
                    Rigidbody itemRgd = item.GetComponent<Rigidbody>();
                    if (itemRgd == null) return;

                    itemRgd.AddForce(transform.up * 1 * 0.00005f, ForceMode.Force); //adding force (find by trial and error :d) to pushibles which are in our bounds

                }
            }
            }
        temp.Clear(); // clearing the Pushible objects in the temp list
    }

    private void OnTriggerEnter(Collider other) //this gets the Pushible objects into a temporary list
    {
        
        if(other.tag == "Pushible")
        {
            temp.Add(other.gameObject);
        }
    }


}
