using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;
using GXPEngine.Core;                           // GXPEngine contains the engine

public class MyGame : Game
{
    Player player;
    Wall wall;
    public MyGame() : base(1920, 1080, false)
    {
        
        for (int i = 0; i < 25; i++)
        {
            wall = new Wall(i *64, 720);
            AddChild(wall);
        }
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                wall = new Wall(i * 1500, j * 64);
                AddChild(wall);
            }
        }

        player = new Player();
        AddChild(player);
    }

    void Update()
    {
    }


    static void Main()					
	{
		new MyGame().Start();				
	}

 
}