using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TheStack : MonoBehaviour

{
    public Text scoreText;
    public Text comboText;
    public Text resultsText;
    public Text moneyEarnedText;
    public GameObject blueCubePrefab;
    public Material stackMatBlue;
    public Material stackMatOrange;
    public Material stackMatGreen;
    public Material stackMatRed;
    public Material stackMatPurple;
    public Material stackMatGrey;
    public GameObject startPanel;
    public GameObject endPanel;
	public AudioClip crateDrop;

    private const float BOUNDS_SIZE = 3.5f;
    private const float STACK_MOVING_SPEED = 5.0f;
    private const float ERROR_MARGIN = 0.15f;
    private const float STACK_BOUNDS_GAIN = 0.25f;
    private const int COMBO_START_GAIN = 5;

    private GameObject[] theStack;
    private Vector2 stackBounds = new Vector2(BOUNDS_SIZE, BOUNDS_SIZE);

    private int stackIndex;
    private int scoreCount = 0;
    private int combo = 0;
    private int actualScore = 0;

    private float tileTransition = 0.0f;
    private float tileSpeed = 0.0f;
    private float secondaryPosition;

    private bool gameRunning = false;
    private bool isMovingOnX = true;
    private bool gameOver = false;

    private Vector3 desiredPosition;
    private Vector3 lastTilePosition;

    private void Start()
    {
        startPanel.SetActive(true);
        endPanel.SetActive(false);
        theStack = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            theStack[i] = transform.GetChild(i).gameObject;

        stackIndex = transform.childCount - 1;

    }

    private void CreateRubble(Vector3 pos, Vector3 scale)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        go.transform.localPosition = pos;
        go.transform.localScale = scale;
        //if (stackIndex % 2 == 0) 
        //go.transform.localRotation = Quaternion.AngleAxis(45, Vector3.up);
        go.AddComponent<Rigidbody>();

        switch (stackIndex)
        {
            case 11:
                go.GetComponent<MeshRenderer>().material = stackMatBlue;
                break;
            case 10:
                go.GetComponent<MeshRenderer>().material = stackMatOrange;
                break;
            case 9:
                go.GetComponent<MeshRenderer>().material = stackMatGreen;
                break;
            case 8:
                go.GetComponent<MeshRenderer>().material = stackMatRed;
                break;
            case 7:
                go.GetComponent<MeshRenderer>().material = stackMatPurple;
                break;
            case 6:
                go.GetComponent<MeshRenderer>().material = stackMatGrey;
                break;
            case 5:
                go.GetComponent<MeshRenderer>().material = stackMatBlue;
                break;
            case 4:
                go.GetComponent<MeshRenderer>().material = stackMatOrange;
                break;
            case 3:
                go.GetComponent<MeshRenderer>().material = stackMatGreen;
                break;
            case 2:
                go.GetComponent<MeshRenderer>().material = stackMatRed;
                break;
            case 1:
                go.GetComponent<MeshRenderer>().material = stackMatPurple;
                break;
            case 0:
                go.GetComponent<MeshRenderer>().material = stackMatGrey;
                break;
        }
    }

    private void Update()
    {
        if (!IsPointerOverUIObject() && Input.GetMouseButtonDown(0))
        {
            if (PlaceTile())
            {
				audio.Play (crateDrop);
                SpawnTile();
                scoreCount++;
                actualScore += combo + 1;

                scoreText.text = "Score: " + actualScore.ToString();
                comboText.text = "Combo: " + combo.ToString();
            }
            else
            {
                EndGame();
            }
        }
        MoveTile();
        // Move the stack
        transform.position = Vector3.Lerp(transform.position, desiredPosition, STACK_MOVING_SPEED * Time.deltaTime);
    }

    private void MoveTile()
    {
        if (gameOver)
            return;

		switch (stackIndex % 3) {
		case 0:
			tileSpeed = 2.0f;
			break;
		case 1:
			tileSpeed = 2.5f;
			break;
		case 2:
			tileSpeed = 3.0f;
			break;
		}

        tileTransition += Time.deltaTime * tileSpeed;
        if (isMovingOnX)

            theStack[stackIndex].transform.localPosition = new Vector3(Mathf.Sin(tileTransition) * BOUNDS_SIZE, scoreCount, secondaryPosition);
        else
            theStack[stackIndex].transform.localPosition = new Vector3(secondaryPosition, scoreCount, Mathf.Sin(tileTransition) * BOUNDS_SIZE);
    }


    private void SpawnTile()
    {
        lastTilePosition = theStack[stackIndex].transform.localPosition;
        stackIndex--;
        if (stackIndex < 0)
            stackIndex = transform.childCount - 1;

        desiredPosition = (Vector3.down) * scoreCount;
        //GameObject cube = Instantiate (blueCubePrefab, new Vector3 (0, scoreCount, 0), transform.rotation) as GameObject;
        //cube.transform.localScale = new Vector3 (stackBounds.x, 1, stackBounds.y);

        theStack[stackIndex].transform.localPosition = new Vector3(0, scoreCount, 0);
        theStack[stackIndex].transform.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);
    }

    private bool PlaceTile()
    {
        Transform t = theStack[stackIndex].transform;

        if (isMovingOnX)
        {
            float deltaX = lastTilePosition.x - t.position.x;
            if (Mathf.Abs(deltaX) > ERROR_MARGIN)
            {
                //CUT THE TILE
                combo = 0;
                stackBounds.x -= Mathf.Abs(deltaX);
                if (stackBounds.x <= 0)
                    return false;

                float middle = lastTilePosition.x + t.localPosition.x / 2;
                t.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);
                CreateRubble
                (
                    new Vector3((t.position.x > 0)
                        ? t.position.x + (t.localScale.x / 2)
                        : t.position.x - (t.localScale.x / 2)
                        , t.position.y
                        , t.position.z),
                    new Vector3(Mathf.Abs(deltaX), 1, t.localScale.z)
                );
                t.localPosition = new Vector3(middle - (lastTilePosition.x / 2), scoreCount, lastTilePosition.z);
            }
            else
            {
                if (combo > COMBO_START_GAIN)
                {
                    if (stackBounds.x > BOUNDS_SIZE)
                        stackBounds.x = BOUNDS_SIZE;

                    stackBounds.x += STACK_BOUNDS_GAIN;
                    float middle = lastTilePosition.x + t.localPosition.x / 2;
                    t.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);
                    t.localPosition = new Vector3(middle - (lastTilePosition.x / 2), scoreCount, lastTilePosition.z);
                }
                combo++;
                t.localPosition = new Vector3(lastTilePosition.x, scoreCount, lastTilePosition.z);
            }
        }
        else
        {
            float deltaZ = lastTilePosition.z - t.position.z;
            if (Mathf.Abs(deltaZ) > ERROR_MARGIN)
            {
                //CUT THE TILE
                combo = 0;
                stackBounds.y -= Mathf.Abs(deltaZ);
                if (stackBounds.y <= 0)
                    return false;

                float middle = lastTilePosition.z + t.localPosition.z / 2;
                t.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);
                CreateRubble
                (
                    new Vector3(t.position.x
                        , t.position.y
                        , (t.position.z > 0)
                        ? t.position.z + (t.localScale.z / 2)
                        : t.position.z - (t.localScale.z / 2)),
                    new Vector3(t.localScale.x, 1, Mathf.Abs(deltaZ))
                );
                t.localPosition = new Vector3(lastTilePosition.x, scoreCount, middle - (lastTilePosition.z / 2));
            }
            else
            {
                if (combo > COMBO_START_GAIN)
                {
                    if (stackBounds.y > BOUNDS_SIZE)
                        stackBounds.y = BOUNDS_SIZE;

                    stackBounds.y += STACK_BOUNDS_GAIN;
                    float middle = lastTilePosition.z + t.localPosition.z / 2;
                    t.localScale = new Vector3(stackBounds.x, 1, stackBounds.y);
                    t.localPosition = new Vector3(lastTilePosition.x, scoreCount, middle - (lastTilePosition.z / 2));
                }
                combo++;
                t.localPosition = lastTilePosition + Vector3.up;
            }
        }

        secondaryPosition = (isMovingOnX)
            ? t.localPosition.x
            : t.localPosition.z;

        isMovingOnX = !isMovingOnX;
        print(combo);


        return true;
    }

    private void EndGame()
    {
        Debug.Log("Lose");
        gameOver = true;
        theStack[stackIndex].AddComponent<Rigidbody>();
        if (Input.GetMouseButtonDown(0)) {
            endPanel.SetActive(true);
            resultsText.text = actualScore.ToString() + "  Crates";
            moneyEarnedText.text = "$ " + (actualScore * 20).ToString();
            Money.currentMoney += actualScore * 20;
            
        }
    }

    public void OnButtonClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
 