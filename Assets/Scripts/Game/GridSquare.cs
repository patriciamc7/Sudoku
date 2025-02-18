using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
{
    public GameObject number_text;
    private int number = 0;
    private int correct_number = 0;


    private bool selected = false;
    private int square_index = -1;
    private bool isDefaultValue = false;

    public void SetHasDefaultValue(bool aIsDefault)
    {
        isDefaultValue = aIsDefault;
    }

    public bool GetIsDeaultValue()
    {
        return isDefaultValue;
    }

    public bool IsSelected() { return selected; }
    public void SetSquareIndex(int index)
    {
        square_index = index;
    }

    public void SetCorrectNumber(int number)
    {
        correct_number = number;
    }

    void Start()
    {
        selected = false;
    }

    void Update()
    {

    }

    public void DisplayText()
    {
        if (number_text.GetComponent<Text>() == null)
        {
            Debug.LogError("number_text does not contain text component!!");
        }
        if (number <= 0)
            number_text.GetComponent<Text>().text = " ";
        else
            number_text.GetComponent<Text>().text = number.ToString();
    }

    public void SetNumber(int aNumber)
    {
        this.number = aNumber;
        DisplayText();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = true;
        GameEvents.SquareSelectedMethod(square_index);
    }

    public void OnSubmit(BaseEventData eventData)
    {

    }

    private void OnEnable()
    {
        GameEvents.OnUpdateSquareNumber += OnSetNumber;
        GameEvents.OnSquareSelected += OnSquareSelected;
    }

    private void OnDisable()
    {
        GameEvents.OnUpdateSquareNumber -= OnSetNumber;
        GameEvents.OnSquareSelected -= OnSquareSelected;
    }

    public void OnSetNumber(int aNumber)
    {
        if (selected && !isDefaultValue)
        {
            SetNumber(aNumber);

            if (number != correct_number)
            {
                number_text.GetComponent<Text>().color = Color.red;
                GameEvents.OnWrongNumberMethod();
            }
            else
            {
                isDefaultValue = true;
                number_text.GetComponent<Text>().color = Color.black;
            }
        }
    }

    public void OnSquareSelected(int aSquareIndex)
    {
        if (square_index != aSquareIndex)
            selected = false;
    }
}
