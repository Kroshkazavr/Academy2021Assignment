# Academy2021Assignment
-------------------------------------------------
# Development
Unity version: `2021.1.1.17f1`
Game orientation is portrait and display ratio is 9:16 (e.g. 1080 x 1920).
-	Clone project into separate directory
-	Open project in Unity editor
-	Press play from a scene called `GameScene`
# How to play
Ball is passing through the obstacles with the same color as a ball. Use left mouse button to make the ball jump.
# Why you have decided to implement the prototype the way you have?
Implementation was based on the following technical requirements: pure Unity and only one scene. Game implementation contains three scripts in order to reduce extra complexity because game is quite small.
For more fun I have implemented an endless generation of obstacles, stars and color switchers. The code is as simple as possible and accomplished by comments. Current game implementation is close to original `ColorSwitch` game. There are also 5 obstacles in the prefabs, but only 2 are used in the game. This can be easily changed by increasing the array size, the random range and adding obstacles to the array.
As further code improvement I would like to separate each object behavior into the separate script.
# What features would you like to add to the gameplay and how would you go about and implement them?
In addition to unique obstacles, sounds and game pause I would like to add an opportunity to collect the stars for the following achievements:
1.	5 stars = invincibility for 5 seconds;
2.	10 stars = the next obstacle becomes the same color as the ball;
3.	15 stars = smile instead of the ball;
Proposed updated can be implemented by using if conditions on the score field.
As a next step it would be great to add other levels (level = scene + scene that will act as Game Manager).
Also, it is possible to add an interactive ability to choose a color scheme before starting the actual game.

