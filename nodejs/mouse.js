import gkm from 'gkm';

export const onMousePress = (callback) => gkm.events.on('mouse.pressed', callback);
