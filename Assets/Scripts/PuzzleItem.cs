using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Item
{
    private string riddle;
    private string answer;
    private bool solved;

    public PuzzleItem(string name, float weight, string riddle, string answer) : base(name, weight)
    {
        this.riddle = riddle;
        this.answer = answer;
        solved = false;
    }

    public string GetRiddle()
    {
        return riddle;
    }

    public string GetAnswer()
    {
        return answer;
    }

    public bool CheckAnswer(string possibleAnswer)
    {
        if (possibleAnswer == answer)
        {
            solved = true;
            return true;
        }

        return false;
    }

    public bool IsSolved()
    {
        return solved;
    }

    public void Reset()
    {
        solved = false;
    }
}
