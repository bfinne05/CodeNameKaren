using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public class StoryBlock
    {
        public string story;
        public string option1Text;
        public string option2Text;
        public StoryBlock option1Block;
        public StoryBlock option2Block;
        public Sprite backgroundImage;

        public StoryBlock(string story, string option1Text = "", string option2Text = "", StoryBlock option1Block = null, StoryBlock option2Block = null, Sprite backgroundImage = null)
        {
            this.story = story;
            this.option1Text = option1Text;
            this.option2Text = option2Text;
            this.option1Block = option1Block;
            this.option2Block = option2Block;
            this.backgroundImage = backgroundImage;
        }

    }

    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] Button option1;
    [SerializeField] Button option2;
    [SerializeField] Image image;
    [SerializeField] public Sprite[] backgroundSprites;
    [SerializeField] public AudioSource gameOver;


    StoryBlock currentBlock;

    static StoryBlock block20 = new StoryBlock("Karen was defeated by the lowly peasant");
    static StoryBlock block19 = new StoryBlock("Karen was satisfied with what she did and decided to go home. On her way home, she was tailgated by the child's mother and driven off a cliff. Game Over. Press a button to restart.");
    static StoryBlock block18 = new StoryBlock("The man replies: GET OUT OF MY STORE.", "Fight the MANAGER.", "Fight the MANAGER.");
    static StoryBlock block17 = new StoryBlock("The man replies: I AM THE MANAGER.", "Fight the MANAGER", "Fight the MANAGER");
    static StoryBlock block16 = new StoryBlock("Karen destroyed the cashier with her facts and logic. She noticed a man with glasses approach her.", "Ask who he is.", "Ask what does he want", block17, block18);
    static StoryBlock block15 = new StoryBlock("Karen enters the grocery store and shops for her items. After she finished, she approached the register and took out her coupons. The Cashier tells her that the store doesn't accept those coupons.", "Throw Shopping Cart At Cashier.", "Throw Shopping Cart At Cashier.", block16, block16);
    static StoryBlock block14 = new StoryBlock("Karen decides to drive to Wendy's and tries to go through the drive through. She hit a curb and the car explodes. Game Over. Press a button to restart.");
    static StoryBlock block13 = new StoryBlock("Karen arrives at the grocery store and pulls into a parking space.", "Enter the grocery store.", "Go Home.", block15, block19);
    static StoryBlock block12 = new StoryBlock("Karen was satisfied with what she did and decided to go home. On her way home, she was tailgated by the child's mother and driven off a cliff. Game Over. Press a button to restart.");
    static StoryBlock block11 = new StoryBlock("Karen continued to the grocery store. She noticed that there was a Wendy's to her left.", "Continue to the grocery store.", "Go To Wendy's.", block13, block14);
    static StoryBlock block10 = new StoryBlock("Karen punted the child. She wondered what to do next.", "Continue to the grocery store.", "Go Home.", block11, block12);
    static StoryBlock block9 = new StoryBlock("Karen tried calling the cops on the girl, but the cops thought she was crazy and hung up. Karen was livid.", "Fight the child.", "Fight the child.", block10, block10);
    static StoryBlock block8 = new StoryBlock("Karen demanded to see a permit from the girl. The girl started to cry, and didn't know what Karen meant.", "Fight the child.", "Fight the child.", block10, block10);
    static StoryBlock block7 = new StoryBlock("Karen tried to ignore the girl, but she couldn't control her urges to confront her. She smiles and asks if Karen wanted to buy any cookies.", "Ask if she has a permit.", "Threaten to call the cops.", block8, block9);
    static StoryBlock block6 = new StoryBlock("Karen chooses to confront the girl. She smiles and asks if Karen wanted to buy any cookies.", "Ask if she has a permit.", "Threaten to call the cops.", block8, block9);
    static StoryBlock block5 = new StoryBlock("Karen drives to grocery store and notices a young girl scout selling cookies.", "Confront the girl.", "Ignore the girl.", block6, block7);
    static StoryBlock block4 = new StoryBlock("Karen walks to grocery store and notices a young girl scout selling cookies.", "Confront the girl.", "Ignore the girl.", block6, block7);
    static StoryBlock block3 = new StoryBlock("Karen curses out God and gets struck by lightning. Game Over. Press a button to restart.");
    static StoryBlock block2 = new StoryBlock("Karen decides to get dressed and goes to the grocery store.", "Walk to Grocery Store", "Use Car", block4, block5);
    static StoryBlock block1 = new StoryBlock("Karen wakes up in a cold sweat.", "Get Dressed.", "Curse out God.", block2, block3);

    void Start()
    {
        if (PersistentData.Instance.Block == 10)
        {
            PersistentData.Instance.Block = 0;
            DisplayBlock(block10);
        }
        else if (PersistentData.Instance.Block == 20)
        {
            DisplayBlock(block16);
        }
        else if (PersistentData.Instance.IsDead)
        {
            DisplayBlock(block20);
        }
        else
        {
            DisplayBlock(block1);
        }
    }

    public void Button1Clicked()
    {
        if (option1.GetComponentInChildren<TextMeshProUGUI>().text == "Fight the child.")
        {
            PersistentData.Instance.Block = 10;
            LoadSceneByName("BattleScene"); // Replace "BattleScene" with the name of your battle scene
            return;
        }        
        if (option1.GetComponentInChildren<TextMeshProUGUI>().text == "Throw Shopping Cart At Cashier.")
        {
            PersistentData.Instance.Block = 20;
            LoadSceneByName("BattleScene2"); // Replace "BattleScene" with the name of your battle scene
            return;
        }

        if (currentBlock.option1Block != null)
        {
            DisplayBlock(currentBlock.option1Block);
        }
        else
        {
            // Reset the game
            DisplayBlock(block1);
        }
    }

    public void Button2Clicked()
    {
        if (option2.GetComponentInChildren<TextMeshProUGUI>().text == "Fight the child.")
        {
            PersistentData.Instance.Block = 10;
            LoadSceneByName("BattleScene"); // Replace "BattleScene" with the name of your battle scene
            return;
        }        
        if (option2.GetComponentInChildren<TextMeshProUGUI>().text == "Throw Shopping Cart At Cashier.")
        {
            PersistentData.Instance.Block = 20;
            LoadSceneByName("BattleScene2"); 
            return;
        }

        if (currentBlock.option2Block != null)
        {
            DisplayBlock(currentBlock.option2Block);
        }
        else
        {
            // Reset the game
            DisplayBlock(block1);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void DisplayBlock(StoryBlock block)
    {
        mainText.text = block.story;
        option1.GetComponentInChildren<TextMeshProUGUI>().text = block.option1Text;
        option2.GetComponentInChildren<TextMeshProUGUI>().text = block.option2Text;

        if (block.backgroundImage != null)
        {
            image.sprite = block.backgroundImage;
        }

        currentBlock = block;

        if (mainText.text == "Karen wakes up in a cold sweat.")
        {
            image.sprite = backgroundSprites[0];
        }
        else if (mainText.text == "Karen decides to get dressed and goes to the grocery store.")
        {
            image.sprite = backgroundSprites[1];
        }
        else if (mainText.text == "Karen arrives at the grocery store and pulls into a parking space." )
        {
          image.sprite = backgroundSprites[2];
        } 
        else if (mainText.text == "Karen enters the grocery store and shops for her items. After she finished, she approached the register and took out her coupons. The Cashier tells her that the store doesn't accept those coupons.")
        {
            image.sprite = backgroundSprites[3];
        }
        if (mainText.text.Contains("Game Over"))
        {
            image.sprite = backgroundSprites[4];
            gameOver.Play();

        }

    }
}
