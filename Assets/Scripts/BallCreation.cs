using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreation : MonoBehaviour
{
    public bool OnPause = true;
    public GameObject line;
    public GameObject ballPrefab;
    public List<GameObject> IcoBall;
    public List<GameObject> selectors;
    public float creationInterval = 2.0f;  // Інтервал між створенням м'ячів
    public float exlodeForceMagnitude = 2f;
    private float lastCreationTime = 0f;

    public void CreateBall(Vector3 position, BallScript.BallSize ballSize)
    {
        GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        newBall.GetComponent<BallScript>().SetSize(ballSize);

    }

    public BallScript.BallSize[] ballSizesArray = {
        BallScript.BallSize.ExtraSmall,
        BallScript.BallSize.Small,
        BallScript.BallSize.Tiny,
        BallScript.BallSize.Miniature,
        BallScript.BallSize.Normal,
        BallScript.BallSize.Large,
        BallScript.BallSize.ExtraLarge,
        BallScript.BallSize.Huge,
        BallScript.BallSize.Gigantic,
        BallScript.BallSize.Enormous

    };
    private BallScript.BallSize randomSize = BallScript.BallSize.Enormous;

    private void Start()
    {
        randomSize = GetRandomSize();
        foreach (GameObject sec in selectors)
        {
            sec.SetActive(false);
        }
        selectors[(int)randomSize].SetActive(true);
    }
    void Update()
    {
        if (OnPause) return;
        // Перевірка наявності торкань
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // Отримання позиції торкання або миші
            Vector3 inputPosition = Input.touchCount > 0 ?
                Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) :
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 topEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 1.4f, 10));

            
            // Перевірка умови для створення нового м'яча
            if (Input.GetTouch(0).phase == TouchPhase.Began && Time.time - lastCreationTime > creationInterval)
            {

                inputPosition.z = 0;
                line.transform.position = new Vector3(inputPosition.x, topEdge.y - 10);
                IcoBall[(int)randomSize].transform.position = new Vector3(inputPosition.x, topEdge.y);
            }

            if(Input.GetTouch(0).phase == TouchPhase.Ended && Time.time - lastCreationTime > creationInterval)
            {
                lastCreationTime = Time.time;
                IcoBall[(int)randomSize].transform.position = new Vector3(inputPosition.x - 20, topEdge.y);
                line.transform.position = new Vector3(inputPosition.x - 20, topEdge.y - 10);


                // Генерація рандомного розміру
         
                CreateBall(new Vector3(inputPosition.x, topEdge.y), randomSize);


                randomSize = GetRandomSize();
                foreach (GameObject sec in selectors)
                {
                    sec.SetActive(false);
                }
                selectors[(int)randomSize].SetActive(true);

            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved && Time.time - lastCreationTime > creationInterval)
            {
                IcoBall[(int)randomSize].transform.position = new Vector3(inputPosition.x, topEdge.y);
                line.transform.position = new Vector3(inputPosition.x, topEdge.y - 10);
            }
        }
    }
    BallScript.BallSize GetRandomSize()
    {
        int randomIndex = UnityEngine.Random.Range(0, 4);
        return ballSizesArray[randomIndex];
    }

}
