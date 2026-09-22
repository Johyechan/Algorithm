function solution(m, n, h, w, drops) {
    var answer = [0, 0];

    const rain = Array.from({ length: m }, () => Array(n).fill(Infinity));

    for(let i = 0; i < drops.length; i++)
    {
        rain[drops[i][0]][drops[i][1]] = i;
    }

    const row = Array.from({length: m}, () => Array(n - w + 1).fill(Infinity))

    let front = 0;

    for(let i = 0; i < m; i++)
    {
        let deque = [];
        front = 0;
        for(let j = 0; j < n; j++)
        {
            while(deque.length > front && deque.at(front) <=  j - w)
            {
                front++;
            }
            while(deque.length > front && rain[i][deque.at(-1)] >= rain[i][j])
            {
                deque.pop();
            }

            deque.push(j);
            if(j >= w - 1)
            {
                row[i][j - w + 1] = rain[i][deque[front]];  
            }
        }
    }

    const col = Array.from({length: m - h + 1}, () => Array(n - w + 1).fill(Infinity))
    front = 0;
    for(let i = 0; i < n - w + 1; i++)
    {
        let deque = [];
        front = 0;
        for(let j = 0; j < m; j++)
        {
            while(deque.length > front && deque[front] <= j - h)
            {
                front++;
            }
            while(deque.length > front && row[deque.at(-1)][i] >= row[j][i])
            {
                deque.pop();
            }
            deque.push(j);
            if(j >= h - 1)
            {
                col[j - h + 1][i] = row[deque[front]][i];
            }
        }
    }

    let big = -1;
    for(let i = 0; i < m - h + 1; i++)
    {
        for(let j = 0; j < n - w + 1; j++)
        {
            if(col[i][j] == Infinity)
            {
                answer[0] = i;
                answer[1] = j;
                return answer;
            }
            else if(col[i][j] > big)
            {
                answer[0] = i;
                answer[1] = j;
                big = col[i][j];
            }
        }
    }
    return answer;
}