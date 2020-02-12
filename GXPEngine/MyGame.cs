using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;
using GXPEngine.Core;                           // GXPEngine contains the engine

public class MyGame : Game
{
    Player player;
    Wall wall;
    Mushrooms mushrooms;

    private float gameSpeed = 2;
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

        mushrooms = new Mushrooms();
        mushrooms.x = 120;
        mushrooms.rotation = 90;
        mushrooms.y = 100;
        AddChild(mushrooms);


        player = new Player();
        AddChild(player);
    }

    void Update()
    {
        mushrooms.y += gameSpeed;

        if (player.HitTest(mushrooms))
        {
            player.y += gameSpeed;
        }

    }


    static void Main()					
	{
		new MyGame().Start();				
	}

 
}