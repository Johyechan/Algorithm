const input = require('fs')  // File System(파일 시스템) 모듈, 파일 읽기/쓰기를 담당
    .readFileSync(0, 'utf8') // 파일을 동기 방식으로 읽는 함수, 매개변수(파일경로, 인코딩)
                             // 여기서 0은 표준 입력으로 "터미널에서 입력 들어온 내용을 전부 읽어라" 라는 의미
                             // Console.ReadLine();과 cin >> input; 이랑 같은 목적
                             // 'utf8'는 은 읽어온 데이터를 문자열로 해석하라는 뜻.
                             // 이게 없으면 <Buffer 48 65 6c 6c 6f> 와 같은 바이너리 데이터 형태로 나옴.
    .trim();                 // 문자열 양 끝 공백 제거.

console.log(input);          // 출력