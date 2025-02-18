using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float every_square_offset = 0.0f;
    public float square_scale = 1.0f;
    public Vector2 start_pos = new Vector2(0.0f, 0.0f);
    public GameObject grid_square;

    private List<GameObject> grid_squares = new List<GameObject>();
    private int selected_grid_data = -1;

    void Start()
    {
        CreateGrid();
        SetGridNumbers(GameSettings.Instance.GetGameMode());
    }

    void Update()
    {

    }

    private void CreateGrid()
    {
        SpawnGridSqueare();
        SetSquarePosition();
    }

    private void SpawnGridSqueare()
    {
        int squareIndex = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                grid_squares.Add(Instantiate(grid_square) as GameObject);
                grid_squares[grid_squares.Count - 1].GetComponent<GridSquare>().SetSquareIndex(squareIndex);
                grid_squares[grid_squares.Count - 1].transform.parent = this.transform; // instantiate this GO as child of the object holding this script
                grid_squares[grid_squares.Count - 1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);
                
                squareIndex++;
            }
        }
    }

    private void SetSquarePosition()
    {
        var square_rect = grid_squares[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + every_square_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + every_square_offset;

        int column_num = 0;
        int row_num = 0;

        foreach (GameObject square in grid_squares)
        {
            if (column_num + 1 > columns)
            {
                row_num++;
                column_num = 0;
            }

            var pos_x_offset = offset.x * column_num;
            var pos_y_offset = offset.y * row_num;
            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(start_pos.x + pos_x_offset, start_pos.y - pos_y_offset);
            column_num++;
        }
    }

    private void SetGridNumbers(string aLevel)
    {
        selected_grid_data = Random.Range(0, SudokuData.Instance.sudoku_game[aLevel].Count);
        var data = SudokuData.Instance.sudoku_game[aLevel][selected_grid_data];
        SetGridSquareData(data);
    }

    private void SetGridSquareData(SudokuData.SudokuBoardData aData)
    {
        for (int i = 0; i < grid_squares.Count; i++)
        {
            grid_squares[i].GetComponent<GridSquare>().SetNumber(aData.unsolved_data[i]);
            grid_squares[i].GetComponent<GridSquare>().SetCorrectNumber(aData.solved_data[i]);
            grid_squares[i].GetComponent<GridSquare>().SetHasDefaultValue(aData.unsolved_data[i] != 0 && aData.unsolved_data[i] == aData.solved_data[i]);
        }     
    }
}
