using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections;

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
            string[] input4  = readOriginalText(@"C:\workspace\adventOfCode\AdventCode\inputDayFour.txt");
            DayFour dayFour = new DayFour();
            int result7 = dayFour.validPassports(input4);
            int result8 = dayFour.validPassportsTwo(input4);
            Console.WriteLine(result7);
            Console.WriteLine(result8);
            string[] input5 = readOriginalText(@"C:\workspace\adventOfCode\AdventCode\inputDayFive.txt");
            DayFive dayFive = new DayFive();
            int result9 = dayFive.highestSeatId(input5);
            int result10 = dayFive.mySeatId(input5);
            Console.WriteLine(result9);
            Console.WriteLine(result10);

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


    public class DayFour{

        public int validPassports(string[] input){

            var result = 0;
            string parameters = "";
            foreach(string line in input){
                if(Regex.Matches(line, ":").Count > 0){
                    parameters = parameters + " " + line;   
                } else{
                    int occurrences = Regex.Matches(parameters, ":").Count;
                    if(occurrences == 8 || (occurrences == 7 && Regex.Matches(parameters, "cid").Count == 0)){
                        result = result +1;  
                    }
                    parameters = "";
                }
                
            }


            return result;
        }

        public int validPassportsTwo(string[] input){
            
            var result = 0;
            int keyLength = 4;
            string parameters = "";
            foreach(string line in input){
                if(Regex.Matches(line, ":").Count > 0){
                    parameters = parameters + " " + line;   
                } else{
                    int occurrences = Regex.Matches(parameters, ":").Count;
                    if(occurrences == 8 || (occurrences == 7 && Regex.Matches(parameters, "cid").Count == 0)){
                        int byrPosition = parameters.IndexOf("byr");
                        int byrSpace = parameters.IndexOf(" ", byrPosition);
                        if(byrSpace == -1){
                            byrSpace = parameters.Length;
                        }
                        int byrValue = int.Parse(parameters.Substring(byrPosition+keyLength, byrSpace-byrPosition-keyLength));
                        int iyrPosition = parameters.IndexOf("iyr");
                        int iyrSpace = parameters.IndexOf(" ", iyrPosition);
                        if(iyrSpace == -1){
                            iyrSpace = parameters.Length;
                        }
                        int iyrValue = int.Parse(parameters.Substring(iyrPosition+keyLength, iyrSpace-iyrPosition-keyLength));          
                        int eyrPosition = parameters.IndexOf("eyr");
                        int eyrSpace = parameters.IndexOf(" ", eyrPosition);
                        if(eyrSpace == -1){
                            eyrSpace = parameters.Length;
                        }
                        int eyrValue = int.Parse(parameters.Substring(eyrPosition+keyLength, eyrSpace-eyrPosition-keyLength));
                        int hgtPosition = parameters.IndexOf("hgt");
                        int hgtSpace = parameters.IndexOf(" ", hgtPosition);
                        if(hgtSpace == -1){
                            hgtSpace = parameters.Length;
                        }
                        string hgtValue = parameters.Substring(hgtPosition +keyLength, hgtSpace-hgtPosition-keyLength);
                        int hclPosition = parameters.IndexOf("hcl");
                        int hclSpace = parameters.IndexOf(" ", hclPosition);
                        if(hclSpace == -1){
                            hclSpace = parameters.Length;
                        }
                        string hclValue = parameters.Substring(hclPosition+keyLength, hclSpace-hclPosition-keyLength);
                        int eclPosition = parameters.IndexOf("ecl");
                        int eclSpace = parameters.IndexOf(" ", eclPosition);
                        if(eclSpace == -1){
                            eclSpace = parameters.Length;
                        }
                        string eclValue = parameters.Substring(eclPosition+keyLength, eclSpace-eclPosition-keyLength);
                        int pidPosition = parameters.IndexOf("pid");
                        int pidSpace = parameters.IndexOf(" ", pidPosition);
                        if(pidSpace == -1){
                            pidSpace = parameters.Length;
                        }
                        string pidValue = parameters.Substring(pidPosition+keyLength, pidSpace-pidPosition-keyLength);


                        if((byrValue >= 1920 && byrValue <= 2002 ) && (iyrValue >=2010 && iyrValue <= 2020) &&(eyrValue >= 2020 && eyrValue <= 2030) && (pidValue.Length == 9)){
                            if(hclValue.Length == 7 && Regex.IsMatch(hclValue, @"#[a-f |\d]{6}")){
                                if(eclValue == "amb" || eclValue == "blu" || eclValue == "brn" || eclValue == "gry" || eclValue== "grn" || eclValue == "hzl" || eclValue == "oth"){
                                    if(Regex.Matches(hgtValue, "in").Count == 1){
                                        int value = int.Parse(Regex.Replace(hgtValue,"in",""));
                                        if(value >= 59 && value <=76){
                                            result = result +1; 
                                        }
                                    }
                                    if( Regex.Matches(parameters, "cm").Count == 1){
                                        int value = int.Parse(Regex.Replace(hgtValue,"cm",""));
                                        if(value >= 150 && value <=193){
                                            result = result +1; 
                                        }
                                    }
                                }
                            }
                        } 
                    }
                    parameters = "";
                }
                
            }

            return result;

        }




    }


    public class DayFive{

        public int highestSeatId(string[] input){

         var max = 0;
            for(int i = 0; i < input.Length; i++){
                int row = Convert.ToInt32(input[i].Replace("B","1").Replace("F","0").Substring(0,7), 2);
                int collumn = Convert.ToInt32(input[i].Replace("L","0").Replace("R","1").Substring(7,3),2);
                int localMax = row*8+collumn;
                if(localMax > max){
                    max = localMax;
                }
            }
        return max;
        }

        public int mySeatId(string[] input){
            var mySeat = 0;
            ArrayList seatIds = new ArrayList();
            for(int i = 0; i < input.Length; i++){
                int row = Convert.ToInt32(input[i].Replace("B","1").Replace("F","0").Substring(0,7), 2);
                int collumn = Convert.ToInt32(input[i].Replace("L","0").Replace("R","1").Substring(7,3),2);
                int seatId = row*8+collumn;
                seatIds.Add(seatId);
            }

            seatIds.Sort();
            int[] seatArray = seatIds.OfType<int>().ToArray();

            for(int j = 0; j < seatArray.Length-1; j++){
                int localNumber = seatArray[j];
                if(j == seatArray.Length-2){
                    if(seatArray[j+1] != localNumber+1){
                        mySeat = localNumber+1;
                    }
                }
                if(seatArray[j+1] != localNumber+1 && seatArray[j+2] != localNumber+2){
                    mySeat = localNumber+1;
                }
            }
            return mySeat;
        }


         

        }



    }

