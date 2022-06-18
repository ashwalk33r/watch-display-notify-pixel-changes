import diff$ from './diff.observable.js';

diff$.subscribe((diff) => {
    console.log(diff);
});
