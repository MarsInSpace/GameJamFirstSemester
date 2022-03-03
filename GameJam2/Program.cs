using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System.Collections.Generic;

class Enemies : RectangleShape
{
    public void EnemyMovementRoom1(float deltaTime)
    {
        for (int i = 0; i < Game.EnemiesListRoom1.Count; i++)
        {
            float distanceX = Game.EnemiesListRoom1[i].Position.X - Game.PlayerObj.Position.X;

            float distanceY = Game.EnemiesListRoom1[i].Position.Y - Game.PlayerObj.Position.Y;

            if (distanceX > 0 && distanceY > 0) 
            {
                Game.EnemiesListRoom1[i].Position += new Vector2f(-20, -20) * deltaTime;
            }

            if (distanceX < 0 && distanceY > 0)
            {
                Game.EnemiesListRoom1[i].Position += new Vector2f(20, -20) * deltaTime;
            }

            if (distanceX > 0 && distanceY < 0)
            {
                Game.EnemiesListRoom1[i].Position += new Vector2f(-20, 20) * deltaTime;
            }

            if (distanceX < 0 && distanceY < 0)
            {
                Game.EnemiesListRoom1[i].Position += new Vector2f(20, 20) * deltaTime;
            }
        }
    }

    public void EnemyMovementRoom2(float deltaTime)
    {
        for (int i = 0; i < Game.EnemiesListRoom2.Count; i++)
        {
            float distanceX = Game.EnemiesListRoom2[i].Position.X - Game.PlayerObj.Position.X;

            float distanceY = Game.EnemiesListRoom2[i].Position.Y - Game.PlayerObj.Position.Y;

            if (distanceX > 0 && distanceY > 0)
            {
                Game.EnemiesListRoom2[i].Position += new Vector2f(-20, -20) * deltaTime;
            }

            if (distanceX < 0 && distanceY > 0)
            {
                Game.EnemiesListRoom2[i].Position += new Vector2f(20, -20) * deltaTime;
            }

            if (distanceX > 0 && distanceY < 0)
            {
                Game.EnemiesListRoom2[i].Position += new Vector2f(-20, 20) * deltaTime;
            }

            if (distanceX < 0 && distanceY < 0)
            {
                Game.EnemiesListRoom2[i].Position += new Vector2f(20, 20) * deltaTime;
            }
        }
    }

    public void EnemyMovementRoom3(float deltaTime)
    {
        for (int i = 0; i < Game.EnemiesListRoom3.Count; i++)
        {
            float distanceX = Game.EnemiesListRoom3[i].Position.X - Game.PlayerObj.Position.X;

            float distanceY = Game.EnemiesListRoom3[i].Position.Y - Game.PlayerObj.Position.Y;

            if (distanceX > 0 && distanceY > 0)
            {
                Game.EnemiesListRoom3[i].Position += new Vector2f(-20, -20) * deltaTime;
            }

            if (distanceX < 0 && distanceY > 0)
            {
                Game.EnemiesListRoom3[i].Position += new Vector2f(20, -20) * deltaTime;
            }

            if (distanceX > 0 && distanceY < 0)
            {
                Game.EnemiesListRoom3[i].Position += new Vector2f(-20, 20) * deltaTime;
            }

            if (distanceX < 0 && distanceY < 0)
            {
                Game.EnemiesListRoom3[i].Position += new Vector2f(20, 20) * deltaTime;
            }
        }
    }

    public void EnemyMovementKeyRoom(float deltaTime)
    {
        for (int i = 0; i < Game.EnemiesListKeyRoom.Count; i++)
        {
            float distanceX = Game.EnemiesListKeyRoom[i].Position.X - Game.PlayerObj.Position.X;

            float distanceY = Game.EnemiesListKeyRoom[i].Position.Y - Game.PlayerObj.Position.Y;

            if (distanceX > 0 && distanceY > 0)
            {
                Game.EnemiesListKeyRoom[i].Position += new Vector2f(-20, -20) * deltaTime;
            }

            if (distanceX < 0 && distanceY > 0)
            {
                Game.EnemiesListKeyRoom[i].Position += new Vector2f(20, -20) * deltaTime;
            }

            if (distanceX > 0 && distanceY < 0)
            {
                Game.EnemiesListKeyRoom[i].Position += new Vector2f(-20, 20) * deltaTime;
            }

            if (distanceX < 0 && distanceY < 0)
            {
                Game.EnemiesListKeyRoom[i].Position += new Vector2f(20, 20) * deltaTime;
            }
        }
    }
}

class Machinegun : RectangleShape
{
    public bool IsDestroyed = false;
    private int SHOT_XSPEED = 0;
    private int SHOT_YSPEED = 0;
    public Machinegun(int shotXSpeed, int shotYSpeed)
    {
        SHOT_XSPEED = shotXSpeed;
        SHOT_YSPEED = shotYSpeed;
        FillColor = new Color(Color.Red);
    }

    public void MachinegunUpdate(float deltaTime)
    {
        Position += new Vector2f(SHOT_XSPEED * deltaTime, SHOT_YSPEED * deltaTime);

        if (Position.Y < 0 || Position.Y > Game.GameWindow.Size.Y || Position.X < 0 || Position.X > Game.GameWindow.Size.X)
            IsDestroyed = true;
    }

    public void CheckMgEnemyCollision(List<Enemies> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            FloatRect boundingBoxAlien = enemies[i].GetGlobalBounds();
            FloatRect boundingBoxShot = GetGlobalBounds();

            if (boundingBoxAlien.Intersects(boundingBoxShot))
            {
                IsDestroyed = true;
                enemies.RemoveAt(i);
                Game.Score += 100;
                break;
            }
        }
    }
}
class Pistol : RectangleShape
{
    public bool IsDestroyed = false;
    private int SHOT_XSPEED = 0;
    private int SHOT_YSPEED = 0;

    public Pistol(int shotXSpeed, int shotYSpeed)
    {
        SHOT_XSPEED = shotXSpeed;
        SHOT_YSPEED = shotYSpeed;
        FillColor = new Color(Color.Red);
    }

    public void PistolUpdate(float deltaTime)
    {
        Position += new Vector2f(SHOT_XSPEED * deltaTime, SHOT_YSPEED * deltaTime);

        if (Position.Y < 0 || Position.Y > Game.GameWindow.Size.Y || Position.X < 0 || Position.X > Game.GameWindow.Size.X)
            IsDestroyed = true;
    }

    public void CheckBulletEnemyCollision(List<Enemies> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            FloatRect boundingBoxAlien = enemies[i].GetGlobalBounds();
            FloatRect boundingBoxShot = GetGlobalBounds();

            if (boundingBoxAlien.Intersects(boundingBoxShot))
            {
                IsDestroyed = true;
                enemies.RemoveAt(i);
                Console.WriteLine(Game.Score);
                Game.Score += 100;
                break;
            }
        }
    }
}

class WeaponObject : RectangleShape
{
    public static bool IsMgActivatedTrue = false;

    public void Init()
    {
        Size = new Vector2f(290, 140);
        Texture = new Texture("./assets/machinegun.png");
        Position = new Vector2f(Game.GameWindow.Size.X / 2 - Size.X/2, Game.GameWindow.Size.Y / 2 - Size.Y/2);
    }

    public static bool IsMgActivated(Player player, WeaponObject weapon)
    {
        if (Game.IsInRoom4 == true)
        {
            FloatRect boundingBoxPlayer = player.GetGlobalBounds();
            FloatRect boundingBoxWeapon = weapon.GetGlobalBounds();

            if ((boundingBoxPlayer.Intersects(boundingBoxWeapon) == true || IsMgActivatedTrue == true) && Game.Score >= 5000)
            {
                Game.Score -= 5000; //doesn't work??, program registers it but doesn't draw new score
                Console.WriteLine(Game.Score);
                PlayWeaponUpSound();
                IsMgActivatedTrue = true;
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }
    public static void PlayWeaponUpSound()
    {
        SoundBuffer Buffer = new SoundBuffer("./Assets/Powerup_1.wav");

        Sound WeaponUpSound = new Sound(Buffer);
        WeaponUpSound.Play();
    }
}

class Key : RectangleShape
{
    const int KEY_SIZE = 30;

    public static bool IsKeyPickedUp = false;

    public void Init()
    {
        Size = new Vector2f(KEY_SIZE, KEY_SIZE);
        Texture = new Texture("./Assets/key.png");
        Position = new Vector2f(Game.GameWindow.Size.X / 2 - KEY_SIZE / 2, Game.GameWindow.Size.Y / 2 - KEY_SIZE / 2);
    }

    public static bool IsKeyOnPlayer(Player player, Key bossKey)
    {
        if (Game.IsInKeyRoom == true && Game.EnemiesListKeyRoom.Count == 0 && IsKeyPickedUp == false)
        {
            FloatRect boundingBoxPlayer = player.GetGlobalBounds();
            FloatRect boundingBoxKey = bossKey.GetGlobalBounds();

            if (boundingBoxPlayer.Intersects(boundingBoxKey) == true)
            {
                IsKeyPickedUp = true;
                PlayPickupSound();
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    static void PlayPickupSound()
    {
        SoundBuffer Buffer = new SoundBuffer("./Assets/Collectibles_5.wav");

        Sound PickupSound = new Sound(Buffer);
        PickupSound.Play();
    }
}

class Levels
{
    public static RectangleShape LeftWall;
    public static RectangleShape RightWall;
    public static RectangleShape UpperWall;
    public static RectangleShape LowerWall;
    public static RectangleShape Hallway;

    public static int WallThickness = 20;

    public static RectangleShape StartBlueDoor;
    public static RectangleShape StartRedDoor;

    public static RectangleShape Room1MagentaDoor;
    public static RectangleShape Room1RedDoor;
    public static RectangleShape Room1GreenDoor;

    public static RectangleShape Room2YellowDoor;
    public static RectangleShape Room2CyanDoor;
    public static RectangleShape Room2GreenDoor;

    public static RectangleShape Room3BlueDoor;
    public static RectangleShape Room3YellowDoor;
    public static RectangleShape Room3CyanDoor;

    public static RectangleShape Room4GreenDoor;

    public static RectangleShape KeyRoomCyanDoor;

    public static RectangleShape HallwayCyanDoor;
    public static RectangleShape HallwayMagentaDoor;

    public static RectangleShape TreasureRoomGreenDoor;

    public static RectangleShape StartTexture;
    public static RectangleShape Room1Texture;
    public static RectangleShape Room2Texture;
    public static RectangleShape Room3Texture;
    public static RectangleShape Room4Texture;
    public static RectangleShape RoomKeyTexture;
    public static RectangleShape RoomTreasureTexture;
    public static RectangleShape HallwayTexture;

    static float DoorSizeX = 100; //horizontal gesehen. Bei vertikal umdrehen
    static float DoorSizeY = 30;

    public enum Room
    {
        Start,
        Room1,
        Room2,
        Room3,
        Room4,
        KeyRoom,
        TreasureRoom,
        Hallway,
    }

    public static Room CurrentRoom;

    public static void InitAllLevels()
    {
        InitBackgroundTextureStart();
        InitBackgroundTextureRoom1();
        InitBackgroundTextureRoom2();
        InitBackgroundTextureRoom3();
        InitBackgroundTextureRoom4();
        InitBackgroundTextureRoomKey();
        InitBackgroundTextureRoomTreasure();
        InitBackgroundTextureHallway();

        InitWalls();

        InitDoorsStart();
        InitDoorsRoom1();
        InitDoorsRoom2();
        InitDoorsRoom3();
        InitDoorsRoom4();
        InitDoorsKeyRoom();
        InitDoorsTreasureRoom();
        InitDoorsHallway();
    }

    public static void InitWalls()
    {
        //left wall
        LeftWall = new RectangleShape();
        LeftWall.Size = new Vector2f(WallThickness, Game.GameWindow.Size.Y);

        //right wall
        RightWall = new RectangleShape();
        RightWall.Size = new Vector2f(WallThickness, Game.GameWindow.Size.Y);
        RightWall.Position = new Vector2f(Game.GameWindow.Size.X - RightWall.Size.X, 0);

        //upper wall
        UpperWall = new RectangleShape();
        UpperWall.Size = new Vector2f(Game.GameWindow.Size.X, WallThickness);

        //lower wall
        LowerWall = new RectangleShape();
        LowerWall.Size = new Vector2f(Game.GameWindow.Size.X, WallThickness);
        LowerWall.Position = new Vector2f(0, Game.GameWindow.Size.Y - LowerWall.Size.Y);

        //hallway
        Hallway = new RectangleShape();
        Hallway.Size = new Vector2f(1166, 568);
    }

    public static void InitDoorsStart()
    {
        //blue door --> left
        StartBlueDoor = new RectangleShape();
        StartBlueDoor.FillColor = Color.Blue;
        StartBlueDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        StartBlueDoor.Position = new Vector2f(0, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));

        //red door --> right
        StartRedDoor = new RectangleShape();
        StartRedDoor.FillColor = Color.Red;
        StartRedDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        StartRedDoor.Position = new Vector2f(Game.GameWindow.Size.X - DoorSizeY, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));
    }

    public static void InitDoorsRoom1()
    {
        //red door --> left
        Room1RedDoor = new RectangleShape();
        Room1RedDoor.FillColor = Color.Red;
        Room1RedDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        Room1RedDoor.Position = new Vector2f(0, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));

        //green (treasure) door --> noch ausgrauen? --> right
        Room1GreenDoor = new RectangleShape();
        Room1GreenDoor.FillColor = Color.Green;
        Room1GreenDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        Room1GreenDoor.Position = new Vector2f(Game.GameWindow.Size.X - DoorSizeY, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));

        //magenta door --> lower
        Room1MagentaDoor = new RectangleShape();
        Room1MagentaDoor.FillColor = Color.Magenta;
        Room1MagentaDoor.Size = new Vector2f(DoorSizeX, DoorSizeY);
        Room1MagentaDoor.Position = new Vector2f(Game.GameWindow.Size.X / 2 - (DoorSizeX / 2), Game.GameWindow.Size.Y - DoorSizeY);
    }

    public static void InitDoorsRoom2()
    {
        //green door --> left
        Room2GreenDoor = new RectangleShape();
        Room2GreenDoor.FillColor = Color.Green;
        Room2GreenDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        Room2GreenDoor.Position = new Vector2f(0, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));

        //cyan door --> right
        Room2CyanDoor = new RectangleShape();
        Room2CyanDoor.FillColor = Color.Cyan;
        Room2CyanDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        Room2CyanDoor.Position = new Vector2f(Game.GameWindow.Size.X - DoorSizeY, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));

        //yellow door --> upper
        Room2YellowDoor = new RectangleShape();
        Room2YellowDoor.FillColor = Color.Yellow;
        Room2YellowDoor.Size = new Vector2f(DoorSizeX, DoorSizeY);
        Room2YellowDoor.Position = new Vector2f(Game.GameWindow.Size.X / 2 - (DoorSizeX / 2), 0);
    }

    public static void InitDoorsRoom3()
    {
        //blue door --> right
        Room3BlueDoor = new RectangleShape();
        Room3BlueDoor.FillColor = Color.Blue;
        Room3BlueDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        Room3BlueDoor.Position = new Vector2f(Game.GameWindow.Size.X - DoorSizeY, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));

        //yellow door --> lower
        Room3YellowDoor = new RectangleShape();
        Room3YellowDoor.FillColor = Color.Yellow;
        Room3YellowDoor.Size = new Vector2f(DoorSizeX, DoorSizeY);
        Room3YellowDoor.Position = new Vector2f(Game.GameWindow.Size.X / 2 - (DoorSizeX / 2), Game.GameWindow.Size.Y - DoorSizeY);

        //cyan door --> upper
        Room3CyanDoor = new RectangleShape();
        Room3CyanDoor.FillColor = Color.Cyan;
        Room3CyanDoor.Size = new Vector2f(DoorSizeX, DoorSizeY);
        Room3CyanDoor.Position = new Vector2f(Game.GameWindow.Size.X / 2 - (DoorSizeX / 2), 0);
    }

    public static void InitDoorsRoom4()
    {
        //green door --> right
        Room4GreenDoor = new RectangleShape();
        Room4GreenDoor.FillColor = Color.Green;
        Room4GreenDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        Room4GreenDoor.Position = new Vector2f(Game.GameWindow.Size.X - DoorSizeY, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));
    }

    public static void InitDoorsKeyRoom()
    {
        //cyan door --> lower
        KeyRoomCyanDoor = new RectangleShape();
        KeyRoomCyanDoor.FillColor = Color.Cyan;
        KeyRoomCyanDoor.Size = new Vector2f(DoorSizeX, DoorSizeY);
        KeyRoomCyanDoor.Position = new Vector2f(Game.GameWindow.Size.X / 2 - (DoorSizeX / 2), Game.GameWindow.Size.Y - DoorSizeY);
    }

    public static void InitDoorsTreasureRoom()
    {
        //green door --> left
        TreasureRoomGreenDoor = new RectangleShape();
        TreasureRoomGreenDoor.FillColor = Color.Green;
        TreasureRoomGreenDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        TreasureRoomGreenDoor.Position = new Vector2f(0, Game.GameWindow.Size.Y / 2 - (DoorSizeX / 2));
    }

    public static void InitDoorsHallway()
    {
        //magenta door --> top
        HallwayMagentaDoor = new RectangleShape();
        HallwayMagentaDoor.FillColor = Color.Magenta;
        HallwayMagentaDoor.Size = new Vector2f(DoorSizeX, DoorSizeY);
        HallwayMagentaDoor.Position = new Vector2f(Hallway.Size.X + (DoorSizeX / 3), 0);

        //cyan door --> left
        HallwayCyanDoor = new RectangleShape();
        HallwayCyanDoor.FillColor = Color.Cyan;
        HallwayCyanDoor.Size = new Vector2f(DoorSizeY, DoorSizeX);
        HallwayCyanDoor.Position = new Vector2f(0, Hallway.Size.Y + (DoorSizeX / 3));
    }

    public static void ResetRoom1()
    {
        Game.CounterRoom1 = 0;
        Game.TimeSinceLastUpdateRoom1 = Time.Zero;
        Game.EnemiesListRoom1.Clear();
        Game.PlayerObj.FillColor = new Color(Color.White);
    }

    public static void ResetRoom2()
    {
        Game.CounterRoom2 = 0;
        Game.TimeSinceLastUpdateRoom2 = Time.Zero;
        Game.EnemiesListRoom2.Clear();
        Game.PlayerObj.FillColor = new Color(Color.White);
    }

    public static void ResetRoom3()
    {
        Game.CounterRoom3 = 0;
        Game.TimeSinceLastUpdateRoom3 = Time.Zero;
        Game.EnemiesListRoom3.Clear();
        Game.PlayerObj.FillColor = new Color(Color.White);
    }

    public static void ResetRoomKey()
    {
        Game.CounterRoomKey = 0;
        Game.TimeSinceLastUpdateRoomKey = Time.Zero;
        Game.EnemiesListKeyRoom.Clear();
        Game.PlayerObj.FillColor = new Color(Color.White);
    }

    public static void ResetRoomStart()
    {
        Game.PlayerObj.FillColor = new Color(Color.White);
    }

    public static void ResetRoom4()
    {
        Game.PlayerObj.FillColor = new Color(Color.White);
    }

    public static void ResetRoomTreasure()
    {
        Game.PlayerObj.FillColor = new Color(Color.White);
    }


    public static void PlayerEnteringLeft()
    {
        Game.PlayerObj.Position = new Vector2f(DoorSizeY + Game.PlayerObj.Size.X / 2, Player.PlayerPositionY - Game.PlayerObj.Size.Y / 2);
        Game.LightLayer.Position = new Vector2f(Game.PlayerObj.Position.X - Game.LightLayer.Size.X / 2 + Game.PlayerObj.Size.X / 2, Game.PlayerObj.Position.Y - Game.LightLayer.Size.Y / 2 + Game.PlayerObj.Size.Y / 2);
    }

    public static void PlayerEnteringRight()
    {
        Game.PlayerObj.Position = new Vector2f(Game.GameWindow.Size.X - DoorSizeY - Game.PlayerObj.Size.X, Player.PlayerPositionY - Game.PlayerObj.Size.Y / 2);
        Game.LightLayer.Position = new Vector2f(Game.PlayerObj.Position.X - Game.LightLayer.Size.X / 2 + Game.PlayerObj.Size.X / 2, Game.PlayerObj.Position.Y - Game.LightLayer.Size.Y / 2 + Game.PlayerObj.Size.Y / 2);
    }

    public static void PlayerEnteringBottom()
    {
        Game.PlayerObj.Position = new Vector2f(Player.PlayerPositionX - Game.PlayerObj.Size.X / 2, 600);
        Game.LightLayer.Position = new Vector2f(Game.PlayerObj.Position.X - Game.LightLayer.Size.X / 2 + Game.PlayerObj.Size.X / 2, Game.PlayerObj.Position.Y - Game.LightLayer.Size.Y / 2 + Game.PlayerObj.Size.Y / 2);
    }

    public static void PlayerEnteringTop()
    {
        Game.PlayerObj.Position = new Vector2f(Player.PlayerPositionX - Game.PlayerObj.Size.X / 2, DoorSizeY);
        Game.LightLayer.Position = new Vector2f(Game.PlayerObj.Position.X - Game.LightLayer.Size.X / 2 + Game.PlayerObj.Size.X / 2, Game.PlayerObj.Position.Y - Game.LightLayer.Size.Y / 2 + Game.PlayerObj.Size.Y / 2);
    }

    public static void RoomTransition()
    {
        //spieler ist im startraum
        if (CheckPlayerStartRedDoor(Game.PlayerObj) == true && CurrentRoom == Room.Start)
        {
            CurrentRoom = Room.Room1;

            ResetRoomStart();

            PlayerEnteringLeft(); 

            Game.GameWindow.Clear();
        }

        if (CheckPlayerStartBlueDoor(Game.PlayerObj) == true && CurrentRoom == Room.Start)
        {
            CurrentRoom = Room.Room3;

            ResetRoomStart();

            PlayerEnteringRight();

            Game.GameWindow.Clear();
        }


        //spieler ist in room1
        if (CheckPlayerRoom1RedDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room1)
        {
            CurrentRoom = Room.Start;

            ResetRoom1();

            PlayerEnteringRight();

            Game.GameWindow.Clear();
        }

        if (CheckPlayerRoom1GreenDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room1)
        {
            if (Key.IsKeyPickedUp == true)
            {
                CurrentRoom = Room.TreasureRoom;

                ResetRoom1();

                PlayerEnteringLeft();

                Game.GameWindow.Clear();
            }
        }

        if (CheckPlayerRoom1MagentaDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room1)
        {
            CurrentRoom = Room.Hallway;

            ResetRoom1();

            Game.PlayerObj.Position = new Vector2f(Hallway.Size.X + Game.PlayerObj.Size.X, DoorSizeY);
            Game.LightLayer.Position = new Vector2f(Game.PlayerObj.Position.X - Game.LightLayer.Size.X / 2 + Game.PlayerObj.Size.X / 2, Game.PlayerObj.Position.Y - Game.LightLayer.Size.Y / 2 + Game.PlayerObj.Size.Y / 2);

            Game.GameWindow.Clear();
        }

        //spieler ist in room 2

        if (CheckPlayerRoom2YellowDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room2)
        {
            CurrentRoom = Room.Room3;

            ResetRoom2();

            PlayerEnteringBottom();

            Game.GameWindow.Clear();
        }

        if (CheckPlayerRoom2GreenDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room2)
        {
            CurrentRoom = Room.Room4;

            ResetRoom2();

            PlayerEnteringRight();

            Game.GameWindow.Clear();
        }

        if (CheckPlayerRoom2CyanDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room2)
        {
            CurrentRoom = Room.Hallway;

            ResetRoom2();

            Game.PlayerObj.Position = new Vector2f(DoorSizeY + Game.PlayerObj.Size.X / 2, Hallway.Size.Y + Game.PlayerObj.Size.Y / 2);
            Game.LightLayer.Position = new Vector2f(Game.PlayerObj.Position.X - Game.LightLayer.Size.X / 2 + Game.PlayerObj.Size.X / 2, Game.PlayerObj.Position.Y - Game.LightLayer.Size.Y / 2 + Game.PlayerObj.Size.Y / 2);

            Game.GameWindow.Clear();
        }

        //spieler ist in room 3
        if (CheckPlayerRoom3BlueDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room3)
        {
            CurrentRoom = Room.Start;

            ResetRoom3();

            PlayerEnteringLeft();

            Game.GameWindow.Clear();
        }

        if (CheckPlayerRoom3CyanDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room3)
        {
            CurrentRoom = Room.KeyRoom;

            ResetRoom3();

            PlayerEnteringBottom();

            Game.GameWindow.Clear();
        }

        if (CheckPlayerRoom3YellowDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room3)
        {
            CurrentRoom = Room.Room2;

            ResetRoom3();

            PlayerEnteringTop();

            Game.GameWindow.Clear();
        }


        //spieler ist in raum 4
        if (CheckPlayerRoom4GreenDoor(Game.PlayerObj) == true && CurrentRoom == Room.Room4)
        {
            CurrentRoom = Room.Room2;

            ResetRoom4();

            PlayerEnteringLeft();

            Game.GameWindow.Clear();
        }

        //spieler ist im key room
        if (CheckPlayerKeyRoomCyanDoor(Game.PlayerObj) == true && CurrentRoom == Room.KeyRoom)
        {
            CurrentRoom = Room.Room3;

            ResetRoomKey();

            PlayerEnteringTop();

            Game.GameWindow.Clear();
        }


        //spieler ist im treasure room
        if (CheckPlayerTreasureRoomGreenDoor(Game.PlayerObj) == true && CurrentRoom == Room.TreasureRoom)
        {
            CurrentRoom = Room.Room1;

            ResetRoomTreasure();

            PlayerEnteringRight();

            Game.GameWindow.Clear();
        }

        //spieler ist in hallway
        if (CheckPlayerHallwayMagentaDoor(Game.PlayerObj) == true && CurrentRoom == Room.Hallway)
        {
            CurrentRoom = Room.Room1;

            PlayerEnteringBottom();

            Game.GameWindow.Clear();
        }

        if (CheckPlayerHallwayCyanDoor(Game.PlayerObj) == true && CurrentRoom == Room.Hallway)
        {
            CurrentRoom = Room.Room2;

            PlayerEnteringRight();

            Game.GameWindow.Clear();
        }
    }

    //start raum
    static bool CheckPlayerStartRedDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = StartRedDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }
    static bool CheckPlayerStartBlueDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = StartBlueDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    //room 1
    static bool CheckPlayerRoom1RedDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room1RedDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerRoom1GreenDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room1GreenDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerRoom1MagentaDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room1MagentaDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    } //hallway fehlt noch


    //room 2
    static bool CheckPlayerRoom2YellowDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room2YellowDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerRoom2GreenDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room2GreenDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerRoom2CyanDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room2CyanDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    } 

    //room 3
    static bool CheckPlayerRoom3BlueDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room3BlueDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerRoom3YellowDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room3YellowDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerRoom3CyanDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room3CyanDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    //room 4
    static bool CheckPlayerRoom4GreenDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = Room4GreenDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    //key room
    static bool CheckPlayerKeyRoomCyanDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = KeyRoomCyanDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    //treasure room
    static bool CheckPlayerTreasureRoomGreenDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = TreasureRoomGreenDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    public static void InitBackgroundTextureStart()
    {
        StartTexture = new RectangleShape();
        StartTexture.Texture = new Texture("./Assets/Start-Hintergrund.png");
        StartTexture.Size = new Vector2f(1366, 768);
        StartTexture.Position = new Vector2f(0, 0);
    }

    //hallway
    static bool CheckPlayerHallwayMagentaDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = HallwayMagentaDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    static bool CheckPlayerHallwayCyanDoor(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxDoor = HallwayCyanDoor.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxDoor);
    }

    public static void InitBackgroundTextureRoom1()
    {
        Room1Texture = new RectangleShape();
        Room1Texture.Texture = new Texture("./Assets/Room1-Hintergrund.png");
        Room1Texture.Size = new Vector2f(1366, 768);
        Room1Texture.Position = new Vector2f(0, 0);
    }

    public static void InitBackgroundTextureRoom2()
    {
        Room2Texture = new RectangleShape();
        Room2Texture.Texture = new Texture("./Assets/Room2-Hintergrund.png");
        Room2Texture.Size = new Vector2f(1366, 768);
        Room2Texture.Position = new Vector2f(0, 0);
    }

    public static void InitBackgroundTextureRoom3()
    {
        Room3Texture = new RectangleShape();
        Room3Texture.Texture = new Texture("./Assets/Room3-Hintergrund.png");
        Room3Texture.Size = new Vector2f(1366, 768);
        Room3Texture.Position = new Vector2f(0, 0);
    }

    public static void InitBackgroundTextureRoom4()
    {
        Room4Texture = new RectangleShape();
        Room4Texture.Texture = new Texture("./Assets/Room4-Hintergrund.png");
        Room4Texture.Size = new Vector2f(1366, 768);
        Room4Texture.Position = new Vector2f(0, 0);
    }

    public static void InitBackgroundTextureRoomKey()
    {
        RoomKeyTexture = new RectangleShape();
        RoomKeyTexture.Texture = new Texture("./Assets/Keyroom-Hintergrund.png");
        RoomKeyTexture.Size = new Vector2f(1366, 768);
        RoomKeyTexture.Position = new Vector2f(0, 0);
    }

    public static void InitBackgroundTextureRoomTreasure()
    {
        RoomTreasureTexture = new RectangleShape();
        RoomTreasureTexture.Texture = new Texture("./Assets/Tresorraum-Hintergrund.png");
        RoomTreasureTexture.Size = new Vector2f(1366, 768);
        RoomTreasureTexture.Position = new Vector2f(0, 0);
    }
    public static void InitBackgroundTextureHallway()
    {
        HallwayTexture = new RectangleShape();
        HallwayTexture.Texture = new Texture("./Assets/Hallway-Hintergrund.png");
        HallwayTexture.Size = new Vector2f(1366, 768);
        HallwayTexture.Position = new Vector2f(0, 0);
    }

    public static void DrawStart()
    {
        Game.GameWindow.Draw(StartTexture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.GameWindow.Draw(Game.PlayerObj);
    }

    public static void DrawRoom1()
    {
        Game.GameWindow.Draw(Room1Texture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.DrawEnemiesRoom1();

        Game.GameWindow.Draw(Game.PlayerObj);
    }

    public static void DrawRoom2()
    {
        Game.GameWindow.Draw(Room2Texture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.DrawEnemiesRoom2();

        Game.GameWindow.Draw(Game.PlayerObj);
    }

    public static void DrawRoom3()
    {
        Game.GameWindow.Draw(Room3Texture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.DrawEnemiesRoom3();

        Game.GameWindow.Draw(Game.PlayerObj);
    }
    
    public static void DrawRoom4()
    {
        Game.GameWindow.Draw(Room4Texture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.GameWindow.Draw(Game.PlayerObj);
    }

    public static void DrawKeyRoom()
    {
        Game.GameWindow.Draw(RoomKeyTexture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.DrawEnemiesKeyRoom();

        Game.GameWindow.Draw(Game.PlayerObj);
    }

    public static void DrawTreasureRoom()
    {
        Game.GameWindow.Draw(RoomTreasureTexture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.GameWindow.Draw(Game.PlayerObj);
    }

    public static void DrawHallway()
    {
        Game.GameWindow.Draw(HallwayTexture);

        foreach (var shot in Game.PistolShots)
            Game.GameWindow.Draw(shot);

        foreach (var shot in Game.MgShots)
            Game.GameWindow.Draw(shot);

        Game.GameWindow.Draw(Game.PlayerObj);
    }
}

class Player : RectangleShape
{
    const int PLAYER_SPEED = 300;

    public static float PlayerPositionX = Game.GameWindow.Size.X / 2;
    public static float PlayerPositionY = Game.GameWindow.Size.Y / 2;

    static int LastDirection = 0;
    const int UP = 1;
    const int DOWN = 2;
    const int LEFT = 3;
    const int RIGHT = 4;

    float TimeSinceLastShot = 0;
    public static bool IsMgOn = false;
    public static bool IsDoorOpen = false;
    //public static bool IsAlreadyAdded = false;

    public static int Lives = 10;

    static bool playerGotHurt = false;
    static float playerDamagedTimer = 0;
    static float playerIsSafeAfterDamage = 1.5f;

    public void Init()
    {
        Size = new Vector2f(61, 72);
        Position = new Vector2f(PlayerPositionX - Size.X / 2, PlayerPositionY - Size.Y/2);
        Texture = new Texture("./Assets/Player_vorne.png");
    }

    public void Update(float deltaTime)
    {
        TimeSinceLastShot += deltaTime;

        if (Game.IsGamePaused)
            return;
        if (Game.IsStartScreenOn)
            return;
        if (Game.IsGameOver)
            return;

        if (Lives == 0)
            Game.IsGameOver = true;

        //player go left
        if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Position.X > Levels.WallThickness)
        {
            Position += new Vector2f(-PLAYER_SPEED, 0) * deltaTime;
            Game.LightLayer.Position += new Vector2f(-PLAYER_SPEED, 0) * deltaTime;
            LastDirection = LEFT;
            Texture = new Texture("./Assets/Player_links.png");
        }
        //player go right
        if (Keyboard.IsKeyPressed(Keyboard.Key.D) && Position.X < Game.GameWindow.Size.X - Game.PlayerObj.Size.X - Levels.WallThickness)
        {
            Position += new Vector2f(PLAYER_SPEED, 0) * deltaTime;
            Game.LightLayer.Position += new Vector2f(PLAYER_SPEED, 0) * deltaTime;
            LastDirection = RIGHT;
            Texture = new Texture("./Assets/Player_rechts.png");
        }
        //player go up
        if (Keyboard.IsKeyPressed(Keyboard.Key.W) && Position.Y > Levels.WallThickness)
        {
            Position += new Vector2f(0, -PLAYER_SPEED) * deltaTime;
            Game.LightLayer.Position += new Vector2f(0, -PLAYER_SPEED) * deltaTime;
            LastDirection = UP;
            Texture = new Texture("./Assets/Player_hinten.png");
        }
        //player go down
        if (Keyboard.IsKeyPressed(Keyboard.Key.S) && Position.Y < Game.GameWindow.Size.Y - Levels.WallThickness - Game.PlayerObj.Size.Y)
        {
            Position += new Vector2f(0, PLAYER_SPEED) * deltaTime;
            Game.LightLayer.Position += new Vector2f(0, PLAYER_SPEED) * deltaTime;
            LastDirection = DOWN;
            Texture = new Texture("./Assets/Player_vorne.png");
        }

        if (WeaponObject.IsMgActivated(Game.PlayerObj, Game.WeaponObj) == true)
            IsMgOn = true;

        if (Key.IsKeyOnPlayer(Game.PlayerObj, Game.BossKey) == true)
            IsDoorOpen = true;

        //shooty shooty bang bang
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && LastDirection == UP)
        {
            if (TimeSinceLastShot > 0.05 && IsMgOn == true)
            {
                TimeSinceLastShot = 0;
                FireMGUp(2, 6);
                PlayMgSound();
            }

            else if (TimeSinceLastShot > 0.4)
            {
                TimeSinceLastShot = 0;
                FirePistolUp(2, 15);
                PlayPistolSound();
            }
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && LastDirection == DOWN)
        {
            if (TimeSinceLastShot > 0.05 && IsMgOn == true)
            {
                TimeSinceLastShot = 0;
                FireMGDown(2, -6);
                PlayMgSound();
            }

            else if (TimeSinceLastShot > 0.4)
            {
                TimeSinceLastShot = 0;
                FirePistolDown(2, -15);
                PlayPistolSound();
            }
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && LastDirection == LEFT)
        {
            if (TimeSinceLastShot > 0.05 && IsMgOn == true)
            {
                TimeSinceLastShot = 0;
                FireMGLeft(6, 2);
                PlayMgSound();
            }

            else if (TimeSinceLastShot > 0.4)
            {
                TimeSinceLastShot = 0;
                FirePistolLeft(15, 2);
                PlayPistolSound();
            }
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && LastDirection == RIGHT)
        {
            if (TimeSinceLastShot > 0.05 && IsMgOn == true)
            {
                TimeSinceLastShot = 0;
                FireMGRight(6, 2);
                PlayMgSound();
            }

            else if (TimeSinceLastShot > 0.4)
            {
                TimeSinceLastShot = 0;
                FirePistolRight(15, 2);
                PlayPistolSound();
            }
        }
    }

    public static void PlayPistolSound()
    {
        SoundBuffer Buffer = new SoundBuffer("./Assets/Bullet_3.wav");

        Sound PistolSound = new Sound(Buffer);
        PistolSound.Play();
    }

    public static void PlayMgSound()
    {
        SoundBuffer Buffer = new SoundBuffer("./Assets/Bullet_6.wav");

        Sound MgSound = new Sound(Buffer);
        MgSound.Play();
    }

    //spawn pistol shots
    public void FirePistolUp(int pistolX, int pistolY)
    {
        Pistol pistolShot = new Pistol(0, -400);
        pistolShot.Size = new Vector2f(pistolX, pistolY);
        pistolShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.PistolShots.Add(pistolShot);
    }
    public void FirePistolDown(int pistolX, int pistolY)
    {
        Pistol pistolShot = new Pistol(0, 400);
        pistolShot.Size = new Vector2f(pistolX, pistolY);
        pistolShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.PistolShots.Add(pistolShot);
    }
    public void FirePistolLeft(int pistolX, int pistolY)
    {
        Pistol pistolShot = new Pistol(-400, 0);
        pistolShot.Size = new Vector2f(pistolX, pistolY);
        pistolShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.PistolShots.Add(pistolShot);
    }
    public void FirePistolRight(int pistolX, int pistolY)
    {
        Pistol pistolShot = new Pistol(400, 0);
        pistolShot.Size = new Vector2f(pistolX, pistolY);
        pistolShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.PistolShots.Add(pistolShot);
    }

    //spawn machinegun shots
    public void FireMGUp(int mgX, int mgY)
    {
        Machinegun mgShot = new Machinegun(0, -500);
        mgShot.Size = new Vector2f(mgX, mgY);
        mgShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.MgShots.Add(mgShot);
    }
    public void FireMGDown(int mgX, int mgY)
    {
        Machinegun mgShot = new Machinegun(0, 500);
        mgShot.Size = new Vector2f(mgX, mgY);
        mgShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.MgShots.Add(mgShot);
    }
    public void FireMGLeft(int mgX, int mgY)
    {
        Machinegun mgShot = new Machinegun(-500, 0);
        mgShot.Size = new Vector2f(mgX, mgY);
        mgShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.MgShots.Add(mgShot);
    }
    public void FireMGRight(int mgX, int mgY)
    {
        Machinegun mgShot = new Machinegun(500, 0);
        mgShot.Size = new Vector2f(mgX, mgY);
        mgShot.Position = Position + new Vector2f(Game.PlayerObj.Size.X / 2, Game.PlayerObj.Size.Y / 2);
        Game.MgShots.Add(mgShot);
    }

    public static bool CheckPlayerEnemyRoom1Collision(RectangleShape enemy)
    {
        FloatRect boundingBoxPlayer = Game.PlayerObj.GetGlobalBounds();
        FloatRect boundingBoxEnemy = enemy.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxEnemy);
    }

    public static bool CheckPlayerEnemyRoom2Collision(RectangleShape enemy)
    {
        FloatRect boundingBoxPlayer = Game.PlayerObj.GetGlobalBounds();
        FloatRect boundingBoxEnemy = enemy.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxEnemy);
    }

    public static bool CheckPlayerEnemyRoom3Collision(RectangleShape enemy)
    {
        FloatRect boundingBoxPlayer = Game.PlayerObj.GetGlobalBounds();
        FloatRect boundingBoxEnemy = enemy.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxEnemy);
    }

    public static bool CheckPlayerEnemyKeyRoomCollision(RectangleShape enemy)
    {
        FloatRect boundingBoxPlayer = Game.PlayerObj.GetGlobalBounds();
        FloatRect boundingBoxEnemy = enemy.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxEnemy);
    }

    public static void PlayerEnemiesRoom1Collision(float deltaTime)
    {
        CollisionTimer(deltaTime);

        for (int i = 0; i < Game.EnemiesListRoom1.Count; i++)
        {
            if (CheckPlayerEnemyRoom1Collision(Game.EnemiesListRoom1[i]) == true && playerGotHurt == false)
            {
                Lives--;
                playerGotHurt = true;
                Game.PlayerObj.FillColor = new Color(Color.Red);

                playerDamagedTimer = 0;
            }
        }
    }
    public static void PlayerEnemiesRoom2Collision(float deltaTime)
    {
        CollisionTimer(deltaTime);

        for (int i = 0; i < Game.EnemiesListRoom2.Count; i++)
        {
            if (CheckPlayerEnemyRoom1Collision(Game.EnemiesListRoom2[i]) == true && playerGotHurt == false)
            {
                Lives--;
                playerGotHurt = true;
                Game.PlayerObj.FillColor = new Color(Color.Red);

                playerDamagedTimer = 0;
            }
        }
    }

    public static void PlayerEnemiesRoom3Collision(float deltaTime)
    {
        CollisionTimer(deltaTime);

        for (int i = 0; i < Game.EnemiesListRoom3.Count; i++)
        {
            if (CheckPlayerEnemyRoom1Collision(Game.EnemiesListRoom3[i]) == true && playerGotHurt == false)
            {
                Lives--;
                playerGotHurt = true;
                Game.PlayerObj.FillColor = new Color(Color.Red);

                playerDamagedTimer = 0;
            }
        }
    }

    public static void PlayerEnemiesKeyRoomCollision(float deltaTime)
    {
        CollisionTimer(deltaTime);

        for (int i = 0; i < Game.EnemiesListKeyRoom.Count; i++)
        {
            if (CheckPlayerEnemyKeyRoomCollision(Game.EnemiesListKeyRoom[i]) == true && playerGotHurt == false)
            {
                Lives--;
                playerGotHurt = true;
                Game.PlayerObj.FillColor = new Color(Color.Red);

                playerDamagedTimer = 0;
            }
        }
    }

    public static void CollisionTimer(float deltaTime)
    {
        playerDamagedTimer += deltaTime;

        if (playerGotHurt == true && playerDamagedTimer > playerIsSafeAfterDamage)
        {
            playerDamagedTimer = 0;
            playerGotHurt = false;

            Game.PlayerObj.FillColor = new Color(Color.White);
        }

        if (Lives <= 0)
        {
            Lives = 0;
            Game.PlayerLives.DisplayedString = "Lives: " + Lives.ToString();
        }
    }

    static bool CheckPlayerHallwayWallCollision(RectangleShape player)
    {
        FloatRect boundingBoxPlayer = player.GetGlobalBounds();
        FloatRect boundingBoxWall = Levels.Hallway.GetGlobalBounds();

        return boundingBoxPlayer.Intersects(boundingBoxWall);
    }

    public static void PlayerHallWallCollision(float deltaTime)
    {
        if(CheckPlayerHallwayWallCollision(Game.PlayerObj) == true && Keyboard.IsKeyPressed(Keyboard.Key.A) && PlayerPositionY < Levels.Hallway.Size.Y - 10)
        {
            Game.PlayerObj.Position += new Vector2f(PLAYER_SPEED, 0) * deltaTime;
        }

        if (CheckPlayerHallwayWallCollision(Game.PlayerObj) == true && Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            Game.PlayerObj.Position += new Vector2f(0, PLAYER_SPEED) * deltaTime;
        }
    }
}

class Light : RectangleShape
{
    public void Init()
    {
        Size = new Vector2f(3160, 2448); //3160, 2448
        Texture = new Texture("./Assets/Lightlayer.png");
        Position = new Vector2f(Game.GameWindow.Size.X / 2 - Size.X / 2, Game.GameWindow.Size.Y / 2 - Size.Y / 2);
    }
}

class Game
{
    public static bool IsStartScreenOn = true;
    public static bool IsGamePaused = false;
    static bool IsPauseButtonPressed = false;
    public static bool IsGameOver = false;

    public static RenderWindow GameWindow;

    public static Player PlayerObj;
    public static WeaponObject WeaponObj;
    public static Key BossKey;
    public static Light LightLayer;

    public static List<Pistol> PistolShots = new List<Pistol>();
    public static List<Machinegun> MgShots = new List<Machinegun>();

    static Font PixelLetters = new Font("./Assets/ARCADE_N.ttf");
    public static Text PlayerScore = new Text();
    public static Text PlayerLives = new Text();
    public static Text TradeText = new Text();
    static Text PauseTextBig = new Text();
    static Text PauseTextSmall = new Text();
    static Text GameOverText = new Text();
    static Text GameName = new Text();
    static Text Controls = new Text();
    static Text PressKey = new Text();
    static Text KeyText = new Text();
    static Text BossPlaceholder = new Text();

    public static bool IsKeyTextShown = false;

    public static int Score = 0;
    public static bool IsInRoom4 = false;
    public static bool IsInKeyRoom = false;
    //public static bool IsInEnemyRoom = false;

    public static Enemies EnemiesRoom1;
    public static Enemies EnemiesRoom2;
    public static Enemies EnemiesRoom3;
    public static Enemies EnemiesKeyRoom;

    public static List<Enemies> EnemiesListRoom1 = new List<Enemies>();
    public static List<Enemies> EnemiesListRoom2 = new List<Enemies>();
    public static List<Enemies> EnemiesListRoom3 = new List<Enemies>();
    public static List<Enemies> EnemiesListKeyRoom = new List<Enemies>();

    static bool IsSoundPlayed = false;

    public static Random randNum = new Random();

    public static int EnemySizeX = 93;
    public static int EnemySizeY = 92;

    public static Clock GameClock2;
    public static float EnemyTimer = 0;

    public static int CounterRoom1 = 0;
    public static int CounterRoom2 = 0;
    public static int CounterRoom3 = 0;
    public static int CounterRoomKey = 0;

    public static Time TimeSinceLastUpdateRoom1 = Time.Zero;
    public static Time TimeSinceLastUpdateRoom2 = Time.Zero;
    public static Time TimeSinceLastUpdateRoom3 = Time.Zero;
    public static Time TimeSinceLastUpdateRoomKey = Time.Zero;

    public static Time timePerFrame = Time.FromSeconds(1.0f / 60.0f);

    static void StartScreen()
    {
        RectangleShape startBlack = new RectangleShape();
        startBlack.Size = new Vector2f(GameWindow.Size.X, GameWindow.Size.Y);
        startBlack.FillColor = new Color(Color.Black);

        //Name of Game, short control explanation, press key to start
        GameName.CharacterSize = 90;
        GameName.Font = PixelLetters;
        GameName.FillColor = new Color(230, 0, 0);
        GameName.Position = new Vector2f(50, 200);
        GameName.DisplayedString = "DOOMING EYESACK";

        Controls.CharacterSize = 20;
        Controls.Font = PixelLetters;
        Controls.FillColor = new Color(Color.White);
        Controls.Position = new Vector2f(GameWindow.Size.X / 2 - 135, 400);
        Controls.DisplayedString = "   Controls: \n WASD to move \nSPACE to shoot \n  P to pause";

        PressKey.CharacterSize = 20;
        PressKey.Font = PixelLetters;
        PressKey.FillColor = new Color(125, 125, 125);
        PressKey.Position = new Vector2f(GameWindow.Size.X / 2 - 150, 700);
        PressKey.DisplayedString = "press F to start";

        GameWindow.Draw(startBlack);
        GameWindow.Draw(GameName);
        GameWindow.Draw(Controls);
        GameWindow.Draw(PressKey);

        GameWindow.Display();

        GameWindow.Clear();
    }

    public static void DrawPauseScreen()
    {
        RectangleShape PauseBackground = new RectangleShape();
        PauseBackground.Size = new Vector2f(GameWindow.Size.X, GameWindow.Size.Y);
        PauseBackground.Position = new Vector2f(0, 0);
        PauseBackground.FillColor = new Color(0, 0, 0, 95);
        GameWindow.Draw(PauseBackground);
        GameWindow.Draw(PauseTextBig);
        GameWindow.Draw(PauseTextSmall);
    }

    static void DrawGameOverScreen()
    {
        RectangleShape LooseBackground = new RectangleShape();
        LooseBackground.Size = new Vector2f(GameWindow.Size.X, GameWindow.Size.Y);
        LooseBackground.Position = new Vector2f(0, 0);
        LooseBackground.FillColor = new Color(0, 0, 0, 95);

        GameOverText.Font = PixelLetters;
        GameOverText.FillColor = Color.Red;
        GameOverText.Position = new Vector2f(GameWindow.Size.X / 2 - 400, GameWindow.Size.Y / 2);
        GameOverText.CharacterSize = 100;
        GameOverText.DisplayedString = "GAME OVER";

        GameWindow.Draw(LooseBackground);
        GameWindow.Draw(GameOverText);

        GameWindow.Display();
        GameWindow.Clear();
        
        SoundBuffer Buffer = new SoundBuffer("./Assets/Loose_13.wav");
        Sound GameOverSound = new Sound(Buffer);

        if (IsSoundPlayed == false)
        {
            GameOverSound.Play();
            IsSoundPlayed = true;
        }
    }

    static void InitGameWindow()
    {
        VideoMode vmode = new VideoMode(1366, 768);
        GameWindow = new RenderWindow(vmode, "DOOMING EYESACK");
    }

    static void InitPlayer()
    {
        PlayerObj = new Player();
        PlayerObj.Init();
    }

    static void InitLight()
    {
        LightLayer = new Light();
        LightLayer.Init();
    }

    static void InitWeaponObj()
    {
        WeaponObj = new WeaponObject();
        WeaponObj.Init();
    }

    static void InitKey()
    {
        BossKey = new Key();
        BossKey.Init();
    }

    static void InitText()
    {
        TradeText.Font = PixelLetters;
        TradeText.Position = new Vector2f(GameWindow.Size.X / 2 - 380, GameWindow.Size.Y / 2 - 60);
        TradeText.FillColor = Color.White;
        TradeText.CharacterSize = 15;
        TradeText.DisplayedString = "trade 5000 scorepoints against the machinegun upgrade!";

        PauseTextBig.Font = PixelLetters;
        PauseTextBig.Position = new Vector2f(GameWindow.Size.X / 2 - 465, GameWindow.Size.Y / 2 - 100);
        PauseTextBig.FillColor = new Color(200, 0, 0);
        PauseTextBig.CharacterSize = 200;
        PauseTextBig.DisplayedString = "PAUSE";

        PauseTextSmall.Font = PixelLetters;
        PauseTextSmall.Position = new Vector2f(GameWindow.Size.X / 2 - 215, GameWindow.Size.Y / 2 + 300);
        PauseTextSmall.FillColor = Color.White;
        PauseTextSmall.CharacterSize = 15;
        PauseTextSmall.DisplayedString = "press P to resume, ESC to quit";

        BossPlaceholder.Font = PixelLetters;
        BossPlaceholder.Position = new Vector2f(GameWindow.Size.X / 2 - 490, GameWindow.Size.Y / 2 - 100);
        BossPlaceholder.FillColor = new Color(150, 0, 0);
        BossPlaceholder.CharacterSize = 100;
        BossPlaceholder.DisplayedString = "    BOSS \nPLACEHOLDER";
    }

    //INIT ALL ENEMIES 
    public static void InitEnemiesRoom1()
    {
        EnemiesRoom1 = new Enemies();
        EnemiesRoom1.Texture = new Texture("./assets/enemy_gelb.png");
        EnemiesRoom1.Size = new Vector2f(EnemySizeX, EnemySizeY);
        EnemiesRoom1.Position = new Vector2f(randNum.Next(30, (int)GameWindow.Size.X - Levels.WallThickness - EnemySizeY), randNum.Next(30, (int)GameWindow.Size.Y - Levels.WallThickness - EnemySizeX));
        EnemiesListRoom1.Add(EnemiesRoom1);
    }

    public static void InitEnemiesRoom2()
    {
        EnemiesRoom2 = new Enemies();
        EnemiesRoom2.Texture = new Texture("./assets/enemy_gelb.png");
        EnemiesRoom2.Size = new Vector2f(EnemySizeX, EnemySizeY);
        EnemiesRoom2.Position = new Vector2f(randNum.Next(30, (int)GameWindow.Size.X - Levels.WallThickness - EnemySizeY), randNum.Next(30, (int)GameWindow.Size.Y - Levels.WallThickness - EnemySizeX));
        EnemiesListRoom2.Add(EnemiesRoom2);
    }

    public static void InitEnemiesRoom3()
    {
        EnemiesRoom3 = new Enemies();
        EnemiesRoom3.Texture = new Texture("./assets/enemy_gelb.png");
        EnemiesRoom3.Size = new Vector2f(EnemySizeX, EnemySizeY);
        EnemiesRoom3.Position = new Vector2f(randNum.Next(30, (int)GameWindow.Size.X - Levels.WallThickness - EnemySizeY), randNum.Next(30, (int)GameWindow.Size.Y - Levels.WallThickness - EnemySizeX));
        EnemiesListRoom3.Add(EnemiesRoom3);
    }

    public static void InitEnemiesKeyRoom()
    {
        EnemiesKeyRoom = new Enemies();
        EnemiesKeyRoom.Texture = new Texture("./assets/enemy_gelb.png");
        EnemiesKeyRoom.Size = new Vector2f(EnemySizeX, EnemySizeY);
        EnemiesKeyRoom.Position = new Vector2f(randNum.Next(30, (int)GameWindow.Size.X - Levels.WallThickness - EnemySizeY), randNum.Next(30, (int)GameWindow.Size.Y - Levels.WallThickness - EnemySizeX));
        EnemiesListKeyRoom.Add(EnemiesKeyRoom);
    }

    //DRAW ALL ENEMIES

    public static void DrawEnemiesRoom1()
    {
        for (int i = 0; i < EnemiesListRoom1.Count; i++)
        {
            GameWindow.Draw(EnemiesListRoom1[i]);
        }
    }

    public static void DrawEnemiesRoom2()
    {
        for (int i = 0; i < EnemiesListRoom2.Count; i++)
        {
            GameWindow.Draw(EnemiesListRoom2[i]);
        }
    }

    public static void DrawEnemiesRoom3()
    {
        for (int i = 0; i < EnemiesListRoom3.Count; i++)
        {
            GameWindow.Draw(EnemiesListRoom3[i]);
        }
    }

    public static void DrawEnemiesKeyRoom()
    {
        for (int i = 0; i < EnemiesListKeyRoom.Count; i++)
        {
            GameWindow.Draw(EnemiesListKeyRoom[i]);
        }
    }

    //SPAWNINTERVALL ALL ENEMIES

    public static void SpawnIntervalEnemiesRoom1(Time deltaTime)
    {
        if (GameClock2.ElapsedTime.AsSeconds() > 2.0f && CounterRoom1 < 5)
        {
            InitEnemiesRoom1();
            CounterRoom1 += 1;
            GameClock2.Restart();
        }
    }

    public static void SpawnIntervalEnemiesRoom2(Time deltaTime)
    {
        if (GameClock2.ElapsedTime.AsSeconds() > 1.8f && CounterRoom2 < 10)
        {
            InitEnemiesRoom2();
            CounterRoom2 += 1;
            GameClock2.Restart();
        }
    }

    public static void SpawnIntervalEnemiesRoom3(Time deltaTime)
    {
        if (GameClock2.ElapsedTime.AsSeconds() > 1.5f && CounterRoom3 < 25)
        {
            InitEnemiesRoom3();
            CounterRoom3 += 1;
            GameClock2.Restart();
        }
    }

    public static void SpawnIntervalEnemiesRoomKey(Time deltaTime)
    {
        if (GameClock2.ElapsedTime.AsSeconds() > 1.3f && CounterRoomKey < 35)
        {
            InitEnemiesKeyRoom();
            CounterRoomKey += 1;
            GameClock2.Restart();
        }
    }

    static void PlayBackgroundMusic()
    {
        SoundBuffer backgroundMusic = new SoundBuffer("./Assets/noStoppingNow.wav");
        Sound Music = new Sound(backgroundMusic);
        Music.Volume = 50;
        Music.Loop = true;
        if(Music.Status != SoundStatus.Playing)
            Music.Play();
    }

    static void DrawEssentials()
    {
        GameWindow.Draw(LightLayer);

        PlayerScore.Font = PixelLetters;
        PlayerScore.Position = new Vector2f(40, 30);
        PlayerScore.FillColor = new Color(125, 125, 125);
        PlayerScore.CharacterSize = 35;
        PlayerScore.DisplayedString = "Score: " + Score.ToString();

        PlayerLives.Font = PixelLetters;
        PlayerLives.Position = new Vector2f(GameWindow.Size.X - 350, 30);
        PlayerLives.FillColor = new Color(125, 125, 125);
        PlayerLives.CharacterSize = 35;
        PlayerLives.DisplayedString = "Lives: " + Player.Lives.ToString();

        GameWindow.Draw(PlayerScore);
        GameWindow.Draw(PlayerLives);

        if (IsGamePaused == true)
            DrawPauseScreen();

        GameWindow.Display();
    }
    
    //Main Loop
    static void Main()
    {
        InitGameWindow();
        InitPlayer();
        InitText();

        Levels.InitAllLevels();
        InitLight();

        Clock GameClock = new Clock();
        Clock clck = new Clock();
        GameClock2 = new Clock();

        PlayBackgroundMusic();
        GameWindow.SetFramerateLimit(120);

        while (true)
        {
            float deltaTime = GameClock.Restart().AsSeconds();

            EnemyTimer += deltaTime;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) == true)
                break;

            GameWindow.DispatchEvents();

            PlayerObj.Update(deltaTime);

            Levels.RoomTransition();

            switch (Levels.CurrentRoom)
            {
                case Levels.Room.Start:
                    {
                        Levels.DrawStart();
                        IsInRoom4 = false;
                        IsInKeyRoom = false;
                        break;
                    }

                case Levels.Room.Room1:
                    {
                        Levels.DrawRoom1();
                        IsInRoom4 = false;
                        IsInKeyRoom = false;

                        TimeSinceLastUpdateRoom1 += clck.Restart();

                        while (TimeSinceLastUpdateRoom1 > timePerFrame)
                        {
                            TimeSinceLastUpdateRoom1 -= timePerFrame;
                            SpawnIntervalEnemiesRoom1(timePerFrame);
                        }

                        if(EnemiesListRoom1.Count > 0)
                            EnemiesRoom1.EnemyMovementRoom1(deltaTime);

                        Player.PlayerEnemiesRoom1Collision(deltaTime);

                        break;
                    }

                case Levels.Room.Room2:
                    {
                        Levels.DrawRoom2();
                        IsInRoom4 = false;
                        IsInKeyRoom = false;

                        TimeSinceLastUpdateRoom2 += clck.Restart();

                        while (TimeSinceLastUpdateRoom2 > timePerFrame)
                        {
                            TimeSinceLastUpdateRoom2 -= timePerFrame;
                            SpawnIntervalEnemiesRoom2(timePerFrame);
                        }

                        if (EnemiesListRoom2.Count > 0)
                            EnemiesRoom2.EnemyMovementRoom2(deltaTime);

                        Player.PlayerEnemiesRoom2Collision(deltaTime);

                        break;
                    }

                case Levels.Room.Room3:
                    {
                        Levels.DrawRoom3();
                        IsInRoom4 = false;
                        IsInKeyRoom = false;

                        TimeSinceLastUpdateRoom3 += clck.Restart();

                        while (TimeSinceLastUpdateRoom3 > timePerFrame)
                        {
                            TimeSinceLastUpdateRoom3 -= timePerFrame;
                            SpawnIntervalEnemiesRoom3(timePerFrame);
                        }
                        if (EnemiesListRoom3.Count > 0)
                            EnemiesRoom3.EnemyMovementRoom3(deltaTime);

                        Player.PlayerEnemiesRoom3Collision(deltaTime);

                        break;
                    }

                case Levels.Room.Room4:
                    {
                        Levels.DrawRoom4();
                        if (Player.IsMgOn == false)
                        {
                            IsInRoom4 = true;
                            IsInKeyRoom = false;
                            InitWeaponObj();
                            GameWindow.Draw(WeaponObj);
                            GameWindow.Draw(TradeText);
                        }
                        break;
                    }

                case Levels.Room.KeyRoom:
                    {
                        Levels.DrawKeyRoom();
                        IsInRoom4 = false;
                        IsInKeyRoom = true;

                        TimeSinceLastUpdateRoomKey += clck.Restart();

                        while (TimeSinceLastUpdateRoomKey > timePerFrame)
                        {
                            TimeSinceLastUpdateRoomKey -= timePerFrame;
                            SpawnIntervalEnemiesRoomKey(timePerFrame);
                        }

                        if (EnemiesListKeyRoom.Count == 0 && Key.IsKeyPickedUp == false)
                        {
                            InitKey();
                            GameWindow.Draw(BossKey);
                        }

                        if (EnemiesListKeyRoom.Count > 0)
                            EnemiesKeyRoom.EnemyMovementKeyRoom(deltaTime);

                        Player.PlayerEnemiesKeyRoomCollision(deltaTime);

                        break;
                    }

                case Levels.Room.Hallway:
                    {
                        IsInRoom4 = false;
                        IsInKeyRoom = false;
                        Levels.DrawHallway();

                        Player.PlayerHallWallCollision(deltaTime);

                        break;
                    }

                case Levels.Room.TreasureRoom:
                    {
                        IsInRoom4 = false;
                        IsInKeyRoom = false;
                        Levels.DrawTreasureRoom();
                        GameWindow.Draw(BossPlaceholder);
                        break;
                    }
            }

            for (int i = PistolShots.Count - 1; i >= 0; i--)
            {
                PistolShots[i].PistolUpdate(deltaTime);

                PistolShots[i].CheckBulletEnemyCollision(EnemiesListRoom1);
                PistolShots[i].CheckBulletEnemyCollision(EnemiesListRoom2);
                PistolShots[i].CheckBulletEnemyCollision(EnemiesListRoom3);
                PistolShots[i].CheckBulletEnemyCollision(EnemiesListKeyRoom);

                if (PistolShots[i].IsDestroyed == true)
                    PistolShots.RemoveAt(i);
            }
            for (int i = MgShots.Count - 1; i >= 0; i--)
            {
                MgShots[i].MachinegunUpdate(deltaTime);

                MgShots[i].CheckMgEnemyCollision(EnemiesListRoom1);
                MgShots[i].CheckMgEnemyCollision(EnemiesListRoom2);
                MgShots[i].CheckMgEnemyCollision(EnemiesListRoom3);
                MgShots[i].CheckMgEnemyCollision(EnemiesListKeyRoom);

                if (MgShots[i].IsDestroyed == true)
                    MgShots.RemoveAt(i);
            }

            if (IsStartScreenOn == false && IsGameOver == false)
                DrawEssentials();

            if (IsStartScreenOn == true)
                StartScreen();

            if (IsGameOver == true)
                DrawGameOverScreen();

            if (Keyboard.IsKeyPressed(Keyboard.Key.F) == true)
                IsStartScreenOn = false;

            if (Keyboard.IsKeyPressed(Keyboard.Key.P) && IsPauseButtonPressed == false)
            {
                IsGamePaused = !IsGamePaused;
                IsPauseButtonPressed = true;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.P) == false)
                IsPauseButtonPressed = false;
        }
    }
}