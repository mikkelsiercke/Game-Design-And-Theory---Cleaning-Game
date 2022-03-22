using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletLife = 10.0f;

    private void Update()
    {
        if(gameObject.name == "Cube(Clone)"){
            Destroy(gameObject, bulletLife);
        }
    }
}
