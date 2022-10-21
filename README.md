# Project Dcumentation
https://docs.google.com/document/d/1JvGs3MdVSd9Pmhjs2qwSehwicMjsZaDGJ86qB_eEVb0/edit?usp=sharing

## Unity Version -2020.3.32f1

## Quest Project 

This is a very simple quest project. 

There are 2 kinds of quests- 

## Prime Number Quests-
The user can start a Prime Number quest, where he has to enter a given amount of integers or whole numbers within a given time( default 10s). On entering the given amount of correct prime numbers, the quest is over.

## Composite Number Quests-
Similar to prime number quest, where the user has to enter a given amount of composite numbers.

The 2 kinds of quests can run independent of each other,and can be active at the same time.

However, at a time, only one Prime number quest and only one Composite Number quest can be active.

## How To Play

1.)Press Start Prime No Quest/ Start Composite No Quest to initialise the respective quest. The button OnClick() event attached to it contains an integer argument, which is the amount of prime/ composite numbers to be entered.

2.)After starting the quest, the numbers can be entered by pressing the Enter Prime No/ Enter Composite No buttons. The OnClick() event attached to these buttons has an integer argument that is the number that gets entered. 

3.)If its a Prime Number quest, only prime numbers will be accepted as entries, and wrong entries will be ignored. Same for Composite Number quest.

4.)After a quest has started, the quest can be monitored on the Inspector of the Player gameobject in the hierarchy. The GameManger script is attached to the Canvas.

Each quest increases the player’s level by 1. Failing quests decreases the player’s level by if it is greater than 0. The time limit for the quest can be changed from the exposed variable in the GameManager script attached to the Canvas.


## Class descriptions

Quest- Quest related attributes and methods are defined here. 

Player- Contains information about the current player and keeps track of all quests and related variables.

GameManager- Contains logic to initialise quests, and handle events when quest is completed.

MathCalculations- Utility class for math calculations


