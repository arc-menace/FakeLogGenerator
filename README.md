# FakeLogGenerator

## About

This is a project I made for fun that prints silly, non sensical log messages that almost seem "techy". In its current state the program runs forever, printing out little log messages from random combinations of the available -ing words and phrases in their respective json files. You can comment and uncomment the code to add words as you see fit. Simply type the word "save" to exit the word entering loop and save your words to the file (the shortcut for this in Visual Studio is Ctrl + K + C to comment a highlighted section and Ctrl + K + U to uncomment a section).

Please feel free to add to the word lists to make more, fun combinations. Just make your changes and submit a PR. I would like to make this into a JavaScript library, and maybe even a microservice/api as well, using those files (or others if I think of a better way).

I am aware that using Thread.Sleep(Milliseconds) is not something that would probably be useful for a real application, I just thought the code would showcase how I envisioned these lists could be used.

Credits: 
Code: Me, Joe Hahn
Inspiration: Zack Freedman in [this](https://www.youtube.com/watch?v=sxfJOMjZeIs&t=987s) video
