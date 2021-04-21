using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just a class to help organize what dialogue Bit will have during the different phases of the game
public class BitDialogue
{
    // General fields
    public string[] firstBefore = new string[]
    {
        "Good morning, Gunther!",
        "It's a beautiful day, isn't it?",
        "Why don't you go play outside for a bit while I contact Master?"
    };
    public int firstBeforeLoopVar = 2;

    public string[] firstDuring = new string[]
    {
        "Oh 01001000 01100101 01100011 01100011!",
        "Excuse my language, but I've just detected a large horde of entities coming right for us! And our barrier is down for some reason!",
        "Of course the ONE TIME a threat larger than anything we've ever seen before appears right when we haven't heard from the Creator for WEEKS!",
        "Well, we have to make do.",
        "As you can see, I don't have any hands or legs. The best I can do is monitor the house's integrity and estimate when the horde will arrive.",
        "Gunther, I need you to defend our home for us. You were made for this, quite literally.",
        "In case you have forgotten, shooting at the ground will cause you to fly in the air, like a jetpack! Use this ability to help you navigate across our land more easily.",
        "Most if not all enemies in Revafthell will take damage from your bullets. If they're bullet proof, try hopping on their heads. I don't know why that works, so don't ask me.",
        "No pressure, but you're our only hope. I believe in you."
    };
    public int firstDuringLoopVar = 3;

    public string[] firstAfter = new string[]
    {
        "THAT WAS AWESOME!",
        "Pretty easy huh?",
        "Well, that'll be quite the story for Master when he retu---01001000 01100101 01100011 01100011!!!",
        "There's more coming! A LOT more!",
        "Oh no, oh no, oh no, oh no...",
        "I have an idea! As you may have detected on your sensors, Master keeps a portal that can transpose you to various dungeons in Revafthell.",
        "You can go through that portal to collect tools to help us protect our home!",
        "Go downstairs, walk up to the bookshelf, and pull one of the books. The bookshelf will move and you'll find an entrance to the basement.",
        "Go to the basement and then go through the portal to be transposed to a dungeon somewhere in Revafthell to retrieve some helpful items!",
        "I'll stay here and monitor the house's Regeneration algorithm. Be safe!"
    };
    public int firstAfterLoopVar = 3;

    public string[] secondBefore = new string[]
{
        "You're back!",
        "And not empty handed I hope...",
        "A shield for the house! Perfect!",
        "Fly onto the roof and go ahead and install it.",
        "That'll protect us quite nicely!"
};
    public int secondBeforeLoopVar = 2;

    public string[] secondDuring = new string[]
{
        "The shield isn't going to hold-up for very long; you're still going to have to be on the offensive.",
        "You did it once, you can do it again! Right?",
        "...",
        "...right?"
};
    public int secondDuringLoopVar = 3;

    public string[] secondAfter = new string[]
{
        "We're alive!",
        "Well, as alive as AI can be I suppose.",
        "I'll scan to see if there are any more coming. In the meantime, I think you should go and get some more resource.",
        "Again: be safe!"
};
    public int secondAfterLoopVar = 2;

    public string[] thirdBefore = new string[]
{
        "Good news: you're back!",
        "Bad news: so will the bad-guys...",
        "...",
        "Well, not much to say, is there?",
        "Go ahead and setup whatever tools you found. Might as well be as prepared as we can be."
};
    public int thirdBeforeLoopVar = 1;

    public string[] thirdDuring = new string[]
{
        "Here they come. We're in this together, Gunther.",
        "Oh Master, where have you gone?"
};
    public int thirdDuringLoopVar = 3;

    public string[] thirdAfter = new string[]
{
        "Well done.",
        "There's nothing else to do but be prepared again.",
        "See you soon"
};
    public int thirdAfterLoopVar = 1;

    public string[] finalBefore = new string[]
{
        "Hello there!",
        "Long time no see.",
        "Go ahead and set up whatever you collected."
};
    public int finalBeforeLoopVar = 1;

    public string[] finalDuring = new string[]
{
        "Alright, they're coming.",
        "You know what to do. Be strong."
};
    public int finalDuringLoopVar = 2;

    public string[] finalAfter = new string[]
{
        "Thank goodness that's over...",
        "When will this end?! How many more waves of enemies are there?",
        "It won't be long before---MASTER!",
        "I got a signal from the Creator!",
        "He's---he's very, very far away.",
        "So far, it's out of my signal's range.",
        "But... how can it be out of range yet I can detect him?",
        "---!",
        "The portal, he's sending the signal through the portal!",
        "Gunther, you must find him for the both of us. You are my legs. Go through the portal, bring him back!",
        "And Gunther---don't forget who you are. Ever.",
        "Goodbye, my friend.",
        "Shutting down...",
        "---Power Off---"
};
    public int finalAfterLoopVar = 1;

    // More dialogue
}
