using System;
using System.IO;
using System.Collections.Generic;
public class Anagram{
    string sourceWord;
    private Dictionary<char,int> sourceWordAnalysis;
    Dictionary<string, Dictionary<char,int> > wordListDictionary;
    
    public Anagram(String sourceWord, string dictionaryFileName){
        //builds a dictionary of the words as key, and for each one list of its characters and the number of their repition as value.
        using(StreamReader wordListStream=File.OpenText(wordListFileName)){
            while (wordListStream.Peek() >=0){
                String currentWord=wordListStream.ReadLine();
                Dictionary<char,int> wordAnalysis =createUniqueCharacterRepetitionDic(currentWord);
                wordListDictionary.Add(currentWord,wordAnalysis);
            }
        }
        this.sourceWord=sourceWord;
        this.sourceWordAnalysis=createUniqueCharacterRepetitionDic(this.sourceWord);
    }
    //This methods is where the multiple Anagram are created.As an example If 2-word Anagram is desired, this method would be used  with AnagramWordNumber=2
    private void createMultiAnagram(int AnagramWordNumber){
        for(int i=0;i<AnagramWordNumber;i++){

            String anagramWord=findAnagram();
            
        }
    }
    private bool isAnagram(String targetWord){
        Dictionary<char,int> targetwordAnalysis=wordListDictionary[targetWord];
        foreach(KeyValuePair<char,int> LetterCount in targetwordAnalysis){
            if(!sourceWordAnalysis.ContainsKey(LetterCount.Key)) 
                return false;
            if(LetterCount.Value>this.sourceWordAnalysis[LetterCount.Key]) 
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
    private string findAnagram(){
        string  resultWord=string.Empty;        
        foreach(KeyValuePair<char,int> currentWord in wordListDictionary){
            if(isAnagram(currentWord.Key))
                resultWord=currentWord;
        }
        //Dictionary<char,int> differenceDic=createDifferenceDictionary(currentWord,sourceWordDic);
        //secondWord=findAnagram(differenceDic,wordList);
        //if(secondWord==null ||secondWord.Length==0) continue;                    
        return " ";
    }
    private const string wordListFileName="wordlist.txt";

 
}