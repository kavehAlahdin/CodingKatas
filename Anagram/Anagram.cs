using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    private static bool isSubAnagram(string word,string sourceWord){
        Dictionary<char,int> sourceWordDictionary=createUniqueCharacterRepetitionDic(sourceWord);
        Dictionary<char,int> wordDictionary=createUniqueCharacterRepetitionDic(word);
        foreach(KeyValuePair<char,int> wordLetterCount in wordDictionary){
            if(!sourceWordDictionary.ContainsKey(wordLetterCount.Key)) return false;
            if(wordLetterCount.Value>sourceWordDictionary[wordLetterCount.Key]) return false;
        }
        return true;
    }
    public static Dictionary<char,int>  createUniqueCharacterRepetitionDic(string word){
        Dictionary<char, int>  LetterDictionary=new Dictionary<char, int> ();
        foreach(char letter in word.ToLower())
            {
            if(!LetterDictionary.ContainsKey(letter))
                LetterDictionary.Add(letter,1);
            else
                LetterDictionary[letter]++;
            }
        return LetterDictionary;
    }
    
    private string findAnagram(string sourceWord,List<string> wordList){
        return "hi";
    }
    private const string wordListFileName="wordlist.txt";
    public static void Main(){
    string sourceWord = "documenting";
    StreamReader wordList=File.OpenText(wordListFileName);
    int CandidateNumber=0;
    string CurrentWord=string.Empty;
    List<string> wordCandidateList=new List<string>();
    string word1=string.Empty;
    string word2=string.Empty;
    while((CurrentWord= wordList.ReadLine())!=null){
        if(!isSubAnagram(CurrentWord,sourceWord))continue;
        wordCandidateList.Add(CurrentWord);
        CandidateNumber++;
        Console.WriteLine("{0}-{1}",CandidateNumber,CurrentWord);
    }
        
        //Console.Write("("+LetterCountPair.Key+","+LetterCountPair.Value+")");

    wordList.Close();


    }
}