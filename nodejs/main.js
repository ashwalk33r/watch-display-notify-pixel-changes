import { filter } from 'rxjs/operators';
import { readFileSync } from 'fs';

import diff$ from './diff.observable.js';

const { saveOnTreshold } = JSON.parse(readFileSync('./cli/screenshot/windows-os/config.json').toString());

diff$
    .pipe(
        filter((diff) => diff > saveOnTreshold)
    )
    .subscribe((diff) => {
        console.log(diff);
    });
