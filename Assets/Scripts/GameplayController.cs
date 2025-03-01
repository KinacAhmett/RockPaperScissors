using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices 
{
    NONE,
    ROCK,
    PAPER,
    SCISSORS
}

public class GameplayController : MonoBehaviour
{
    
    [SerializeField]
    private Sprite rock_sprite, paper_sprite, scissors_sprite;

    [SerializeField]
    private Image playerChoice_Img, opponentChoice_Img;

    [SerializeField]
    private Text infoText;

    private GameChoices player_Choice = GameChoices.NONE, opponent_Choice = GameChoices.NONE;

    private AnimationController animationController;

    void Awake()
    {
         animationController = FindFirstObjectByType<AnimationController>();

    }

    public void SetChoices(GameChoices gameChoices) 
    {
        switch(gameChoices) 
        {
            case GameChoices.ROCK:
            playerChoice_Img.sprite = rock_sprite;
            player_Choice = GameChoices.ROCK;
            break;
            
            case GameChoices.PAPER:
            playerChoice_Img.sprite = paper_sprite;
            player_Choice = GameChoices.PAPER;
            break;
            
            case GameChoices.SCISSORS:
            playerChoice_Img.sprite = scissors_sprite;
            player_Choice = GameChoices.SCISSORS;
            break;
        }

        SetOpponentChoice();
        DetermineWinner();


    }


    void SetOpponentChoice() 
    {
        int rnd = Random.Range(0, 3);
        switch(rnd) 
        {
            case 0:
            opponent_Choice = GameChoices.ROCK;
            opponentChoice_Img.sprite = rock_sprite;
            break;

            case 1:
            opponent_Choice = GameChoices.PAPER;
            opponentChoice_Img.sprite = paper_sprite;
            break;

            case 2:
            opponent_Choice = GameChoices.SCISSORS;
            opponentChoice_Img.sprite = scissors_sprite;
            break;

        }
    }

    void DetermineWinner() 
    {
        if(player_Choice == opponent_Choice) 
        {
            infoText.text = "It's a Draw!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(player_Choice == GameChoices.PAPER && opponent_Choice == GameChoices.ROCK) 
        {
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(opponent_Choice == GameChoices.PAPER && player_Choice == GameChoices.ROCK) 
        {
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }
        
        if(player_Choice == GameChoices.ROCK && opponent_Choice == GameChoices.SCISSORS) 
        {
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(opponent_Choice == GameChoices.ROCK && player_Choice == GameChoices.SCISSORS) 
        {
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(player_Choice == GameChoices.SCISSORS && opponent_Choice == GameChoices.PAPER) 
        {
            infoText.text = "You Win!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }

        if(opponent_Choice == GameChoices.SCISSORS && player_Choice == GameChoices.PAPER) 
        {
            infoText.text = "You Lose!";
            StartCoroutine(DisplayWinnerAndRestart());

            return;
        }
    }

    IEnumerator DisplayWinnerAndRestart() 
    {
        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations();
    }


}
