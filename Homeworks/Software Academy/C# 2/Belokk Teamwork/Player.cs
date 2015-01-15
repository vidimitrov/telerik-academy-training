using System;
using System.Collections.Generic;

public class Player
{
    public int CurrentPositionX { get; set; }
    public int LastPositionX { get; set; }
    public int CurrentPositionY { get; set; }
    public int LastPositionY { get; set; }
    private ConsoleColor PlayerColor { get; set; }
    private char PlayerChar { get; set; }

    public CellStatus currentPosition = CellStatus.Head;

    public CellStatus lastPosition = CellStatus.Filled;

    public MovementStatus movement = MovementStatus.Stopped;

    //Working on filling the occupied cells
    public struct Coordinate
    {
        public int X;
        public int Y;
    }

    public List<Coordinate> angles = new List<Coordinate>();

    public Player(int x, int y, ConsoleColor color = ConsoleColor.DarkYellow, char character = (char)2)
    {
        CurrentPositionX = x;
        CurrentPositionY = y;
        LastPositionX = x;
        LastPositionY = y;
        PlayerColor = color;
        PlayerChar = character;
        lastPosition = CellStatus.Filled;
    }

    public void MoveOnDirection(MovementStatus movement, GameField field)
    {
        if (movement == MovementStatus.Left)
        {
            if (this.currentPosition == CellStatus.Empty)
            {
                this.Move(new ConsoleKeyInfo('\u2190', ConsoleKey.LeftArrow, false, false, false), field);
            }
            else if (this.currentPosition == CellStatus.Trail)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Ball)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Filled)
            {
                //Fill the occupied field
                this.movement = MovementStatus.Stopped;

                Coordinate pos = new Coordinate();

                pos.X = LastPositionX;
                pos.Y = LastPositionY;

                this.angles.Add(pos);

                FillRectangle(this.angles[0], this.angles[2], field);

                this.angles.Clear();
            }
        }
        else if (movement == MovementStatus.Right)
        {
            if (this.currentPosition == CellStatus.Empty)
            {
                this.Move(new ConsoleKeyInfo('\u2192', ConsoleKey.RightArrow, false, false, false), field);
            }
            else if (this.currentPosition == CellStatus.Trail)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Ball)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Filled)
            {
                //Fill the occupied field
                this.movement = MovementStatus.Stopped;

                Coordinate pos = new Coordinate();

                pos.X = LastPositionX;
                pos.Y = LastPositionY;

                this.angles.Add(pos);

                FillRectangle(this.angles[0], this.angles[2], field);

                this.angles.Clear();
            }
        }
        else if (movement == MovementStatus.Up)
        {
            if (this.currentPosition == CellStatus.Empty)
            {
                this.Move(new ConsoleKeyInfo('\u2191', ConsoleKey.UpArrow, false, false, false), field);
            }
            else if (this.currentPosition == CellStatus.Trail)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Ball)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Filled)
            {
                //Fill the occupied field
                this.movement = MovementStatus.Stopped;

                Coordinate pos = new Coordinate();

                pos.X = LastPositionX;
                pos.Y = LastPositionY;

                this.angles.Add(pos);

                FillRectangle(this.angles[0], this.angles[2], field);

                this.angles.Clear();
            }
        }
        else if (movement == MovementStatus.Down)
        {
            if (this.currentPosition == CellStatus.Empty)
            {
                this.Move(new ConsoleKeyInfo('\u2193', ConsoleKey.DownArrow, false, false, false), field);
            }
            else if (this.currentPosition == CellStatus.Trail)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Ball)
            {
                //Qix_Game.Game.GameOver();
            }
            else if (this.currentPosition == CellStatus.Filled)
            {
                //Fill the occupied field
                this.movement = MovementStatus.Stopped;

                Coordinate pos = new Coordinate();

                pos.X = LastPositionX;
                pos.Y = LastPositionY;

                this.angles.Add(pos);

                FillRectangle(this.angles[0], this.angles[2], field);

                this.angles.Clear();
            }
        }
    }

    public void Move(ConsoleKeyInfo pressedKey, GameField field)
    {
        if (pressedKey.Key == ConsoleKey.LeftArrow)
        {
            if (CurrentPositionX > 0)
            {
                if (currentPosition == CellStatus.Empty)
                {
                    this.lastPosition = CellStatus.Trail;
                }
                else if (currentPosition == CellStatus.Filled)
                {
                    this.lastPosition = CellStatus.Filled;
                }
                else if (currentPosition == CellStatus.Trail)
                {
                    this.lastPosition = currentPosition;
                }

                this.LastPositionX = this.CurrentPositionX;
                this.LastPositionY = this.CurrentPositionY;


                this.CurrentPositionX--;

                this.currentPosition = field.gameField[this.CurrentPositionY, this.CurrentPositionX];

                if (this.currentPosition == CellStatus.Empty && this.movement != MovementStatus.Left)
                {
                    this.movement = MovementStatus.Left;

                    //Working on filling the occupied cells

                    Coordinate pos = new Coordinate();

                    if (this.lastPosition == CellStatus.Filled)
                    {
                        pos.X = CurrentPositionX;
                        pos.Y = CurrentPositionY;
                    }
                    else
                    {
                        pos.X = LastPositionX;
                        pos.Y = LastPositionY;
                    }

                    this.angles.Add(pos);
                }
            }
        }
        else if (pressedKey.Key == ConsoleKey.RightArrow)
        {
            if (CurrentPositionX < field.width - 1)
            {
                if (currentPosition == CellStatus.Empty)
                {
                    this.lastPosition = CellStatus.Trail;
                }
                else if (currentPosition == CellStatus.Filled)
                {
                    this.lastPosition = CellStatus.Filled;
                }
                else if (currentPosition == CellStatus.Trail)
                {
                    this.lastPosition = currentPosition;
                }

                this.LastPositionX = this.CurrentPositionX;
                this.LastPositionY = this.CurrentPositionY;

                this.CurrentPositionX++;

                this.currentPosition = field.gameField[this.CurrentPositionY, this.CurrentPositionX];

                if (this.currentPosition == CellStatus.Empty && this.movement != MovementStatus.Right)
                {
                    this.movement = MovementStatus.Right;

                    //Working on filling the occupied cells

                    Coordinate pos = new Coordinate();

                    if (this.lastPosition == CellStatus.Filled)
                    {
                        pos.X = CurrentPositionX;
                        pos.Y = CurrentPositionY;
                    }
                    else
                    {
                        pos.X = LastPositionX;
                        pos.Y = LastPositionY;
                    }

                    this.angles.Add(pos);
                }
            }
        }
        else if (pressedKey.Key == ConsoleKey.UpArrow)
        {
            if (CurrentPositionY > 0)
            {
                if (currentPosition == CellStatus.Empty)
                {
                    this.lastPosition = CellStatus.Trail;
                }
                else if (currentPosition == CellStatus.Filled)
                {
                    this.lastPosition = CellStatus.Filled;
                }
                else if (currentPosition == CellStatus.Trail)
                {
                    this.lastPosition = currentPosition;
                }

                this.LastPositionX = this.CurrentPositionX;
                this.LastPositionY = this.CurrentPositionY;

                this.CurrentPositionY--;

                this.currentPosition = field.gameField[this.CurrentPositionY, this.CurrentPositionX];

                if (this.currentPosition == CellStatus.Empty && this.movement != MovementStatus.Up)
                {
                    this.movement = MovementStatus.Up;

                    //Working on filling the occupied cells

                    Coordinate pos = new Coordinate();

                    if (this.lastPosition == CellStatus.Filled)
                    {
                        pos.X = CurrentPositionX;
                        pos.Y = CurrentPositionY;
                    }
                    else
                    {
                        pos.X = LastPositionX;
                        pos.Y = LastPositionY;
                    }

                    this.angles.Add(pos);
                }
            }
        }
        else if (pressedKey.Key == ConsoleKey.DownArrow)
        {
            if (CurrentPositionY < field.height - 1)
            {
                if (currentPosition == CellStatus.Empty)
                {
                    this.lastPosition = CellStatus.Trail;
                }
                else if (currentPosition == CellStatus.Filled)
                {
                    this.lastPosition = CellStatus.Filled;
                }
                else if (currentPosition == CellStatus.Trail)
                {
                    this.lastPosition = currentPosition;
                }

                this.LastPositionX = this.CurrentPositionX;
                this.LastPositionY = this.CurrentPositionY;

                this.CurrentPositionY++;

                this.currentPosition = field.gameField[this.CurrentPositionY, this.CurrentPositionX];

                if (this.currentPosition == CellStatus.Empty && this.movement != MovementStatus.Down)
                {
                    this.movement = MovementStatus.Down;

                    //Working on filling the occupied cells

                    Coordinate pos = new Coordinate();

                    if (this.lastPosition == CellStatus.Filled)
                    {
                        pos.X = CurrentPositionX;
                        pos.Y = CurrentPositionY;
                    }
                    else
                    {
                        pos.X = LastPositionX;
                        pos.Y = LastPositionY;
                    }

                    this.angles.Add(pos);
                }

                //Delete me
                //FillRectangle(new Coordinate() { X = 1, Y = 1 }, new Coordinate() { X = 10, Y = 10 }, field);
            }
        }

        field.gameField[this.LastPositionY, this.LastPositionX] = this.lastPosition;
        field.gameField[this.CurrentPositionY, this.CurrentPositionX] = CellStatus.Head;
    }

    //Fill(make them CellStatus.Filled) a rectangle in the matrix, from 2 coordinates

    public void FillRectangle(Coordinate firstDot, Coordinate secondDot, GameField field)
    {
        //Many check for different quadrants

        if (firstDot.X <= secondDot.X && firstDot.Y <= secondDot.Y)
        {
            for (int i = firstDot.Y; i <= secondDot.Y; i++)
            {
                for (int j = firstDot.X; j <= secondDot.X; j++)
                {
                    field.gameField[i, j] = CellStatus.Filled;
                }
            }
        }
        else
        {
            for (int i = secondDot.Y; i <= firstDot.Y; i++)
            {
                for (int j = secondDot.X; j >= firstDot.X; j--)
                {
                    field.gameField[i, j] = CellStatus.Filled;
                }
            }
        }


    }
}