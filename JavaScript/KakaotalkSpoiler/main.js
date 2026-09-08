const fs = require('fs');

let word = "";
let wordStartIndex = 0;
let wordEndIndex = 0;

const spoilerWord = new Set();
const normalWord = new Set();

function checkWord(spoiler_ranges)
{
    for(let j = 0; j < spoiler_ranges.length; j++)
    {
        if(wordEndIndex >= spoiler_ranges[j][0]
            && wordStartIndex <= spoiler_ranges[j][1])
        {
            spoilerWord.add(word);
            return;
        }
    }

    normalWord.add(word);
}

function solution(message, spoiler_ranges)
{
    var answer = 0;

    for(let i = 0; i < message.length; i++)
    {
        if(message[i] === ' ')
        {
            wordEndIndex = i - 1;
            
            checkWord(spoiler_ranges);

            word = "";
            wordStartIndex = i + 1;
            continue;
        }

        word += message[i];
    }

    wordEndIndex = message.length - 1;
    checkWord(spoiler_ranges);

    for (const word of normalWord)
    {
        spoilerWord.delete(word);
    }
    
    answer = spoilerWord.size;
                
    return answer;
}

const input = fs.readFileSync(0, 'utf8')
    .trim()
    .split('\n');

const message = input[0].trim();
const row = Number(input[1]);

const arr = [];

for (let i = 0; i < row; i++)
{
    const numbers = input[i + 2]
        .trim()
        .split(/\s+/)
        .map(Number);

    arr.push(numbers);
}

const result = solution(message, arr);

console.log(result);