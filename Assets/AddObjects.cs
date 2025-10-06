using UnityEngine;

public class AddObjects : MonoBehaviour
{
    //set object (capule item) to newItem directly in unity
    public GameObject newItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void addObject()
    {
        //add object to scene at 0,0,0
        Instantiate(newItem, Vector3.zero, Quaternion.identity);
        //create animation to move object to its place in capsule
    }

    //add this file to OnClick() under button in Unity; action should be "addObject()"
    //worse case (ex. no time) change instantiate.. to newItem.SetActive(true) or newItem.enable(true) to instantly place --> see ModifyTMR.cs

    // Update is called once per frame
    void Update()
    {
        
    }
}
