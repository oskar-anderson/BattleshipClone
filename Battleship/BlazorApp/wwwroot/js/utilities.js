window.setTitle = (title) => {
    document.title = title + " - BlazorGames";
}

window.SetFocusToElement = (element) => {
    element.focus();
};

window.PlayAudio = (elementName) => {
    document.getElementById(elementName).play();
}

window.PauseAudio = (elementName) => {
    document.getElementById(elementName).pause();
}

window.WriteCookie = (name, value, days) => {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    }
    else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

window.ReadCookie = (cname) => {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return 0;
}


window.JsFunctions = {
    addKeyboardEventListener: function () {
        let serializedEvent = (e) => {
            return {
                key: e.key,
                code: e.keyCode.toString(),
                location: e.location,
                repeat: e.repeat,
                ctrlKey: e.ctrlKey,
                shiftKey: e.shiftKey,
                altKey: e.altKey,
                metaKey: e.metaKey,
                type: e.type
            };
        }
        window.document.addEventListener('keydown', (e) => {
            DotNet.invokeMethodAsync('BlazorApp', 'JsKeyDown', serializedEvent(e))
        })
    },
}

console.log("utilities.js loaded");

app = null;

window.runpixi = async () => {
    app = new PIXI.Application();
    // The application will create a canvas element for you that you
    // can then insert into the DOM
    document.body.appendChild(app.view);

    // await app.loader.add('images/ps2p.fnt');
    
    return new Promise((resolve, reject) => {
        app.loader.add('font/ps2p.fnt').load();
        
        app.loader.onComplete.add(() => {
            resolve();
        })
        app.loader.onError.add(() => {
            reject();
        })
    });
}

function doNothing(drawArea) {

}

async function printDate(dotNetHelper) {
    let date = await dotNetHelper.invokeMethodAsync('GetDate');
    console.log(date);
}

async function pixiMain2(dotNetHelper) {
    let drawArea = await dotNetHelper.invokeMethodAsync('GetDrawArea');
    drawArea = JSON.parse(drawArea);
    pixiMain(drawArea);
}

async function pixiMain(drawArea) {
    // The application will create a renderer using WebGL, if possible,
    // with a fallback to a canvas render.
    // let drawArea = JSON.parse(drawAreaSer);
    app.stage.removeChildren();  // removes previous stage effectively clearing the screen
    for (let y = 0; y < drawArea.length; y++) {
        let row = drawArea[y];
        for (let x = 0; x < row.length; x++) {
            let tile = row[x];
            let bitmapText = new PIXI.BitmapText(tile, {
                fontName: "Press Start 2P",
                fontSize: 24,
                align: "right"
            });
            bitmapText.tint = '0x008000';
            bitmapText.x = x * 24;
            bitmapText.y = y * 24;
            app.stage.addChild(bitmapText);
        }
    }

    /* 
    // load the texture we need
    app.loader.add('bunny', 'images/bunny.png').load((loader, resources) => {
        // This creates a texture from a 'bunny.png' image
        const bunny = new PIXI.Sprite(resources.bunny.texture);

        // Setup the position of the bunny
        bunny.x = app.renderer.width / 2;
        bunny.y = app.renderer.height / 2;
        bunny.scale.x = 0.3;
        bunny.scale.y = 0.3;
        // Rotate around the center
        bunny.anchor.x = 0.5;
        bunny.anchor.y = 0.5;

        // Add the bunny to the scene we are building

        // -----

        // -------


        app.stage.addChild(bunny);

        // Listen for frame updates
        app.ticker.add(() => {
            // each frame we spin the bunny around a bit
            bunny.rotation += 0.01;
        });
        

    });
    
    
     */

}