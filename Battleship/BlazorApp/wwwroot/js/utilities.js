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

window.getGameView = (DrawArea, height, width) => {

    let ColorIntToCssString = {
        0: "rgb(12,     12,     12 )",             // Black
        1: "rgb(0,      55,     218) ",            // DarkBlue
        2: "rgb(19,     161,    14  )",            // DarkGreen
        3: "rgb(58,     150,    221) ",            // DarkCyan
        4: "rgb(197,    15,     31  )",            // DarkRed
        5: "rgb(136,    23,     152) ",            // DarkMagenta
        6: "rgb(193,    156,    0  )",             // DarkYellow
        7: "rgb(204,    204,    204) ",            // Gray
        8: "rgb(118,    118,    118) ",            // DarkGrey
        9: "rgb(59,     120,    255) ",            // Blue
        10: "rgb(22,    192,    12  )",            // Green
        11: "rgb(97,    214,    214) ",            // Cyan
        12: "rgb(231,   72,     86  )",            // Red
        13: "rgb(180,   0,      158) ",            // Magenta
        14: "rgb(249,   241,    165) ",            // Yellow
        15: "rgb(242,   242,    242) "             // White
    };

    let result = [];
    for (let y = 0; y < height; y++)
    {
        result.push('<p style="display: flex; margin-top: 0; margin-bottom: 0;">');
        for (let x = 0; x < width; x++)
        {
            let charInfo = DrawArea[y][x];
            let colCss = ColorIntToCssString[charInfo.color.intVal];
            let character = charInfo.glyph;
            character = character === ' ' ? '.' : character;
            result.push(`<em style="color: ${colCss};">${character}</em>`);
        }
        result.push('</p>');
    }
    document.getElementById("board").innerHTML = result.join('');
}