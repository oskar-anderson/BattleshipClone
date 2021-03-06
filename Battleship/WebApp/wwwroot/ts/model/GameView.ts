import CharInfo from "./CharInfo.js";
import GameData from "./GameData.js"

export default class GameView {
    GameData: GameData;
    Base64Picture: string;
    ShipPlacementStatus: string;
    
    constructor(_gameData: object | undefined,
                _base64Picture: string | undefined, 
                _shipPlacementStatus: string | undefined) {
        if ([_gameData, _base64Picture, _shipPlacementStatus].includes(undefined)) {
            throw Error("Object has undefined fields!");
        }
        // @ts-ignore
        this.GameData = _gameData!;
        this.Base64Picture = _base64Picture!;
        this.ShipPlacementStatus = _shipPlacementStatus!;
    }

    public static mapJsonToObject(json: string): GameView {
        console.log("mapJsonToObject");
        console.log(json);
        let obj = JSON.parse(json);
        return new GameView(obj.GameData, obj.Base64Picture, obj.ShipPlacementStatus);
    }
}