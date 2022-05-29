using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Game;
using RogueSharp;
using SFML.Graphics;
using SFML.Window;

namespace SfmlApp
{
    public class ConsoleInput
    {
        private readonly RenderWindow window;
        public ConsoleInput(RenderWindow window)
        {
            this.window = window;
        }

        public Input.BtnState GetKeyState(Keyboard.Key key, string identifierKey, Input? oldInput)
        {
            if (GetKey(key))
            {
                if (oldInput != null && 
                    oldInput.Keyboard.KeyboardState
                        .Any(x => x.Identifier.Key == identifierKey && 
                                  x.IsPressed())
                   )
                {
                    return Input.BtnState.Echo;
                }
                return Input.BtnState.Pressed;
            }
            else
            {
                return Input.BtnState.Released;
            }
        }

        public Input.MouseInput GetMouseState(Input? oldInput, Window window)
        {
            Input.BtnState GetMouseButtonState(bool isPressed, bool isEcho)
            {
                if (isPressed)
                {
                    return isEcho ? Input.BtnState.Echo : Input.BtnState.Pressed;
                }
                return Input.BtnState.Released;
            };
            
            var leftButton = GetMouseButtonState(
                SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Left),
                oldInput != null && oldInput.Mouse.LeftButton == Input.BtnState.Pressed
            );
            var middleButton = GetMouseButtonState(
                SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle),
                oldInput != null && oldInput.Mouse.LeftButton == Input.BtnState.Pressed
            );
            var rightButton = GetMouseButtonState(
                SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Right),
                oldInput != null && oldInput.Mouse.LeftButton == Input.BtnState.Pressed
            );

            Point p = new Point()
            {
                X = SFML.Window.Mouse.GetPosition(window).X,
                Y = SFML.Window.Mouse.GetPosition(window).Y
            };
            var mousePos = new RogueSharp.Point(p.X, p.Y);
            
            
            
            return new Input.MouseInput()
            {
                LeftButton = leftButton,
                MiddleButton = middleButton,
                RightButton = rightButton,
                ScrollWheel = 0,
                X = mousePos.X,
                Y = mousePos.Y
            };
        }

        public Input UpdateInput(Input? oldInput)
        {
            var result = new Input()
            {
                Keyboard = new Input.KeyboardInput()
                {
                    KeyboardState = new List<Input.KeyboardInput.KeyboardKey>()
                    {
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyR,
                            Value = GetKeyState(Keyboard.Key.R, Input.KeyboardInput.KeyboardIdentifierList.KeyR.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyX,
                            Value = GetKeyState(Keyboard.Key.X, Input.KeyboardInput.KeyboardIdentifierList.KeyX.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Escape,
                            Value = GetKeyState(Keyboard.Key.Escape, Input.KeyboardInput.KeyboardIdentifierList.Escape.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyC,
                            Value = GetKeyState(Keyboard.Key.C, Input.KeyboardInput.KeyboardIdentifierList.KeyC.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyZ,
                            Value = GetKeyState(Keyboard.Key.Z, Input.KeyboardInput.KeyboardIdentifierList.KeyZ.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Digit1,
                            Value = GetKeyState(Keyboard.Key.Num1, Input.KeyboardInput.KeyboardIdentifierList.Digit1.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Digit2,
                            Value = GetKeyState(Keyboard.Key.Num2, Input.KeyboardInput.KeyboardIdentifierList.Digit2.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Digit3,
                            Value = GetKeyState(Keyboard.Key.Num3, Input.KeyboardInput.KeyboardIdentifierList.Digit3.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyA,
                            Value = GetKeyState(Keyboard.Key.A, Input.KeyboardInput.KeyboardIdentifierList.KeyA.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyW,
                            Value = GetKeyState(Keyboard.Key.W, Input.KeyboardInput.KeyboardIdentifierList.KeyW.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyD,
                            Value = GetKeyState(Keyboard.Key.D, Input.KeyboardInput.KeyboardIdentifierList.KeyD.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyS,
                            Value = GetKeyState(Keyboard.Key.S, Input.KeyboardInput.KeyboardIdentifierList.KeyS.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowLeft,
                            Value = GetKeyState(Keyboard.Key.Left, Input.KeyboardInput.KeyboardIdentifierList.ArrowLeft.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowUp,
                            Value = GetKeyState(Keyboard.Key.Up, Input.KeyboardInput.KeyboardIdentifierList.ArrowUp.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowRight,
                            Value = GetKeyState(Keyboard.Key.Right, Input.KeyboardInput.KeyboardIdentifierList.ArrowRight.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowDown,
                            Value = GetKeyState(Keyboard.Key.Down, Input.KeyboardInput.KeyboardIdentifierList.ArrowDown.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyJ,
                            Value = GetKeyState(Keyboard.Key.J, Input.KeyboardInput.KeyboardIdentifierList.KeyJ.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyI,
                            Value = GetKeyState(Keyboard.Key.I, Input.KeyboardInput.KeyboardIdentifierList.KeyI.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyL,
                            Value = GetKeyState(Keyboard.Key.L, Input.KeyboardInput.KeyboardIdentifierList.KeyL.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyK,
                            Value = GetKeyState(Keyboard.Key.K, Input.KeyboardInput.KeyboardIdentifierList.KeyK.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Slash,
                            Value = GetKeyState(Keyboard.Key.Slash, Input.KeyboardInput.KeyboardIdentifierList.Slash.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Period,
                            Value = GetKeyState(Keyboard.Key.Period, Input.KeyboardInput.KeyboardIdentifierList.Period.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Comma,
                            Value = GetKeyState(Keyboard.Key.Comma, Input.KeyboardInput.KeyboardIdentifierList.Comma.Key, oldInput),
                        },
                    }
                },
                Mouse = GetMouseState(oldInput, window)
            };
            return result;
        }

        private bool GetKey(Keyboard.Key key)
        {
            return SFML.Window.Keyboard.IsKeyPressed(key);
        }
    }
}