import { filter } from 'rxjs/operators';
import { readFileSync } from 'fs';

import { alarm } from './alarm.js';
import diff$ from './diff.observable.js';

const { saveOnTreshold } = JSON.parse(readFileSync('./cli/screenshot/windows-os/config.json').toString());

alarm.set(true);
setTimeout(() => alarm.set(false), 5000)

diff$
    .pipe(
        filter((diff) => diff > saveOnTreshold)
    )
    .subscribe((diff) => {

    });
