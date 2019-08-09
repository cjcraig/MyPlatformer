using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{

    //allow the scene editor/inspector to set the ui object that will display deaths
    public Text txtDeathCount;

    //this is the player, we'll check if they fall below a threshold
    private Rigidbody2D playerObj;

    public float fallDeathThreshold = -2;

    private PlayerMoveScript playMovScr;

    // Start is called before the first frame update
    void Start()
    {
        if (txtDeathCount == null)
        {
            //TODO make the script destroy itself or something if there's no text box
        }

        if (playerObj == null)
        {
            playerObj = GetComponent<Rigidbody2D>();
        }

        

        if (playMovScr == null)
        {
            playMovScr = GetComponent<PlayerMoveScript>();
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (playerObj.transform.position.y < fallDeathThreshold)
        {
            
            playMovScr.respawn();
            //insert death behaviour here
        }

        

    }

    void FixedUpdate()
    {

        

    }
}
