# ![Quiz Maker picture](quiz.jpg) Quiz Maker

## Introduction

The Quiz Maker is a console game. By running the game you will get a random question from QuizList.txt and 2 to 4 answers.
After selecting the answer your answers will be counted as correct or wrong answer.
The  game will end after answering on all existing questions or by selecting the option for not continue the game.

The list of questions provided with this game stored in QuizList.txt.
Using QuizMaker.dll.config can be defined the path for QuizList.txt or  define your own.
Using your own question create a text file by using this format:

\<Your question string>?\<Answers>

You should provide minimum 2 and maximum 4 answers. Correct answer should have a "*" mark

|\<Answer1>|\<Answer2>|\<Answer3>*|\<Answer4>

Your questions will be serialized in QuizList.xml the path is provided in QuizMaker.dll.config and can be changed.

### Thank you and have a fun
