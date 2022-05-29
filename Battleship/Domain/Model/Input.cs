using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Model
{
    public class Input
    {
        public KeyboardInput Keyboard { get; set; } = null!;
        public MouseInput Mouse { get; set; } = null!;

        public static Input GetDefaultInput()
        {
            return new Input()
            {
                Keyboard = new KeyboardInput()
                {
                    KeyboardState = new List<KeyboardInput.KeyboardKey>()
                    {
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyR,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyX,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Escape,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyC,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyZ,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Digit1,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Digit2,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Digit3,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyA,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyW,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyD,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyS,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.ArrowLeft,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.ArrowUp,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.ArrowRight,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.ArrowDown,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyJ,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyI,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyL,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.KeyK,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Slash,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Period,
                            Value = BtnState.Released
                        },
                        new KeyboardInput.KeyboardKey()
                        {
                            Identifier = KeyboardInput.KeyboardIdentifierList.Comma,
                            Value = BtnState.Released
                        },
                    }
                },
                Mouse = new MouseInput()
                {
                    LeftButton = BtnState.Released,
                    MiddleButton = BtnState.Released,
                    RightButton = BtnState.Released,
                    ScrollWheel = 0,
                    X = 0,
                    Y = 0
                }
            };

        }
        
        public class KeyboardInput
        {
            public List<KeyboardKey> KeyboardState { get; set; } = null!;
            
            public class KeyboardKey
            {
                public KeyboardIdentifier Identifier { get; set; } = null!;
                public BtnState Value { get; set; } = BtnState.Released;

                public bool IsPressed()
                {
                    return this.Value == BtnState.Pressed;
                }
                
                public bool IsEcho()
                {
                    return this.Value == BtnState.Echo;
                }
                
                public bool IsReleased()
                {
                    return this.Value == BtnState.Released;
                }

                public bool IsDown()
                {
                    return Value is BtnState.Pressed or BtnState.Echo;
                }
            }
    
            public class KeyboardIdentifier
            {
                public int Unicode { get; set; } = 0;
                public string Key { get; set; } = null!;
            }

            public static class KeyboardIdentifierList
            {
                public static readonly KeyboardIdentifier KeyR = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyR",
                    Unicode = 82,
                };
                public static readonly KeyboardIdentifier KeyX = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyX",
                    Unicode = 88,
                };
                public static readonly KeyboardIdentifier Escape = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "Escape",
                    Unicode = 27,
                };
                public static readonly KeyboardIdentifier KeyC = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyC",
                    Unicode = 67,
                };
                public static readonly KeyboardIdentifier KeyZ = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyZ",
                    Unicode = 90,
                };
                
                public static readonly KeyboardIdentifier Digit1 = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "Digit1",
                    Unicode = 49,
                };
                public static readonly KeyboardIdentifier Digit2 = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "Digit2",
                    Unicode = 50,
                };
                public static readonly KeyboardIdentifier Digit3 = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "Digit3",
                    Unicode = 51,
                };
                        
                public static readonly KeyboardIdentifier KeyA = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyA",
                    Unicode = 65,
                };
                public static readonly KeyboardIdentifier KeyW = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyW",
                    Unicode = 87,
                };
                public static readonly KeyboardIdentifier KeyD = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyD",
                    Unicode = 68,
                };
                public static readonly KeyboardIdentifier KeyS = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyS",
                    Unicode = 83,
                };
                
                public static readonly KeyboardIdentifier ArrowLeft = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "ArrowLeft",
                    Unicode = 37,
                };
                public static readonly KeyboardIdentifier ArrowUp = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "ArrowUp",
                    Unicode = 38,
                };
                public static readonly KeyboardIdentifier ArrowRight = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "ArrowRight",
                    Unicode = 39,
                };
                public static readonly KeyboardIdentifier ArrowDown = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "ArrowDown",
                    Unicode = 40,
                };

                public static readonly KeyboardIdentifier KeyJ = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyJ",
                    Unicode = 74,
                };
                public static readonly KeyboardIdentifier KeyI = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyI",
                    Unicode = 73,
                };
                public static readonly KeyboardIdentifier KeyL = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyL",
                    Unicode = 76,
                };
                public static readonly KeyboardIdentifier KeyK = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "KeyK",
                    Unicode = 75,
                };
                   
                public static readonly KeyboardIdentifier Slash = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = "Slash",
                    Unicode = 173,
                };
                public static readonly KeyboardIdentifier Period = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = ".",
                    Unicode = 190,
                };
                public static readonly KeyboardIdentifier Comma = new Input.KeyboardInput.KeyboardIdentifier()
                {
                    Key = ",",
                    Unicode = 188,
                };


                public static Input GetDefaultInput()
                {
                    return new Input()
                    {
                        Keyboard = new KeyboardInput()
                        {
                            KeyboardState = new List<KeyboardKey>()
                            {
                                new KeyboardKey() {Identifier = KeyR},
                                new KeyboardKey() {Identifier = KeyX},
                                new KeyboardKey() {Identifier = Escape},
                                new KeyboardKey() {Identifier = KeyC},
                                new KeyboardKey() {Identifier = KeyZ},

                                new KeyboardKey() {Identifier = Digit1},
                                new KeyboardKey() {Identifier = Digit2},
                                new KeyboardKey() {Identifier = Digit3},

                                new KeyboardKey() {Identifier = ArrowLeft},
                                new KeyboardKey() {Identifier = ArrowUp},
                                new KeyboardKey() {Identifier = ArrowRight},
                                new KeyboardKey() {Identifier = ArrowDown},

                                new KeyboardKey() {Identifier = KeyJ},
                                new KeyboardKey() {Identifier = KeyI},
                                new KeyboardKey() {Identifier = KeyL},
                                new KeyboardKey() {Identifier = KeyK},

                                new KeyboardKey() {Identifier = Slash},
                                new KeyboardKey() {Identifier = Period},
                                new KeyboardKey() {Identifier = Comma}
                            }
                        },
                        Mouse = new MouseInput()
                    };
                }
            }
            
            public void HandelKeyboardEcho()
            {
                var pressedKeys = KeyboardState.Where(x => x.IsPressed());
                foreach (var keyboardKey in pressedKeys)
                {
                    keyboardKey.Value = BtnState.Echo;
                }
            }
        }

        public class MouseInput
        {
            public int X { get; set; } = 0;
            public int Y { get; set; } = 0;
            public int ScrollWheel { get; set; } = 0;
            public BtnState LeftButton { get; set; } = BtnState.Released;
            public BtnState MiddleButton { get; set; } = BtnState.Released;
            public BtnState RightButton { get; set; } = BtnState.Released;

            public bool IsPressed(BtnState btnState)
            {
                return btnState == BtnState.Pressed;
            }
        }

        public enum BtnState
        {
            Pressed,
            Echo,
            Released
        }
    }
}