using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

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
            string[] input3 = readOriginalText(@"C:\workspace\adventOfCode\AdventCode\inputDayThree.txt");
            DayThree dayThree = new DayThree();
            int result5 = dayThree.trajectory(input3,3,1);
            int[,] slopes = new int[,] {{1,1},{3,1},{5,1},{7,1},{1,2}};
            int result6 = dayThree.trajectoryTwo(input3,slopes);
            Console.WriteLine(result5);
            Console.WriteLine(result6);
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

    public class DayThree{

        public int trajectory(string[] input, int x, int y){
            var result = 0;
            var xIndex = x;
            var down = y;
            char letter;
            for(int i=down; i < input.Length; i = i + down){
                if(input[i].Length <= xIndex){
                    int multiplier = xIndex/input[i].Length;
                    string pattern = String.Concat(Enumerable.Repeat(input[i],multiplier+1));
                    letter = pattern[xIndex];
                   
                }else{
                    letter = input[i][xIndex];
                }
                if(letter == '#'){
                    result++;
                }
                xIndex = xIndex+x;  
            }
            return result;
        }


        public int trajectoryTwo(string[] input, int[,] slope){
            var result = 1;
            for(int i = 0; i < slope.GetLength(0); i++){
                int trees = trajectory(input, slope[i,0], slope[i,1]);
                result = result * trees;
            }
            return result;
        }



    }


}