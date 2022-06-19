import { readFileSync } from 'fs';

export const config = JSON.parse(readFileSync('./cli/screenshot/windows-os/config.json').toString());

