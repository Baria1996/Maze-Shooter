using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//applied to gameManager
public class PlayerManager : MonoBehaviour {

    #region
    //a playermanager called 'instance' is created. 
    public static PlayerManager instance;
    //awake is used to initiallize a variable before the game starts 
    //or set a references between scripts.
    //here an instance of the player is being initialized.
    void Awake()
    {
        instance = this;
    }
    #endregion

    //this is the gameobject that will reference this instance of the player
    //and since we are not instantiating the player at runtime 
    //it is necessary to reference the player in this script
    public GameObject player;
}
