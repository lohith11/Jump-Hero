using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameInstance;

    [SerializeField]
    private GameObject Player , Platform;

    private float minX = -2.5f, maxX = 2.5f, minY = -4.7f, maxY = -3.7f;

    private bool lerpCamera;
    private float lerpTime = 1.5f;
    private float lerpX;
    
    private void Awake() 
    {
        gameInstance = this;    
        createInitialPlatform();
    }

    private void Update() 
    {
        if(lerpCamera)
        {
            lerptheCamera();
        }
    }
    void createInitialPlatform()
    {
        Vector3 temp = new Vector3(Random.Range(minX , minX + 1.2f) , Random.Range(minY , maxY) , 0 );
        Instantiate(Platform , temp , Quaternion.identity);

        temp.y += 2f;
        Instantiate(Player , temp , Quaternion.identity);

        temp = new Vector3(Random.Range(maxX , maxX - 1.2f) , Random.Range(minY , maxY) , 0 );
        Instantiate(Platform , temp , Quaternion.identity);
    }

    void lerptheCamera()
    {
        float x = Camera.main.transform.position.x;

        x = Mathf.Lerp(x , lerpX , lerpTime * Time.deltaTime);

        Camera.main.transform.position = new Vector3(x , Camera.main.transform.position.y , Camera.main.transform.position.z);

        if(Camera.main.transform.position.x >= (lerpX - 0.07f))
        {
            lerpCamera = false;
        }
    }
    public void createNewPlatformandLerp(float lerpPosition)
    {
        createNewPlatform();

        lerpX = lerpPosition + maxX;
        lerpCamera = true;
    }
    void createNewPlatform()
    {
        float cameraX  = Camera.main.transform.position.x;

        float newmaxX = (maxX * 2) + cameraX;

        Instantiate(Platform, new Vector3(Random.Range(newmaxX , newmaxX - 1.2f) , Random.Range(maxY , maxY - 1.25f) , 0), Quaternion.identity);
    }
}
