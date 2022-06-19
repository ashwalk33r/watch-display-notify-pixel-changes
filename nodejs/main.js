import { filter } from 'rxjs/operators';

import { alarm } from './alarm.js';
import { config } from './config.js';
import diff$ from './diff.observable.js';

const { saveOnThreshold } = config;

diff$
    .pipe(
        filter((diff) => diff > saveOnThreshold)
    )
    .subscribe(() => {
        alarm.set(true);
    });
