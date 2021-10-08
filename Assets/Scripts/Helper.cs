using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;
public class Helper : MonoBehaviour
{
    //flips sprite
    public static void FlipSprite(GameObject obj, int dir)
    {
        if (dir == Left)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


    }
    //Throw spear when player is less than 20m away
    public static void FacePlayer(GameObject object1, GameObject object2)
    {
        float x1 = object1.transform.position.x;
        float x2 = object2.transform.position.x;
        float dist = x2 - x1;
        
    }

    public static int GetObjectDir(GameObject obj)
    {
        float ang = obj.transform.eulerAngles.y;
        if (ang == 180)
        {
            return Left;
        }
        else
            return Right;
    }

    public static void MakeBullet(GameObject prefab, float xpos, float ypos, float xvel, float yvel)
    {
        // instantiate the object at xpos,ypos
        GameObject instance = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);

        // set the velocity of the instantiated object
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(xvel, yvel, 0);

        // set the direction of the instance based on the x velocity
        FlipSprite(instance, xvel < 0 ? Left : Right);
    }

}
