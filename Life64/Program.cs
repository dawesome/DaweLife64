using System;

namespace Life64
{
    class LifeMain
    {
        static void Main(string[] args)
        {
            GameState gs;
            GameState next = new GameState();

            // Read from Console, run 10 iterations, output
            LifeIO.ReadFromConsole(out gs);

            GameLogic.MultiTick(gs, ref next, 10);

            LifeIO.WriteToConsole(next);
        }
    }
}

/*
 * Game of Life Coding Sample Take-home Question
So, here's the challenge:

Implement Conway's Game of Life in 64-bit integer-space using the language of your choice.

Imagine a 2D grid - each cell (coordinate) can be either "alive" or "dead". Every generation of the simulation, the system ticks forward. Each cell's value changes according to the following:
If an "alive" cell had less than 2 or more than 3 alive neighbors (in any of the 8 surrounding cells), it becomes dead.
If a "dead" cell had *exactly* 3 alive neighbors, it becomes alive.
Your input is a list of alive (x, y) integer coordinates. They could be anywhere in the signed 64-bit range. This means the board could be very large!

Sample input:
(0, 1)
(1, 2)
(2, 0)
(2, 1)
(2, 2)
(-2000000000000, -2000000000000)
(-2000000000001, -2000000000001)
-----------------------------------------

Your program should read the state of the simulation from standard input, run 10 iterations of the Game of Life, and print the result to standard output in Life 1.06 format. 

We're most interested in seeing how you break down the problem and deal with very large integers. Otherwise, feel free to add whatever you like for extra credit. For example, you might add a GUI or animation (Here's a sample for inspiration!).

We intentionally leave the specification for the solution vague to see how you make decisions about these kinds of things and how those decisions are reflected in your code.  The most important advice I can give is to make sure your solution represents your best work and to come prepared to discuss what decisions you've made, alternatives you may have rejected (and why), and where you might take the work going forward.

Please submit the completed project in whatever format you deem reasonable (GitHub, hosted in a web-viewer, etc.) via email. Thank you, and good luck!

*/
