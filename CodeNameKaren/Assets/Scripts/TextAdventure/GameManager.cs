using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    class StoryBlock
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


    StoryBlock currentBlock;


    static StoryBlock block12 = new StoryBlock("Karen was satisfied with what she did and decided to go home. On her way home, she was tailgated by the child's mother and driven off a cliff. Game Over. Press a button to restart.");
    static StoryBlock block11 = new StoryBlock("Karen continued to the grocery store. She noticed that there was a Wendy's to her left.", "Continue to the grocery store.", "Go To Wendy's.");
    static StoryBlock block10 = new StoryBlock("Karen punted the child. She wondered what to do next.", "Continue to the grocery store.", "Go Home.", block11, block12);
    static StoryBlock block9 = new StoryBlock("Karen tried calling the cops on the girl, but the cops thought she was crazy and hung up. Karen was livid.", "Fight the child", "Fight the child.", block10, block10);
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
        DisplayBlock(block1);
    }

    public void Button1Clicked()
    {
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
        //else if (mainText.text == )
        //{
        //    image.sprite = backgroundSprites[2];
        //} else if (mainText.text ==)

    }
}
