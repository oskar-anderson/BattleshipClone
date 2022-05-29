using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using ConsoleGameEngineCore;
using Domain.Model;
using Game;

namespace PureConsoleApp
{
    public class ConsoleInput
    {
        private readonly ConsoleEngine engine;
        public ConsoleInput(ConsoleEngine engine)
        {
            this.engine = engine;
        }

        public Input.BtnState GetKeyState(ConsoleKey ck, string identifierKey, Input? oldInput)
        {
            if (GetKey(ck))
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

        public Input.MouseInput GetMouseState(Input? oldInput)
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
                engine.GetMouseLeft(),
                oldInput != null && oldInput.Mouse.LeftButton == Input.BtnState.Pressed
            );
            var middleButton = GetMouseButtonState(
                engine.GetMouseLeft(),
                oldInput != null && oldInput.Mouse.LeftButton == Input.BtnState.Pressed
            );
            var rightButton = GetMouseButtonState(
                engine.GetMouseLeft(),
                oldInput != null && oldInput.Mouse.LeftButton == Input.BtnState.Pressed
            );

            Point p = engine.GetMousePos();
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
                            Value = GetKeyState(ConsoleKey.R, Input.KeyboardInput.KeyboardIdentifierList.KeyR.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyX,
                            Value = GetKeyState(ConsoleKey.X, Input.KeyboardInput.KeyboardIdentifierList.KeyX.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Escape,
                            Value = GetKeyState(ConsoleKey.Escape, Input.KeyboardInput.KeyboardIdentifierList.Escape.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyC,
                            Value = GetKeyState(ConsoleKey.C, Input.KeyboardInput.KeyboardIdentifierList.KeyC.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyZ,
                            Value = GetKeyState(ConsoleKey.Z, Input.KeyboardInput.KeyboardIdentifierList.KeyZ.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Digit1,
                            Value = GetKeyState(ConsoleKey.D1, Input.KeyboardInput.KeyboardIdentifierList.Digit1.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Digit2,
                            Value = GetKeyState(ConsoleKey.D2, Input.KeyboardInput.KeyboardIdentifierList.Digit2.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Digit3,
                            Value = GetKeyState(ConsoleKey.D3, Input.KeyboardInput.KeyboardIdentifierList.Digit3.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyA,
                            Value = GetKeyState(ConsoleKey.A, Input.KeyboardInput.KeyboardIdentifierList.KeyA.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyW,
                            Value = GetKeyState(ConsoleKey.W, Input.KeyboardInput.KeyboardIdentifierList.KeyW.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyD,
                            Value = GetKeyState(ConsoleKey.D, Input.KeyboardInput.KeyboardIdentifierList.KeyD.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyS,
                            Value = GetKeyState(ConsoleKey.S, Input.KeyboardInput.KeyboardIdentifierList.KeyS.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowLeft,
                            Value = GetKeyState(ConsoleKey.LeftArrow, Input.KeyboardInput.KeyboardIdentifierList.ArrowLeft.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowUp,
                            Value = GetKeyState(ConsoleKey.UpArrow, Input.KeyboardInput.KeyboardIdentifierList.ArrowUp.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowRight,
                            Value = GetKeyState(ConsoleKey.RightArrow, Input.KeyboardInput.KeyboardIdentifierList.ArrowRight.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.ArrowDown,
                            Value = GetKeyState(ConsoleKey.DownArrow, Input.KeyboardInput.KeyboardIdentifierList.ArrowDown.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyJ,
                            Value = GetKeyState(ConsoleKey.J, Input.KeyboardInput.KeyboardIdentifierList.KeyJ.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyI,
                            Value = GetKeyState(ConsoleKey.I, Input.KeyboardInput.KeyboardIdentifierList.KeyI.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyL,
                            Value = GetKeyState(ConsoleKey.L, Input.KeyboardInput.KeyboardIdentifierList.KeyL.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.KeyK,
                            Value = GetKeyState(ConsoleKey.K, Input.KeyboardInput.KeyboardIdentifierList.KeyK.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Slash,
                            Value = GetKeyState(ConsoleKey.OemMinus, Input.KeyboardInput.KeyboardIdentifierList.Slash.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Period,
                            Value = GetKeyState(ConsoleKey.OemPeriod, Input.KeyboardInput.KeyboardIdentifierList.Period.Key, oldInput),
                        },
                        new Input.KeyboardInput.KeyboardKey()
                        {
                            Identifier = Input.KeyboardInput.KeyboardIdentifierList.Comma,
                            Value = GetKeyState(ConsoleKey.OemComma, Input.KeyboardInput.KeyboardIdentifierList.Comma.Key, oldInput),
                        },
                    }
                },
                Mouse = GetMouseState(oldInput)
            };
            return result;
        }
        
        [DllImport("user32.dll", SetLastError = true)]
        private static extern short GetAsyncKeyState(int vKey);

        private bool GetKey(ConsoleKey key)
        {
            if (false)
            {
                return engine.GetKey((ConsoleKey) (int) key);
            }
            short s = GetAsyncKeyState((int) key);
            return (s & 0x8000) > 0;
        }
    }
}