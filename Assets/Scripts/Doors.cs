using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject RightDoor;

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
          leftDoor.SetActive(false);
          RightDoor.SetActive(false);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        { 
         leftDoor.SetActive(true);
         RightDoor.SetActive(true);
        }
        
    }

}
