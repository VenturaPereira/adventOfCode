using System;
using System.Collections.Generic;

namespace AdventCode
{
    public class DayOne
    {

        static void Main(string[] args)
        {
            int[] input = readFile(@"C:\workspace\adventOfCode\AdventCode\inputDayOne.txt");
            int result1 =  dayOneSolutionPartOne(input);
            int result2 = dayOneSolutionPartTwo(input);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
        }

        static int[] readFile(string path){
            string[] lines = System.IO.File.ReadAllLines(path);
            int[] input = Array.ConvertAll(lines, s => int.Parse(s));
            return input;
        }
        static int dayOneSolutionPartOne(int[] input){

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

        static int dayOneSolutionPartTwo(int[] input){

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
}