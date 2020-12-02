using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventCode
{
    public class Advent{

        static void Main(string[] args)
        {
            DayOne dayOne = new DayOne();
            int[] input1 = readFile(@"C:\workspace\adventOfCode\AdventCode\inputDayOne.txt");
            int result1 = dayOne.dayOneSolutionPartOne(input1);
            int result2 = dayOne.dayOneSolutionPartTwo(input1);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            string[] input2 = readOriginalText(@"C:\workspace\adventOfCode\AdventCode\inputDayTwo.txt");
            DayTwo dayTwo = new DayTwo();
            int result3 = dayTwo.getValidPasswords(input2);
            int result4 = dayTwo.getValidPasswordsTwo(input2);
            Console.WriteLine(result3);
            Console.WriteLine(result4);
        }

        static int[] readFile(string path){
            string[] lines = System.IO.File.ReadAllLines(path);
            int[] input = Array.ConvertAll(lines, s => int.Parse(s));
            return input;
        }

        static string[] readOriginalText(string path){
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }


    }

    public class DayOne
    {


        public int dayOneSolutionPartOne(int[] input){

            int num1, num2;
            var result = 0;
            for(var i = 0; i < input.Length-1; i++){
                num1 = input[i];
                for(var j = i+1; j < input.Length; j++ ){
                    num2 = input[j];
                    int check = num1+num2;
                    if(check == 2020){
                        result = num1*num2;
                        break;
                    }
                }
            }

            return result;
        }

        public int dayOneSolutionPartTwo(int[] input){

            int num1, num2, num3;
            var result = 0;
            for(var i = 0; i < input.Length-2; i++){
                num1 = input[i];
                for(var j = i+1; j < input.Length-1; j++ ){
                    num2 = input[j];
                    int check = num1+num2;
                    if(check < 2020){
                       for(var k = j+1; k < input.Length; k++ ){
                           num3 = input[k];
                           int check2 = num1+num2+num3;
                           if(check2 == 2020){
                               result = num1*num2*num3;
                           }
                       }
                    }
                }
            }

            return result;

        }
    
    }

    public class DayTwo
    {

        public int getValidPasswords(string[] lines){
            int validPasswords = 0;
            char[] delimiterChars = {' ', '-', ':'};
            foreach(string line in lines){
                string[] values = line.Split(delimiterChars);
                int minimum = int.Parse(values[0]);
                int maximum = int.Parse(values[1]);
                string letter = values[2];
                string word = values[4];
                int occurrences = Regex.Matches(word, letter).Count;
                if(occurrences >= minimum && occurrences <= maximum){
                    validPasswords++;
                }
            }
            return validPasswords;
        }


        public int getValidPasswordsTwo(string[] lines){
            int validPasswords = 0;
            char[] delimiterChars = {' ', '-', ':'};
            foreach(string line in lines){
                string[] values = line.Split(delimiterChars);
                int index1 = int.Parse(values[0]);
                int index2 = int.Parse(values[1]);
                char letter = char.Parse(values[2]);
                string word = values[4];
                if(word[index1-1] == letter && word[index2-1] != letter ){
                    validPasswords++;
                } else if(word[index1-1] != letter && word[index2-1] == letter){
                    validPasswords++;
                }
            }
            return validPasswords;
        }



    }
}