const input = require('fs').readFileSync(0, 'utf8').trim();

for(let i = 0; i < input.length; i++)
{
    console.log(`${input[i]}`);
}