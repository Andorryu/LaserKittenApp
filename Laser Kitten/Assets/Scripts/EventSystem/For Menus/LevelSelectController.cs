using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;
    public GameObject[] gameTypes;
    public int gameTypeIndex;
    public float speed;
    public float gameTypePosition;
    [Header("x = minimum index, y = maximum index")]
    public Vector2 minAndMax;

    // Start is called before the first frame update
    void Start()
    {
        leftArrow = GameObject.Find("LeftArrow");
        rightArrow = GameObject.Find("RightArrow");
    }

    // Update is called once per frame
    void Update()
    {
        LimitIndex();
        //Debug.Log(gameTypes[gameTypeIndex].GetComponent<RectTransform>().position.x);

        // disable left and right arrows if they won't lead anywhere
        if (gameTypeIndex == minAndMax.x) leftArrow.GetComponent<Button>().interactable = false;
        else leftArrow.GetComponent<Button>().interactable = true;
        if (gameTypeIndex == minAndMax.y) rightArrow.GetComponent<Button>().interactable = false;
        else rightArrow.GetComponent<Button>().interactable = true;
    }
    private void FixedUpdate()
    {
        MoveGameTypes();
    }

    void LimitIndex()
    {
        if (gameTypeIndex < minAndMax.x)
        {
            // (int) converts float to int
            gameTypeIndex = (int)minAndMax.x;
        }
        else if (gameTypeIndex > minAndMax.y)
        {
            // (int) converts float to int
            gameTypeIndex = (int)minAndMax.y;
        }
    }
    void MoveGameTypes()
    {
        Rigidbody2D rb = GameObject.Find("Mover").GetComponent<Rigidbody2D>();
        Vector3 pos = gameTypes[gameTypeIndex].GetComponent<RectTransform>().position;


        // if text is in 10 units range of target position,
        if (pos.x > gameTypePosition - 20 && pos.x < gameTypePosition + 20)
        {
            // zero its velocity and position
            rb.velocity = Vector2.zero;
            pos = new Vector3(gameTypePosition, pos.y, pos.z);
        }
        // otherwise, move it towards the correct position
        else if (pos.x > gameTypePosition)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (pos.x < gameTypePosition)
        {
            rb.velocity = new Vector2(speed, 0);
        }
    }

    public void ChangeIndex(int amountToAdd)
    {
        gameTypeIndex += amountToAdd;
    }

}
