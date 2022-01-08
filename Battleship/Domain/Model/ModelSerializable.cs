﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Tile;
using RogueSharp;
using Point = RogueSharp.Point;

namespace Domain.Model
{
    public sealed class GameDataSerializable : AbstractGameData<PlayerSerializable>
    {
        public override PlayerSerializable ActivePlayer { get; set; } = null!;
        public override PlayerSerializable InactivePlayer { get; set; } = null!;
        public override List<Sprite> Sprites { get; set; } = null!;
        public string[][] BoardSerializationFriendly { get; set; } = null!;
        public override int AllowedPlacementType { get; set; }
        public override List<Point> ShipSizes { get; set; } = null!;
        public override GameState State { get; set; }
        public override int FrameCount { get; set; }
        public override List<double> DeltaTimes { get; set; } = null!;
        public override double ElapsedTime { get; set; }
        public override Input Input { get; set; } = null!;

        public GameDataSerializable()
        {
            // Serialization uses this
        }

        public GameDataSerializable(GameData gameData)
        {
            ActivePlayer = new PlayerSerializable(gameData.ActivePlayer);
            InactivePlayer = new PlayerSerializable(gameData.InactivePlayer);
            Sprites = gameData.Sprites;
            BoardSerializationFriendly = gameData.Board2D.ToJaggedArray();
            AllowedPlacementType = gameData.AllowedPlacementType;
            ShipSizes = gameData.ShipSizes;
            State = gameData.State;
            FrameCount = gameData.FrameCount;
            DeltaTimes = gameData.DeltaTimes;
            ElapsedTime = gameData.ElapsedTime;
            Input = gameData.Input;
        }

        public static GameData ToGameModelSerializable(GameDataSerializable gameData)
        {
            var game = new GameData()
            {
                ActivePlayer = PlayerSerializable.ToGameModelSerializable(gameData.ActivePlayer),
                InactivePlayer = PlayerSerializable.ToGameModelSerializable(gameData.InactivePlayer),
                Sprites = gameData.Sprites,
                Board2D = gameData.BoardSerializationFriendly.To2DArray(
                    gameData.BoardSerializationFriendly.Length, 
                    gameData.BoardSerializationFriendly[0].Length),
                AllowedPlacementType = gameData.AllowedPlacementType,
                ShipSizes = gameData.ShipSizes,
                State = gameData.State,
                FrameCount = gameData.FrameCount,
                DeltaTimes = gameData.DeltaTimes,
                ElapsedTime = gameData.ElapsedTime,
                Input = gameData.Input
            };
            return game;
        }
    }

    public sealed class PlayerSerializable : AbstractPlayer
    {
        public override List<Rectangle> Ships { get; set; } = null!;
        public override List<ShootingHistoryItem> ShootingHistory { get; set; } = new List<ShootingHistoryItem>();
        public override Sprite.PlayerSprite Sprite { get; set; } = null!;
        public override Rectangle BoardBounds { get; set; }
        public override int ShipBeingPlacedIdx { get; set; } = 0;
        public override bool IsHorizontalPlacement { get; set; } = true;
        public override string Name { get; set; } = null!;
        public override int PlayerType { get; set; }
        public override float fCameraPixelPosY { get; set; } = 0.0f;
        public override float fCameraPixelPosX { get; set; } = 0.0f;
        public override float fCameraScaleX { get; set; } = 1.0f;
        public override float fCameraScaleY { get; set; } = 1.0f;
        public override float fMouseSelectedTileX { get; set; } = 0.0f;
        public override float fMouseSelectedTileY { get; set; } = 0.0f;
        
        
        public PlayerSerializable()
        {
            // Serialization uses this
        }

        public PlayerSerializable(Player player)
        {
            Ships = player.Ships;
            ShootingHistory = player.ShootingHistory;
            Sprite = player.Sprite;
            BoardBounds = player.BoardBounds;
            ShipBeingPlacedIdx = player.ShipBeingPlacedIdx;
            IsHorizontalPlacement = player.IsHorizontalPlacement;
            Name = player.Name;
            PlayerType = player.PlayerType;
            fCameraPixelPosY = player.fCameraPixelPosY;
            fCameraPixelPosX = player.fCameraPixelPosX;
            fCameraScaleX = player.fCameraScaleX;
            fCameraScaleY = player.fCameraScaleY;
            fMouseSelectedTileX = player.fMouseSelectedTileX;
            fMouseSelectedTileY = player.fMouseSelectedTileY;
        }
        
        public static Player ToGameModelSerializable(PlayerSerializable player)
        {
            var result = new Player()
            {
                Ships = player.Ships,
                ShootingHistory = player.ShootingHistory,
                Sprite = player.Sprite,
                BoardBounds = player.BoardBounds,
                ShipBeingPlacedIdx = player.ShipBeingPlacedIdx,
                IsHorizontalPlacement = player.IsHorizontalPlacement,
                Name = player.Name,
                PlayerType = player.PlayerType,
                fCameraPixelPosY = player.fCameraPixelPosY,
                fCameraPixelPosX = player.fCameraPixelPosX,
                fCameraScaleX = player.fCameraScaleX,
                fCameraScaleY = player.fCameraScaleY,
                fMouseSelectedTileX = player.fMouseSelectedTileX,
                fMouseSelectedTileY = player.fMouseSelectedTileY,
            };
            return result;
        }
    }
}