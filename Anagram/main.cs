using System;
using System.IO;
using System.Collections.Generic;
public class Program{
    public static void Main(string[] args){
    if ((args==null) &&(args.Length!=2)&&File.Exists(args[1])){
        Console.WriteLine("There was an error!");
        return;
    }
    string sourceWord = args[0];
    string wordListFileName=args[1];
    StreamReader wordList=File.OpenText(wordListFileName);
    int CandidateNumber=0;
    string CurrentWord=string.Empty;
    List<string> wordCandidateList=new List<string>();
    string word1=string.Empty;
    string word2=string.Empty;
    Anagram anagram= new Anagram(sourceWord,wordListFileName);
    List <String >a= anagram.findAnagram();
    foreach(var pair in a){
        Console.WriteLine(pair+"---");
        
    }
    while((CurrentWord= wordList.ReadLine())!=null){
        CandidateNumber++;
        //äConsole.WriteLine("{0}-{1}",CandidateNumber,CurrentWord);
    }
    wordList.Close();


    }
}