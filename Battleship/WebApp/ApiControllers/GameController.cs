﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Api;
using Game;
using Domain.Model;
using System.Text.Json;
using Domain.Tile;
using Domain;
using WebApp.ApiControllers.Models;

namespace WebApp.ApiControllers
{
	// API return values are serialized manually, because automatic return value
	// serialization turns Json keys to lowercase to match js conventions.
	// Maintaining the same naming convention in front- and backend is clearer.
	[Route("api/[controller]")]
	[ApiController]
	public class GameController : ControllerBase
	{
		[HttpPost("CheckValidGameSettings")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult<string> CheckValidGameSettings(ValidGameSettingsInRuleSet settings)
		{
			System.Diagnostics.Debug.WriteLine("In CheckValidGameSettings");
			string errorMsgText = "";
			bool areSettingsValid = Game.Utils.TryBtnStart(settings.Ships, settings.BoardWidth, settings.BoardHeight, settings.AllowedPlacementType, ref errorMsgText, out _);
			var result = new ValidGameSettingsOut()
			{
				AreSettingsValid = areSettingsValid,
				ErrorMessage = errorMsgText
			};
			return TurnApiReturnValueToJson(result);
		}


		[HttpPost("StartGame")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult<string> StartGame(ValidGameSettingsInRuleSet settings)
		{
			Console.WriteLine(settings);
			BaseBattleship game = new WebBattle(
				settings.BoardHeight,
				settings.BoardWidth,
				settings.Ships,
				settings.AllowedPlacementType,
				-1,
				-1
			);
			GameViewDTO gameViewDto = GetGameViewDto(game);
			return TurnApiReturnValueToJson(gameViewDto);
		}
		

		[HttpPost("DoGame")]
		[Consumes("application/json")]
		[Produces("application/json")]
		// Unfortunately API input has to be string otherwise automatic deserialization to the class fails
		// if the class has a property with a JSONIgnore tag
		public ActionResult<string> DoGame(GameDataSerializable gameDataSerializable)
		{
			// GameDataSerializable gameDataSerializable = JsonSerializer.Deserialize<GameDataSerializable>(gameDataSerializableString)!;
			GameData gameData = GameDataSerializable.ToGameModelSerializable(gameDataSerializable);
			BaseBattleship game = new WebBattle(gameData);
            
			game.Initialize();
			game.Update(1d, game.GameData);
			game.GameData.FrameCount++;

			GameViewDTO gameViewDto = GetGameViewDto(game);
			return TurnApiReturnValueToJson(gameViewDto);
		}
		
		[HttpPost("GetDrawArea")]
		[Consumes("application/json")]
		[Produces("application/json")]
		public ActionResult<string> GetDrawArea(GameDataSerializable gameDataSerializable)
		{
			GameData gameData = GameDataSerializable.ToGameModelSerializable(gameDataSerializable);
			BaseBattleship game = new WebBattle(gameData);
            
			game.Initialize();

			TileData.CharInfo[][] drawArea = GetDrawArea(game.GameData);
			return TurnApiReturnValueToJson(drawArea);
		}

		private ActionResult<string> TurnApiReturnValueToJson(object o)
		{
			string json = JsonSerializer.Serialize(o, new JsonSerializerOptions() { WriteIndented = true });
			return Ok(json);
		}

		private GameViewDTO GetGameViewDto(BaseBattleship game)
		{
			GameDataSerializable gameDataSerializable = new GameDataSerializable(game.GameData);
			
			TileData.CharInfo[][] board = GetDrawArea(game.GameData);
			UpdateLogic.ShipPlacementStatus shipPlacementStatus = UpdateLogic.GetShipPlacementStatus(game.GameData);
			
			GameViewDTO result = new GameViewDTO(gameDataSerializable, board, "todo");
			return result;
		}
		
		private TileData.CharInfo[][] GetDrawArea(GameData gameData)
		{
			TileData.CharInfo[,] map = new TileData.CharInfo[40, 40];
			BaseDraw.GetDrawArea(gameData, ref map);
			return map.ToJaggedArray();
		}
	}
}