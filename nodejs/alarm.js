import path from 'path';
import player from 'play-sound';
import throttle from 'lodash.throttle';

const soundFileDuration = 1000;
const soundFilePath = path.resolve('./audio/alarm.mp3');
const playerPath = path.resolve('./cli/player/cmdmp3/cmdmp3.exe');

const playerInstance = player({ player: playerPath });

const play = throttle(() => playerInstance.play(soundFilePath, (err) => {
    if (err) {
        console.log(err);
    }
}), soundFileDuration);

class Alarm {
    constructor() {
        this._on = false;
        this._watch();
    }

    _watch() {
        setInterval(() => {
            if (this.isOn() === false) {
                return;
            }

            play();
        }, 10);
    }

    isOn() {
        return this._on === true;
    }

    set(value) {
        this._on = !!value;
    }
}

export const alarm = new Alarm();
