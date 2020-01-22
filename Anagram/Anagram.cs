using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    string sourceWord;
    StreamReader wordList; 
    Dictionary<string, KeyValuePair<char,int> > wordDictionary;
    public Anagram(String sourceWord, string dictionaryFileName){
        if (File.Exists(dictionaryFileName))
            StreamReader wordList=File.OpenText(wordListFileName);

    }
    private static bool isSubAnagram(Dictionary<char,int> sourceWordDictionary,
                                    Dictionary<char,int> wordDictionary){
        foreach(KeyValuePair<char,int> wordLetterCount in wordDictionary){
            if(!sourceWordDictionary.ContainsKey(wordLetterCount.Key)) 
                return false;
            if(wordLetterCount.Value>sourceWordDictionary[wordLetterCount.Key]) 
                return false;
        }
        return true;
    }
    private Dictionary<char,int> createDifferenceDictionary(Dictionary<char,int> wordDic,Dictionary<char,int> sourceWordDic){
        Dictionary<char,int> differenceDic=new Dictionary<char, int>();
        foreach(KeyValuePair<char,int> letterPair in wordDic)
            sourceWordDic[letterPair.Key]-=letterPair.Value;
        return differenceDic;
    }
    public static Dictionary<char,int>  createUniqueCharacterRepetitionDic(string word){
        Dictionary<char, int>  LetterDictionary=new Dictionary<char, int> ();
        foreach(char letter in word.ToLower())
            if(!LetterDictionary.ContainsKey(letter))
                LetterDictionary.Add(letter,1);
            else
                LetterDictionary[letter]++;
        return LetterDictionary;
    }
    private Dictionary<string , string> resultTwoWordAnagram;
 
    static  int counter=0;
    private string findAnagram(Dictionary<char,int> sourceWordDic,List<string> wordList){
        string  firstWord=string.Empty;
        string secondWord=string.Empty;
        foreach(string currentWord in wordList){
            Dictionary<char,int> currentWordDic=createUniqueCharacterRepetitionDic(currentWord);
            if(isSubAnagram(currentWordDic,sourceWordDic))
                firstWord=currentWord;
        }
        //Dictionary<char,int> differenceDic=createDifferenceDictionary(currentWord,sourceWordDic);
        //secondWord=findAnagram(differenceDic,wordList);
        //if(secondWord==null ||secondWord.Length==0) continue;                    
        return firstWord+","+secondWord;
    }
    private const string wordListFileName="wordlist.txt";

 
}