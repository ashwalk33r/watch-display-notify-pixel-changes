import { map, filter, takeWhile, takeLast, skipUntil } from 'rxjs/operators';
import { spawn, trim } from 'rxjs-shell';

const source$ = spawn('powershell.exe', [`cd ./cli/screenshot/windows-os/bin/ ; ./run.ps1`])
    .pipe(
        //
        trim(),
        map((payload) => payload.chunk.toString())
    );

const ready$ = source$
    .pipe(
        map((data) => {
            console.log(data);
            return data;
        }),
        takeWhile((data) => data.indexOf('SCREENSHOT COMPARISON STARTED...') === -1),
        takeLast(1)
    );

const diff$ = source$.pipe(
    skipUntil(ready$),
    map((data) => parseInt(data, 10)),
    filter((data) => false === isNaN(data))
);

export default diff$;