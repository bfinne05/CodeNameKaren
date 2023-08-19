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

        public StoryBlock(string story, string option1Text = "", string option2Text = "", StoryBlock option1Block = null, StoryBlock option2Block = null)
        {
            this.story = story;
            this.option1Text = option1Text;
            this.option2Text = option2Text;
            this.option1Block = option1Block;
            this.option2Block = option2Block;
        }
    }

    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] Button option1;
    [SerializeField] Button option2;

    StoryBlock currentBlock;

    static StoryBlock block7 = new StoryBlock("Karen tried to ignore the girl, but she couldn't control her urges to confront her. She smiles and asks if Karen wanted to buy any cookies.", "Ask if she has a permit.", "Threaten to call the cops.");
    static StoryBlock block6 = new StoryBlock("Karen chooses to confront the girl. She smiles and asks if Karen wanted to buy any cookies.", "Ask if she has a permit.", "Threaten to call the cops.");
    static StoryBlock block5 = new StoryBlock("Karen drives to grocery store and notices a young girl scout selling cookies.", "Confront the girl.", "Ignore the girl.", block6, block7);
    static StoryBlock block4 = new StoryBlock("Karen walks to grocery store and notices a young girl scout selling cookies.", "Confront the girl.", "Ignore the girl.", block6, block7);
    static StoryBlock block3 = new StoryBlock("Karen curses out God and gets struck by lightning. Game Over.");
    static StoryBlock block2 = new StoryBlock("Karen decides to get dressed and goes to the grocery store.", "Walk to Grocery Store", "Use Car", block4, block5);
    static StoryBlock block1 = new StoryBlock("Karen wakes up in a cold sweat.", "Get Dressed.", "Curse out God.", block2, block3);

    // Start is called before the first frame update
    void Start()
    {
        DisplayBlock(block1);
    }

    public void Button1Clicked()
    {
        DisplayBlock(currentBlock.option1Block);
    }

    public void Button2Clicked()
    {
        DisplayBlock(currentBlock.option2Block);
    }

    void DisplayBlock(StoryBlock block) 
    {
        mainText.text = block.story;
        option1.GetComponentInChildren<TextMeshProUGUI>().text = block.option1Text;
        option2.GetComponentInChildren<TextMeshProUGUI>().text = block.option2Text;

        currentBlock = block;
    }

}
